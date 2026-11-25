import assert from 'node:assert/strict';
import { SECOND_TENANT, TENANT } from '../harness.mjs';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Frozen Company → Company matrix. WP-07 adds the desktop New/Edit/Save/reopen identity workflow (MS_COMPANY) and
 * the OD-5 soft delete; generic CO_MAST writes stay blocked so only the dedicated versioned writer runs.
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
// A login without the Company FRM_VIEW right never opens the form on the desktop (MDI_FORM.cs:7032-7049 shows
// "You Have No Rights....." and returns), so the web page stays blank with that message while the list still loads.
async function open(page, { noRights = false } = {}) {
  const response = page.waitForResponse(
    (item) =>
      item.request().method() === 'GET' &&
      new URL(item.url()).pathname === '/api/context/companies',
  );
  await page.goto('/masters/companies');
  await page.getByRole('heading', { name: 'Company', exact: true }).waitFor();
  assert.equal((await response).status(), 200);
  if (noRights) {
    await page.getByRole('status').filter({ hasText: 'You Have No Rights.....' }).waitFor();
    assert.equal(await page.locator('#company-code').inputValue(), '');
    return;
  }
  await page.waitForFunction(() => document.querySelector('#company-code')?.value === '01');
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
  title: 'Company → Company (MS_COMPANY): identity workflow and OD-5 delete',
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
    C('entry.read-only-list', 'T01', 'read-only', 'MS_COMPANY.cs:5704-6001', async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await page.getByRole('button', { name: 'New', exact: true }).waitFor();
      await page.getByLabel('Name', { exact: true }).waitFor();
      return {
        observation: 'Company list and identity actions displayed',
        expected: { actions: ['New', 'Edit', 'Save', 'Delete'] },
      };
    }),
    C(
      'fields.complete-round-trip',
      'T02',
      'mutation',
      'MS_COMPANY.cs:5882-6001,6074-6189',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        for (const label of ['Name', 'Address 1', 'State', 'City', 'GST No', 'PAN No'])
          assert.equal(await page.getByLabel(label, { exact: true }).isEditable(), true);
        // Lite cannot save a second company. Exercise New, then edit the default company's identity.
        await page.getByRole('button', { name: 'Cancel', exact: true }).click();
        await page.getByRole('button', { name: 'Edit', exact: true }).click();
        const values = {
          Name: 'IDENTITY ROUND TRIP',
          'Address 1': 'TEST ROAD',
          'Address 2': 'TEST FLOOR',
          'Address 3': 'TEST AREA',
          Country: 'INDIA',
          'State Code': '24',
          State: 'GUJARAT',
          City: 'SURAT',
          'Pin Code': '395001',
          Phone: '111111',
          'Phone 2': '222222',
          Mobile: '333333',
          'Mobile 2': '444444',
          Email: 'TEST@EXAMPLE.INVALID',
          Jurisdiction: 'SURAT',
          'GST No': '24ABCDE1234F1Z5',
          'CST No': 'CST TEST',
          'PAN No': 'ABCDE1234F',
          'Dhiran No': 'DH TEST',
          'Bank Name': 'TEST BANK',
          'Bank Area': 'TEST BRANCH',
          'Bank Account No': '123456',
          'RTGS No': 'TEST0001',
          'Company Type': 'A',
        };
        for (const [label, value] of Object.entries(values))
          await page.getByLabel(label, { exact: true }).fill(value);
        await page.getByLabel('Report Header', { exact: true }).selectOption('B');
        await page.getByLabel('Work Type', { exact: true }).selectOption('W');
        await page.getByLabel('Metal Type', { exact: true }).selectOption('S');
        await page.getByRole('button', { name: 'Save', exact: true }).click();
        await page.getByText('Data Are Saved.', { exact: true }).waitFor();
        await page.reload();
        for (const [label, value] of Object.entries(values)) {
          await page.getByLabel(label, { exact: true }).waitFor();
          assert.equal(await page.getByLabel(label, { exact: true }).inputValue(), value);
        }
        for (const [label, value] of Object.entries({
          'Report Header': 'B',
          'Work Type': 'W',
          'Metal Type': 'S',
        }))
          assert.equal(await page.getByLabel(label, { exact: true }).inputValue(), value);
        const identityKeys = [
          'CO_NAME',
          'CO_ADD1',
          'CO_ADD2',
          'CO_ADD3',
          'CO_COUNTRY',
          'CO_STATE_CODE',
          'CO_STATE',
          'CO_CITY',
          'CO_PIN',
          'CO_PHONE',
          'CO_PHONE2',
          'CO_MOBILE',
          'CO_MOBILE2',
          'CO_MAIL',
          'CO_JUD',
          'CO_GST_NO',
          'CO_CSTNO',
          'CO_PAN_NO',
          'DHIRAN_NO',
          'BANK_NAME',
          'BANK_AREA',
          'BANK_AC_NO',
          'BANK_RTGS_NO',
          'CO_TYPE',
        ];
        const database = await ctx.rows(
          `SELECT ${identityKeys.map((key) => '"' + key + '"').join(',')},"REP_ADD_TYPE","WORK_TYPE","METAL_TYPE" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        assert.deepEqual(database, [
          {
            ...Object.fromEntries(
              identityKeys.map((key, index) => [key, Object.values(values)[index]]),
            ),
            REP_ADD_TYPE: 'B',
            WORK_TYPE: 'W',
            METAL_TYPE: 'S',
          },
        ]);
        return {
          observation: 'New permits identity entry; all identity fields survive save and reload',
          expected: values,
          database,
          downstream: { companyHeader: database[0].CO_NAME },
        };
      },
      { observe: (ctx) => rows(ctx, 'CO_MAST') },
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
    C(
      'reopen-no-op.pending',
      'T08',
      'mutation',
      'MS_COMPANY.cs:5882-6001',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        await page.getByRole('button', { name: 'Edit', exact: true }).click();
        const before = await representativeDependentRows(ctx);
        await page.getByRole('button', { name: 'Save', exact: true }).click();
        await page.getByText('Data Are Saved.', { exact: true }).waitFor();
        const database = await representativeDependentRows(ctx);
        assert.deepEqual(database, before);
        return {
          observation: 'Unchanged save preserved identity and dependent rows',
          expected: before,
          database,
          downstream: database,
        };
      },
      { observe: (ctx) => rows(ctx, 'CO_MAST') },
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
    C('cancel.pending', 'T10', 'read-only', 'MS_COMPANY.cs:6791-6822', async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await page.getByRole('button', { name: 'Edit', exact: true }).click();
      const name = await page.getByLabel('Name', { exact: true }).inputValue();
      await page.getByLabel('Name', { exact: true }).fill('CANCELLED CHANGE');
      await page.getByRole('button', { name: 'Cancel', exact: true }).click();
      await page.waitForFunction(
        (value) => document.querySelector('#company-CO_NAME')?.value === value,
        name,
      );
      assert.equal(await page.getByLabel('Name', { exact: true }).isEditable(), false);
      return { observation: 'Cancel discarded unsaved identity', expected: { name } };
    }),
    C(
      'delete.safe-decision.blocked',
      'T10',
      'refusal',
      'MS_COMPANY.cs:6254-6280; OD-5/D38',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        await page.getByRole('button', { name: 'Edit', exact: true }).waitFor({ state: 'visible' });
        const before = await representativeDependentRows(ctx);
        await page.getByRole('button', { name: 'Delete', exact: true }).click();
        await page.getByText('You cant Delete Defoult company...', { exact: true }).waitFor();
        const database = await representativeDependentRows(ctx);
        assert.deepEqual(database, before);
        return {
          observation: 'Default-company delete refused before confirmation',
          expected: before,
          database,
        };
      },
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
          await open(restrictedPage, { noRights: true });
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
      'keyboard.enter-opens-company',
      'T17',
      'read-only',
      'MS_COMPANY.cs:6428-6477 opens the focused company from the list with Enter',
      async (ctx) =>
        withCompanyFixtures(ctx, {}, async () => {
          const { page } = await ctx.session();
          await open(page);
          const second = page
            .getByTestId('company-list')
            .locator(`tbody tr[data-code="${EXTRA_COMPANY.code}"]`);
          await second.focus();
          await second.press('Enter');
          await page.waitForFunction(() => document.querySelector('#company-code')?.value === '02');
          assert.equal(
            await page.getByLabel('Name', { exact: true }).inputValue(),
            EXTRA_COMPANY.name,
          );
          return {
            observation: 'Enter on focused company 02 opened its identity in the form',
            expected: { code: EXTRA_COMPANY.code, name: EXTRA_COMPANY.name },
          };
        }),
    ),
    C(
      'duplicate.group-name',
      'T06',
      'refusal',
      'MS_GROUP.cs:2029-2041 and MS_AC_GROUP.cs:1695-1712 tGrName_Validating: a group name another code already uses is refused with the other code in the message; an edit that keeps its own name is allowed',
      async (ctx) => {
        const { page } = await ctx.session();
        const post = (path, data) => request(page, 'POST', path, data);
        const body = async (response) => ({
          status: response.status(),
          json: await response.json(),
        });
        const mark = async () => [
          await ctx.rows(
            `SELECT "AC_GR" c,"AC_GR_NAME" n FROM "AC_GROUP" WHERE tenant_id=$1 AND "AC_GR" LIKE 'Z%' ORDER BY 1`,
          ),
          await ctx.rows(
            `SELECT "GR_CODE" c,"GR_NAME" n FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" LIKE 'Z%' ORDER BY 1`,
          ),
        ];
        try {
          // Account group, in the screen: the second code with the same name shows the desktop message.
          assert.equal(
            (await post('/masters/ac-groups', { AC_GR: 'Z1', AC_GR_NAME: 'ZDUP ACC' })).status(),
            201,
          );
          await page.goto('/masters/ac-groups');
          await page.getByRole('button', { name: '+ New', exact: true }).click();
          await page.locator('.field:has(> label:text-is("A/c Group *")) input').fill('Z2');
          await page
            .locator('.field:has(> label:text-is("A/c Group Name")) input')
            .fill('zdup acc');
          await page.getByRole('button', { name: 'Save', exact: true }).click();
          const shown = await page.locator('.msg.err').textContent();
          assert.equal(
            shown.trim(),
            "This Group Name already Exist in  'Z1'  Group Code...Please Change Gr Name...",
          );
          // Item group, through the generic route: the same refusal in the Item Group words.
          assert.equal(
            (
              await post('/masters/groups', { GR_CODE: 'Z1', GR_NAME: 'ZDUP ITEM', GR_TYPE: 'G' })
            ).status(),
            201,
          );
          const refused = await body(
            await post('/masters/groups', { GR_CODE: 'Z2', GR_NAME: 'ZDUP ITEM', GR_TYPE: 'G' }),
          );
          assert.deepEqual(refused, {
            status: 409,
            json: {
              error: 'duplicate-key',
              message:
                "This Group Name already Exist in  'Z1'  Group Code... Please Change Group Name...",
            },
          });
          // Keeping its own name on an edit is allowed.
          const edit = await request(page, 'PUT', '/masters/groups', {
            GR_CODE: 'Z1',
            GR_NAME: 'ZDUP ITEM',
            GR_TYPE: 'S',
          });
          assert.equal(edit.status(), 200, await edit.text());
          const database = await mark();
          assert.deepEqual(database, [[{ c: 'Z1', n: 'ZDUP ACC' }], [{ c: 'Z1', n: 'ZDUP ITEM' }]]);
          return {
            observation: `refused: ${shown.trim()} | ${refused.json.message}; own-name edit saved`,
            expected: 'both desktop messages, one row each, own-name edit accepted',
            database: { rows: database },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "AC_GROUP" WHERE tenant_id=$1 AND "AC_GR" LIKE 'Z%'`,
            TENANT,
          );
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" LIKE 'Z%'`,
            TENANT,
          );
        }
      },
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
