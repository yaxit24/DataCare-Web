import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import { huidUser, seedHuid, cleanHuid } from './huidSeed.mjs';

const C = (suffix, group, source, run) => ({
  id: `huid-report.${suffix}`,
  group,
  kind: 'read-only',
  applicable: true,
  source,
  requiredEvidence: ['browser', 'expected'],
  run: async (ctx) => {
    await seedHuid(ctx);
    try {
      return await run(ctx);
    } finally {
      await cleanHuid(ctx);
    }
  },
});
const open = async (page) => {
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === '/api/reports/huid/defaults'),
    page.goto('/reports/huid'),
  ]);
  await page.getByRole('heading', { name: 'HuId Report', exact: true }).waitFor();
};
const view = async (page) => {
  await page.getByLabel('From', { exact: true }).fill('05/04/2026');
  await page.getByLabel('To', { exact: true }).fill('30/06/2026');
  const [res] = await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === '/api/reports/huid'),
    page.getByRole('button', { name: 'In Tag', exact: true }).click(),
  ]);
  assert.equal(res.status(), 200);
  await page.getByTestId('huid-totals').waitFor();
  return res.json();
};
export const huidResidualCases = [
  C(
    'entry.default-item-type-silver-when-not-gold',
    'T01',
    'MS_OPNCOMP.cs:481-484; RP_HUID.cs:1562-1570: blank/G selects Gold, other metal selects Silver',
    async (ctx) => {
      const [old] = await ctx.rows(
        `SELECT "METAL_TYPE" metal FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      );
      try {
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_MAST" SET "METAL_TYPE"='S' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          ctx.tenantId,
        );
        const { page } = await ctx.session();
        await open(page);
        await page.waitForFunction(() => document.querySelector('#huid-item-type')?.value === 'S');
        assert.equal(await page.getByLabel('Item Type', { exact: true }).inputValue(), 'S');
        const data = await view(page);
        assert.ok(data.rows.length > 0);
        assert.ok(data.rows.every((r) => r.itCode === 'SVC'));
        return {
          observation: 'Silver selected from company metal; only silver rows listed',
          expected: 'Silver',
        };
      } finally {
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_MAST" SET "METAL_TYPE"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          ctx.tenantId,
          old.metal,
        );
      }
    },
  ),
  C(
    'total.weights-rounding-to-precision',
    'T03',
    'RP_HUID.cs:2070-2096 footer sums; BAR_DETL weights DECIMAL(14,3)',
    async (ctx) => {
      await ctx.owner.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "ITM_GWT"=1.2345,"ITM_NWT"=1.1114,"HM_ID_WT"=0.1255
      WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='09' AND "TAG_NO"='TG-001'`,
        ctx.tenantId,
      );
      const { page } = await ctx.session();
      await open(page);
      await page.getByLabel('Tag No', { exact: true }).fill('TG-001');
      const data = await view(page);
      assert.deepEqual(
        [data.totals.grwt, data.totals.netWt, data.totals.huWt],
        ['1.235', '1.111', '0.126'],
      );
      const footer = page.getByTestId('huid-totals');
      assert.equal((await footer.locator('[data-col="grwt"]').innerText()).trim(), '1.235');
      return {
        observation: 'Stored three-decimal weights and footer agree: 1.235 / 1.111 / 0.126',
        expected: ['1.235', '1.111', '0.126'],
      };
    },
  ),
  C(
    'rights.list-right',
    'T11',
    'RP_HUID.cs:1406-1417 reads edit/delete/print only; web report View is enforced by RBAC',
    async (ctx) => {
      const user = USERS.clerk.user;
      const old = await ctx.rows(
        `SELECT "FRM_VIEW" v,"FRM_EDIT" e,"FRM_DELETE" d,"FRM_PRINT" p,"MAIN_MENU" m
      FROM "USER_SET" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='09' AND "USER_NAME"=$2 AND "SUB_MENU"='HuId Report'`,
        user,
      );
      const remove = () =>
        ctx.owner.$executeRawUnsafe(
          `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='09' AND "USER_NAME"=$2 AND "SUB_MENU"='HuId Report'`,
          ctx.tenantId,
          user,
        );
      const grant = (v, e = 'N', d = 'N', p = 'N', m = 'Reports') =>
        ctx.owner.$executeRawUnsafe(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES ($1,'01','09',$2,$3,'HuId Report',$4,$5,$6,$7)`,
          ctx.tenantId,
          user,
          m,
          v,
          e,
          d,
          p,
        );
      try {
        await remove();
        await grant('Y');
        const { page } = await ctx.session(huidUser(user));
        await open(page);
        assert.equal((await view(page)).rows.length, 10);
        await remove();
        await grant('N');
        const res = await page.request.get(
          '/api/reports/huid?view=in&from=2026-04-05&to=2026-06-30',
        );
        assert.equal(res.status(), 403);
        return {
          observation: 'View Y lists 10 rows; View N refuses read',
          expected: '200 then 403',
        };
      } finally {
        await remove();
        for (const r of old) await grant(r.v, r.e, r.d, r.p, r.m);
      }
    },
  ),
  C(
    'labels.title-desktop-text',
    'T16',
    'MDI_FORM.cs:7264,9032; RP_HUID.cs:1408-1409 runtime menu caption',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      assert.equal(await page.getByRole('heading', { level: 1 }).innerText(), 'HuId Report');
      return { observation: 'HuId Report', expected: 'HuId Report' };
    },
  ),
  C('labels.hallmark-options', 'T16', 'RP_HUID.cs:1570-1573', async (ctx) => {
    const { page } = await ctx.session();
    await open(page);
    const options = await page
      .getByLabel('HuId Type', { exact: true })
      .locator('option')
      .allTextContents();
    assert.deepEqual(options, ['All', 'With HuId', 'Whout HuId']);
    return { observation: options.join(', '), expected: ['All', 'With HuId', 'Whout HuId'] };
  }),
  C(
    'output.headers-desktop-aliases',
    'T16',
    'RP_HUID.cs:1761 SELECT aliases, :2038-2046 hidden columns',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await view(page);
      const headers = await page.locator('[role="grid"] thead th').allTextContents();
      const expected = [
        'VchTyp',
        'VchNo',
        'VchDate',
        'TagNo',
        'ItCode',
        'Counter',
        'Qty',
        'Pcs',
        'Grwt',
        'NetWt',
        'HuId',
        'HuWt',
        'HuId2',
        'HuWt2',
        'HuId3',
        'HuWt3',
        'HuId4',
        'HuWt4',
        'KrName',
        'ItRemark',
        'TagId',
      ];
      assert.deepEqual(
        headers.map((v) => v.trim()),
        expected,
      );
      return { observation: headers.join(', '), expected };
    },
  ),
  C(
    'invalid.blank-or-bad-date',
    'T06',
    'DC_Main.cs:1641-1672 SetDate; RP_HUID date handlers',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      const from = page.getByLabel('From', { exact: true });
      await from.fill('32/04/2026');
      await from.press('Enter');
      const dialog = page.getByRole('alertdialog');
      await dialog.waitFor();
      assert.match(await dialog.innerText(), /Date Not Valid/);
      await dialog.getByRole('button', { name: 'OK', exact: true }).click();
      assert.equal(await from.evaluate((el) => document.activeElement === el), true);
      return {
        observation: 'Invalid day refused; focus returns to From',
        expected: 'Date Not Valid...',
      };
    },
  ),
  C(
    'drill.disabled-when-stock-merge-y',
    'T05',
    'RP_HUID.cs:2254-2257 returns before looking up a book',
    async (ctx) => {
      const [old] = await ctx.rows(
        `SELECT "CO_STK_MERGE" merge FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      );
      assert.ok(old, 'fixture company has CO_SET');
      try {
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_SET" SET "CO_STK_MERGE"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          ctx.tenantId,
        );
        const { page } = await ctx.session();
        await open(page);
        await view(page);
        const row = page.locator('[role="grid"] tbody tr').first();
        // The screen's own request (it carries the session context headers a bare request lacks).
        const [res] = await Promise.all([
          page.waitForResponse((r) => new URL(r.url()).pathname === '/api/reports/huid/zoom'),
          row.dblclick(),
        ]);
        assert.equal(res.status(), 404, await res.text());
        await page.waitForTimeout(500);
        assert.equal(new URL(page.url()).pathname, '/reports/huid');
        return {
          observation: 'Merged-stock zoom refused; report remains open',
          expected: 'no voucher navigation',
        };
      } finally {
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_SET" SET "CO_STK_MERGE"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          ctx.tenantId,
          old.merge,
        );
      }
    },
  ),
];
