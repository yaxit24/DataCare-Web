import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Company → Open Company (desktop MS_OPNCOMP, web /select).
 *
 * The desktop opens a company, location and year for the signed-in user. The web stores that choice on the session
 * (`POST /context/select`, a serializable transaction). Several sessions opening at the same moment made one of
 * them lose with the raw code `context-transaction-conflict` (G172); the screen now retries it and otherwise explains.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `company-open.${id}`,
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

async function openSelect(page) {
  await page.goto('/select');
  await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
  const open = page.getByRole('button', { name: 'Open', exact: true });
  for (let i = 0; i < 100 && !(await open.isEnabled()); i++) await page.waitForTimeout(100);
  assert.ok(await open.isEnabled(), 'Open is enabled once the choices load');
  return open;
}

const pending = (name, group) => ({
  ...C(`${name}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})),
  blocked: 'Not written yet: the Open Company module is completed in document 15 step E11.',
});

export const companyOpen = {
  feature: 'company-open',
  title: 'Company → Open Company (MS_OPNCOMP, /select)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/select/page.tsx',
    'web/apps/web/lib/contextSelection.ts',
    'web/apps/api/src/modules/auth/sessionContextSelection.ts',
    'web/apps/web/test/features/modules/companyOpen.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.lists-choices',
      'T01',
      'read-only',
      'MS_OPNCOMP offers the companies, locations and years the user may open',
      async (ctx) => {
        const { page } = await ctx.session();
        await openSelect(page);
        const company = await page.getByRole('combobox', { name: 'COMPANY' }).inputValue();
        const years = await page
          .getByRole('combobox', { name: 'FINANCIAL YEAR' })
          .locator('option')
          .count();
        assert.equal(company, '01');
        assert.ok(years >= 1, 'at least one year');
        return {
          observation: `company ${company}, ${years} year(s) offered`,
          expected: { company: '01', years: '>= 1' },
        };
      },
    ),
    C(
      'concurrency.sessions-open-at-once',
      'T12',
      'read-only',
      'G172: four sessions of one user pressing Open at the same moment all open the company; none shows a raw code',
      async (ctx) => {
        const sessions = [];
        for (const slot of ['open-1', 'open-2', 'open-3', 'open-4'])
          sessions.push(await ctx.session(as(USERS.admin.user, `company-${slot}`)));
        const buttons = [];
        for (const { page } of sessions) buttons.push(await openSelect(page));
        await Promise.all(buttons.map((button) => button.click()));
        const outcomes = await Promise.all(
          sessions.map(async ({ page }) => {
            try {
              await page.waitForURL(/\/dashboard/, { timeout: 20_000 });
              return 'opened';
            } catch {
              return (await page.locator('body').innerText()).slice(0, 200);
            }
          }),
        );
        assert.deepEqual(
          outcomes,
          ['opened', 'opened', 'opened', 'opened'],
          JSON.stringify(outcomes),
        );
        return {
          observation: `outcomes ${outcomes.join(', ')}`,
          expected: 'all four sessions open the company',
        };
      },
    ),
    pending('branches', 'T02'),
    pending('calculations', 'T03'),
    pending('refusals', 'T04'),
    pending('lines', 'T05'),
    pending('settlement', 'T06'),
    pending('reopen', 'T07'),
    pending('unchanged-save', 'T08'),
    pending('edit', 'T09'),
    pending('delete', 'T10'),
    pending('rights', 'T11'),
    pending('retry', 'T13'),
    pending('rollback', 'T14'),
    pending('settings', 'T15'),
    pending('output', 'T16'),
    pending('keyboard', 'T17'),
    pending('journey', 'T18'),
  ],
};
