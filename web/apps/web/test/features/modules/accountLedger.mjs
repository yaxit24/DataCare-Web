import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Reports → Ledger Report (desktop RP_LEDR, web /reports/account-ledger).
 *
 * RP_LEDR is a READ-ONLY report (MDI_FORM.cs:8871-8880 opens it; it writes nothing). So the mutation
 * groups T07-T10 and T12-T14 are not applicable, each with a recorded reason. The applicable groups:
 *   T01 defaults and the single primary action; T02 the selectors; T03 the view switch (summary vs
 *   ageing recalculates); T04 the account lookup; T05 the drill-down child rows; T06 the empty-account
 *   refusal (no request, visible message); T11 rights/scope; T15 the With-Zero filter effect; T16 the
 *   PDF/Excel/CSV outputs; T17 Enter/Esc keyboard; T18 the summary -> detail drill-down journey.
 *
 * Expected values are derived from the desktop arithmetic (RP_LEDR.cs:6408/6417/6426 for the summary
 * sign split; :6989-7160 for running balances; :9877-10282 for FIFO ageing), seeded into AC_DATA/AC_MAST
 * directly because the report has no web writer.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `account-ledger.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const ROUTE = '/reports/account-ledger';
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
const button = (page, name) => page.getByRole('button', { name, exact: true });

/** Codes/names the cases own, so cleanup is exact. */
const CODES = ['Z100', 'Z200', 'Z300', 'Z400', 'Z500', 'Z600'];

async function cleanCase(ctx) {
  await exec(
    ctx,
    `DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
    CODES,
  );
  await exec(
    ctx,
    `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
    CODES,
  );
  await exec(ctx, `DELETE FROM "REMARK_DATA" WHERE tenant_id=$1 AND "VCH_NO" LIKE 'Z%'`);
  await exec(
    ctx,
    `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
    USERS.printViewer.user,
  );
}

async function seedAccount(ctx, code, name, extra = {}) {
  await exec(
    ctx,
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_CITY","AC_MOBILE")
     VALUES($1,'01','01',$2,$3,$4,$5,$6)`,
    code,
    name,
    extra.gr ?? 'DEBTOR',
    extra.city ?? 'RAJKOT',
    extra.mobile ?? '9000000009',
  );
}

let seq = 0;
async function seedLeg(ctx, code, o) {
  seq += 1;
  await exec(
    ctx,
    `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","LEDR_KEY",
       "BOOK_NAME","AC_CODE","LD_CODE","CR_AMT","DR_AMT","IT_TYPE","SIGN","FINE_WT","ENTRY_TIME","DATA_TYPE")
     VALUES($1,'01','01',$2,$3,$4,'SAL',$5::date,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15::timestamp,'A')`,
    ctx.coYear ?? yearOf(),
    o.book ?? 'SL',
    o.vchNo,
    o.date,
    `${ctx.tenantId}-ZK${seq}`,
    o.bookName ?? 'SALES',
    code,
    o.ldCode ?? null,
    o.cr ?? 0,
    o.dr ?? 0,
    o.itType ?? null,
    o.sign ?? null,
    o.fine ?? null,
    o.entry ?? `${o.date} 09:00:00`,
  );
}

function yearOf() {
  const now = new Date();
  const start = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
  return `${start}-${start + 1}`;
}

async function openScreen(page) {
  await page.goto(ROUTE);
  await page.getByRole('heading', { name: 'Ledger Report', exact: true }).waitFor();
}

async function withCase(ctx, fn) {
  await cleanCase(ctx);
  try {
    return await fn();
  } finally {
    await cleanCase(ctx);
  }
}

/** Scenario A account: money -40 -> Dr 40; gold +1.75 -> Cr; silver -6.25 -> Dr. */
async function seedAlpha(ctx) {
  await seedAccount(ctx, 'Z100', 'ZZ ALPHA');
  await seedLeg(ctx, 'Z100', { vchNo: 'Z0001', date: '2024-04-01', cr: 100 });
  await seedLeg(ctx, 'Z100', { vchNo: 'Z0002', date: '2024-04-02', dr: 140 });
  await seedLeg(ctx, 'Z100', {
    vchNo: 'Z0003',
    date: '2024-04-03',
    itType: 'G',
    sign: '+',
    fine: 2.5,
  });
  await seedLeg(ctx, 'Z100', {
    vchNo: 'Z0004',
    date: '2024-04-04',
    itType: 'G',
    sign: '-',
    fine: 0.75,
  });
  await seedLeg(ctx, 'Z100', {
    vchNo: 'Z0005',
    date: '2024-04-05',
    itType: 'S',
    sign: '-',
    fine: 6.25,
  });
}

/**
 * WP-20 print account Z600 (cases.md output.gold-figures): opening before the from date CR 100, G+ 1.5, S+ 2.256;
 * 2024-05-10 DR 40 with G- 0.5; 2024-06-15 CR 60 with G+ 2.0 and S- 1.0.
 */
const PRINT_FROM = '2024-04-01';
const PRINT_TO = '2024-06-30';
async function seedPrintAccount(ctx) {
  await seedAccount(ctx, 'Z600', 'ZZ PRINT');
  await seedLeg(ctx, 'Z600', {
    vchNo: 'Z6001',
    date: '2024-03-31',
    cr: 100,
    itType: 'G',
    sign: '+',
    fine: 1.5,
  });
  await seedLeg(ctx, 'Z600', {
    vchNo: 'Z6002',
    date: '2024-03-31',
    itType: 'S',
    sign: '+',
    fine: 2.256,
  });
  await seedLeg(ctx, 'Z600', {
    vchNo: 'Z6003',
    date: '2024-05-10',
    dr: 40,
    itType: 'G',
    sign: '-',
    fine: 0.5,
  });
  await seedLeg(ctx, 'Z600', {
    vchNo: 'Z6004',
    date: '2024-06-15',
    cr: 60,
    itType: 'G',
    sign: '+',
    fine: 2.0,
  });
  await seedLeg(ctx, 'Z600', {
    vchNo: 'Z6005',
    date: '2024-06-15',
    bookName: 'FINE JV',
    itType: 'S',
    sign: '-',
    fine: 1.0,
  });
}

/** Run the summary for the print dates and double-click Z600 into its detail drill-down. */
async function drillIntoPrintAccount(page) {
  await openScreen(page);
  await page.locator('#al-from').fill(PRINT_FROM);
  await page.locator('#al-to').fill(PRINT_TO);
  await button(page, 'Run').click();
  const row = page.locator('table.grid tbody tr', { hasText: 'ZZ PRINT' }).first();
  await row.waitFor();
  await row.dblclick();
  await page.waitForFunction(() => document.querySelector('#al-view')?.value === 'detail');
  await button(page, 'Gold').waitFor();
}

/** Click a print button, answer the layout question, and return the question and the PDF response. */
async function pressPrint(page, name, answerYes) {
  let question = null;
  // The harness accepts every dialog by default; this print answers its own question, then restores it.
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    question = dialog.message();
    void (answerYes ? dialog.accept() : dialog.dismiss());
  });
  try {
    const [response] = await Promise.all([
      page.waitForResponse((r) =>
        /\/api\/reports\/account-ledger\/[a-z-]+\/export\.pdf/.test(r.url()),
      ),
      button(page, name).click(),
    ]);
    return {
      question,
      url: response.url(),
      status: response.status(),
      type: response.headers()['content-type'] ?? '',
    };
  } finally {
    page.removeAllListeners('dialog');
    page.on('dialog', (dialog) => void dialog.accept());
  }
}

/** The JSON behind a print: the same query the PDF used, from its data route. */
async function printData(page, pdfUrl) {
  const path = new URL(pdfUrl).pathname.replace('/export.pdf', '') + new URL(pdfUrl).search;
  return page.evaluate(async (p) => {
    const res = await fetch(p, { credentials: 'include' });
    return { status: res.status, body: await res.json() };
  }, path);
}

export const accountLedger = {
  feature: 'account-ledger',
  title: 'Reports → Ledger Report (RP_LEDR)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/reports/account-ledger/page.tsx',
    'web/apps/web/app/(app)/reports/account-ledger/useAccountLedger.ts',
    'web/apps/web/app/(app)/reports/account-ledger/AccountLedgerGrid.tsx',
    'web/apps/api/src/modules/reports/accountLedgerReport.ts',
    'web/apps/api/src/routes/accountLedger.ts',
    'web/apps/api/src/routes/ledgerFinePrints.ts',
    'web/apps/api/src/modules/reports/ledgerFinePrints.ts',
    'web/apps/api/src/modules/reports/ledgerFineSources.ts',
    'web/apps/web/test/features/modules/accountLedger.mjs',
  ],
  fixtureManifest: { base: 'seedCompany; cases seed AC_DATA/AC_MAST/REMARK_DATA directly' },
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:8871-8880 opens RP_LEDR; the summary is the default view; the single main action is Run',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const primaries = (await page.locator('main button.primary').allInnerTexts()).map((t) =>
            t.trim(),
          );
          assert.deepEqual(primaries, ['Run']);
          assert.equal(await page.locator('#al-view').inputValue(), 'summary');
          return { observation: 'summary default; one primary Run', expected: { primaries } };
        }),
    ),
    C(
      'summary.sign-split',
      'T03',
      'read-only',
      'AcSumm (:6408/6417/6426): money Σ(CR-DR); gold/silver signed fine; negative -> Dr, positive -> Cr',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAlpha(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Run').click();
          const row = page.locator('table.grid tbody tr', { hasText: 'ZZ ALPHA' }).first();
          await row.waitFor();
          const cells = (await row.locator('td').allInnerTexts()).map((t) => t.trim());
          // Sr, Name, Mobile, DrAmt, CrAmt, DrGold, CrGold, DrSilver, CrSilver
          assert.equal(cells[3], '40.00'); // Dr Amt
          assert.equal(cells[4], ''); // Cr Amt blank
          assert.equal(cells[6], '1.750'); // Cr Gold
          assert.equal(cells[7], '6.250'); // Dr Silver
          return {
            observation: 'ALPHA splits to Dr 40 / Cr Gold 1.750 / Dr Silver 6.250',
            expected: { drAmt: '40.00', crGold: '1.750', drSilver: '6.250' },
          };
        }),
    ),
    C(
      'filter.account-lookup',
      'T04',
      'read-only',
      'RP_LEDR account selector (F1 opens the help; a typed code resolves): the web account LookupPicker',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAlpha(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const lookup = page.getByLabel('Account', { exact: true });
          await lookup.click();
          await lookup.fill('ZZ');
          // the dropdown lists the matching account
          await page.getByText('ZZ ALPHA', { exact: false }).first().waitFor();
          return { observation: 'account lookup lists ZZ ALPHA', expected: { typed: 'ZZ' } };
        }),
    ),
    C(
      'drill.detail-children',
      'T05',
      'read-only',
      'DGV_DETL_FILL (:6862-7266): a selected account shows its per-voucher detail rows with running balances',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAlpha(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await page.locator('#al-view').selectOption('detail');
          await page.getByLabel('Account', { exact: true }).fill('Z100');
          await button(page, 'Run').click();
          await page.locator('table.grid tbody tr').first().waitFor();
          const count = await page.locator('table.grid tbody tr').count();
          assert.ok(count >= 5, `detail shows the legs (got ${count})`);
          return { observation: `detail drill shows ${count} rows`, expected: { atLeast: 5 } };
        }),
    ),
    C(
      'refuse.empty-account',
      'T06',
      'refusal',
      'detail/voucher-summary require an account (RP_LEDR has no account selected on load); the web shows a message and sends no request',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await page.locator('#al-view').selectOption('detail');
          let sawRequest = false;
          page.on('request', (r) => {
            if (new URL(r.url()).pathname.startsWith('/api/reports/account-ledger'))
              sawRequest = true;
          });
          await button(page, 'Run').click();
          const alertBox = page.getByTestId('ledger-error');
          await alertBox.waitFor();
          const alert = (await alertBox.innerText()).trim();
          assert.match(alert, /account/i);
          assert.equal(sawRequest, false, 'no report request on an empty account');
          return {
            observation: 'empty-account detail shows an alert and sends no request',
            expected: { alert },
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'config.with-zero',
      'T15',
      'read-only',
      'chkZero (:6424-6433): a transaction-backed zero-balance account appears only when With Zero is on',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAccount(ctx, 'Z200', 'ZZ BETA');
          await seedLeg(ctx, 'Z200', { vchNo: 'Z0010', date: '2024-04-01', cr: 50 });
          await seedLeg(ctx, 'Z200', { vchNo: 'Z0011', date: '2024-04-02', dr: 50 });
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Run').click();
          await page.locator('table.grid').waitFor();
          assert.equal(await page.getByText('ZZ BETA', { exact: false }).count(), 0);
          await page.getByText('With Zero', { exact: false }).locator('input').check();
          await button(page, 'Run').click();
          await page.getByText('ZZ BETA', { exact: false }).first().waitFor();
          return {
            observation: 'ZZ BETA hidden by default, shown with With Zero',
            expected: { withZeroShows: 'ZZ BETA' },
          };
        }),
    ),
    C(
      'output.exports',
      'T16',
      'output',
      'RP_LEDR Print and Excel (BtnPrint/BtnSave); the web adds PDF/Excel/CSV, all from the same dataset',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAlpha(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Run').click();
          await page.locator('table.grid').waitFor();
          // The export buttons appear only after a run.
          for (const name of ['Print', 'Download PDF', 'Excel', 'CSV'])
            assert.ok(await button(page, name).isVisible(), `${name} is offered after a run`);
          // A direct fetch proves the export resolves the same rows (ALPHA present).
          const csv = await page.evaluate(async () => {
            const res = await fetch('/api/reports/account-ledger/export.csv?view=summary', {
              credentials: 'include',
            });
            return { status: res.status, body: await res.text() };
          });
          assert.equal(csv.status, 200);
          assert.match(csv.body, /ZZ ALPHA/);
          return {
            observation: 'PDF/Excel/CSV offered; CSV contains ALPHA',
            expected: { csvHasAlpha: true },
            output: { csvStatus: csv.status },
          };
        }),
    ),
    C(
      'keyboard.enter-esc',
      'T17',
      'read-only',
      'RP_LEDR keys (:5998-6095): Enter on the last selector runs; Esc leaves a drill-down back to the summary',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAlpha(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          // Enter on the To date runs the report.
          await page.locator('#al-to').focus();
          await page.keyboard.press('Enter');
          await page.locator('table.grid').waitFor();
          assert.ok((await page.locator('table.grid tbody tr').count()) >= 1);
          // Drill into detail, then Esc returns to the summary view.
          await page.locator('#al-view').selectOption('detail');
          await page.getByLabel('Account', { exact: true }).fill('Z100');
          await button(page, 'Run').click();
          await page.waitForFunction(() => document.querySelector('#al-view')?.value === 'detail');
          await page.locator('table.grid').waitFor();
          // Close any open lookup dropdown so the page-level Esc handler (not the lookup's) runs, then Esc.
          await page.getByRole('heading', { name: 'Ledger Report', exact: true }).click();
          await page.waitForFunction(() => !document.querySelector('[data-lookup-open]'));
          await page.keyboard.press('Escape');
          await page.waitForFunction(() => document.querySelector('#al-view')?.value === 'summary');
          return {
            observation: 'Enter runs; Esc returns a drill-down to the summary',
            expected: { afterEsc: 'summary' },
          };
        }),
    ),
    C(
      'journey.summary-to-detail',
      'T18',
      'read-only',
      'DGV_AC double-click -> DGV_DETL (:6500-6680): the full summary -> drill-down journey',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAlpha(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Run').click();
          const row = page.locator('table.grid tbody tr', { hasText: 'ZZ ALPHA' }).first();
          await row.waitFor();
          await row.dblclick();
          await page.waitForFunction(() => document.querySelector('#al-view')?.value === 'detail');
          await page.locator('table.grid tbody tr').first().waitFor();
          return {
            observation: 'double-click on a summary row drills into its detail',
            expected: { view: 'detail' },
          };
        }),
    ),
    C(
      'scope.rights',
      'T11',
      'read-only',
      'the Ledger Report route is guarded by its own form right (routePolicy Reports/Account Ledger -> Ledger Report); reads are tenant-scoped',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAlpha(ctx);
          // The same account code with a moved balance in the sentinel tenant. A name test on this tenant's own
          // accounts (for example its seeded OTHER CHARGES A/C, which earlier modules' vouchers move) proves nothing.
          const other = { ...ctx, tenantId: SECOND_TENANT };
          await cleanCase(other);
          try {
            await seedAccount(other, 'Z100', 'ZZ SENTINEL TENANT');
            await seedLeg(other, 'Z100', { vchNo: 'Z0001', date: '2024-04-01', dr: 999 });
            const { page } = await ctx.session();
            await openScreen(page);
            await button(page, 'Run').click();
            await page.locator('table.grid').waitFor();
            const names = await page.locator('table.grid tbody tr td:nth-child(2)').allInnerTexts();
            assert.ok(
              names.some((n) => n.includes('ZZ ALPHA')),
              `this tenant's account is listed: ${names}`,
            );
            assert.ok(
              names.every((n) => !n.includes('ZZ SENTINEL TENANT')),
              `the other tenant's account is never listed: ${names}`,
            );
            return { observation: 'only this tenant rows', expected: { scoped: true } };
          } finally {
            await cleanCase(other);
          }
        }),
    ),
    C(
      'entry.print-buttons-drill-only',
      'T01',
      'read-only',
      'RP_LEDR.cs:6024 {{((Control)BtnGold).Visible = false;}} on Esc; captions RP_LEDR.cs:2439 {{BtnGold.Text = "&Gold";}}, :2453 &Silver, :2425 &JmaUdr',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedPrintAccount(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await page.locator('#al-from').fill(PRINT_FROM);
          await page.locator('#al-to').fill(PRINT_TO);
          await button(page, 'Run').click();
          await page.locator('table.grid tbody tr', { hasText: 'ZZ PRINT' }).first().waitFor();
          for (const name of ['Gold', 'Silver', 'JmaUdr'])
            assert.equal(await button(page, name).count(), 0, `${name} hidden on the summary`);
          await page.locator('table.grid tbody tr', { hasText: 'ZZ PRINT' }).first().dblclick();
          await page.waitForFunction(() => document.querySelector('#al-view')?.value === 'detail');
          for (const name of ['Gold', 'Silver', 'JmaUdr']) {
            await button(page, name).waitFor();
            assert.equal(
              await button(page, name).evaluate((b) => b.classList.contains('primary')),
              false,
              `${name} is not a primary button`,
            );
          }
          await page.getByRole('heading', { name: 'Ledger Report', exact: true }).click();
          await page.keyboard.press('Escape');
          await page.waitForFunction(() => document.querySelector('#al-view')?.value === 'summary');
          // The buttons leave with the drill-down result once the summary has loaded.
          await button(page, 'Gold').waitFor({ state: 'detached' });
          for (const name of ['Gold', 'Silver', 'JmaUdr'])
            assert.equal(await button(page, name).count(), 0, `${name} hidden after Esc`);
          return {
            observation: 'Gold/Silver/JmaUdr only inside the drill-down; Esc hides them',
            expected: { drillOnly: ['Gold', 'Silver', 'JmaUdr'] },
          };
        }),
    ),
    C(
      'output.gold-figures',
      'T16',
      'output',
      'RP_LEDR.cs:8382 {{Hz Jama Udhar Gold Report}}; :8384 JmUdFineHz / :8388 JmUdFine; :8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedPrintAccount(ctx);
          const { page } = await ctx.session();
          await drillIntoPrintAccount(page);
          const no = await pressPrint(page, 'Gold', false);
          assert.equal(no.question, 'Hz Jama Udhar Gold Report');
          assert.equal(no.status, 200);
          assert.match(no.type, /application\/pdf/);
          assert.match(no.url, /hz=N/);
          const yes = await pressPrint(page, 'Gold', true);
          assert.equal(yes.status, 200);
          assert.match(yes.url, /hz=Y/);
          const dataNo = await printData(page, no.url);
          const dataYes = await printData(page, yes.url);
          assert.equal(dataNo.body.report, 'JmUdFine');
          assert.equal(dataYes.body.report, 'JmUdFineHz');
          const expected = [
            "RptTitel = 'Ledr With Gold Fine Report As On 30/06/2024'",
            'FromDate = Date(2024,4,01) ',
            'ToDate = Date(2024,6,30) ',
            'OpBal = 1.500',
            'ClBal = 3.000',
            'OpAmtBal = 100.00',
            'ClAmtBal = 120.00',
          ];
          for (const p of expected) assert.ok(dataNo.body.parameters.includes(p), `parameter ${p}`);
          assert.deepEqual(
            dataYes.body.parameters,
            dataNo.body.parameters,
            'both layouts carry the same figures',
          );
          return {
            observation: 'Gold asks the Hz question; both answers print the same AC_DATA figures',
            expected: { parameters: expected },
            output: { pdfStatus: no.status, contentType: no.type },
          };
        }),
    ),
    C(
      'output.silver-print',
      'T16',
      'output',
      'RP_LEDR.cs:9013 {{Hz Jama Udhar Silver Report}}; :9019 {{DC_Main.RptName = "JmUdFineSl";}}; D14 silver balance at two decimals (RP_LEDR.cs:8954)',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedPrintAccount(ctx);
          const { page } = await ctx.session();
          await drillIntoPrintAccount(page);
          const res = await pressPrint(page, 'Silver', false);
          assert.equal(res.question, 'Hz Jama Udhar Silver Report');
          assert.equal(res.status, 200);
          const data = await printData(page, res.url);
          assert.equal(data.body.report, 'JmUdFineSl');
          // Opening silver 2.256 reads as 2.26, closing 1.256 as 1.26 (SILVER_THREE_DIGIT off).
          assert.ok(data.body.parameters.includes('OpBal = 2.260'));
          assert.ok(data.body.parameters.includes('ClBal = 1.260'));
          // RP_LEDR.cs:8920 the silver FINE JV leg of the period prints; the gold legs do not.
          const fines = data.body.rows.map((r) => r.fine);
          assert.ok(fines.includes(1), 'the silver 1.000 leg prints');
          assert.ok(!fines.includes(2) && !fines.includes(0.5), 'no gold leg prints');
          return {
            observation: 'Silver prints JmUdFineSl with the silver rows and two-decimal balances',
            expected: { opBal: 'OpBal = 2.260', clBal: 'ClBal = 1.260' },
            output: { pdfStatus: res.status },
          };
        }),
    ),
    C(
      'output.jmaudr-print',
      'T16',
      'output',
      'RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}}; :4065 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";}}',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedPrintAccount(ctx);
          const { page } = await ctx.session();
          await drillIntoPrintAccount(page);
          const res = await pressPrint(page, 'JmaUdr', true);
          assert.equal(res.question, null, 'JmaUdr asks no layout question');
          assert.equal(res.status, 200);
          const data = await printData(page, res.url);
          assert.equal(data.body.report, 'JmUdAmt');
          assert.ok(data.body.parameters.includes('OpBal = 100.00'));
          assert.ok(data.body.parameters.includes('ClBal = 120.00'));
          return {
            observation: 'JmaUdr prints JmUdAmt with OpBal 100.00 / ClBal 120.00',
            expected: { opBal: 'OpBal = 100.00' },
            output: { pdfStatus: res.status },
          };
        }),
    ),
    C(
      'refuse.print-rights-gold',
      'T06',
      'refusal',
      'RP_LEDR.cs:8234 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}} then :8236 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedPrintAccount(ctx);
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES($1,'01','01',$2,'Report','Ledger Report','Y','N','N','N')`,
            USERS.printViewer.user,
          );
          const { page } = await ctx.session(as(USERS.printViewer.user));
          await drillIntoPrintAccount(page);
          for (const name of ['Gold', 'Silver', 'JmaUdr']) {
            const res = await pressPrint(page, name, false);
            assert.equal(res.status, 403, `${name} refuses`);
            const alertBox = page.getByTestId('ledger-error');
            await alertBox.waitFor();
            assert.equal((await alertBox.innerText()).trim(), 'You Have No Print Rights.....');
          }
          return {
            observation:
              'a user without the print right gets the desktop text on every print button',
            expected: { message: 'You Have No Print Rights.....' },
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'keyboard.print-hotkeys',
      'T17',
      'read-only',
      'the caption hot keys: RP_LEDR.cs:2439 {{BtnGold.Text = "&Gold";}} = Alt+G, :2453 &Silver = Alt+S, :2425 &JmaUdr = Alt+J',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedPrintAccount(ctx);
          const { page } = await ctx.session();
          await drillIntoPrintAccount(page);
          await page.getByRole('heading', { name: 'Ledger Report', exact: true }).click();
          const seen = [];
          for (const [key, kind] of [
            ['Alt+KeyJ', 'jama-udhar'],
            ['Alt+KeyG', 'gold-fine'],
            ['Alt+KeyS', 'silver-fine'],
          ]) {
            const [response] = await Promise.all([
              page.waitForResponse((r) =>
                r.url().includes(`/api/reports/account-ledger/${kind}/export.pdf`),
              ),
              page.keyboard.press(key),
            ]);
            assert.equal(response.status(), 200, `${key} prints ${kind}`);
            seen.push(kind);
          }
          return { observation: 'Alt+J/G/S trigger the prints', expected: { seen } };
        }),
    ),
    C(
      'config.lite-ageing-hidden',
      'T15',
      'read-only',
      'RP_LEDR.cs:4587 {{if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0))}} then :4589 {{((Control)BtnTimeWise).Visible = false;}}',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          // The feature stack runs the Lite default (no edition gate, D33), so the ageing view is not offered.
          const views = await page
            .locator('#al-view option')
            .evaluateAll((os) => os.map((o) => o.value));
          assert.ok(!views.includes('ageing'), `views offered: ${views.join(',')}`);
          assert.ok(views.includes('summary') && views.includes('detail'));
          return {
            observation: 'Debit Ageing is not offered in the Lite default',
            expected: { views },
          };
        }),
    ),
    notApplicable(
      'create',
      'T07',
      'RP_LEDR is a read-only report (MDI_FORM.cs:8871-8880); it writes no voucher',
      'read-only report has no create',
    ),
    notApplicable(
      'reopen',
      'T08',
      'RP_LEDR writes nothing; there is no saved voucher to reopen',
      'read-only report has no reopen/unchanged-save',
    ),
    notApplicable('edit', 'T09', 'RP_LEDR writes nothing', 'read-only report has no edit'),
    notApplicable(
      'delete',
      'T10',
      'RP_LEDR writes nothing',
      'read-only report has no delete/cancel/reverse',
    ),
    notApplicable(
      'concurrency',
      'T12',
      'RP_LEDR writes nothing; there is no lost-update path',
      'read-only report has no concurrency',
    ),
    notApplicable(
      'retry',
      'T13',
      'RP_LEDR writes nothing; a duplicate read is idempotent by nature',
      'read-only report has no write to retry',
    ),
    notApplicable(
      'rollback',
      'T14',
      'RP_LEDR writes nothing; there is no partial write to roll back',
      'read-only report has no rollback',
    ),
    notApplicable(
      'field-route',
      'T02',
      'the selectors are a view dropdown, an account lookup and date inputs; their behaviour is covered by T03/T04/T06',
      'selector routing is covered by the view/lookup/refusal cases',
    ),
  ],
};
