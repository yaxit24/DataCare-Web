import assert from 'node:assert/strict';
import { SECOND_TENANT, TENANT } from '../harness.mjs';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Frozen Company → Company matrix. Milestone 1 blocks generic CO_MAST writes and replaces the generic editor with
 * a tenant-scoped read-only surface. Identity, provisioning, print, and safe-delete behavior remain future work.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
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
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});
const pending = (id, group, kind, source, reason) => ({
  ...C(`${id}.pending`, group, kind, source, async () => ({})),
  blocked: `Blocked by the known open G38/G39 Company prerequisite or its unavailable downstream stage: ${reason}`,
});
const blocked = (id, group, kind, source, reason) => ({
  ...C(`${id}.blocked`, group, kind, source, async () => ({})),
  blocked: reason,
});
const notApplicable = (id, group, source, reason) => ({
  ...C(`${id}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const MESSAGE =
  'Company uses a dedicated workflow for identity and provisioning; generic create, update, delete, and CSV import are unavailable.';
const EXTRA_COMPANY = { code: '02', name: 'E2E COMPANY TWO' };
const FOREIGN_COMPANY = { code: '98', name: 'FOREIGN COMPANY SENTINEL' };

async function withCompanyFixtures(ctx, { foreign = false } = {}, run) {
  const fixtures = [
    { tenant: TENANT, ...EXTRA_COMPANY },
    ...(foreign ? [{ tenant: SECOND_TENANT, ...FOREIGN_COMPANY }] : []),
  ];
  try {
    for (const fixture of fixtures)
      await ctx.owner.$executeRawUnsafe(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,$3)`,
        fixture.tenant,
        fixture.code,
        fixture.name,
      );
    return await run();
  } finally {
    for (const fixture of fixtures)
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        fixture.tenant,
        fixture.code,
      );
  }
}

const rows = (ctx, table) => {
  const order = table === 'CO_MAST' ? '"CO_CODE"' : 'row_id';
  return ctx.rows(`SELECT to_jsonb(t) row FROM "${table}" t WHERE tenant_id=$1 ORDER BY ${order}`);
};
const representativeDependentRows = async (ctx) => ({
  company: await rows(ctx, 'CO_MAST'),
  locations: await rows(ctx, 'LOCT_MAST'),
  years: await rows(ctx, 'YEAR_MAST'),
  settings: await rows(ctx, 'CO_SET'),
});
async function open(page) {
  const response = page.waitForResponse(
    (item) =>
      item.request().method() === 'GET' &&
      new URL(item.url()).pathname === '/api/context/companies',
  );
  await page.goto('/masters/companies');
  await page.getByRole('heading', { name: 'Company', exact: true }).waitFor();
  assert.equal((await response).status(), 200);
}
async function headers(page) {
  const response = await page.request.get('/api/me');
  assert.equal(response.status(), 200, await response.text());
  const me = await response.json();
  return {
    'x-session-context-id': me.context.sessionId,
    'x-session-context-epoch': me.context.contextEpoch,
  };
}
async function request(page, method, path, data) {
  return page.request.fetch(`/api${path}`, {
    method,
    headers: await headers(page),
    ...(data === undefined ? {} : { data }),
  });
}
const expectedCompanies = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "CO_CODE" code,"CO_NAME" name FROM "CO_MAST" WHERE tenant_id=$1 ORDER BY "CO_CODE"`,
    )
  ).map((row) => [String(row.code), String(row.name ?? '')]);

export const companyMaster = {
  feature: 'company-master',
  title: 'Company → Company (MS_COMPANY), milestone 1 read-only containment',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/companies/page.tsx',
    'web/apps/api/src/modules/masters/configs.ts',
    'web/apps/api/src/modules/masters/master.service.ts',
    'web/apps/api/src/modules/auth/businessScope.ts',
    'web/apps/api/src/app.ts',
    'web/apps/web/test/features/modules/companyMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings:
      'catalogue defaults; no Company business writes; request audits remain expected',
  },
  cases: [
    C(
      'entry.read-only-list',
      'T01',
      'read-only',
      'MS_COMPANY.cs:5704-6001 clears, lists, selects, and displays companies; milestone 1 exposes only Code/Name from authenticated GET /context/companies',
      async (ctx) =>
        withCompanyFixtures(ctx, {}, async () => {
          const { page } = await ctx.session();
          await open(page);
          const listed = await page
            .getByTestId('company-list')
            .locator('tbody tr[data-code]')
            .evaluateAll((items) =>
              items.map((item) =>
                [...item.querySelectorAll('td')].map((cell) => cell.textContent.trim()),
              ),
            );
          const expected = await expectedCompanies(ctx);
          assert.deepEqual(
            listed.map(([code, name]) => [code, name.replace(/\s*\(Current\)$/, '')]),
            expected,
          );
          assert.equal(await page.locator('#company-code').inputValue(), '01');
          assert.equal(
            await page.locator('#current-company').inputValue(),
            'Current session company',
          );
          const main = page.locator('main');
          for (const name of ['New', 'Edit', 'Delete', 'CSV'])
            assert.equal(await main.getByRole('button', { name, exact: true }).count(), 0);

          const search = page.getByLabel('Search company');
          await search.fill(EXTRA_COMPANY.name);
          const other = page
            .getByTestId('company-list')
            .locator(`tbody tr[data-code="${EXTRA_COMPANY.code}"]`);
          assert.equal(await other.count(), 1);
          assert.equal(await other.getAttribute('tabindex'), '0');
          assert.equal(await other.getAttribute('aria-selected'), 'true');
          assert.equal(await page.locator('#company-code').inputValue(), EXTRA_COMPANY.code);
          assert.equal(await page.locator('#company-name').inputValue(), EXTRA_COMPANY.name);
          await page.keyboard.press('Tab');
          assert.equal(await other.evaluate((row) => row === document.activeElement), true);

          await search.fill('NO SUCH COMPANY');
          assert.equal(
            await page.getByTestId('company-list').locator('tbody tr[data-code]').count(),
            0,
          );
          await page.getByText('No companies match the search.', { exact: true }).waitFor();
          assert.equal(await page.locator('#company-code').inputValue(), '');
          assert.equal(await page.locator('#company-name').inputValue(), '');
          return {
            observation:
              'scoped company rows rendered; filtering moved the active details and Tab stop to company 02, then no match cleared details',
            expected: {
              companies: expected,
              current: '01',
              filtered: EXTRA_COMPANY,
              noMatchDetails: { code: '', name: '' },
              actions: [],
            },
          };
        }),
    ),
    C(
      'fields.complete-round-trip',
      'T02',
      'mutation',
      'MS_COMPANY.cs:5882-6001,6074-6189 reads and writes the complete CO_MAST identity field set',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        const newAction = page.getByRole('button', { name: 'New', exact: true });
        assert.equal(
          await newAction.count(),
          1,
          'Company requires the desktop New action to begin editable identity entry',
        );
        await newAction.click();
        for (const label of ['Name', 'Address 1', 'State', 'City', 'GST No', 'PAN No'])
          assert.equal(
            await page.getByLabel(label, { exact: true }).isEditable(),
            true,
            `${label} must be editable in the Company identity workflow`,
          );
        return {
          observation: 'the rich Company identity workflow is available and editable',
          expected: { action: 'New', editableIdentityFields: 6 },
        };
      },
      {
        expected: {
          route: '/masters/companies',
          action: 'New',
          editableIdentityFields: ['Name', 'Address 1', 'State', 'City', 'GST No', 'PAN No'],
        },
        observe: (ctx) => rows(ctx, 'CO_MAST'),
      },
    ),
    notApplicable(
      'formula',
      'T03',
      'MS_COMPANY.cs:6022-6227',
      'Company identity has no source-defined arithmetic or rounding result.',
    ),
    pending(
      'lookup.state-and-clone',
      'T04',
      'read-only',
      'MS_COMPANY.cs:6484-6745; MS_YEAR.cs:1504-1595 selects state and optional source company',
      'state help and source-company clone lookups are not implemented',
    ),
    notApplicable(
      'children',
      'T05',
      'MS_COMPANY.cs:5704-6227',
      'MS_COMPANY has no editable child grid; copied master families belong to the atomic provisioning write set.',
    ),
    pending(
      'required.company-detail',
      'T06',
      'refusal',
      'MS_COMPANY.cs:6069-6072 says exactly "Enter Company Detail" when code or name is blank',
      'the dedicated save command is not implemented',
    ),
    pending(
      'duplicate.code',
      'T06',
      'refusal',
      "MS_COMPANY.cs:6022-6033 says `This Company Code already Exist in  '<name>'  Company Name...Please Change Company Code...`",
      'duplicate-code validation awaits the dedicated writer',
    ),
    pending(
      'duplicate.name',
      'T06',
      'refusal',
      "MS_COMPANY.cs:6756-6769 says `This Company Name already Exist in  '<code>'  Company Code...Please Change Company Name...`",
      'duplicate-name validation awaits the dedicated writer',
    ),
    pending(
      'edition.lite-basic-limits',
      'T06',
      'refusal',
      'MS_COMPANY.cs:6049-6067 gives exact Lite and Basic company-count refusal messages',
      'edition-aware dedicated create is not implemented',
    ),
    pending(
      'length.control-and-schema',
      'T06',
      'refusal',
      'MS_COMPANY.cs:6022-6227 plus CO_MAST schema field widths define the complete boundary set',
      'the rich form has no accepted normalized length contract yet',
    ),
    notApplicable(
      'malformed-gst-pan',
      'T06',
      'MS_COMPANY.cs:6484-6745 moves through GST and PAN without a format refusal',
      'No malformed GST/PAN refusal exists in the desktop source; inventing one would not be parity.',
    ),
    blocked(
      'gst-length-discrepancy',
      'T06',
      'refusal',
      'MS_COMPANY identity controls permit a wider GST value while schema.prisma CO_GST_NO is varchar(15)',
      'Blocked pending an accepted decision on the recorded 16–30 character UI/schema discrepancy.',
    ),
    pending(
      'create.full-write-set',
      'T07',
      'mutation',
      'MS_COMPANY.cs:6074-6218; MS_YEAR.cs:1170-1400,1504-1595 writes CO_MAST, YEAR_MAST and all 17 copied master families',
      'atomic identity, first-year, and 17-family provisioning are not implemented',
    ),
    pending(
      'reopen-no-op',
      'T08',
      'mutation',
      'MS_COMPANY.cs:5882-6001 reloads the complete row before an edit save',
      'lossless reopen and unchanged save require the dedicated writer',
    ),
    pending(
      'edit-no-reseed-headers',
      'T09',
      'mutation',
      'MS_COMPANY.cs:6194-6227 opens MS_YEAR only for add mode; existing companies clear and reopen after save',
      'versioned identity edit, no-reseed proof, and downstream header proof are not implemented',
    ),
    C(
      'delete.generic-contained',
      'T10',
      'refusal',
      'MS_COMPANY.cs:6254-6418 is an unsafe broad cascade; milestone 1 blocks generic DELETE before it can orphan dependent rows',
      async (ctx) => {
        const before = await representativeDependentRows(ctx);
        const { page } = await ctx.session();
        await open(page);
        const response = await request(page, 'DELETE', '/masters/companies', { CO_CODE: '01' });
        assert.equal(response.status(), 400, await response.text());
        assert.deepEqual(await response.json(), { error: 'dedicated-writer', message: MESSAGE });
        const after = await representativeDependentRows(ctx);
        assert.deepEqual(after, before);
        return {
          observation:
            'generic DELETE returned dedicated-writer; representative Company/dependent rows unchanged',
          expected: { status: 400, error: 'dedicated-writer', message: MESSAGE },
          database: after,
        };
      },
    ),
    pending(
      'cancel',
      'T10',
      'read-only',
      'MS_COMPANY.cs:6791-6822 Cancel invokes CLEAR_DATA',
      'editable form cancel is not implemented',
    ),
    blocked(
      'delete.safe-decision',
      'T10',
      'refusal',
      'MS_COMPANY.cs:6254-6418 deletes a large unscoped table cascade',
      'Blocked: no accepted safe hosted-company deletion decision exists; the desktop cascade must not be ported.',
    ),
    C(
      'scope.generic-create-update-contained',
      'T11',
      'refusal',
      'MDI_FORM.cs:7032-7049,7411-7420 gates Company by caption; generic writes cannot bypass the dedicated workflow',
      async (ctx) => {
        const before = await representativeDependentRows(ctx);
        const { page } = await ctx.session();
        await open(page);
        const outcomes = [];
        for (const [method, data] of [
          ['POST', { CO_CODE: '02', CO_NAME: 'UNSAFE CREATE' }],
          ['PUT', { CO_CODE: '01', CO_NAME: 'UNSAFE UPDATE' }],
        ]) {
          const response = await request(page, method, '/masters/companies', data);
          outcomes.push({ status: response.status(), body: await response.json() });
        }
        const expectedOutcomes = [
          { status: 409, body: { error: 'scope-mismatch' } },
          { status: 400, body: { error: 'dedicated-writer', message: MESSAGE } },
        ];
        assert.deepEqual(outcomes, expectedOutcomes);
        const after = await representativeDependentRows(ctx);
        assert.deepEqual(after, before);
        return {
          observation:
            'cross-company POST returned scope-mismatch before the writer; same-company PUT returned dedicated-writer; representative Company/dependent rows unchanged',
          expected: expectedOutcomes,
          database: after,
        };
      },
    ),
    C(
      'rights.caption-admin-tenant',
      'T11',
      'read-only',
      'MDI_FORM.cs:7032-7049 reads USER_SET by the Company caption; tenant isolation is a web safety requirement',
      async (ctx) =>
        withCompanyFixtures(ctx, { foreign: true }, async () => {
          const { page: adminPage } = await ctx.session();
          await open(adminPage);
          const adminCodes = await adminPage
            .getByTestId('company-list')
            .locator('tbody tr[data-code]')
            .evaluateAll((items) => items.map((item) => item.getAttribute('data-code')));
          assert.deepEqual(adminCodes, ['01', EXTRA_COMPANY.code]);
          assert.equal(adminCodes.includes(FOREIGN_COMPANY.code), false);

          const { page: restrictedPage } = await ctx.session(
            as(USERS.clerk.user, 'company-master-scoped-clerk'),
          );
          await open(restrictedPage);
          const restrictedCodes = await restrictedPage
            .getByTestId('company-list')
            .locator('tbody tr[data-code]')
            .evaluateAll((items) => items.map((item) => item.getAttribute('data-code')));
          assert.deepEqual(restrictedCodes, ['01']);
          return {
            observation:
              'admin listed companies 01 and 02 only in the feature tenant; the existing clerk assigned only to 01 listed only 01; second-tenant company 98 stayed hidden',
            expected: {
              admin: ['01', EXTRA_COMPANY.code],
              restricted: ['01'],
              hiddenForeignTenant: FOREIGN_COMPANY.code,
            },
            database: {
              sameTenantFixture: EXTRA_COMPANY,
              foreignTenantFixture: FOREIGN_COMPANY,
              restrictedLogin: USERS.clerk.user,
            },
          };
        }),
    ),
    pending(
      'concurrency.version',
      'T12',
      'refusal',
      'Web contract D17 requires versioned master edits; MS_COMPANY.cs:5882-6001 establishes open-before-edit state',
      'the dedicated version token and stale-save refusal are not implemented',
    ),
    C(
      'retry.csv-contained',
      'T13',
      'refusal',
      'Generic CSV import delegates each row to createMaster; Company dedicatedWriter must prevent every row from writing',
      async (ctx) => {
        const before = await representativeDependentRows(ctx);
        const { page } = await ctx.session();
        await open(page);
        const response = await request(page, 'POST', '/masters/companies/import', {
          rows: [{ CO_CODE: '02', CO_NAME: 'UNSAFE IMPORT' }],
        });
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(await response.json(), {
          created: 0,
          failed: 1,
          errors: [{ row: 1, error: 'error' }],
        });
        const after = await representativeDependentRows(ctx);
        assert.deepEqual(after, before);
        return {
          observation:
            'CSV row reached the blocked writer; created 0 and representative rows stayed unchanged',
          expected: { created: 0, failed: 1, errors: [{ row: 1, error: 'error' }] },
          database: after,
        };
      },
    ),
    pending(
      'retry.idempotent-command',
      'T13',
      'mutation',
      'MS_COMPANY.cs:6042-6227 saves once; web command contract additionally requires idempotent retry',
      'dedicated identity/provision command does not exist',
    ),
    pending(
      'rollback.per-stage',
      'T14',
      'mutation',
      'MS_COMPANY.cs:6074-6218 and MS_YEAR.cs:1504-1595 define a multi-family write set that the web must make atomic',
      'fault injection for each identity/provision stage awaits that transaction',
    ),
    pending(
      'snapshot.source-company',
      'T15',
      'mutation',
      'MS_YEAR.cs:1504-1595 copies either the selected old company or constrained company 01 defaults',
      'pinned source snapshot behavior is not implemented',
    ),
    pending(
      'history.fiscal-boundary',
      'T15',
      'mutation',
      'MS_YEAR.cs:1170-1400 creates YEAR_MAST with opening/closing dates before NewCompParmCreat',
      'first-year fiscal boundary behavior is not implemented',
    ),
    pending(
      'print.company-rpt',
      'T16',
      'output',
      'MS_COMPANY.cs:6776-6790 selects Company.RPT; extraction_output/rpt_xml/Company.xml:99-305 orders code, name, address 1/2, state, city',
      'semantic Company.rpt print is not implemented',
    ),
    C(
      'keyboard.read-only-selection',
      'T17',
      'read-only',
      'MS_COMPANY.cs:6428-6477 uses Enter and arrows in the company list',
      async (ctx) =>
        withCompanyFixtures(ctx, {}, async () => {
          const { page } = await ctx.session();
          await open(page);
          const first = page.getByTestId('company-list').locator('tbody tr[data-code="01"]');
          const second = page
            .getByTestId('company-list')
            .locator(`tbody tr[data-code="${EXTRA_COMPANY.code}"]`);
          await second.focus();
          assert.equal(await second.getAttribute('aria-selected'), 'false');
          await second.press('Enter');
          assert.equal(await second.getAttribute('aria-selected'), 'true');
          assert.equal(await page.locator('#company-code').inputValue(), EXTRA_COMPANY.code);
          assert.equal(await page.locator('#company-name').inputValue(), EXTRA_COMPANY.name);
          await second.press('ArrowUp');
          assert.equal(await first.evaluate((row) => row === document.activeElement), true);
          assert.equal(await first.getAttribute('aria-selected'), 'true');
          assert.equal(await page.locator('#company-code').inputValue(), '01');
          await first.press('ArrowDown');
          assert.equal(await second.evaluate((row) => row === document.activeElement), true);
          assert.equal(await second.getAttribute('aria-selected'), 'true');
          assert.equal(await page.locator('#company-code').inputValue(), EXTRA_COMPANY.code);
          return {
            observation:
              'Enter selected focused company 02; ArrowUp moved focus/selection to 01 and ArrowDown restored 02',
            expected: {
              selected: ['01', EXTRA_COMPANY.code, '01', EXTRA_COMPANY.code],
              focusFlow: 'focus row 02 Enter -> ArrowUp row 01 -> ArrowDown row 02',
            },
          };
        }),
    ),
    pending(
      'keyboard.full-workflow',
      'T17',
      'mutation',
      'MS_COMPANY.cs:6428-6745,7211-7276 defines full Enter, F1, Ctrl and tab flow',
      'the full editable keyboard workflow awaits the rich form',
    ),
    pending(
      'journey.login-new-company-voucher',
      'T18',
      'mutation',
      'MS_COMPANY.cs:6194-6218 opens Year Create; MS_YEAR.cs:1170-1400,1504-1595 enables reopen/login and real work',
      'new-company login and real-voucher journey await atomic provisioning',
    ),
    blocked(
      'desktop-runtime-comparison',
      'T18',
      'read-only',
      'Feature evidence contract requires original Windows runtime comparison for desktop-match credit',
      'Blocked: no original desktop-runtime comparison has been executed; desktop-match remains 0%.',
    ),
  ],
};
