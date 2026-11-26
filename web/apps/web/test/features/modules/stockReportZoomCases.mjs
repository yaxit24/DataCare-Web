import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import * as data from './stockReportData.mjs';
import { C, dropRights, onData } from './stockReportCases.mjs';
import { M, button, drill, gridOf, movementsOf, openScreen, run } from './stockReportScreen.mjs';

/**
 * Voucher zoom (RP_STOCK.cs:5218-5600): a double click on a movement row opens the entry screen of the row's book
 * on that voucher. The cases click real rows of the worked data set and read the entry screen that opens.
 */
const A = data.ITEMS.A;
const T = data.TAG;
const NO_RIGHTS = 'You Have No Rights...';

/** [label, summary column, row test, route, the text the opened screen shows for the voucher] */
const TARGETS = [
  [
    'Tag Opening',
    'opening-pcs',
    (r) => r[M.tag] === T.T1,
    '/txn/tag-opening',
    (v) => `Loaded #${v}`,
  ],
  [
    'Purchase',
    'purchase-pcs',
    (r) => r[M.party] === data.SUP.name,
    '/txn/purchase',
    (v) => `Loaded #${v}`,
  ],
  ['Sales', 'sale-wt', (r) => r[M.tag] === T.T1, '/txn/sales', (v) => `Loaded #${v}`],
  [
    'Sales Return',
    'inward-pcs',
    (r) => r[M.tag] === T.T1,
    '/txn/sale-return',
    (v) => `Editing return #${Number(v)}`,
  ],
  [
    'Purchase Return',
    'outward-pcs',
    (r) => r[M.party] === data.SUP.name,
    '/txn/purchase-return',
    (v) => `Loaded #${v}`,
  ],
  [
    'Stock Adjust',
    'inward-pcs',
    (r) => r[M.tag] === 'N' && r[M.party] === '',
    '/txn/stock-adjust',
    () => /^Loaded voucher /,
  ],
  [
    'Tag Cancel',
    'outward-pcs',
    (r) => r[M.tag] === T.T2,
    '/txn/tag-cancel',
    () => /^Loaded voucher /,
  ],
  [
    'Approval Issue',
    'outward-pcs',
    (r) => r[M.tag] === T.T3,
    '/txn/tour',
    () => /^Loaded voucher /,
  ],
];

/** Open the report for item A, drill into `column`, double click the row `test` picks; returns the row's cells. */
async function zoomRow(page, column, test) {
  await openScreen(page, { filters: { item: A.code } });
  await run(page);
  const m = await drill(page, A.name, column);
  const at = m.rows.findIndex(test);
  assert.ok(at >= 0, `no movement row matched in ${JSON.stringify(m.rows)}`);
  await movementsOf(page).locator('tbody tr:not([data-total])').nth(at).dblclick();
  return m.rows[at];
}
const rightsRow = (ctx, user, main, sub, view) =>
  data.exec(
    ctx,
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     VALUES($1,'01',$2,$3,$4,$5,$6,'N','N','N')`,
    data.LC,
    user,
    main,
    sub,
    view,
  );

export const zoomCases = [
  C(
    'zoom.lite-voucher-targets',
    'T05',
    'read-only',
    'RP_STOCK.cs:5265-5423: each book opens its own entry screen on that voucher',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const opened = [];
        for (const [label, column, test, route, shows] of TARGETS) {
          const row = await zoomRow(page, column, test);
          const vch = row[M.vch];
          try {
            await page.waitForURL((url) => url.pathname === route, { timeout: 15_000 });
            await page.getByText(shows(vch)).first().waitFor({ timeout: 15_000 });
          } catch (error) {
            const note = await page
              .getByTestId('stock-message')
              .innerText({ timeout: 500 })
              .catch(() => '');
            throw new Error(
              `${label} (voucher ${vch}): stayed on ${new URL(page.url()).pathname}${note ? ` with "${note}"` : ''}: ${String(error).split('\n')[0]}`,
            );
          }
          opened.push(`${label} ${vch}`);
        }
        return {
          observation: `double click opened: ${opened.join('; ')}`,
          expected: { screens: TARGETS.map(([label, , , route]) => `${label} ${route}`) },
        };
      }),
  ),
  C(
    'zoom.item-opening-refused',
    'T05',
    'refusal',
    'RP_STOCK.cs:5263 a voucher number shorter than 3 characters is an Item Opening row',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: A.code } });
        await run(page);
        const m = await drill(page, A.name, 'opening-pcs');
        const at = m.rows.findIndex((r) => r[M.vch].length < 3);
        assert.ok(at >= 0, 'the Item Opening row (M1) is in Opening');
        await movementsOf(page).locator('tbody tr:not([data-total])').nth(at).dblclick();
        await page.getByTestId('stock-message').waitFor();
        assert.equal(
          (await page.getByTestId('stock-message').innerText()).trim(),
          'This Is a Item Wise Opening Stock Voucher You Cant Zoom ....',
        );
        assert.equal(new URL(page.url()).pathname, '/reports/stock-report', 'nothing opened');
        assert.equal(await movementsOf(page).count(), 1, 'the movement grid stays');
        return {
          observation:
            'the Item Opening row (voucher G) answered the desktop text and opened nothing',
          expected: { message: 'This Is a Item Wise Opening Stock Voucher You Cant Zoom ....' },
          database: { unchanged: true },
        };
      }),
  ),
  C(
    'zoom.screen-with-two-books',
    'T05',
    'read-only',
    'RP_STOCK.cs:5240-5600: the zoom names the voucher\'s book (CurBook); a screen that has two books of the family still opens that voucher',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const stockAdjust = TARGETS[5];
        // A second STOCK ADJUST book in this location: the screen has two books and no single default.
        await data.exec(
          ctx,
          `INSERT INTO "BOOK_DATA" SELECT (jsonb_populate_record(NULL::"BOOK_DATA", (to_jsonb(b) - 'row_id') || jsonb_build_object('row_id', (SELECT COALESCE(MAX(row_id),0)+1 FROM "BOOK_DATA"), 'CO_BOOK', 'SJ2', 'BOOK_SNAME', 'SJ2'))).*
             FROM "BOOK_DATA" b WHERE b.tenant_id=$1 AND b."CO_CODE"='01' AND b."LC_CODE"=$2 AND b."CO_BOOK"='SAJ'`,
          data.LC,
        );
        try {
          const row = await zoomRow(page, stockAdjust[1], stockAdjust[2]);
          await page.waitForURL((url) => url.pathname === stockAdjust[3], { timeout: 15_000 });
          await page.getByText(stockAdjust[4](row[M.vch])).first().waitFor({ timeout: 15_000 });
          const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
          assert.equal(await book.inputValue(), 'SAJ', 'the voucher\'s own book is selected');
          assert.equal(await book.locator('option[value]:not([value=""])').count(), 2);
        } finally {
          await data.exec(
            ctx,
            `DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$2 AND "CO_BOOK"='SJ2'`,
            data.LC,
          );
        }
        return {
          observation: 'with two Stock Adjust books the zoom still loaded the voucher in book SAJ',
          expected: { book: 'SAJ' },
        };
      }),
  ),
  C(
    'zoom.tag-gen-opens-only-tag-entry',
    'T05',
    'read-only',
    'RP_STOCK.cs:5272: a TAG GEN voucher opens TR_TAG_OPBL, which the web shows as Only Tag Entry (?mode=TAG GEN)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        // The report's answer for a TAG GEN row (the API case in stockReport.db.test.ts proves the server side); the
        // browser must carry the mode into the address.
        await page.route('**/api/reports/stock-report/zoom*', (route) =>
          route.fulfill({
            json: {
              action: 'open',
              path: '/txn/tag-opening',
              vchNo: 'T10',
              coBook: 'TGN',
              coYear: data.YEAR,
              lcCode: data.LC,
              mode: 'TAG GEN',
            },
          }),
        );
        try {
          await zoomRow(page, 'opening-pcs', (r) => r[M.tag] === T.T1);
          await page.waitForURL((url) => url.pathname === '/txn/tag-opening', { timeout: 15_000 });
          assert.equal(new URL(page.url()).searchParams.get('mode'), 'TAG GEN');
          await page.getByRole('heading', { name: /^Only Tag Entry/ }).waitFor({ timeout: 15_000 });
        } finally {
          await page.unroute('**/api/reports/stock-report/zoom*');
        }
        return {
          observation: 'the zoom address carried mode=TAG GEN and Tag Opening showed Only Tag Entry',
          expected: { mode: 'TAG GEN' },
        };
      }),
  ),
  C(
    'zoom.needs-target-read-right',
    'T05',
    'refusal',
    'RP_STOCK.cs:5245 the target menu needs View; the hosted service also refuses a missing rights row (decision 5)',
    async (ctx) =>
      onData(ctx, async () => {
        const user = USERS.printViewer.user;
        const viewer = await ctx.session(data.at(user));
        const { page } = viewer;
        const sales = TARGETS[2];
        try {
          await dropRights(ctx, user);
          await rightsRow(ctx, user, 'Report', 'Stock Report', 'Y');
          await rightsRow(ctx, user, 'Sales', 'Sales Invoice', 'N');
          await zoomRow(page, sales[1], sales[2]);
          await page.getByTestId('stock-message').waitFor();
          assert.equal((await page.getByTestId('stock-message').innerText()).trim(), NO_RIGHTS);
          assert.equal(new URL(page.url()).pathname, '/reports/stock-report');
          assert.equal(await movementsOf(page).count(), 1, 'stays on the movement grid');
          // No rights row for Sales at all: the hosted service refuses with the same text.
          await dropRights(ctx, user);
          await rightsRow(ctx, user, 'Report', 'Stock Report', 'Y');
          await zoomRow(page, sales[1], sales[2]);
          await page.getByTestId('stock-message').waitFor();
          assert.equal((await page.getByTestId('stock-message').innerText()).trim(), NO_RIGHTS);
          // View granted: the voucher opens.
          await dropRights(ctx, user);
          await rightsRow(ctx, user, 'Report', 'Stock Report', 'Y');
          await rightsRow(ctx, user, 'Sales', 'Sales Invoice', 'Y');
          const row = await zoomRow(page, sales[1], sales[2]);
          await page.waitForURL((url) => url.pathname === sales[3]);
          await page.getByText(sales[4](row[M.vch])).first().waitFor({ timeout: 15_000 });
        } finally {
          await dropRights(ctx, user);
        }
        return {
          observation:
            'Sales View N and no Sales row both answered "You Have No Rights..." on the movement grid; View Y opened the sales voucher',
          expected: { message: NO_RIGHTS },
          database: { rights: 'Sales Invoice N, none, then Y' },
        };
      }),
  ),
];

// ---- InOut: the item picker and the item ledger print (RP_STOCK.cs:5857-5976) ---------------------------------
const picker = (page) => page.getByTestId('stock-item-picker');

export const inOutCases = [
  C(
    'invalid.item-picker-nothing-ticked',
    'T06',
    'refusal',
    'RP_STOCK.cs:5942 Ok with no item ticked answers "Item Selection Not Done..." and prints nothing',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { itemType: 'G' });
        const requests = [];
        page.on('request', (r) => requests.push(r.url()));
        await button(page, 'InOut').click();
        await picker(page).waitFor();
        await picker(page).getByRole('button', { name: 'Ok', exact: true }).click();
        await page.getByTestId('stock-message').waitFor();
        assert.equal(
          (await page.getByTestId('stock-message').innerText()).trim(),
          'Item Selection Not Done...',
        );
        await picker(page).waitFor({ state: 'detached' });
        await page.waitForTimeout(300);
        assert.equal(
          requests.some((u) => /item-ledger\.pdf/.test(u)),
          false,
          'no print started',
        );
        return {
          observation:
            'Ok with nothing ticked: "Item Selection Not Done...", the picker closed, no ledger request',
          expected: { message: 'Item Selection Not Done...' },
          database: { unchanged: true },
        };
      }),
  ),
  C(
    'output.item-ledger-print',
    'T16',
    'output',
    'RP_STOCK.cs:5879 the picker lists the items of the Item Type; :5958 the ledger covers the ticked items up to To',
    async (ctx) =>
      onData(ctx, async () => {
        const { page, context } = await ctx.session();
        await openScreen(page, { itemType: 'G' });
        await button(page, 'InOut').click();
        await picker(page).waitFor();
        const codes = await picker(page)
          .locator('tbody tr[data-it]')
          .evaluateAll((rows) => rows.map((r) => r.getAttribute('data-it')));
        assert.ok(
          codes.includes(A.code) && codes.includes(data.ITEMS.B.code),
          `gold items listed: ${codes}`,
        );
        assert.equal(
          codes.includes(data.ITEMS.S.code),
          false,
          'the silver item is not listed for Gold',
        );
        await picker(page).locator(`tr[data-it="${A.code}"] input[type="checkbox"]`).check();
        const documentRequest = context.waitForEvent(
          'request',
          (r) => /item-ledger\.pdf/.test(r.url()),
          { timeout: 15_000 },
        );
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          picker(page).getByRole('button', { name: 'Ok', exact: true }).click(),
        ]);
        const url = (await documentRequest).url();
        assert.match(url, new RegExp(`items=${A.code}&`), 'only the ticked item is sent');
        const pdf = await page.request.get(url);
        assert.equal(pdf.status(), 200, await pdf.text());
        assert.match(pdf.headers()['content-type'] ?? '', /pdf/);
        assert.equal((await pdf.body()).subarray(0, 4).toString(), '%PDF');
        await popup.close();
        const json = await (
          await page.request.get(url.replace('item-ledger.pdf', 'item-ledger'))
        ).json();
        assert.deepEqual(
          json.items.map((i) => i.code),
          [A.code],
          'items not ticked are absent',
        );
        assert.deepEqual([json.items[0].closingPcs, json.items[0].closingNetWt], [14, 138]);
        assert.equal(
          json.title,
          `Stock Ledger Report From ${data.W1[0].split('-').reverse().join('/')} To ${data.W1[1].split('-').reverse().join('/')}`,
        );
        // Silver lists only the silver item.
        await page.locator('#sr-ittype').selectOption('S');
        await button(page, 'InOut').click();
        await picker(page).waitFor();
        const silver = await picker(page)
          .locator('tbody tr[data-it]')
          .evaluateAll((rows) => rows.map((r) => r.getAttribute('data-it')));
        assert.ok(silver.includes(data.ITEMS.S.code) && !silver.includes(A.code));
        return {
          observation: `ledger of ${A.code}: closing 14 / 138.000 at ${data.W1[1]}; PDF ${pdf.headers()['content-type']}; silver list ${silver.length} item(s)`,
          expected: { closing: '14 / 138.000' },
          output: await pdf.body(),
        };
      }),
  ),
];

// ---- Print (RP_STOCK.cs:4020-4240): the document is built from the query on screen --------------------------------
const csvRows = (text) =>
  text
    .trim()
    .split(/\r?\n/)
    .map((l) => l.split(','));
/** Press Print and return the document's URL (the request the new tab made) and its response. */
async function pressPrint(page) {
  const request = page
    .context()
    .waitForEvent('request', (r) => /export\.pdf/.test(r.url()), { timeout: 15_000 });
  const [popup] = await Promise.all([page.waitForEvent('popup'), button(page, 'Print').click()]);
  const url = (await request).url();
  const response = await page.request.get(url);
  await popup.close();
  return { url, response };
}

export const printCases = [
  C(
    'output.group-print',
    'T16',
    'output',
    'RP_STOCK.cs:4032 GroupStkRpt; :4224 the title "Group Wise Stock From Date  dd/MM/yyyy To dd/MM/yyyy"',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page, 'Group');
        const printed = await pressPrint(page);
        assert.equal(printed.response.status(), 200, await printed.response.text());
        assert.match(printed.response.headers()['content-type'] ?? '', /pdf/);
        const pdf = await printed.response.body();
        assert.equal(pdf.subarray(0, 4).toString(), '%PDF');
        const query = new URL(printed.url).searchParams;
        assert.equal(query.get('dimension'), 'group');
        const title = `Group Wise Stock From Date  ${data.W1[0].split('-').reverse().join('/')} To ${data.W1[1].split('-').reverse().join('/')}`;
        const summaryUrl = new URL(printed.url);
        summaryUrl.pathname = '/api/reports/stock-report';
        const json = await (await page.request.get(summaryUrl.toString())).json();
        assert.equal(
          json.title,
          title,
          'the printed title is the desktop one (two spaces after Date)',
        );
        const csv = csvRows(
          await (await page.request.get(printed.url.replace('export.pdf', 'export.csv'))).text(),
        );
        const gold = csv.find((r) => r[1] === 'ZR GOLD ORNAMENTS');
        const silver = csv.find((r) => r[1] === 'ZR SILVER ARTICLES');
        assert.deepEqual(
          [gold[3], gold[4], gold[13], gold[14]],
          ['18', '176.000', '20', '208.000'],
        );
        assert.deepEqual(
          [silver[3], silver[4], silver[13], silver[14]],
          ['100', '950.000', '110', '1045.000'],
        );
        assert.deepEqual([csv.at(-1)[13], csv.at(-1)[14]], ['130', '1253.000'], 'grand closing');
        return {
          observation: `${title}: GOLD ORNAMENTS 18 / 176.000 -> 20 / 208.000, SILVER ARTICLES 100 / 950.000 -> 110 / 1045.000, grand 130 / 1253.000; PDF ${pdf.length} bytes`,
          expected: { title, grand: '130 / 1253.000' },
          output: pdf,
        };
      }),
  ),
  C(
    'output.print-uses-screen-filters',
    'T16',
    'output',
    'RP_STOCK.cs:4125 the desktop formula omits tag, item, design, account and the gross box; the web prints what the screen shows',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { itemType: 'G', filters: { tag: data.TAG.T1 } });
        await run(page, 'Group');
        const net = await pressPrint(page);
        assert.equal(new URL(net.url).searchParams.get('tagNo'), data.TAG.T1);
        assert.equal(new URL(net.url).searchParams.get('weight'), 'net');
        assert.equal(net.response.status(), 200);
        const netCsv = csvRows(
          await (await page.request.get(net.url.replace('export.pdf', 'export.csv'))).text(),
        );
        const gold = netCsv.find((r) => r[1] === 'ZR GOLD ORNAMENTS');
        assert.deepEqual(
          [gold[3], gold[4], gold[7], gold[8], gold[11], gold[12], gold[13], gold[14]],
          ['1', '12.000', '1', '12.000', '1', '12.000', '1', '12.000'],
        );
        assert.equal(
          netCsv.filter((r) => r[1] === 'ZR GOLD ORNAMENTS').length,
          1,
          'only tag T1 is printed',
        );
        await page.getByLabel('Gross Wise Weight').check();
        await run(page, 'Group');
        const gross = await pressPrint(page);
        assert.equal(new URL(gross.url).searchParams.get('weight'), 'gross');
        const grossCsv = csvRows(
          await (await page.request.get(gross.url.replace('export.pdf', 'export.csv'))).text(),
        );
        const g = grossCsv.find((r) => r[1] === 'ZR GOLD ORNAMENTS');
        assert.deepEqual([g[4], g[8], g[12], g[14]], ['12.500', '12.500', '12.500', '12.500']);
        return {
          observation:
            'Group, tag ZT1: the print query carries the tag and the weight; net 12.000 in every weight column, gross 12.500',
          expected: { net: '12.000', gross: '12.500' },
          output: await gross.response.body(),
        };
      }),
  ),
];
export { gridOf };
