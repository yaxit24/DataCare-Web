import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Company → User Create (desktop MS_USER, web Users & Rights).
 *
 * MS_USER keeps a user's category in LOGIN_MAST.LOGIN_CATG ('A' admin, MS_USER.cs:1981-1997, read back at :2485).
 * The web adds one safeguard the desktop does not need (it has a built-in main user): the company may not be left
 * without an administrator (G178), because the only admin demoting themselves locked every admin screen.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `users.${id}`,
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

const category = async (ctx, user) =>
  (
    await ctx.rows(
      `SELECT "LOGIN_CATG" c FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LOGIN_NAME"=$2`,
      user,
    )
  )[0]?.c;

async function openUsers(page) {
  await page.goto('/admin/users');
  await page.getByRole('combobox', { name: `Category for ${USERS.admin.user}` }).waitFor();
}

export const usersRights = {
  feature: 'users',
  title: 'Company → User Create (MS_USER, Users & Rights)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/admin/users/page.tsx',
    'web/apps/api/src/modules/rbac/users.ts',
    'web/apps/web/test/features/modules/usersRights.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.lists-users',
      'T01',
      'read-only',
      'MS_USER lists every login of the company with its category (LOGIN_MAST.LOGIN_CATG, MS_USER.cs:2485)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openUsers(page);
        const adminCategory = await page
          .getByRole('combobox', { name: `Category for ${USERS.admin.user}` })
          .inputValue();
        const clerkCategory = await page
          .getByRole('combobox', { name: `Category for ${USERS.clerk.user}` })
          .inputValue();
        assert.equal(adminCategory, 'ADMIN');
        assert.equal(clerkCategory, 'USER');
        return {
          observation: `${USERS.admin.user} ${adminCategory}, ${USERS.clerk.user} ${clerkCategory}`,
          expected: { [USERS.admin.user]: 'ADMIN', [USERS.clerk.user]: 'USER' },
        };
      },
    ),
    C(
      'rights.clerk-refused',
      'T11',
      'refusal',
      'User Create is an administrator screen: a USER category login is refused (MS_USER opens for admins only)',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.clerk.user));
        const response = page.waitForResponse(
          (r) => /\/api\/admin\/users(\?|$)/.test(r.url()) && r.request().method() === 'GET',
        );
        await page.goto('/admin/users');
        assert.equal((await response).status(), 403);
        await page.getByText('Admin access required', { exact: false }).first().waitFor();
        const clerk = await category(ctx, USERS.clerk.user);
        return {
          observation: 'the clerk is refused with "Admin access required"',
          expected: { status: 403 },
          database: { clerkCategory: clerk },
        };
      },
    ),
    C(
      'rights.last-admin-refused',
      'T04',
      'refusal',
      'G178: the only administrator cannot remove their own admin category; the screen says why and nothing changes',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await category(ctx, USERS.admin.user);
        assert.equal(before, 'ADMIN');
        await openUsers(page);
        await page
          .getByRole('combobox', { name: `Category for ${USERS.admin.user}` })
          .selectOption('USER');
        const row = page.locator('tr', { has: page.getByText(USERS.admin.user, { exact: true }) });
        const response = page.waitForResponse(
          (r) =>
            r.url().includes(`/admin/users/${USERS.admin.user}/rights`) &&
            r.request().method() === 'POST',
        );
        await row.getByRole('button', { name: 'Save', exact: true }).click();
        assert.equal((await response).status(), 400);
        await page.getByText('at least one administrator', { exact: false }).waitFor();
        const after = await category(ctx, USERS.admin.user);
        assert.equal(after, 'ADMIN', 'the category is unchanged');
        // The admin still reaches an admin screen.
        await openUsers(page);
        return {
          observation: `demoting the only admin answered 400 with the reason on screen; LOGIN_CATG still ${after}`,
          expected: { status: 400, category: 'ADMIN' },
          database: { before, after },
        };
      },
    ),
    {
      ...C('branches.pending', 'T02', 'read-only', 'Playbook T02', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('calculations.pending', 'T03', 'read-only', 'Playbook T03', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('lines.pending', 'T05', 'read-only', 'Playbook T05', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('settlement.pending', 'T06', 'read-only', 'Playbook T06', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('reopen.pending', 'T07', 'read-only', 'Playbook T07', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('unchanged-save.pending', 'T08', 'read-only', 'Playbook T08', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('edit.pending', 'T09', 'read-only', 'Playbook T09', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('delete.pending', 'T10', 'read-only', 'Playbook T10', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('concurrency.pending', 'T12', 'read-only', 'Playbook T12', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('retry.pending', 'T13', 'read-only', 'Playbook T13', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('rollback.pending', 'T14', 'read-only', 'Playbook T14', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('settings.pending', 'T15', 'read-only', 'Playbook T15', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('output.pending', 'T16', 'read-only', 'Playbook T16', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('keyboard.pending', 'T17', 'read-only', 'Playbook T17', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
    {
      ...C('journey.pending', 'T18', 'read-only', 'Playbook T18', async () => ({})),
      blocked: 'Not written yet: the Users & Rights module is completed in document 15 step E11.',
    },
  ],
};
