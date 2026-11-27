import assert from 'node:assert/strict';
import { purgeCompany } from '../harness.mjs';
import { USERS } from '../fixtures/catalogue.mjs';

/**
 * Company → Company, Ctrl+R "Reset Company" (MS_COMPANY.cs:6477-6480). The desktop clears a flagged company at the
 * next login, keeping its default rows (Module_Schm.cs:60-230, MS_LOGIN.cs:581-593); the web (owner decision
 * 2026-11-28) clears the shown company at once and keeps the company, administrators only, behind a second
 * confirmation (typed code and name, password, reason), and archives every deleted row (api
 * modules/masters/companyReset.ts, docs/handbook/web/desktop-adaptations.md "Company reset").
 * Every case works on a throwaway company 08 provisioned with the real seedCompany and removed afterwards.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run) => ({
  id: `company-master.${id}`,
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
});
const SOURCE = 'MS_COMPANY.cs:6477-6480,6116,6162; Module_Schm.cs:60-230; MS_LOGIN.cs:581-593';
const CODE = '08';
const NAME = 'E2E RESET COMPANY';
const REASON = 'Throwaway synthetic company for the reset case';
const FINAL = `Clear all data of ${CODE} — ${NAME}`;
const ARCHIVE_NOTE =
  'The deleted data is kept in a protected archive; support can recover it if needed.';
const KEPT = [
  'CO_MAST',
  'CO_SET',
  'CO_SET_NEW',
  'PRINT_MAST',
  'E_MAST',
  'BOOK_DATA',
  'BOOK_DETL',
  'LOGIN_MAST',
  'USER_SET',
  'LOCT_MAST',
  'YEAR_MAST',
];

/** Rows of company 08 in every company-scoped table (tenant_id + CO_CODE), without surrogate ids. */
async function content(ctx) {
  const tables = await ctx.owner.$queryRawUnsafe(
    `SELECT c.table_name FROM information_schema.columns c
       JOIN information_schema.tables t USING (table_schema,table_name)
      WHERE c.table_schema='public' AND t.table_type='BASE TABLE' AND c.column_name IN ('tenant_id','CO_CODE')
      GROUP BY c.table_name HAVING count(*)=2 ORDER BY c.table_name`,
  );
  const out = {};
  for (const { table_name } of tables) {
    const rows = await ctx.rows(
      `SELECT (to_jsonb(t) - 'row_id')::text r FROM "${table_name}" t WHERE tenant_id=$1 AND "CO_CODE"::text=$2`,
      CODE,
    );
    if (rows.length) out[table_name] = rows.map((row) => row.r).sort();
  }
  return out;
}
const split = (all) => ({
  kept: Object.fromEntries(Object.entries(all).filter(([t]) => KEPT.includes(t))),
  rest: Object.fromEntries(Object.entries(all).filter(([t]) => !KEPT.includes(t))),
});
const companyCount = async (ctx) =>
  (await ctx.rows(`SELECT count(*)::int n FROM "CO_MAST" WHERE tenant_id=$1`))[0].n;

/** Provision company 08, run the case, then remove every trace of it (rows, reset runs and their archive). */
async function withThrowaway(ctx, run) {
  await purgeCompany(ctx.owner, ctx.tenantId, CODE);
  await ctx.stack.seedCompany(ctx.stack.runtime, ctx.tenantId, CODE, { coName: NAME });
  const fresh = await content(ctx);
  // A party and an item the user added: not defaults, so a reset removes them.
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,$2,'01','E2ERST','E2E RESET PARTY','20')`,
    ctx.tenantId,
    CODE,
  );
  try {
    return await run(fresh);
  } finally {
    await ctx.owner.$transaction(async (tx) => {
      await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
      // Deleting the run cascades to its archive rows.
      await tx.$executeRawUnsafe(
        `DELETE FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id='company-reset' AND co_code=$2`,
        ctx.tenantId,
        CODE,
      );
    });
    await purgeCompany(ctx.owner, ctx.tenantId, CODE);
  }
}

async function openCompany(page, code) {
  await page.goto('/masters/companies');
  await page.getByRole('heading', { name: 'Company', exact: true }).waitFor();
  await page.waitForFunction(() => document.querySelector('#company-code')?.value === '01');
  if (code === '01') return;
  await page.getByTestId('company-list').locator(`tr[data-code="${code}"]`).click();
  await page.waitForFunction((c) => document.querySelector('#company-code')?.value === c, code);
}
async function openPanel(page, code = CODE) {
  const preview = page.waitForResponse(
    (r) => new URL(r.url()).pathname === `/api/companies/${code}/reset/preview`,
  );
  await page.keyboard.press('Control+r');
  const panel = page.getByRole('dialog', { name: 'Reset Company' });
  await panel.waitFor();
  const response = await preview;
  assert.equal(response.status(), 200);
  await panel.getByRole('list', { name: 'Will be deleted' }).waitFor();
  return { panel, plan: await response.json() };
}
const kindCount = async (panel, kind) =>
  Number((await panel.locator(`li[data-kind="${kind}"] strong`).first().textContent()).trim());

export const companyResetCases = [
  C('reset.admin-preview-kept-and-deleted', 'T05', 'refusal', SOURCE, async (ctx) =>
    withThrowaway(ctx, async () => {
      const before = await content(ctx);
      const { page } = await ctx.session(as(USERS.admin.user, 'company-master-reset'));
      await openCompany(page, CODE);
      const { panel, plan } = await openPanel(page);
      const deleted = Object.fromEntries(plan.deleted.map((t) => [t.table, t.rows]));
      // The accounts the books and the location post to stay; the user's own party goes.
      const keptAccounts = plan.kept.find((t) => t.table === 'AC_MAST')?.rows ?? 0;
      assert.ok(keptAccounts > 0, 'accounts named by the books stay');
      assert.ok(deleted.AC_MAST >= 1, 'the added party is cleared');
      assert.equal(keptAccounts + deleted.AC_MAST, before.AC_MAST.length);
      assert.equal(deleted.LOGIN_MAST, undefined, 'users are kept');
      assert.equal(deleted.BOOK_DATA, undefined, 'books are kept');
      assert.ok(plan.kept.some((t) => t.table === 'CO_MAST'));
      assert.equal(await kindCount(panel, 'masters'), plan.kinds.masters);
      assert.equal(await kindCount(panel, 'vouchers'), plan.kinds.vouchers);
      assert.match(
        await panel.getByTestId('company-reset-archive').textContent(),
        /protected archive/,
      );
      assert.equal(await panel.getByRole('link', { name: 'Data Backup' }).count(), 0);
      assert.equal(await panel.getByRole('button', { name: 'Reset company…' }).isEnabled(), true);
      await ctx.shot(page, 'preview');
      await panel.getByRole('button', { name: 'Close', exact: true }).click();
      // Company 01, the company the admin works in, can be reset too: the panel offers it.
      await openCompany(page, '01');
      const own = await openPanel(page, '01');
      assert.equal(
        await own.panel.getByRole('button', { name: 'Reset company…' }).isEnabled(),
        true,
      );
      assert.deepEqual(await content(ctx), before);
      return {
        observation:
          'admin Ctrl+R on company 08 listed what is cleared per kind and what stays, the archive note and no backup step; company 01 was offered too; nothing changed',
        expected: { kinds: plan.kinds, keptYear: plan.keptYear },
        database: { unchanged: true },
      };
    }),
  ),
  C('reset.confirmation-gate-and-cancel', 'T05', 'refusal', SOURCE, async (ctx) =>
    withThrowaway(ctx, async () => {
      const before = await content(ctx);
      const { page } = await ctx.session(as(USERS.admin.user, 'company-master-reset'));
      await openCompany(page, CODE);
      const { panel } = await openPanel(page);
      await panel.getByRole('button', { name: 'Reset company…' }).click();
      const dialog = page.getByRole('dialog', { name: 'Confirm company reset' });
      await dialog.waitFor();
      assert.match(await dialog.textContent(), /protected archive; support can recover it/);
      const final = dialog.getByRole('button', { name: FINAL });
      const states = [];
      const step = async (label, value) => {
        await dialog.getByLabel(label).fill(value);
        states.push(await final.isEnabled());
      };
      await step('Company code (08)', CODE);
      await step('Company name (E2E RESET COMPANY)', 'E2E RESET COMPAN');
      await step('Your password', process.env.FEATURE_E2E_PASSWORD);
      await step('Reason (at least 12 characters)', 'too short');
      await step('Reason (at least 12 characters)', REASON);
      await step('Company name (E2E RESET COMPANY)', NAME);
      await step('Company code (08)', '8');
      await step('Company code (08)', CODE);
      assert.deepEqual(states, [false, false, false, false, false, true, false, true]);
      // The page behind is inert while the dialog is open; Escape cancels it.
      assert.equal(
        await page.evaluate(() => document.querySelector('dialog')?.matches(':modal')),
        true,
      );
      await page.keyboard.press('Escape');
      await dialog.waitFor({ state: 'detached' });
      await panel.waitFor();
      await panel.getByRole('button', { name: 'Reset company…' }).click();
      await dialog.waitFor();
      await dialog.getByRole('button', { name: 'Cancel', exact: true }).click();
      await dialog.waitFor({ state: 'detached' });
      assert.deepEqual(await content(ctx), before);
      const runs = await ctx.rows(
        `SELECT count(*)::int n FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id='company-reset'`,
      );
      assert.equal(runs[0].n, 0);
      return {
        observation: `"${FINAL}" stayed disabled until code, exact name, password and a 12+ character reason all matched; Escape and Cancel closed the dialog and nothing changed`,
        expected: { enabledStates: states },
        database: { unchanged: true, resetRuns: 0 },
      };
    }),
  ),
  C('reset.success-clears-data-keeps-company', 'T03', 'mutation', SOURCE, async (ctx) =>
    withThrowaway(ctx, async (fresh) => {
      const before = await content(ctx);
      const companiesBefore = await companyCount(ctx);
      const { page } = await ctx.session(as(USERS.admin.user, 'company-master-reset'));
      await openCompany(page, CODE);
      const { panel, plan } = await openPanel(page);
      await panel.getByRole('button', { name: 'Reset company…' }).click();
      const dialog = page.getByRole('dialog', { name: 'Confirm company reset' });
      await dialog.getByLabel('Company code (08)').fill(CODE);
      await dialog.getByLabel('Company name (E2E RESET COMPANY)').fill(NAME);
      await dialog.getByLabel('Your password').fill(process.env.FEATURE_E2E_PASSWORD);
      await dialog.getByLabel('Reason (at least 12 characters)').fill(REASON);
      const reset = page.waitForResponse(
        (r) =>
          r.request().method() === 'POST' &&
          new URL(r.url()).pathname === `/api/companies/${CODE}/reset`,
      );
      await dialog.getByRole('button', { name: FINAL }).click();
      assert.equal((await reset).status(), 200);
      const result = page.getByTestId('company-reset-result');
      await result.waitFor();
      assert.match(await result.textContent(), new RegExp(`${plan.deletedTotal} rows`));
      await ctx.shot(page, 'reset-done');
      const after = await content(ctx);
      // The company stays, with its kept tables as they were; everything else is a fresh company's defaults.
      assert.deepEqual(split(after).kept, split(before).kept);
      assert.deepEqual(split(after).rest, split(fresh).rest);
      assert.equal(await companyCount(ctx), companiesBefore);
      await page.getByTestId('company-list').locator(`tr[data-code="${CODE}"]`).waitFor();
      const [run] = await ctx.rows(
        `SELECT row_id::text id,operator,reason,state,applied_counts FROM "data_repair_run"
          WHERE tenant_id=$1 AND operation_id='company-reset' AND co_code=$2`,
        CODE,
      );
      assert.equal(run.operator, USERS.admin.user);
      assert.equal(run.reason, REASON);
      assert.equal(run.state, 'applied');
      const archived = await ctx.rows(
        `SELECT table_name t, count(*)::int n FROM company_reset_archive
          WHERE tenant_id=$1 AND run_id=$2::bigint GROUP BY table_name`,
        run.id,
      );
      const planned = Object.fromEntries(plan.deleted.map((t) => [t.table, t.rows]));
      assert.deepEqual(Object.fromEntries(archived.map((row) => [row.t, row.n])), planned);
      assert.deepEqual(
        Object.fromEntries(run.applied_counts.map((d) => [d.table, d.delete])),
        planned,
      );
      return {
        observation: `company 08 cleared from the second dialog: ${plan.deletedTotal} rows deleted and archived, the company and its kept tables stayed, the rest equals a freshly provisioned company, and an applied company-reset run recorded the counts`,
        expected: { deleted: planned },
        database: {
          run: { operator: run.operator, reason: run.reason },
          archived: plan.deletedTotal,
        },
        downstream: { companyStillListed: CODE },
      };
    }),
  ),
  C('reset.non-admin-sees-note-only', 'T05', 'refusal', SOURCE, async (ctx) => {
    const { page } = await ctx.session(as(USERS.clerk.user, 'company-master-reset-clerk'));
    await page.goto('/masters/companies');
    await page.getByRole('heading', { name: 'Company', exact: true }).waitFor();
    await page.keyboard.press('Control+r');
    const panel = page.getByRole('dialog', { name: 'Reset Company' });
    await panel.getByText('Only an administrator can reset a company.').waitFor();
    assert.equal(await panel.getByRole('button', { name: 'Reset company…' }).count(), 0);
    assert.equal(await panel.getByRole('list').count(), 0);
    await panel.getByRole('button', { name: 'Close', exact: true }).click();
    return {
      observation:
        'a non-admin Ctrl+R showed only the administrator note, no counts and no reset button',
      expected: { note: 'Only an administrator can reset a company.' },
      database: { unchanged: true },
    };
  }),
];
