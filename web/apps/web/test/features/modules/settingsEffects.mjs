import assert from 'node:assert/strict';
import { tenantFingerprint, withWriteFault } from '../faults.mjs';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import { salesScreen as S } from './salesInvoice.mjs';

/**
 * Feature: Company Settings (desktop UT_SETTING / UT_SETTING_MAIN / UT_SET_ADMIN) and their effect on the screens
 * that read them. Each consumer case changes one setting through the Settings screen, makes a sale through the Sales
 * screen, compares the result with the desktop rule, and restores the setting.
 */

const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

/** Set one setting through the Settings screen: find its tab, change the control, save. */
async function setSetting(page, id, value) {
  await page.goto('/settings');
  await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
  await editSetting(page, id, value);
  return saveSettingsScreen(page);
}

async function editSetting(page, id, value) {
  const control = page.locator(`[id="${id}"]`);
  const tabs = page.getByRole('tab');
  const n = await tabs.count();
  for (let i = 0; i < n && !(await control.count()); i++) await tabs.nth(i).click();
  assert(await control.count(), `setting ${id} is not on any Settings tab`);
  if ((await control.evaluate((el) => el.tagName)) === 'SELECT') await control.selectOption(value);
  else await control.fill(value);
}

async function saveSettingsScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => new URL(r.url()).pathname === '/api/settings' && r.request().method() === 'POST',
    ),
    page.getByRole('button', { name: /^Save \d+ change\(s\)$/ }).click(),
  ]);
  return response;
}
export async function mustSet(page, id, value) {
  const response = await setSetting(page, id, value);
  assert.equal(response.status(), 200, `saving ${id}=${value}: ${await response.text()}`);
  await page
    .locator('.msg.ok')
    .filter({ hasText: /^Saved \d+ setting/ })
    .waitFor();
}
const stored = async (ctx, table, key) =>
  (
    await ctx.rows(`SELECT "${key}"::text v FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01'`)
  )[0]?.v ?? null;

/** Make a sale through the screen; returns the response and the voucher number (or null when refused). */
async function sell(page, { party = PARTIES.local.code, line = S.LINE_A, cash } = {}) {
  await S.openSales(page);
  await S.pickParty(page, party);
  await S.fillLine(page, 0, line);
  if (cash) await S.field(page, 'Cash ₹').fill(cash);
  const response = await S.save(page);
  const body = await response.json().catch(() => ({}));
  return {
    response,
    body,
    vchNo: response.status() === 201 ? String(body.vchNo).padStart(5, '0') : null,
  };
}
const salesCount = async (ctx) =>
  (await ctx.rows(`SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL'`))[0]
    .n;

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `settings.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : ['browser', 'expected'],
  run,
  ...extra,
});
const NA = (id, group, reason) => ({
  id: `settings.${id}`,
  group,
  kind: 'read-only',
  source: reason,
  applicable: false,
  reason,
  requiredEvidence: ['browser', 'expected'],
  run: async () => ({}),
});

export const settingsEffects = {
  feature: 'settings',
  title: 'Company Settings and their effect on a sale (UT_SETTING)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/test/features/faults.mjs',
    'web/apps/web/app/(app)/settings/page.tsx',
    'web/apps/api/src/modules/settings/settingsCatalog.ts',
    'web/apps/api/src/modules/shared/settingsBehavior.ts',
    'web/apps/api/src/modules/sales/sales.ts',
    'web/apps/web/test/features/modules/settingsEffects.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { restoredAfterEachCase: true },
  cases: [
    C(
      'entry.all-settings',
      'T01',
      'read-only',
      'UT_SETTING/UT_SETTING_MAIN/UT_SET_ADMIN: every CO_SET and CO_SET_NEW setting is on a tab',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/settings');
        await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
        const intro = await page.locator('p.muted').first().innerText();
        const total = Number(intro.match(/All (\d+) settings/)?.[1] ?? 0);
        const tabs = await page.getByRole('tab').allInnerTexts();
        const onTabs = tabs.reduce((s, t) => s + Number(t.match(/\((\d+)\)/)?.[1] ?? 0), 0);
        assert(total > 100, `settings listed: ${total}`);
        assert.equal(onTabs, total, 'every setting appears on exactly one tab');
        await ctx.shot(page, 'settings');
        return {
          observation: `${total} settings on ${tabs.length} tabs: ${tabs.join(', ')}`,
          expected: 'every setting on a tab',
        };
      },
    ),

    C(
      'field.route-and-reload',
      'T02',
      'mutation',
      'A changed setting is stored in its table and shown again after reload',
      async (ctx) => {
        const { page } = await ctx.session();
        await mustSet(page, 'CO_SET_NEW.TOT_AMT_ROF', '1');
        const value = await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF');
        await page.reload();
        await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
        const tabs = page.getByRole('tab');
        for (
          let i = 0;
          i < (await tabs.count()) &&
          !(await page.locator('[id="CO_SET_NEW.TOT_AMT_ROF"]').count());
          i++
        )
          await tabs.nth(i).click();
        const shown = await page.locator('[id="CO_SET_NEW.TOT_AMT_ROF"]').inputValue();
        await mustSet(page, 'CO_SET_NEW.TOT_AMT_ROF', '');
        assert.equal(String(value).trim(), '1');
        assert.equal(shown, '1');
        return {
          observation: `stored ${value}, shown ${shown} after reload; restored blank`,
          expected: '1 stored and shown',
          database: { TOT_AMT_ROF: value },
          downstream: { shown },
        };
      },
    ),

    C(
      'refusal.invalid-cash-limit',
      'T06',
      'refusal',
      'CASH_LIMIT is an amount: a non-number must be refused, not stored to break every later sale',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await stored(ctx, 'CO_SET', 'CASH_LIMIT');
        const response = await setSetting(page, 'CO_SET.CASH_LIMIT', 'abc');
        const after = await stored(ctx, 'CO_SET', 'CASH_LIMIT');
        const refused = response.status() >= 400 && response.status() < 500;
        let saleAfter = null;
        if (!refused) {
          // Accepted: does every later sale still work?
          const { response: sale } = await sell(page);
          saleAfter = sale.status();
          await mustSet(page, 'CO_SET.CASH_LIMIT', '');
        }
        assert(
          refused,
          `CASH_LIMIT='abc' answered ${response.status()} and stored ${after}; a sale afterwards answered ${saleAfter}`,
        );
        assert.equal(after, before, 'nothing stored');
        return {
          observation: `refused ${response.status()}; stored value unchanged (${after})`,
          expected: '4xx + unchanged',
          database: { before, after },
        };
      },
      {
        expected: { refused: true },
        observe: async (ctx) => ({ CASH_LIMIT: await stored(ctx, 'CO_SET', 'CASH_LIMIT') }),
      },
    ),

    C(
      'effect.sale-amount-fine',
      'T15',
      'mutation',
      'SL_AMT_TYPE=F (TR_SALE.cs CommPassTotal): a new line is priced on fine — Math.Round(9.160 × 6,123.45 = 56,090.80, 0) = 56,091 (whole-rupee line, TR_SALE.cs:10343-10362) + making 2,375 = 58,466, RATE_WITH F',
      async (ctx) => {
        const { page } = await ctx.session();
        await mustSet(page, 'CO_SET.SL_AMT_TYPE', 'F');
        try {
          const { response, vchNo } = await sell(page);
          assert.equal(response.status(), 201, await response.text());
          const [l] = await ctx.rows(
            `SELECT "ITM_AMT"::float amt,"NET_AMT"::float net,"RATE_WITH" rw FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
            vchNo,
          );
          assert.deepEqual([l.amt, l.net, l.rw], [56091, 58466, 'F']);
          return {
            observation: `voucher ${vchNo}: ITM_AMT ${l.amt}, NET_AMT ${l.net}, RATE_WITH ${l.rw}`,
            expected: { metal: 56091, net: 58466, rateWith: 'F' },
            database: { line: l },
            downstream: { rateWith: l.rw },
          };
        } finally {
          await mustSet(page, 'CO_SET.SL_AMT_TYPE', 'N');
        }
      },
    ),

    C(
      'effect.negative-stock-refused',
      'T15',
      'refusal',
      'NEGATIVE_STK_SALE=N (TR_SALE.cs:10398 "Negative Stock is Not Allow"): a sale beyond loose stock is refused; within stock it saves',
      async (ctx) => {
        const { page } = await ctx.session();
        await mustSet(page, 'CO_SET_NEW.NEGATIVE_STK_SALE', 'N');
        try {
          const before = await salesCount(ctx);
          const huge = { ...S.LINE_A, gross: '99999', net: '99999' };
          const { response } = await sell(page, { line: huge });
          assert(
            response.status() >= 400 && response.status() < 500,
            `oversell answered ${response.status()}`,
          );
          const message = await page.locator('.msg.err').innerText();
          assert.match(message, /negative stock/i);
          assert.equal(await salesCount(ctx), before, 'nothing written');
          const ok = await sell(page);
          assert.equal(ok.response.status(), 201, 'a sale within stock still saves');
          return {
            observation: `oversell refused: "${message.slice(0, 120)}"; a 10 g sale saved as ${ok.vchNo}. Desktop text is "Negative Stock is Not Allow Curent Stock = …"`,
            expected: 'refusal + no write; in-stock sale saves',
            database: { before, after: await salesCount(ctx) },
          };
        } finally {
          await mustSet(page, 'CO_SET_NEW.NEGATIVE_STK_SALE', 'Y');
        }
      },
    ),

    C(
      'effect.whole-rupee-rounding',
      'T15',
      'mutation',
      "TOT_AMT_ROF=0 (TR_SALE.cs:19192 Math.Round, banker's): 61,234.50 → 61,234; net 63,609; tax 3% 1,908.27 (TAX_ROF blank → 2dp); total 65,517",
      async (ctx) => {
        const { page } = await ctx.session();
        await mustSet(page, 'CO_SET_NEW.TOT_AMT_ROF', '0');
        try {
          const { response, vchNo } = await sell(page);
          assert.equal(response.status(), 201, await response.text());
          const [h] = await S.header(ctx, vchNo);
          const [l] = await S.lines(ctx, vchNo);
          assert.deepEqual([l.amt, h.net, h.tax, h.tot], [61234, 63609, 1908.27, 65517]);
          return {
            observation: `voucher ${vchNo}: line ${l.amt}, net ${h.net}, tax ${h.tax}, total ${h.tot}`,
            expected: { line: 61234, net: 63609, tax: 1908.27, total: 65517 },
            database: { header: h, line: l },
            downstream: { total: h.tot },
          };
        } finally {
          await mustSet(page, 'CO_SET_NEW.TOT_AMT_ROF', '');
        }
      },
      {
        expected: { line: 61234, net: 63609, tax: 1908.27, total: 65517 },
        observe: async (ctx) => ({
          lastSale: await ctx.rows(
            `SELECT "VCH_NO","NET_AMT"::float net,"TAX_AMT"::float tax,"TOT_AMT"::float tot FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' ORDER BY "VCH_NO" DESC LIMIT 1`,
          ),
        }),
      },
    ),

    C(
      'effect.lock-date-refuses',
      'T15',
      'refusal',
      'LOCK_DATE (TR_SALE.cs:15066 "You Cant Save and Delete This Voucher Becouse Lock Date is"): a sale dated on or before the lock date is refused',
      async (ctx) => {
        const { page } = await ctx.session();
        const today = new Date().toISOString().slice(0, 10);
        await mustSet(page, 'CO_SET.LOCK_DATE', today);
        try {
          const before = await salesCount(ctx);
          const { response } = await sell(page);
          assert(
            response.status() >= 400 && response.status() < 500,
            `sale on the lock date answered ${response.status()}`,
          );
          const message = await page.locator('.msg.err').innerText();
          assert.equal(await salesCount(ctx), before);
          return {
            observation: `refused: "${message.slice(0, 140)}"`,
            expected: 'refusal + no write',
            database: { before, after: before },
          };
        } finally {
          await mustSet(page, 'CO_SET.LOCK_DATE', '');
        }
      },
    ),

    C(
      'effect.cash-limit-refuses',
      'T15',
      'refusal',
      'CASH_LIMIT (DC_Main.cs:2149-2165, TR_SALE.cs:14978-14988): party cash above the limit blocks the save',
      async (ctx) => {
        const { page } = await ctx.session();
        await mustSet(page, 'CO_SET.CASH_LIMIT', '50000');
        try {
          const before = await salesCount(ctx);
          const { response } = await sell(page, { cash: '65517.79' });
          assert(
            response.status() >= 400 && response.status() < 500,
            `cash above the limit answered ${response.status()}`,
          );
          const message = await page.locator('.msg.err').innerText();
          assert.match(message, /Cash Recieved Limit Amount = 50000/);
          assert.equal(await salesCount(ctx), before);
          return {
            observation: `refused: "${message.split('\n')[0]}"`,
            expected: 'refusal with the desktop message + no write',
            database: { before, after: before },
          };
        } finally {
          await mustSet(page, 'CO_SET.CASH_LIMIT', '');
        }
      },
    ),

    C(
      'effect.pan-limit',
      'T15',
      'refusal',
      'PAN_CARD_VAL (TR_SALE.cs:15111-15128): bill value at or above the limit needs the party PAN; WALKIN has none, E2ELOC has one',
      async (ctx) => {
        // 20 g line: metal 20 × 6,123.45 = 1,22,469; making 20 × 237.5 = 4,750; net 1,27,219; total 1,31,035.57 > 1,00,000.
        const big = { ...S.LINE_A, gross: '20.5', net: '20' };
        const { page } = await ctx.session();
        await mustSet(page, 'CO_SET.PAN_CARD_VAL', '100000');
        try {
          const before = await salesCount(ctx);
          const walkin = await sell(page, { party: 'WALKIN', line: big });
          assert(
            walkin.response.status() >= 400 && walkin.response.status() < 500,
            `WALKIN answered ${walkin.response.status()}`,
          );
          const message = await page.locator('.msg.err').innerText();
          assert.match(message, /PanNo/i);
          assert.equal(await salesCount(ctx), before);
          const withPan = await sell(page, { party: PARTIES.local.code, line: big });
          assert.equal(
            withPan.response.status(),
            201,
            'a party with a PAN may buy above the limit',
          );
          return {
            observation: `WALKIN refused "${message.slice(0, 100)}"; E2ELOC saved ${withPan.vchNo}`,
            expected: 'blank PAN refused, PAN party allowed',
            database: { before, after: await salesCount(ctx) },
          };
        } finally {
          await mustSet(page, 'CO_SET.PAN_CARD_VAL', '');
        }
      },
    ),

    C(
      'field.pan-limit-any-amount',
      'T02',
      'mutation',
      'UT_SETTING.cs cboPanCardVal is an editable combo (presets 100000/200000, saved as Val(Text) at :5059): the operator may enter any amount, e.g. 50000',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/settings');
        await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
        const control = page.locator('[id="CO_SET.PAN_CARD_VAL"]');
        const tabs = page.getByRole('tab');
        for (let i = 0; i < (await tabs.count()) && !(await control.count()); i++)
          await tabs.nth(i).click();
        const tag = await control.evaluate((el) => el.tagName);
        const options = tag === 'SELECT' ? await control.locator('option').allTextContents() : [];
        assert.notEqual(
          tag,
          'SELECT',
          `the PAN limit is a fixed list ${JSON.stringify(options)}; 50000 cannot be entered`,
        );
        await mustSet(page, 'CO_SET.PAN_CARD_VAL', '50000');
        const value = await stored(ctx, 'CO_SET', 'PAN_CARD_VAL');
        await mustSet(page, 'CO_SET.PAN_CARD_VAL', '');
        assert.equal(Number(value), 50000);
        return {
          observation: `stored ${value}`,
          expected: 50000,
          database: { PAN_CARD_VAL: value },
          downstream: { stored: value },
        };
      },
      {
        expected: { enterable: 50000 },
        observe: async (ctx) => ({ PAN_CARD_VAL: await stored(ctx, 'CO_SET', 'PAN_CARD_VAL') }),
      },
    ),

    C(
      'field.grid-row-height-whole-number',
      'T02',
      'mutation',
      'UT_SETTING_MAIN.cs:9148 saves GRID_ROW_HIGHT as Val(cboGridRowHeight.Text) into an integer column: any whole number may be typed, a fraction is refused',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/settings');
        await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
        const id = 'CO_SET_NEW.GRID_ROW_HIGHT';
        const control = page.locator(`[id="${id}"]`);
        const tabs = page.getByRole('tab');
        for (let i = 0; i < (await tabs.count()) && !(await control.count()); i++)
          await tabs.nth(i).click();
        assert.equal(
          await control.evaluate((el) => el.tagName),
          'INPUT',
          'an editable box with presets',
        );
        const presets = await page.locator(`datalist[id="${id}-presets"] option`).count();
        const before = await stored(ctx, 'CO_SET_NEW', 'GRID_ROW_HIGHT');
        await mustSet(page, id, '31');
        const typed = await stored(ctx, 'CO_SET_NEW', 'GRID_ROW_HIGHT');
        assert.equal(Number(typed), 31);
        const refused = await setSetting(page, id, '22.5');
        assert.equal(refused.status(), 400, await refused.text());
        await page.getByText('must be a whole number', { exact: false }).first().waitFor();
        const afterFraction = await stored(ctx, 'CO_SET_NEW', 'GRID_ROW_HIGHT');
        assert.equal(Number(afterFraction), 31, 'the fraction is not stored');
        await mustSet(page, id, before == null ? '' : String(before));
        return {
          observation: `${presets} presets; typed 31 stored ${typed}; 22.5 refused, stored ${afterFraction}`,
          expected: { typed: 31, fraction: 'refused' },
          database: { GRID_ROW_HIGHT: typed, afterFraction },
          downstream: { stored: typed },
        };
      },
    ),

    C(
      'rights.clerk-cannot-change',
      'T11',
      'refusal',
      'Settings are an administrator form (UT_SET_ADMIN refuses non-admins): a clerk cannot save a setting',
      async (ctx) => {
        const clerk = await ctx.session(as(USERS.clerk.user));
        const before = await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF');
        await clerk.page.goto('/settings');
        await clerk.page.waitForTimeout(1500);
        let status = null;
        if (
          await clerk.page
            .getByRole('heading', { name: 'Company Settings', exact: true })
            .isVisible()
            .catch(() => false)
        ) {
          const response = await setSetting(clerk.page, 'CO_SET_NEW.TOT_AMT_ROF', '1').catch(
            () => null,
          );
          status = response?.status() ?? null;
        }
        const after = await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF');
        assert.equal(
          after,
          before,
          `clerk changed TOT_AMT_ROF (${before} → ${after}), save answered ${status}`,
        );
        return {
          observation: `clerk save ${status ?? 'not offered'}; value unchanged`,
          expected: 'refused + unchanged',
          database: { before, after },
        };
      },
      {
        expected: { unchanged: true },
        observe: async (ctx) => ({ TOT_AMT_ROF: await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF') }),
      },
    ),

    NA(
      'formula.n-a',
      'T03',
      'The settings screen computes nothing; formula effects are the T15 consumer cases',
    ),
    NA('lookup.n-a', 'T04', 'The settings screen has no lookups'),
    NA('children.n-a', 'T05', 'Settings have no child rows'),
    NA('create.n-a', 'T07', 'Settings rows are created by provisioning, not by this screen'),
    NA('reopen.n-a', 'T08', 'Reopen is the reload step of field.route-and-reload'),
    NA('edit.n-a', 'T09', 'Edit is field.route-and-reload'),
    NA('delete.n-a', 'T10', 'Settings cannot be deleted'),

    ...['different-settings', 'same-setting'].map((mode) =>
      C(
        `concurrency.two-admins.${mode}`,
        'T12',
        'mutation',
        'WP-35 cases.md D4; UT_SETTING.cs:5014, :4912 each button writes one column.',
        async (ctx) => {
          const { page: a } = await ctx.session();
          const { page: b } = await ctx.session(as(USERS.admin.user, 'wp35-settings-second'));
          const oldCash = await stored(ctx, 'CO_SET', 'CASH_LIMIT');
          const oldRound = await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF');
          try {
            for (const page of [a, b]) {
              await page.goto('/settings');
              await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
            }
            await editSetting(a, 'CO_SET.CASH_LIMIT', '50000');
            await editSetting(
              b,
              mode === 'same-setting' ? 'CO_SET.CASH_LIMIT' : 'CO_SET_NEW.TOT_AMT_ROF',
              mode === 'same-setting' ? '60000' : '1',
            );
            assert.equal((await saveSettingsScreen(a)).status(), 200);
            assert.equal((await saveSettingsScreen(b)).status(), 200);
            const cash = Number(await stored(ctx, 'CO_SET', 'CASH_LIMIT'));
            const rounding = Number(await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF'));
            assert.equal(cash, mode === 'same-setting' ? 60000 : 50000);
            if (mode === 'different-settings') assert.equal(rounding, 1);
            return {
              observation: JSON.stringify({ cash, rounding }),
              expected: mode,
              database: { cash, rounding },
              downstream: { cash, rounding },
            };
          } finally {
            await mustSet(a, 'CO_SET.CASH_LIMIT', oldCash ?? '');
            await mustSet(a, 'CO_SET_NEW.TOT_AMT_ROF', oldRound ?? '');
          }
        },
      ),
    ),
    NA(
      'retry.n-a',
      'T13',
      'Saving the same setting twice is idempotent by design (same value written)',
    ),

    C(
      'rollback.second-table-fault',
      'T14',
      'refusal',
      'WP-35 cases.md; UT_SETTING.cs:5014 single-column desktop writes; web two-table patch is atomic.',
      async (ctx) => {
        const { page } = await ctx.session();
        const oldCash = await stored(ctx, 'CO_SET', 'CASH_LIMIT');
        const oldRound = await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF');
        try {
          await page.goto('/settings');
          await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
          await editSetting(page, 'CO_SET.CASH_LIMIT', '50000');
          await editSetting(page, 'CO_SET_NEW.TOT_AMT_ROF', '1');
          const before = await tenantFingerprint(ctx);
          await withWriteFault(ctx, 'CO_SET_NEW', 'UPDATE', async () => {
            const response = await saveSettingsScreen(page);
            assert.ok(response.status() >= 400);
            await page.locator('.msg.err').waitFor();
            assert.deepEqual(await tenantFingerprint(ctx), before);
            assert.equal(await stored(ctx, 'CO_SET', 'CASH_LIMIT'), oldCash);
            assert.equal(await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF'), oldRound);
          });
          assert.equal((await saveSettingsScreen(page)).status(), 200);
          assert.equal(Number(await stored(ctx, 'CO_SET', 'CASH_LIMIT')), 50000);
          assert.equal(Number(await stored(ctx, 'CO_SET_NEW', 'TOT_AMT_ROF')), 1);
          return {
            observation: 'Second-table fault preserves both values; retry saves both',
            expected: 'Atomic settings patch',
            database: { before, oldCash, oldRound },
          };
        } finally {
          await mustSet(page, 'CO_SET.CASH_LIMIT', oldCash ?? '');
          await mustSet(page, 'CO_SET_NEW.TOT_AMT_ROF', oldRound ?? '');
        }
      },
    ),
    NA('output.n-a', 'T16', 'The settings screens have no print or export'),
    NA('keyboard.n-a', 'T17', 'Covered by the voucher modules; the settings form is a plain form'),
    NA(
      'journey.n-a',
      'T18',
      'The T15 consumer cases are the journey: setting → sale → stored result',
    ),
  ],
};
