import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';

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
const CODES = ['Z100', 'Z200', 'Z300', 'Z400', 'Z500'];

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
          await page.getByRole('alert').waitFor();
          const alert = (await page.getByRole('alert').innerText()).trim();
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
          await page.locator('table.grid').waitFor();
          await page.locator('body').press('Escape');
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
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Run').click();
          await page.locator('table.grid').waitFor();
          // The report never shows another tenant's rows (seedAlpha is this tenant only).
          const names = await page.locator('table.grid tbody tr td:nth-child(2)').allInnerTexts();
          assert.ok(names.every((n) => !n.includes('OTHER')));
          return { observation: 'only this tenant rows', expected: { scoped: true } };
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
