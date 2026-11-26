import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import { holdAdvisoryLock, purgeYear } from '../harness.mjs';
import { changedTables, tenantFingerprint } from '../faults.mjs';
import {
  as,
  C,
  COMPLETE,
  ITEM,
  LITE,
  NO_YEAR,
  PARTY,
  button,
  dropItemStock,
  dropParty,
  exec,
  followingYear,
  openScreen,
  runDataset,
  seedItemStock,
  seedParty,
  sessionYear,
  withNextYears,
} from './balanceTransferShared.mjs';

/**
 * Balance TrFr cases that need a second user, a second session, a dropped answer or a failed write.
 *
 * Rights: BtmSchm has no rights check of its own (BtmSchm.cs:1944-1953 reads USER_SET but UserEdit, UserDelete and
 * UserPrint are never tested); the menu button is the gate (MDI_FORM.cs:7032-7049 needs FRM_VIEW = 'Y', else "You Have
 * No Rights....."), and the catalog right is Create (C-----). On the web a create needs the form's View right
 * (authorization.ts), so the user with the Balance TrFr menu runs it and a user without it is refused.
 *
 * Faults are database triggers installed by the test on its own connection (the pattern of faults.mjs) and dropped
 * again; nothing in the application can be switched.
 */
const FORM = 'Balance TrFr';
const grant = (ctx, user, view, edit) =>
  exec(
    ctx,
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     VALUES ($1,'01','01',$2,'Company','${FORM}',$3,$4,'N','N')`,
    user,
    view,
    edit,
  );
const dropGrants = (ctx) =>
  exec(
    ctx,
    `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "SUB_MENU"='${FORM}' AND "USER_NAME" = ANY($2::text[])`,
    [USERS.clerk.user, USERS.printViewer.user],
  );
const opRows = (ctx) =>
  ctx.rows(
    `SELECT "CO_YEAR" yr,"AC_CODE" ac,"OP_AMT"::float amt,"OP_SIGN" sg FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
    PARTY.code,
  );
const itemRows = (ctx) =>
  ctx.rows(
    `SELECT "CO_YEAR" yr,"ITM_PCS"::float pcs,"ITM_GWT"::float gwt,"ITM_NWT"::float nwt,"ITM_AMT"::float amt
       FROM "ITM_OPBL" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
    ITEM.code,
  );

/** A BEFORE INSERT trigger that fails the carry's write into `table` for one tenant and year. */
async function installFault(ctx, table, year) {
  await ctx.owner.$executeRawUnsafe(
    `CREATE OR REPLACE FUNCTION e2e_bt_fault() RETURNS trigger LANGUAGE plpgsql SECURITY DEFINER AS $f$
     BEGIN
       IF NEW.tenant_id = '${ctx.tenantId}' AND NEW."CO_YEAR" = '${year}' AND NEW."CO_BOOK" = '000' THEN
         RAISE EXCEPTION 'e2e fault on ${table}';
       END IF;
       RETURN NEW;
     END $f$`,
  );
  await ctx.owner.$executeRawUnsafe(
    `CREATE TRIGGER e2e_bt_fault BEFORE INSERT ON "${table}" FOR EACH ROW EXECUTE FUNCTION e2e_bt_fault()`,
  );
}
async function removeFault(ctx, table) {
  await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS e2e_bt_fault ON "${table}"`);
  await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_bt_fault()`);
}

export const faultCases = [
  C(
    'rights.create-right-required',
    'T11',
    'refusal',
    'MDI_FORM.cs:7032-7049 the menu needs FRM_VIEW; BtmSchm.cs:1944-1953 reads the rights but never tests them; catalog right C-----',
    async (ctx) => {
      const probe = await ctx.session(as(USERS.admin.user, 'bt-rights-admin'));
      return withNextYears(ctx, probe.page, 1, async ({ current, clDate, next }) => {
        await seedParty(ctx, current, clDate);
        await dropGrants(ctx);
        try {
          const writes = ['ac-balance', 'item-stock', 'tag-stock', 'sales-order', 'approval'];
          const attempt = async (page) => {
            const out = { read: (await page.request.get('/api/balance-transfer')).status() };
            for (const dataset of writes)
              out[dataset] = (
                await page.request.post(`/api/balance-transfer/${dataset}`, {
                  data: { toYear: next[0].year },
                })
              ).status();
            return out;
          };
          // No Balance TrFr row: the menu would answer "You Have No Rights....."; every route is refused.
          const none = await ctx.session({
            ...as(USERS.printViewer.user, 'bt-rights-none'),
            year: current,
          });
          const refusedNone = await attempt(none.page);
          // An edit-only row (no View) does not open the menu either.
          await grant(ctx, USERS.printViewer.user, 'N', 'Y');
          const refusedEdit = await attempt(none.page);
          const refused = { none: refusedNone, editOnly: refusedEdit };
          for (const result of Object.values(refused))
            for (const status of Object.values(result))
              assert.equal(status, 403, JSON.stringify(refused));
          assert.deepEqual(await opRows(ctx), [], 'a refused user writes nothing');
          // The screen of a refused user shows the desktop's menu refusal.
          await none.page.goto('/company/balance-transfer');
          await none.page.getByText('You Have No Rights.....', { exact: true }).waitFor();
          // A user whose Balance TrFr row has View opens the form and runs the carry through the screen.
          await grant(ctx, USERS.clerk.user, 'Y', 'N');
          const clerk = await ctx.session({
            ...as(USERS.clerk.user, 'bt-rights-clerk'),
            year: current,
          });
          await openScreen(clerk.page);
          const { response } = await runDataset(clerk.page, 'Ac Balance');
          assert.equal(response.status(), 200, await response.text());
          await clerk.page.getByText(COMPLETE, { exact: true }).waitFor();
          const written = await opRows(ctx);
          assert.deepEqual(
            written.map((r) => [r.yr, r.amt, r.sg]),
            [[next[0].year, 3499.25, 'C']],
          );
          return {
            observation: `no row and edit-only row refused ${JSON.stringify(refused)}; the View row ran Ac Balance`,
            expected: { refused: 403, viewRowSucceeds: 200 },
            database: { written },
          };
        } finally {
          await dropGrants(ctx);
          await dropParty(ctx);
        }
      });
    },
  ),
  C(
    'retry.lost-ack-after-commit',
    'T13',
    'mutation',
    'BtmSchm.cs:2932 a run deletes and rewrites ITM_OPBL, so a repeat after a lost answer is the same rows; :2755 completion text',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'bt-lost-ack'));
      return withNextYears(ctx, page, 1, async ({ current, clDate }) => {
        await seedItemStock(ctx, current, clDate);
        try {
          await openScreen(page);
          await page.route('**/api/balance-transfer/item-stock', async (route) => {
            // The run reaches the server and commits; its answer is lost on the way back.
            await route.fetch();
            await route.fulfill({
              status: 408,
              contentType: 'application/json',
              body: '{"error":"lost"}',
            });
          });
          const lost = await runDataset(page, 'Item Stock');
          assert.equal(lost.response.status(), 408);
          await page.locator('.msg[role="alert"]').waitFor();
          assert.equal(await page.getByText(COMPLETE, { exact: true }).count(), 0);
          await page.unroute('**/api/balance-transfer/item-stock');
          const once = await itemRows(ctx);
          assert.equal(once.length, 1, 'the committed run left one row');
          const again = await runDataset(page, 'Item Stock');
          assert.equal(again.response.status(), 200, await again.response.text());
          await page.getByText(COMPLETE, { exact: true }).waitFor();
          const twice = await itemRows(ctx);
          assert.deepEqual(
            twice,
            once,
            'the second run replaces the rows, it does not double them',
          );
          return {
            observation:
              'the lost answer showed an error; clicking again replaced the rows and showed the completion text',
            expected: { rows: 1, pcs: 6, text: COMPLETE },
            database: { once, twice },
            downstream: { rows: twice.length },
          };
        } finally {
          await dropItemStock(ctx);
        }
      });
    },
  ),
  C(
    'config.new-year-created-after-load',
    'T15',
    'mutation',
    'BtmSchm.cs:2085-2105 the Transfer Year is read from YEAR_MAST when the form opens; MS_YEAR.cs:1153-1228 creates a year',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'bt-new-year'));
      const current = await sessionYear(page);
      const target = followingYear(current);
      const later = await ctx.rows(
        `SELECT count(*)::int n FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR" > $2`,
        current,
      );
      assert.equal(later[0].n, 0, 'the catalogue has no later year');
      try {
        await page.goto('/company/balance-transfer');
        await page.getByText(NO_YEAR, { exact: true }).waitFor();
        for (const label of LITE) assert.equal(await button(page, label).isDisabled(), true, label);
        // Year Create in a second tab of the same session.
        const tab = await page.context().newPage();
        await tab.goto('/masters/year-create');
        await tab.getByLabel('Year (CO_YEAR)', { exact: true }).fill(target);
        await tab.getByRole('button', { name: 'Create Year', exact: true }).click();
        await tab
          .getByText('New Year are Created...Now ReOpen Sofware...', { exact: true })
          .waitFor();
        await tab.close();
        // The first tab still shows what it loaded; a reload offers the new year.
        assert.equal(await button(page, 'Ac Balance').isDisabled(), true);
        await page.reload();
        await page.getByRole('heading', { name: 'Balance TrFr', exact: true }).waitFor();
        await page.waitForFunction(
          (year) => document.getElementById('balance-transfer-year')?.value === year,
          target,
        );
        for (const label of LITE) assert.equal(await button(page, label).isEnabled(), true, label);
        assert.equal(await page.getByText(NO_YEAR, { exact: true }).count(), 0);
        const database = await ctx.rows(
          `SELECT "CO_YEAR" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR"=$2`,
          target,
        );
        assert.equal(database.length, 1);
        return {
          observation: `after creating ${target} in a second tab, a reload offers it and the five buttons are enabled`,
          expected: { toYear: target, enabled: LITE },
          database,
          downstream: { toYear: target },
        };
      } finally {
        await purgeYear(ctx.owner, ctx.tenantId, target);
        await exec(ctx, `DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR"=$2`, target);
      }
    },
  ),
  C(
    'concurrency.same-button-twice',
    'T12',
    'mutation',
    'BtmSchm.cs:2764 a run replaces its dataset; web: one run at a time per company, location, Transfer Year and dataset (balanceTransfer.ts lockTx)',
    async (ctx) => {
      const a = await ctx.session(as(USERS.admin.user, 'bt-race-a'));
      const b = await ctx.session(as(USERS.admin.user, 'bt-race-b'));
      return withNextYears(ctx, a.page, 1, async ({ current, clDate, next }) => {
        await seedParty(ctx, current, clDate);
        let lock;
        try {
          await openScreen(a.page);
          await openScreen(b.page);
          // Both runs queue behind the lock the writer takes, then are released at the same instant.
          lock = await holdAdvisoryLock(
            ctx.owner,
            'hashtextextended',
            `BALANCE_TRFR:${ctx.tenantId}:01:01:${next[0].year}:ac-balance`,
          );
          const answers = [a, b].map(({ page }) =>
            page.waitForResponse(
              (r) =>
                r.request().method() === 'POST' &&
                new URL(r.url()).pathname === '/api/balance-transfer/ac-balance',
            ),
          );
          await Promise.all([a, b].map(({ page }) => button(page, 'Ac Balance').click()));
          let waiting = 0;
          for (let i = 0; i < 100 && waiting < 2; i++) {
            [{ n: waiting }] = await ctx.owner.$queryRawUnsafe(
              `SELECT count(*)::int n FROM pg_locks WHERE locktype='advisory' AND NOT granted`,
            );
            if (waiting < 2) await a.page.waitForTimeout(100);
          }
          assert.equal(waiting, 2, 'both runs are waiting on the same lock');
          await lock.release();
          lock = undefined;
          const responses = await Promise.all(answers);
          assert.deepEqual(
            responses.map((r) => r.status()),
            [200, 200],
          );
          for (const { page } of [a, b]) await page.getByText(COMPLETE, { exact: true }).waitFor();
          const rows = await opRows(ctx);
          assert.deepEqual(
            rows.map((r) => [r.yr, r.amt, r.sg]),
            [[next[0].year, 3499.25, 'C']],
          );
          return {
            observation:
              'two sessions pressed Ac Balance together: both answered 200, one OP_DATA row, no error',
            expected: { statuses: [200, 200], rows: 1, amount: 3499.25 },
            database: { rows },
            downstream: { rows: rows.length },
          };
        } finally {
          if (lock) await lock.release().catch(() => {});
          await dropParty(ctx);
        }
      });
    },
  ),
  C(
    'rollback.ac-balance-after-first-table',
    'T14',
    'refusal',
    'BtmSchm.cs:2755 completion only after every write; weakness 9 (no transaction): web writes a run in one transaction',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'bt-rollback'));
      return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
        const year = next[0].year;
        await seedParty(ctx, current, clDate, PARTY, { afterVoucher: false });
        await seedItemStock(ctx, current, clDate);
        let installed = null;
        try {
          await openScreen(page);
          for (const label of ['Ac Balance', 'Item Stock']) {
            const { response } = await runDataset(page, label);
            assert.equal(response.status(), 200, await response.text());
            await page.getByText(COMPLETE, { exact: true }).waitFor();
          }
          const first = { party: await opRows(ctx), item: await itemRows(ctx) };
          assert.deepEqual(
            first.party.map((r) => r.amt),
            [3499.25],
          );
          assert.deepEqual(
            first.item.map((r) => r.pcs),
            [6],
          );
          // The closing year changes, so a clean re-run would write different figures.
          await exec(
            ctx,
            `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","DATA_TYPE","VCH_TYPE","LEDR_KEY")
             VALUES ($1,'01','01',$2,'JV','BT5',$3::date,$4,0,249.25,'A','A','JV','E2E-BT-5')`,
            current,
            clDate,
            PARTY.code,
          );
          await exec(
            ctx,
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
             VALUES ($1,'01','01',$2,'PUR','BT3',$3::date,$4,'N','+',1,10,9.8)`,
            current,
            clDate,
            ITEM.code,
          );
          const attempts = [];
          // A fault on the carry's own write after the earlier writes of the same run: OP_DATA is deleted and
          // rewritten, then the opening legs fail; for the item run ITM_OPBL is deleted, then its insert fails.
          for (const [label, table] of [
            ['Ac Balance', 'AC_DATA'],
            ['Item Stock', 'ITM_OPBL'],
          ]) {
            await installFault(ctx, table, year);
            installed = table;
            const before = await tenantFingerprint(ctx);
            const { response } = await runDataset(page, label);
            assert.ok(response.status() >= 400, `${label}: answered ${response.status()}`);
            await page.locator('.msg[role="alert"]').waitFor();
            assert.equal(await page.getByText(COMPLETE, { exact: true }).count(), 0);
            const after = await tenantFingerprint(ctx);
            assert.deepEqual(
              changedTables(before, after),
              [],
              `${label}: every table is unchanged`,
            );
            await removeFault(ctx, table);
            installed = null;
            attempts.push({ label, table, status: response.status() });
          }
          assert.deepEqual({ party: await opRows(ctx), item: await itemRows(ctx) }, first);
          // The fault is gone: the same buttons now write the new closing.
          for (const label of ['Ac Balance', 'Item Stock']) {
            const { response } = await runDataset(page, label);
            assert.equal(response.status(), 200, await response.text());
            await page.getByText(COMPLETE, { exact: true }).waitFor();
          }
          const second = { party: await opRows(ctx), item: await itemRows(ctx) };
          assert.deepEqual(
            second.party.map((r) => [r.amt, r.sg]),
            [[3250, 'C']],
          );
          assert.deepEqual(
            second.item.map((r) => r.pcs),
            [7],
          );
          return {
            observation:
              'a failed write rolled both runs back whole; after the fault the figures were rewritten',
            expected: { afterFault: first, afterRetry: { amount: 3250, pcs: 7 } },
            database: { attempts, first, second },
          };
        } finally {
          if (installed) await removeFault(ctx, installed).catch(() => {});
          await dropParty(ctx);
          await dropItemStock(ctx);
        }
      });
    },
  ),
];
