import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import * as data from './stockReportData.mjs';
import { C, dropRights, grantOnly, onData } from './stockReportCases.mjs';
import { mustSet } from './settingsEffects.mjs';
import {
  FIELD,
  ROUTE,
  button,
  dmy,
  drill,
  gridOf,
  movementsOf,
  openScreen,
  ready,
  rowNames,
  run,
  setDate,
  totalRow,
} from './stockReportScreen.mjs';

/**
 * Stock Report cases for the open-time behaviour (company metal type, future-dated warning, F3, the View right) and
 * the Enter-opens-help code boxes. Each case puts back what it changed (company row, rights row, the one extra
 * movement), so the cases after it read the worked figures.
 */
const A = data.ITEMS.A;
const S = data.ITEMS.S;
const NO_RIGHTS = 'You Have No Rights.....';

const exec = (ctx, sql, ...params) => data.exec(ctx, sql, ...params);

/** A rights row at the stock-report location: View refused (FRM_VIEW = N) on the Stock Report menu. */
async function refuseView(ctx, user) {
  await dropRights(ctx, user);
  await exec(
    ctx,
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     VALUES($1,'01',$2,$3,'Report','Stock Report','N','N','N','N')`,
    data.LC,
    user,
  );
}
async function grantView(ctx, user) {
  await dropRights(ctx, user);
  await exec(
    ctx,
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     VALUES($1,'01',$2,$3,'Report','Stock Report','Y','N','N','N')`,
    data.LC,
    user,
  );
}
const noRights = (page) => page.getByTestId('stock-no-rights');

/** Type into a code box and press Enter. */
async function enterCode(page, selector, code) {
  await page.locator(selector).fill(code);
  await page.locator(selector).press('Enter');
}
const help = (page) => page.getByTestId('stock-help');
/** Open the screen without touching a field, and wait until its defaults have landed (the form is hydrated and enabled). */
async function openPlain(page) {
  await page.goto(ROUTE);
  await button(page, 'Item').waitFor();
  await ready(page);
}

export const entryCases = [
  C(
    'formula.dimension-item-lot',
    'T03',
    'mutation',
    'RP_STOCK.cs:3701 the Safe button reads Item Lot when ITM_WITH_LOT_STK = Y; :4485 GROUP BY A.ITM_LOT; :3102 the drill-down shows Itm Lot',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const prior = await data.rows(
          ctx,
          `SELECT "ITM_WITH_LOT_STK" v FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        try {
          // The purchase M9 (item A, 4 pcs / 40.000) is the one lot-bearing movement.
          await exec(
            ctx,
            `UPDATE "MAIN_STOCK" SET "ITM_LOT"='ZLOT1' WHERE tenant_id=$1 AND "LC_CODE"='${data.LC}' AND "CO_BOOK"='PR'`,
          );
          await mustSet(page, 'CO_SET_NEW.ITM_WITH_LOT_STK', 'Y');
          await openScreen(page, { itemType: 'G' });
          assert.equal(await button(page, 'Safe').count(), 0, 'the Safe button is renamed');
          await run(page, 'Item Lot');
          assert.deepEqual(await rowNames(page), ['', 'ZLOT1']);
          const lot = await gridOf(page)
            .locator('tbody tr[data-row]', { hasText: 'ZLOT1' })
            .locator('td')
            .allInnerTexts();
          assert.deepEqual(
            lot.slice(2 + 2, 2 + 4),
            ['4', '40.000'],
            'purchase 4 / 40.000 in the lot',
          );
          assert.deepEqual(lot.slice(-2), ['4', '40.000'], 'closing 4 / 40.000 in the lot');
          const m = await drill(page, 'ZLOT1', 'closing-pcs');
          const heads = (await movementsOf(page).locator('thead th').allInnerTexts()).map((t) =>
            t.trim(),
          );
          assert.equal(heads[5], 'Itm Lot');
          assert.equal(m.rows[0][5], 'ZLOT1');
        } finally {
          // The settings row did not exist before the screen saved it: put the tenant back without one.
          if (prior.length === 0)
            await exec(ctx, `DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`);
          else
            await exec(
              ctx,
              `UPDATE "CO_SET_NEW" SET "ITM_WITH_LOT_STK"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
              prior[0].v,
            );
          await exec(
            ctx,
            `UPDATE "MAIN_STOCK" SET "ITM_LOT"=NULL WHERE tenant_id=$1 AND "LC_CODE"='${data.LC}' AND "CO_BOOK"='PR'`,
          );
        }
        return {
          observation:
            'ITM_WITH_LOT_STK Y: the Safe button reads Item Lot, rows are the lots (blank, ZLOT1), the drill-down column is Itm Lot',
          expected: { lots: ['', 'ZLOT1'] },
        };
      }),
  ),
  C(
    'entry.item-type-default-silver',
    'T01',
    'mutation',
    'RP_STOCK.cs:3628-3635 MsMetalType G selects Gold, anything else Silver (MS_OPNCOMP.cs:481 reads CO_MAST.METAL_TYPE)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const [{ v }] = await data.rows(
          ctx,
          `SELECT "METAL_TYPE" v FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        try {
          await exec(
            ctx,
            `UPDATE "CO_MAST" SET "METAL_TYPE"='S' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
          await openPlain(page);
          assert.equal(
            await page.locator(FIELD.type).inputValue(),
            'S',
            'Item Type defaults to Silver',
          );
          await setDate(page, FIELD.from, data.W1[0]);
          await setDate(page, FIELD.to, data.W1[1]);
          await run(page, 'Item');
          assert.deepEqual(await rowNames(page), [S.name], 'only the silver item');
          // Cancel returns to the metal default (CLEAR_DATA, RP_STOCK.cs:3740).
          await page.locator(FIELD.type).selectOption('G');
          await button(page, 'Cancel').click();
          await page.waitForFunction(() => document.querySelector('#sr-ittype')?.value === 'S');
        } finally {
          await exec(
            ctx,
            `UPDATE "CO_MAST" SET "METAL_TYPE"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            v,
          );
        }
        await openPlain(page);
        assert.equal(await page.locator(FIELD.type).inputValue(), 'G', 'back to Gold');
        return {
          observation:
            'company metal type S: Item Type opens as Silver and Item lists only the silver item; Cancel keeps Silver; restored to Gold',
          expected: { itemType: 'S' },
        };
      }),
  ),
  C(
    'entry.future-dated-warning',
    'T01',
    'mutation',
    'RP_STOCK.cs:3713 a movement dated after today warns on open, and To becomes its date',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const later = new Date(Date.now() + 3 * 86_400_000).toISOString().slice(0, 10);
        const [{ name }] = await data.rows(
          ctx,
          `SELECT "BOOK_NAME" name FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='${data.LC}' AND "CO_BOOK"='SL' LIMIT 1`,
        );
        const dialogs = [];
        const onDialog = (d) => dialogs.push(d.message());
        page.on('dialog', onDialog);
        try {
          await exec(
            ctx,
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","IT_CODE","TAG_NO",
               "TBL_CODE","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","KR_FINE","DATA_TYPE")
             VALUES($1,'01','${data.LC}','${data.YEAR}','SL','000045',1,$2::date,'SALES',$3,'N','001','S','-',1,1,1,0.9,0.9,'A')`,
            later,
            A.code,
          );
          await openPlain(page);
          assert.deepEqual(dialogs, [
            `Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = ${name} And VchNo = 000045....`,
          ]);
          assert.equal(
            await page.locator(FIELD.to).inputValue(),
            dmy(later),
            'To is the voucher date',
          );
        } finally {
          await exec(
            ctx,
            `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "LC_CODE"='${data.LC}' AND "CO_BOOK"='SL' AND "VCH_NO"='000045'`,
          );
          page.off('dialog', onDialog);
        }
        dialogs.length = 0;
        page.on('dialog', onDialog);
        await openPlain(page);
        await page.waitForTimeout(300);
        page.off('dialog', onDialog);
        assert.deepEqual(dialogs, [], 'no future row, no message');
        return {
          observation: `the message named Book = ${name} And VchNo = 000045 and To became ${later}; without the row there was no message`,
          expected: { to: later },
        };
      }),
  ),
  C(
    'entry.f3-shortcut',
    'T01',
    'read-only',
    'MDI_FORM.cs:5574 F3 Stock Report; MDI_FORM.cs:13952 no View right answers You Have No Rights.....',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await page.goto('/dashboard');
        await page.locator('nav.sidebar').waitFor();
        await page.keyboard.press('F3');
        await page.getByRole('heading', { name: 'Stock Report', exact: true }).waitFor();
        assert.equal(new URL(page.url()).pathname, ROUTE);
        await button(page, 'Item').waitFor();
        const user = USERS.printViewer.user;
        const viewer = await ctx.session(data.at(user));
        await refuseView(ctx, user);
        try {
          await viewer.page.goto('/dashboard');
          await viewer.page.locator('nav.sidebar').waitFor();
          await viewer.page.keyboard.press('F3');
          await noRights(viewer.page).waitFor();
          assert.equal((await noRights(viewer.page).innerText()).trim(), NO_RIGHTS);
          assert.equal(await button(viewer.page, 'Item').count(), 0, 'the screen does not open');
        } finally {
          await dropRights(ctx, user);
        }
        return {
          observation:
            'F3 opened /reports/stock-report; a user whose View is refused got "You Have No Rights....." and no form',
          expected: { route: ROUTE, refusal: NO_RIGHTS },
        };
      }),
  ),
  C(
    'entry.menu-needs-view-right',
    'T01',
    'refusal',
    'MDI_FORM.cs:7041 AND FRM_VIEW = Y before Report_Form(); the refusal is You Have No Rights.....',
    async (ctx) =>
      onData(ctx, async () => {
        const user = USERS.printViewer.user;
        const viewer = await ctx.session(data.at(user));
        const { page } = viewer;
        try {
          await refuseView(ctx, user);
          await page.goto(ROUTE);
          await noRights(page).waitFor();
          assert.equal((await noRights(page).innerText()).trim(), NO_RIGHTS);
          assert.equal(await button(page, 'Item').count(), 0);
          const refused = await page.request.get('/api/reports/stock-report/defaults');
          assert.equal(refused.status(), 403);
          await page.goto('/dashboard');
          await page.locator('nav.sidebar').waitFor();
          assert.equal(
            await page.locator('nav.sidebar a[href="/reports/stock-report"]').count(),
            0,
            'no menu entry without View',
          );
          await grantView(ctx, user);
          await page.goto(ROUTE);
          await button(page, 'Item').waitFor();
          assert.equal(await noRights(page).count(), 0);
        } finally {
          await dropRights(ctx, user);
        }
        return {
          observation:
            'View refused: the screen shows only "You Have No Rights....." and the API answers 403; View granted: the screen opens',
          expected: { refusal: NO_RIGHTS },
          database: { rights: 'FRM_VIEW N then Y' },
        };
      }),
  ),

  // ---- T04 lookups ---------------------------------------------------------------------------------------------
  C(
    'lookup.code-help-on-enter',
    'T04',
    'read-only',
    'RP_STOCK.cs:5721 tPrCode_KeyDown, :5753 tGrCode, :6145 tItCode, :6179 tDesignNo, :6092 tAcCode: an unknown code opens the help',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        const boxes = [
          ['product', 'ZA', 'Z', 'ZA'],
          ['group', 'ZGA', 'ZG', 'ZGA'],
          ['item', A.code, 'ZRN', A.code],
          ['design', 'D1', 'D', 'D1'],
          ['account', data.SUP.code, 'ZSUP', data.SUP.code],
        ];
        for (const [key, known, unknown, pick] of boxes) {
          const selector = FIELD[key];
          await enterCode(page, selector, known);
          await page.waitForTimeout(250);
          assert.equal(await help(page).count(), 0, `${key}: a known code opens no help`);
          assert.equal(await page.locator(selector).inputValue(), known);
          if (key === 'account') await gridOf(page).waitFor();
          await enterCode(page, selector, unknown);
          await help(page).waitFor();
          await help(page)
            .getByRole('option', { name: new RegExp(`^${pick}\\b`) })
            .first()
            .click();
          assert.equal(
            await page.locator(selector).inputValue(),
            pick,
            `${key}: the chosen code is written back`,
          );
          assert.equal(await help(page).count(), 0);
          await page.locator(selector).fill('');
        }
        return {
          observation:
            'Pr, Gr, It, Design and Ac boxes: a known code stays (Ac runs Item); an unknown one opens the help and the chosen code is written back',
          expected: { boxes: boxes.map(([k]) => k) },
        };
      }),
  ),
  C(
    'lookup.stale-and-cancel',
    'T04',
    'read-only',
    'MS_HELP: Esc leaves the box unchanged (HelpClose); a late answer never replaces a later one',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: A.code } });
        await run(page);
        const before = await gridOf(page).locator('tbody tr').count();
        // The first lookup answers late; the operator types again before it arrives.
        await page.route('**/api/lookup/products?q=ZQA*', async (route) => {
          await new Promise((resolve) => setTimeout(resolve, 1200));
          await route.continue();
        });
        const box = page.locator(FIELD.product);
        await box.fill('ZQA');
        await box.press('Enter');
        await box.fill('ZA');
        await page.waitForTimeout(1800);
        assert.equal(await help(page).count(), 0, 'the late answer opened nothing');
        assert.equal(await box.inputValue(), 'ZA');
        await page.unroute('**/api/lookup/products?q=ZQA*');
        await enterCode(page, FIELD.product, 'ZQQ');
        await help(page).waitFor();
        await page.keyboard.press('Escape');
        await help(page).waitFor({ state: 'detached' });
        assert.equal(await box.inputValue(), 'ZQQ', 'Esc leaves the box as typed');
        assert.equal(
          await gridOf(page).locator('tbody tr').count(),
          before,
          'the grid is untouched',
        );
        return {
          observation:
            'a delayed first answer opened no list after the next keystroke; Esc closed the help, the box and the grid stayed',
          expected: { box: 'ZQQ' },
        };
      }),
  ),
];

// ---- T17 keyboard -----------------------------------------------------------------------------------------------
const inGrid = (page) =>
  page.evaluate(() => Boolean(document.activeElement?.closest('[data-testid="stock-grid"]')));

export const keyboardCases = [
  C(
    'invalid.print-without-right',
    'T06',
    'refusal',
    'RP_STOCK.cs:4024 and :3237 You Have No Print Rights.....; the API answers 403',
    async (ctx) =>
      onData(ctx, async () => {
        const user = USERS.printViewer.user;
        const viewer = await ctx.session(data.at(user));
        try {
          await grantOnly(ctx, user, 'Stock Report', 'N');
          await openScreen(viewer.page, { filters: { item: A.code } });
          await run(viewer.page);
          await button(viewer.page, 'Print').click();
          const message = viewer.page.locator('[data-testid="stock-message"]');
          await message.waitFor();
          assert.equal(
            ((await message.textContent()) ?? '').trim(),
            'You Have No Print Rights.....',
          );
          await button(viewer.page, 'Excel').click();
          assert.equal(
            ((await message.textContent()) ?? '').trim(),
            'You Have No Print Rights.....',
          );
          const refused = viewer.requests.filter((r) =>
            r.path.startsWith('/api/reports/stock-report/export'),
          );
          assert.ok(
            refused.length >= 1 && refused.every((r) => r.status === 403),
            JSON.stringify(refused),
          );
        } finally {
          await dropRights(ctx, user);
        }
        return {
          observation: 'Print and Excel show the desktop refusal; export calls answered 403',
          expected: { message: 'You Have No Print Rights.....' },
          database: { unchanged: true },
        };
      }),
  ),
  C(
    'scope.list-right',
    'T11',
    'refusal',
    'RP_STOCK.cs:3392-3394 reads FRM_EDIT, FRM_DELETE and FRM_PRINT; only the menu View (MDI_FORM.cs:7041) and Print (:3235, :4022) are enforced',
    async (ctx) =>
      onData(ctx, async () => {
        const user = USERS.printViewer.user;
        const viewer = await ctx.session(data.at(user));
        const { page } = viewer;
        const query = `fromDate=${data.W1[0]}&toDate=${data.W1[1]}&dimension=item`;
        const refusals = [];
        try {
          await refuseView(ctx, user);
          for (const url of [
            `/api/reports/stock-report?${query}`,
            `/api/reports/stock-report/movements?${query}&key=${data.ITEMS.A.code}&rowType=G&column=closing`,
            `/api/reports/stock-report/export.csv?${query}`,
          ]) {
            const response = await page.request.get(url);
            assert.equal(response.status(), 403, url);
            refusals.push(response.status());
          }
          await grantView(ctx, user);
          const ok = await page.request.get(`/api/reports/stock-report?${query}`);
          assert.equal(ok.status(), 200);
          await openScreen(page, { filters: { item: data.ITEMS.A.code } });
          await run(page);
          // Only View, Print and the exports exist on the screen: no Add, Edit, Delete or Save control.
          for (const name of ['Add', 'Edit', 'Delete', 'Save', 'New'])
            assert.equal(await button(page, name).count(), 0, `no ${name} control`);
        } finally {
          await dropRights(ctx, user);
        }
        return {
          observation: `View refused: the rows, the drill-down and the export answered ${refusals.join(', ')}; restored: 200 and a screen with no Add, Edit, Delete or Save`,
          expected: { refusals: [403, 403, 403] },
          database: { rights: 'FRM_VIEW N then Y' },
        };
      }),
  ),
  C(
    'invalid.bad-date-text',
    'T06',
    'refusal',
    'RP_STOCK.cs:5177-5192 mFromDt_KeyDown runs DC_Main.SetDate: an impossible date is refused with its message and the box keeps the focus',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await page.goto(ROUTE);
        await ready(page);
        const from = page.locator(FIELD.from);
        await from.fill('31/02/2026');
        await from.press('Enter');
        const box = page.getByRole('alertdialog', { name: 'Date Not Valid...' });
        await box.waitFor();
        await box.getByRole('button', { name: 'OK', exact: true }).click();
        assert.equal(
          await from.inputValue(),
          '__/__/____',
          'the impossible date is cleared to the mask',
        );
        assert.equal(
          await page.evaluate(() => document.activeElement?.id),
          'sr-from',
          'the focus stays in From',
        );
        await from.fill('01/04/2026');
        await from.press('Enter');
        assert.equal(
          await page.evaluate(() => document.activeElement?.id),
          'sr-to',
          'a valid date moves on',
        );
        assert.equal(await from.inputValue(), '01/04/2026');
        return {
          observation:
            '31/02/2026 answered "Date Not Valid...", cleared the box and kept the focus; 01/04/2026 moved to To',
          expected: { message: 'Date Not Valid...' },
          database: { unchanged: true },
        };
      }),
  ),
  C(
    'keyboard.arrows-and-escape',
    'T17',
    'read-only',
    'RP_STOCK.cs:4009 Up or Down moves focus to the grid; :4006 Esc with the summary showing closes the screen',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await page.goto('/dashboard');
        await page.locator('nav.sidebar').waitFor();
        await openScreen(page, { filters: { item: A.code } });
        await run(page);
        for (const key of ['ArrowUp', 'ArrowDown']) {
          await page.locator(FIELD.search).focus();
          await page.keyboard.press(key);
          assert.equal(await inGrid(page), true, `${key} from the search box focuses the grid`);
        }
        await page.keyboard.press('Escape');
        await page.waitForURL((url) => url.pathname === '/dashboard');
        return {
          observation:
            'Up and Down from the search box focused a grid cell; Esc on the summary closed the screen',
          expected: { after: '/dashboard' },
        };
      }),
  ),
  C(
    'keyboard.full-run-without-mouse',
    'T17',
    'read-only',
    'RP_STOCK.cs:5177-5192 Enter in a date validates and moves on; I runs Item; Enter on a cell drills; Esc back; Esc exit',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const seen = [];
        for (const [width, height] of [
          [1280, 720],
          [390, 800],
        ]) {
          await page.setViewportSize({ width, height });
          await page.goto('/dashboard');
          await page.locator('nav.sidebar').waitFor({ state: 'attached' });
          await page.goto(ROUTE);
          await button(page, 'Item').waitFor();
          await ready(page);
          await page.locator(FIELD.from).focus();
          await setDate(page, FIELD.from, data.W1[0]);
          await page.keyboard.press('Enter');
          assert.equal(
            await page.evaluate(() => document.activeElement?.id),
            'sr-to',
            'Enter in From moves to To',
          );
          await setDate(page, FIELD.to, data.W1[1]);
          await page.keyboard.press('Enter');
          assert.equal(await page.evaluate(() => document.activeElement?.id), 'sr-search');
          await page.keyboard.press('Tab');
          assert.equal(await page.evaluate(() => document.activeElement?.id), 'sr-ittype');
          await page.locator(FIELD.type).selectOption('');
          await page.evaluate(() => document.activeElement?.blur());
          await page.keyboard.press('i');
          await gridOf(page).waitFor();
          const focusOutline = await page.locator(FIELD.search).evaluate((el) => {
            el.focus();
            const style = getComputedStyle(el);
            return style.outlineStyle !== 'none' || style.boxShadow !== 'none';
          });
          assert.equal(focusOutline, true, 'focus is visible');
          await page.keyboard.press('ArrowDown');
          assert.equal(await inGrid(page), true);
          await page.keyboard.press('Enter');
          await movementsOf(page).waitFor();
          await page.keyboard.press('Escape');
          await gridOf(page).waitFor();
          await totalRow(page).scrollIntoViewIfNeeded();
          assert.equal(await totalRow(page).isVisible(), true, 'the Total row can be reached');
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => url.pathname === '/dashboard');
          seen.push(`${width}x${height}`);
        }
        await page.setViewportSize({ width: 1280, height: 720 });
        return {
          observation: `keyboard-only run (dates, search, Item Type, I, grid, drill, Esc, Esc) at ${seen.join(' and ')}`,
          expected: { sizes: seen },
        };
      }),
  ),
];
