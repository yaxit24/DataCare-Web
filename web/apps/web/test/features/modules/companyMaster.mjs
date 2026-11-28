import assert from 'node:assert/strict';
import { SECOND_TENANT, TENANT, purgeCompany } from '../harness.mjs';
import { changedTables, tenantFingerprint, withWriteFault } from '../faults.mjs';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Frozen Company → Company matrix. WP-07 adds the desktop New/Edit/Save/reopen identity workflow (MS_COMPANY) and
 * the OD-5 soft delete; generic CO_MAST writes stay blocked so only the dedicated versioned writer runs.
 * The ids keep the `.pending` suffix they were frozen with; those cases now run against the WP-07 writer (#284).
 * The feature stack has no edition gate (harness.mjs buildApp), so a new company can be created on the screen; the
 * Lite and Basic count refusals are database-layer cases (companyIdentity.db.test.ts).
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
// The page draws an empty form first and fills it when GET /company-identity/<code> answers, so a field is read
// only once the current company (01) is displayed. A label that exists is not enough: the input is in the DOM
// before its value is set.
const recordShown = (page) =>
  page.waitForFunction(() => document.querySelector('#company-code')?.value === '01');
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
  await recordShown(page);
}
// tCoType is disabled until Ctrl+O (MS_COMPANY.cs:4253,6471-6476), which also disables Save until Enter on it
// (:7279-7290).
async function fillCompanyType(page, value) {
  await page.keyboard.press('Control+o');
  const box = page.getByLabel('Company Type', { exact: true });
  await box.fill(value);
  await box.press('Enter');
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

// ---- Shared by the identity cases (WP-07 writer, #284) ----
/** Every identity column the dedicated writer saves (companyIdentity.ts COMPANY_FIELDS without CO_CODE). */
const IDENTITY_KEYS = [
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
  'CO_CSTNO',
  'CO_GST_NO',
  'CO_PAN_NO',
  'DHIRAN_NO',
  'BANK_NAME',
  'BANK_AREA',
  'BANK_AC_NO',
  'BANK_RTGS_NO',
  'CO_TYPE',
  'REP_ADD_TYPE',
  'WORK_TYPE',
  'METAL_TYPE',
];
/** Desktop control MaxLength of each identity box (MS_COMPANY.cs designer lines), the UI half of the boundary. */
const DESKTOP_MAX = {
  CO_CODE: 2, // :4562 tCoCode
  CO_NAME: 50, // :4555 tCoName
  CO_ADD1: 50, // :4460
  CO_ADD2: 50, // :4452
  CO_ADD3: 50, // :4444
  CO_COUNTRY: 25, // :4393
  CO_STATE_CODE: 2, // :4274
  CO_STATE: 25, // :4375 TState
  CO_CITY: 25, // :4436
  CO_PIN: 10, // :4468
  CO_PHONE: 15, // :4428
  CO_PHONE2: 15, // :4357
  CO_MOBILE: 15, // :4420
  CO_MOBILE2: 15, // :4339
  CO_MAIL: 50, // :4412
  CO_JUD: 30, // :4720
  CO_CSTNO: 30, // :4754
  CO_GST_NO: 30, // :4762 (the column is narrower; the smaller bound wins)
  CO_PAN_NO: 30, // :4738
  DHIRAN_NO: 30, // :4746
  BANK_NAME: 50, // :4979
  BANK_AREA: 40, // :4971
  BANK_AC_NO: 30, // :4963
  BANK_RTGS_NO: 30, // :4955
  CO_TYPE: 1, // :4256
};
const company01 = async (ctx) =>
  (
    await ctx.rows(
      `SELECT ${IDENTITY_KEYS.map((key) => '"' + key + '"').join(',')} FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    )
  )[0];
/** Run a case that edits company 01 and always put its identity back, even when an assertion fails. */
async function keepCompany01(ctx, run) {
  const original = await company01(ctx);
  try {
    return await run(original);
  } finally {
    await ctx.owner.$executeRawUnsafe(
      `UPDATE "CO_MAST" SET ${IDENTITY_KEYS.map((key, i) => '"' + key + '"=$' + (i + 2)).join(',')} WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
      ...IDENTITY_KEYS.map((key) => original[key] ?? null),
    );
  }
}
/** The page's message line (role=status, class msg) showing exactly this text. */
async function shownMessage(page, text) {
  const line = page.locator('div.msg[role="status"]');
  await line.filter({ hasText: text }).waitFor();
  assert.equal((await line.textContent()).trim(), text);
  return text;
}
async function saveIdentity(page) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        ['POST', 'PUT'].includes(r.request().method()) &&
        new URL(r.url()).pathname === '/api/company-identity',
    ),
    page.getByRole('button', { name: 'Save', exact: true }).click(),
  ]);
  return response;
}
const companyFootprint = async (ctx) => ({
  ...(await representativeDependentRows(ctx)),
  yearCount: (await ctx.rows(`SELECT count(*)::int n FROM "YEAR_MAST" WHERE tenant_id=$1`))[0].n,
});
/** An injected database fault answers 500 and the browser logs exactly that one failed load. */
function acceptOne500(session, response) {
  if (response.status() < 500) return;
  assert.deepEqual(session.consoleErrors, [
    'Failed to load resource: the server responded with a status of 500 (Internal Server Error)',
  ]);
  session.consoleErrors.length = 0;
}
/** The company the create cases make through the screen; purgeCompany removes every row it gets. */
const NEW_COMPANY = { code: '07', name: 'E2E NEW COMPANY', year: '2026-2027' };
const DEFAULT_GROUPS = "('916','DM','EM','FGL','FSL','GO','OG','ORD','OS','OT','SL','SN')";
const DEFAULT_ITEMS = "('999','DM','EM','FSL','HM','OG','ORG','ORS','OS','OT','RD','SN')";
const DEFAULT_PRODUCTS = "('DM','EM','FN','HM','OD','OG','OR','OS','OT','RD','SN')";
const NUMERIC_BELOW_101 = `CASE WHEN "AC_CODE" ~ '^[0-9]+$' THEN "AC_CODE"::numeric < 101 ELSE false END`;
/**
 * The source rows NewCompParmCreat copies, per family, as [source company, extra WHERE]: the blank old-company branch
 * (MS_YEAR.cs:1555-1591) or the selected old company (:1508-1553, AC_MAST by the Import All Party answer :1512-1521).
 */
function desktopCopySources(oldCo, importAll) {
  if (!oldCo)
    return {
      AC_GROUP: ['01', ''],
      AC_MAST: ['01', ` AND "LC_CODE"='00' AND ${NUMERIC_BELOW_101}`],
      BAL_GR: ['01', ''],
      BOOK_DATA: ['01', ` AND "LC_CODE"='00'`],
      BOOK_DETL: ['01', ` AND "LC_CODE"='00'`],
      CO_SET: ['01', ''],
      CO_SET_NEW: ['01', ''],
      COL_MAST: ['01', ''],
      CONV_MAST: ['01', ''],
      EMP_MAST: ['01', ` AND "EMP_CODE"='001'`],
      GROUP_MAST: ['01', ` AND "GR_CODE" IN ${DEFAULT_GROUPS}`],
      ITEM_MAST: ['01', ` AND "IT_CODE" IN ${DEFAULT_ITEMS}`],
      LOCT_MAST: ['01', ` AND "LC_CODE"='00'`],
      PRINT_MAST: ['01', ''],
      PRODUCT_MAST: ['01', ` AND "PR_CODE" IN ${DEFAULT_PRODUCTS}`],
      TABLE_MAST: ['01', ` AND "TABLE_CODE"='001'`],
      TAX_MAST: ['01', ''],
    };
  const all = (extra = '') => [oldCo, extra];
  return {
    AC_GROUP: all(),
    AC_MAST: importAll
      ? all(` AND "LC_CODE"='00'`)
      : ['01', ` AND "LC_CODE"='00' AND "AC_CODE" < '00101'`],
    BAL_GR: all(),
    BOOK_DATA: all(` AND "LC_CODE"='00'`),
    BOOK_DETL: all(` AND "LC_CODE"='00'`),
    CO_SET: all(),
    CO_SET_NEW: all(),
    COL_MAST: all(),
    CONV_MAST: all(),
    EMP_MAST: all(),
    GROUP_MAST: all(),
    ITEM_MAST: all(),
    LOCT_MAST: ['01', ` AND "LC_CODE"='00'`],
    PRINT_MAST: all(),
    PRODUCT_MAST: all(),
    TABLE_MAST: all(),
    TAX_MAST: all(),
  };
}
const countWhere = async (ctx, table, coCode, extra = '') =>
  (
    await ctx.rows(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2${extra}`,
      coCode,
    )
  )[0].n;
async function expectedCopy(ctx, oldCo, importAll) {
  const out = {};
  for (const [table, [source, extra]] of Object.entries(desktopCopySources(oldCo, importAll)))
    out[table] = await countWhere(ctx, table, source, extra);
  return out;
}
async function copiedCounts(ctx, coCode) {
  const out = {};
  for (const table of Object.keys(desktopCopySources('')))
    out[table] = await countWhere(ctx, table, coCode);
  return out;
}
const accountCodes = async (ctx, coCode) =>
  (
    await ctx.rows(
      `SELECT "AC_CODE" c FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
      coCode,
    )
  ).map((row) => row.c);
/**
 * The catalogue company 01 is web-provisioned at location 01 (catalogue.mjs seedCompany lcCode '01'), while
 * NewCompParmCreat copies the location-00 head office, books and accounts. The case adds a location-00 head office, one
 * location-00 book with a slot, and accounts 00097 (below 101) and 00150 (above), and removes exactly what it added.
 */
async function withHeadOfficeSource(ctx, run) {
  const added = [];
  const add = async (table, where, sql, ...params) => {
    const [{ n }] = await ctx.rows(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND ${where}`,
    );
    if (n) return;
    await ctx.owner.$executeRawUnsafe(sql, TENANT, ...params);
    added.push([table, where]);
  };
  await purgeCompany(ctx.owner, TENANT, NEW_COMPANY.code);
  try {
    await add(
      'LOCT_MAST',
      `"LC_CODE"='00'`,
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01','00','E2E HEAD OFFICE')`,
    );
    await add(
      'BOOK_DATA',
      `"LC_CODE"='00' AND "CO_BOOK"='ZHO'`,
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","DATA_TYPE")
       VALUES ($1,'01','00','ZHO','E2E HEAD OFFICE CASH','ZHO','CASH REC','I','Y','A')`,
    );
    await add(
      'BOOK_DETL',
      `"LC_CODE"='00' AND "CO_BOOK"='ZHO'`,
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
       VALUES ($1,'01','00','ZHO',1,'E2E HEAD OFFICE CASH','ZHO','CASH REC','I','00097','E2E HO CASH','A')`,
    );
    for (const [code, name, group] of [
      ['00097', 'E2E HO CASH', '01'],
      ['00150', 'E2E HO PARTY', '10'],
    ])
      await add(
        'AC_MAST',
        `"AC_CODE"='${code}'`,
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','00',$2,$3,$4)`,
        code,
        name,
        group,
      );
    return await run();
  } finally {
    await purgeCompany(ctx.owner, TENANT, NEW_COMPANY.code);
    for (const [table, where] of added.reverse())
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND ${where}`,
        TENANT,
      );
  }
}
/** "Now ReOpen": Open Company on the new company, its copied head office and its first year. */
async function openNewCompany(page) {
  await page.goto('/select');
  await page.locator('#context-company').selectOption(NEW_COMPANY.code);
  await page.waitForFunction(
    (year) =>
      [...(document.getElementById('context-year')?.options ?? [])].some(
        (option) => option.value === year,
      ),
    NEW_COMPANY.year,
  );
  await page.locator('#context-year').selectOption(NEW_COMPANY.year);
  await Promise.all([
    page.waitForURL('**/dashboard', { timeout: 20_000 }),
    page.getByRole('button', { name: 'Open', exact: true }).click(),
  ]);
  const me = await (await page.request.get('/api/me')).json();
  assert.deepEqual([me.coCode, me.lcCode, me.coYear], [NEW_COMPANY.code, '00', NEW_COMPANY.year]);
  return me;
}
/** New → identity → Year Create inputs → Save, through the screen (MS_COMPANY.cs:6042-6218 → MS_YEAR). */
async function createOnScreen(page, { source = '', importAll = true } = {}) {
  await page.getByRole('button', { name: 'New', exact: true }).click();
  await page.locator('#company-code').fill(NEW_COMPANY.code);
  await page.getByLabel('Name', { exact: true }).fill(NEW_COMPANY.name);
  await page.getByLabel('City', { exact: true }).fill('SURAT');
  await page.getByLabel('With Old Company Master', { exact: true }).selectOption(source);
  if (source) {
    const box = page.getByLabel(`Import All Party from Ac Master Of ${source} Compnay...?`);
    assert.equal(await box.isChecked(), true, 'the Import All Party question defaults to Yes');
    if (!importAll) await box.uncheck();
  }
  await page.locator('#company-year').fill(NEW_COMPANY.year);
  await page.locator('#company-opening').fill('2026-04-01');
  await page.locator('#company-closing').fill('2027-03-31');
  const response = await saveIdentity(page);
  assert.equal(response.status(), 200, await response.text());
  await shownMessage(page, 'Data Are Saved.');
  return response;
}

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
    'web/apps/api/src/modules/masters/companyIdentity.ts',
    'web/apps/api/src/routes/companyIdentity.ts',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings:
      'catalogue defaults; identity edits of company 01 are put back after each case; company 07 (created on the screen), the location-00 source rows and the STATE_MAST rows a case adds are removed after it',
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
        const restoreKeys = [
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
          'REP_ADD_TYPE',
          'WORK_TYPE',
          'METAL_TYPE',
        ];
        const [original] = await ctx.rows(
          `SELECT ${restoreKeys.map((key) => '"' + key + '"').join(',')} FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        const { page } = await ctx.session();
        try {
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
            if (label === 'Company Type') await fillCompanyType(page, value);
            else await page.getByLabel(label, { exact: true }).fill(value);
          await page.getByLabel('Report Header', { exact: true }).selectOption('B');
          await page.getByLabel('Work Type', { exact: true }).selectOption('W');
          await page.getByLabel('Metal Type', { exact: true }).selectOption('S');
          await page.getByRole('button', { name: 'Save', exact: true }).click();
          await page.getByText('Data Are Saved.', { exact: true }).waitFor();
          await page.reload();
          await recordShown(page);
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
        } finally {
          // Later modules share this database; put the default company's identity back even when an assertion fails.
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "CO_MAST" SET ${restoreKeys.map((key, i) => '"' + key + '"=$' + (i + 2)).join(',')} WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            TENANT,
            ...restoreKeys.map((key) => original[key] ?? null),
          );
        }
      },
      { observe: (ctx) => rows(ctx, 'CO_MAST') },
    ),
    notApplicable(
      'formula',
      'T03',
      'MS_COMPANY.cs:6022-6227',
      'Company identity has no source-defined arithmetic or rounding result.',
    ),
    C(
      'lookup.state-and-clone.pending',
      'T04',
      'read-only',
      'MS_COMPANY.cs:7209-7240 tStateCode Enter: a known STATE_MAST code fills the State box with STATE_NAME, otherwise the help lists STATE_MAST by STATE_NAME; :5724-5738 cboWithOldCoMast is a blank item then every CO_MAST code by CO_CODE',
      async (ctx) =>
        withCompanyFixtures(ctx, {}, async () => {
          // The catalogue tenant has no STATE_MAST rows; the case adds two and removes them.
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "STATE_MAST"(tenant_id,"STATE_CODE","STATE_NAME") VALUES ($1,'Z1','ZETA E2E STATE'),($1,'Z2','ALPHA E2E STATE')`,
            TENANT,
          );
          try {
            const states = await ctx.rows(
              `SELECT "STATE_CODE" code,"STATE_NAME" name FROM "STATE_MAST" WHERE tenant_id=$1 ORDER BY "STATE_NAME"`,
            );
            assert.ok(states.length >= 2, 'the tenant has a state list');
            const { page } = await ctx.session();
            await open(page);
            await page.getByRole('button', { name: 'New', exact: true }).click();
            const help = await page
              .locator('#company-states option')
              .evaluateAll((items) => items.map((item) => [item.value, item.textContent]));
            assert.deepEqual(
              help,
              states.map((state) => [state.code, state.name]),
            );
            const pick = states.find((state) => state.code === 'Z1');
            await page.getByLabel('State Code', { exact: true }).fill(pick.code);
            await page.waitForFunction(
              (name) => document.querySelector('#company-CO_STATE')?.value === name,
              String(pick.name).toUpperCase(),
            );
            const codes = (
              await ctx.rows(
                `SELECT "CO_CODE" code FROM "CO_MAST" WHERE tenant_id=$1 AND deleted_at IS NULL ORDER BY "CO_CODE"`,
              )
            ).map((row) => row.code);
            const sources = await page
              .getByLabel('With Old Company Master', { exact: true })
              .locator('option')
              .evaluateAll((items) => items.map((item) => item.value));
            assert.deepEqual(sources, ['', ...codes]);
            await page.getByRole('button', { name: 'Cancel', exact: true }).click();
            return {
              observation: `state help ${help.length} rows by name; code ${pick.code} filled ${pick.name}; source companies ${JSON.stringify(sources)}`,
              expected: { help: states.length, state: pick.name, sources: ['', ...codes] },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "STATE_MAST" WHERE tenant_id=$1 AND "STATE_CODE" IN ('Z1','Z2')`,
              TENANT,
            );
          }
        }),
    ),
    notApplicable(
      'children',
      'T05',
      'MS_COMPANY.cs:5704-6227',
      'MS_COMPANY has no editable child grid; copied master families belong to the atomic provisioning write set.',
    ),
    C(
      'required.company-detail.pending',
      'T06',
      'refusal',
      'MS_COMPANY.cs:6069-6072 says exactly "Enter Company Detail" when code or name is blank',
      async (ctx) =>
        keepCompany01(ctx, async () => {
          const before = await companyFootprint(ctx);
          const { page } = await ctx.session();
          await open(page);
          await page.getByRole('button', { name: 'Edit', exact: true }).click();
          await page.getByLabel('Name', { exact: true }).fill('');
          const response = await saveIdentity(page);
          assert.equal(response.status(), 400, await response.text());
          await shownMessage(page, 'Enter Company Detail');
          const database = await companyFootprint(ctx);
          assert.deepEqual(database, before);
          return {
            observation: 'blank name refused with "Enter Company Detail"; nothing written',
            expected: 'Enter Company Detail',
            database,
          };
        }),
    ),
    C(
      'duplicate.code.pending',
      'T06',
      'refusal',
      "MS_COMPANY.cs:6022-6033 says `This Company Code already Exist in  '<name>'  Company Name...Please Change Company Code...`",
      async (ctx) => {
        const before = await companyFootprint(ctx);
        const [{ name }] = await ctx.rows(
          `SELECT "CO_NAME" name FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        const text = `This Company Code already Exist in  '${name}'  Company Name...Please Change Company Code...`;
        const { page } = await ctx.session();
        await open(page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        // Lite lets only code 01 through (MS_COMPANY.cs:6054-6057), so 01 is the one code a new entry can repeat.
        await page.locator('#company-code').fill('01');
        await page.getByLabel('Name', { exact: true }).fill('DUPLICATE CODE TRY');
        const response = await saveIdentity(page);
        assert.equal(response.status(), 409, await response.text());
        await shownMessage(page, text);
        const database = await companyFootprint(ctx);
        assert.deepEqual(database, before);
        return { observation: `refused: ${text}`, expected: text, database };
      },
    ),
    C(
      'duplicate.name.pending',
      'T06',
      'refusal',
      "MS_COMPANY.cs:6756-6769 says `This Company Name already Exist in  '<code>'  Company Code...Please Change Company Name...`",
      async (ctx) =>
        withCompanyFixtures(ctx, {}, () =>
          keepCompany01(ctx, async () => {
            const before = await companyFootprint(ctx);
            const text = `This Company Name already Exist in  '${EXTRA_COMPANY.code}'  Company Code...Please Change Company Name...`;
            const { page } = await ctx.session();
            await open(page);
            await page.getByRole('button', { name: 'Edit', exact: true }).click();
            await page.getByLabel('Name', { exact: true }).fill(EXTRA_COMPANY.name.toLowerCase());
            const response = await saveIdentity(page);
            assert.equal(response.status(), 409, await response.text());
            await shownMessage(page, text);
            const database = await companyFootprint(ctx);
            assert.deepEqual(database, before);
            return { observation: `refused: ${text}`, expected: text, database };
          }),
        ),
    ),
    {
      ...C(
        'edition.lite-basic-limits.pending',
        'T06',
        'refusal',
        'MS_COMPANY.cs:6054-6057 (Lite: any code but 01) and :6059-6067 (Basic: a third company) run before the blank check at :6069-6072',
        async () => ({}),
      ),
      applicable: false,
      reason:
        'Database layer: the feature stack builds the API without an edition (harness.mjs startStack buildApp; app.ts:119-120 "Absent = no edition gate"), so neither refusal can be reached from the browser. Both texts, and their order before "Enter Company Detail", are proved in web/apps/api/test/companyIdentity.db.test.ts ("applies Lite and default deletion refusals").',
    },
    C(
      'length.control-and-schema.pending',
      'T06',
      'refusal',
      'MS_COMPANY.cs designer MaxLength of every identity box (:4256-4979) and the CO_MAST column widths: the smaller of the two is the boundary; the State box is cut to 25 (Strings.Mid)',
      async (ctx) =>
        keepCompany01(ctx, async () => {
          const widths = Object.fromEntries(
            (
              await ctx.owner.$queryRawUnsafe(
                `SELECT column_name k, character_maximum_length n FROM information_schema.columns
                  WHERE table_schema='public' AND table_name='CO_MAST'`,
              )
            ).map((row) => [row.k, row.n == null ? Infinity : Number(row.n)]),
          );
          const limit = Object.fromEntries(
            Object.entries(DESKTOP_MAX).map(([key, max]) => [key, Math.min(max, widths[key])]),
          );
          const { page } = await ctx.session();
          await open(page);
          const shown = {};
          for (const key of Object.keys(DESKTOP_MAX))
            shown[key] = await page
              .locator(key === 'CO_CODE' ? '#company-code' : `#company-${key}`)
              .evaluate((input) => input.maxLength);
          assert.deepEqual(shown, limit, 'each box takes exactly the boundary');

          const version = async () =>
            (await (await request(page, 'GET', '/company-identity/01')).json()).version;
          const base = await (await request(page, 'GET', '/company-identity/01')).json();
          const identity = Object.fromEntries(
            ['CO_CODE', ...IDENTITY_KEYS].map((key) => [key, base[key] ?? '']),
          );
          const before = await companyFootprint(ctx);
          const refused = {};
          for (const key of Object.keys(limit)) {
            if (key === 'CO_CODE' || key === 'CO_STATE') continue;
            const response = await request(page, 'PUT', '/company-identity', {
              ...identity,
              [key]: 'W'.repeat(limit[key] + 1),
              expectedVersion: await version(),
            });
            refused[key] = response.status();
          }
          assert.deepEqual(
            Object.values(refused).filter((status) => status !== 400),
            [],
            `one character over the boundary is refused: ${JSON.stringify(refused)}`,
          );
          assert.deepEqual(await companyFootprint(ctx), before, 'the refused saves wrote nothing');

          const atLimit = Object.fromEntries(
            Object.keys(limit)
              .filter((key) => key !== 'CO_CODE')
              .map((key) => [key, (key === 'CO_TYPE' ? 'Z' : 'W').repeat(limit[key])]),
          );
          atLimit.CO_STATE = 'S'.repeat(limit.CO_STATE + 5);
          const saved = await request(page, 'PUT', '/company-identity', {
            ...identity,
            ...atLimit,
            expectedVersion: await version(),
          });
          assert.equal(saved.status(), 200, await saved.text());
          const [stored] = await ctx.rows(
            `SELECT ${Object.keys(atLimit)
              .map((key) => `char_length("${key}") "${key}"`)
              .join(',')} FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
          const expectedStored = Object.fromEntries(
            Object.keys(atLimit).map((key) => [key, limit[key]]),
          );
          assert.deepEqual(stored, expectedStored, 'every box stores its full boundary length');
          return {
            observation: `boxes ${JSON.stringify(shown)}; one over refused for ${Object.keys(refused).length} fields; at the boundary stored in full, State cut to ${stored.CO_STATE}`,
            expected: limit,
            database: { refused, stored },
          };
        }),
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
    C(
      'create.full-write-set.pending',
      'T07',
      'mutation',
      'MS_COMPANY.cs:6074-6218 writes CO_MAST (LC_CODE 00, MAIN_USER) and opens MS_YEAR, which writes YEAR_MAST (MS_YEAR.cs:1170-1400) and, with no old company chosen, NewCompParmCreat copies the 17 default master families from company 01 (MS_YEAR.cs:1555-1591)',
      async (ctx) =>
        withHeadOfficeSource(ctx, async () => {
          const expected = await expectedCopy(ctx, '', true);
          const { page } = await ctx.session();
          await open(page);
          const before = await tenantFingerprint(ctx);
          await createOnScreen(page);
          const [company] = await ctx.rows(
            `SELECT "CO_NAME" name,"CO_CITY" city,"LC_CODE" lc,btrim("MAIN_USER") mu FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
            NEW_COMPANY.code,
          );
          assert.deepEqual(company, {
            name: NEW_COMPANY.name,
            city: 'SURAT',
            lc: '00',
            mu: USERS.admin.user,
          });
          const years = await ctx.rows(
            `SELECT "CO_YEAR" y,"OP_DATE"::date::text op,"CL_DATE"::date::text cl FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
            NEW_COMPANY.code,
          );
          assert.deepEqual(years, [{ y: NEW_COMPANY.year, op: '2026-04-01', cl: '2027-03-31' }]);
          const copied = await copiedCounts(ctx, NEW_COMPANY.code);
          assert.deepEqual(copied, expected, 'each family copies exactly the desktop source rows');
          assert.deepEqual(await accountCodes(ctx, NEW_COMPANY.code), ['00097']);
          const written = changedTables(before, await tenantFingerprint(ctx)).sort();
          const families = Object.keys(expected).filter((table) => expected[table] > 0);
          assert.deepEqual(written, ['CO_MAST', 'YEAR_MAST', ...families].sort());
          return {
            observation: `company ${NEW_COMPANY.code} saved with its first year; copied ${JSON.stringify(copied)}; tables written ${written.join(',')}`,
            expected: { company: NEW_COMPANY, copy: expected },
            database: { company, years, copied },
            downstream: { written, accounts: ['00097'] },
          };
        }),
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
    C(
      'edit-no-reseed-headers.pending',
      'T09',
      'mutation',
      'MS_COMPANY.cs:6194-6227 opens MS_YEAR only for add mode; an edit rewrites the identity and nothing else, and the list shows the new name',
      async (ctx) =>
        keepCompany01(ctx, async (original) => {
          const { page } = await ctx.session();
          await open(page);
          const before = await tenantFingerprint(ctx);
          await page.getByRole('button', { name: 'Edit', exact: true }).click();
          await page.getByLabel('Name', { exact: true }).fill('NO RESEED NAME');
          await page.getByLabel('City', { exact: true }).fill('VAPI');
          const response = await saveIdentity(page);
          assert.equal(response.status(), 200, await response.text());
          await shownMessage(page, 'Data Are Saved.');
          const changed = changedTables(before, await tenantFingerprint(ctx));
          assert.deepEqual(changed, ['CO_MAST'], 'only the identity row changed');
          const [row] = await ctx.rows(
            `SELECT "CO_NAME" name,"CO_CITY" city FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
          assert.deepEqual(row, { name: 'NO RESEED NAME', city: 'VAPI' });
          const listed = await page
            .getByTestId('company-list')
            .locator('tbody tr[data-code="01"]')
            .textContent();
          assert.match(listed, /NO RESEED NAME/);
          return {
            observation: `edit changed only ${changed.join(',')}; list shows ${listed.trim()}`,
            expected: {
              changedTables: ['CO_MAST'],
              name: 'NO RESEED NAME',
              from: original.CO_NAME,
            },
            database: { row, changed },
            downstream: { listed: listed.trim() },
          };
        }),
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
    C(
      'concurrency.version.pending',
      'T12',
      'refusal',
      'Web contract D17 requires versioned master edits; MS_COMPANY.cs:5882-6001 establishes open-before-edit state',
      async (ctx) =>
        keepCompany01(ctx, async () => {
          const { page } = await ctx.session();
          await open(page);
          await page.getByRole('button', { name: 'Edit', exact: true }).click();
          await page.getByLabel('Name', { exact: true }).fill('STALE SAVE');
          // Another session saves company 01 after this one opened it.
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "CO_MAST" SET "CO_CITY"='OTHER WRITER' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            TENANT,
          );
          const before = await companyFootprint(ctx);
          const response = await saveIdentity(page);
          assert.equal(response.status(), 409, await response.text());
          const text = await shownMessage(
            page,
            'Company changed. Open it again before saving or deleting.',
          );
          const database = await companyFootprint(ctx);
          assert.deepEqual(database, before, 'the stale save wrote nothing');
          const [row] = await ctx.rows(
            `SELECT "CO_NAME" name,"CO_CITY" city FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
          assert.equal(row.city, 'OTHER WRITER');
          assert.notEqual(row.name, 'STALE SAVE');
          return {
            observation: `refused: ${text}; the other writer's row kept`,
            expected: text,
            database: row,
          };
        }),
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
    C(
      'rollback.per-stage.pending',
      'T14',
      'mutation',
      'MS_COMPANY.cs:6074-6191 rewrites CO_MAST and then, for company type A or B, the BOOK_DATA transfer flags (:6183-6191) as separate statements; the web writes both in one transaction, so a fault on either stage leaves every table unchanged and the same Save then succeeds',
      async (ctx) => {
        const books = await ctx.rows(
          `SELECT row_id::text id,"TRFR_BOOK" trfr,"RESET_BOOK" reset FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        assert.ok(books.length > 0, 'company 01 has books for the second stage to update');
        try {
          return await keepCompany01(ctx, async () => {
            const session = await ctx.session();
            const { page } = session;
            await open(page);
            await page.getByRole('button', { name: 'Edit', exact: true }).click();
            await page.getByLabel('Name', { exact: true }).fill('ROLLBACK STAGES');
            await fillCompanyType(page, 'A');
            const before = await tenantFingerprint(ctx);
            const attempts = [];
            for (const table of ['CO_MAST', 'BOOK_DATA']) {
              const response = await withWriteFault(ctx, table, 'UPDATE', () => saveIdentity(page));
              assert.ok(
                response.status() >= 400,
                `fault on ${table}: answered ${response.status()}`,
              );
              acceptOne500(session, response);
              assert.deepEqual(
                changedTables(before, await tenantFingerprint(ctx)),
                [],
                `fault on ${table}: every table unchanged`,
              );
              attempts.push({ table, status: response.status() });
            }
            const response = await saveIdentity(page);
            assert.equal(response.status(), 200, await response.text());
            await shownMessage(page, 'Data Are Saved.');
            const [row] = await ctx.rows(
              `SELECT "CO_NAME" name,"CO_TYPE" type FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            );
            assert.deepEqual(row, { name: 'ROLLBACK STAGES', type: 'A' });
            const trfr = await ctx.rows(
              `SELECT DISTINCT "TRFR_BOOK" t FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            );
            assert.deepEqual(trfr, [{ t: 'Y' }]);
            return {
              observation: `faults ${JSON.stringify(attempts)} left every table unchanged; the same Save then wrote CO_MAST and set TRFR_BOOK Y`,
              expected: { faulted: 'no change', thenSaved: row },
              database: { attempts, row },
              downstream: { trfr },
            };
          });
        } finally {
          for (const book of books)
            await ctx.owner.$executeRawUnsafe(
              `UPDATE "BOOK_DATA" SET "TRFR_BOOK"=$2,"RESET_BOOK"=$3 WHERE tenant_id=$1 AND row_id=$4::bigint`,
              TENANT,
              book.trfr,
              book.reset,
              book.id,
            );
        }
      },
    ),
    C(
      'snapshot.source-company.pending',
      'T15',
      'mutation',
      'MS_YEAR.cs:1508-1553: with an old company chosen, every family is copied from it (AC_MAST by the Import All Party answer :1512-1521, location 00 only for books and accounts, the head office from company 01); the copy is taken at save time, so a later change to the source leaves the new company as it was',
      async (ctx) =>
        withHeadOfficeSource(ctx, async () => {
          const expected = await expectedCopy(ctx, '01', true);
          const { page } = await ctx.session();
          await open(page);
          await createOnScreen(page, { source: '01', importAll: true });
          const copied = await copiedCounts(ctx, NEW_COMPANY.code);
          assert.deepEqual(copied, expected, 'each family copies exactly the old company rows');
          // Import All Party: every location-00 account, not only those below 101.
          assert.deepEqual(await accountCodes(ctx, NEW_COMPANY.code), ['00097', '00150']);
          const groups = (coCode) =>
            ctx.rows(
              `SELECT "AC_GR" gr,"AC_GR_NAME" name FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
              coCode,
            );
          const snapshot = await groups(NEW_COMPANY.code);
          assert.deepEqual(snapshot, await groups('01'));
          assert.ok(snapshot.length > 0, 'the source has account groups');
          const [first] = snapshot;
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "AC_GROUP" SET "AC_GR_NAME"='E2E CHANGED LATER' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_GR"=$2`,
            TENANT,
            first.gr,
          );
          try {
            assert.deepEqual(
              await groups(NEW_COMPANY.code),
              snapshot,
              'the copy is not a reference',
            );
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `UPDATE "AC_GROUP" SET "AC_GR_NAME"=$3 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_GR"=$2`,
              TENANT,
              first.gr,
              first.name,
            );
          }
          return {
            observation: `copied from 01 ${JSON.stringify(copied)}; accounts 00097 and 00150; renaming source group ${first.gr} left the copy as saved`,
            expected: { copy: expected, accounts: ['00097', '00150'] },
            database: { copied, snapshot },
            downstream: { sourceChangedLater: first.gr },
          };
        }),
    ),
    C(
      'history.fiscal-boundary.pending',
      'T15',
      'mutation',
      'MS_YEAR.cs:1170-1400 creates the first YEAR_MAST row with the opening and closing dates before NewCompParmCreat; the new company then opens on that year (Open Company, MS_OPNCOMP) and only that year',
      async (ctx) =>
        withHeadOfficeSource(ctx, async () => {
          const session = await ctx.session(as(USERS.admin.user, 'company-master-new-company'));
          const { page } = session;
          await open(page);
          await createOnScreen(page);
          const me = await openNewCompany(page);
          const years = await (await page.request.get('/api/years')).json();
          assert.deepEqual(
            years.map((y) => [y.coYear, y.opDate, y.clDate]),
            [[NEW_COMPANY.year, '2026-04-01', '2027-03-31']],
          );
          return {
            observation: `company ${NEW_COMPANY.code} opened at location 00 on ${me.coYear}; its only year runs 2026-04-01 to 2027-03-31`,
            expected: { year: NEW_COMPANY.year, opDate: '2026-04-01', clDate: '2027-03-31' },
            database: { years },
            downstream: { session: [me.coCode, me.lcCode, me.coYear] },
          };
        }),
    ),
    C(
      'print.company-rpt.pending',
      'T16',
      'output',
      'MS_COMPANY.cs:6776-6790 BtnPrint_Click: without FRM_PRINT "You Have No Print Rights.....", else Company.RPT for {CO_MAST.CO_CODE} = the logged-in company; rpt_xml/Company.xml:88-250 heads and prints code, name, address 1, address 2, state, city, with PrintDate (:165) and PageNumber (:287)',
      async (ctx) =>
        withCompanyFixtures(ctx, {}, async () => {
          const columns = ['CO_CODE', 'CO_NAME', 'CO_ADD1', 'CO_ADD2', 'CO_STATE', 'CO_CITY'];
          const expected = (
            await ctx.rows(
              `SELECT ${columns.map((c) => '"' + c + '"').join(',')} FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            )
          ).map((row) => columns.map((c) => String(row[c] ?? '')));
          const { page } = await ctx.session();
          await open(page);
          // Open company 02 in the form: the print is still the logged-in company 01 (DC_Main.MCo_code).
          await page
            .getByTestId('company-list')
            .locator(`tbody tr[data-code="${EXTRA_COMPANY.code}"]`)
            .click();
          await page.waitForFunction(() => document.querySelector('#company-code')?.value === '02');
          await page.getByRole('button', { name: 'Print', exact: true }).click();
          const sheet = page.getByTestId('company-print');
          await sheet.waitFor();
          const heads = await sheet.locator('thead th').allTextContents();
          const body = await sheet
            .locator('tbody tr')
            .evaluateAll((rows) =>
              rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent)),
            );
          const date = (await page.getByTestId('company-print-date').textContent()).trim();
          const pageNo = (await page.getByTestId('company-print-page').textContent()).trim();
          const today = new Date();
          const pad = (n) => String(n).padStart(2, '0');
          assert.deepEqual(heads, columns);
          assert.deepEqual(body, expected);
          assert.equal(
            date,
            `${pad(today.getDate())}/${pad(today.getMonth() + 1)}/${today.getFullYear()}`,
          );
          assert.equal(pageNo, '1');

          // A login with the Company view right but no print right gets the desktop text and no sheet.
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Company','Company','Y','N','N','N')`,
            TENANT,
            USERS.printViewer.user,
          );
          try {
            const { page: viewer } = await ctx.session(as(USERS.printViewer.user));
            await open(viewer);
            const [refused] = await Promise.all([
              viewer.waitForResponse(
                (r) => new URL(r.url()).pathname === '/api/company-identity/print',
              ),
              viewer.getByRole('button', { name: 'Print', exact: true }).click(),
            ]);
            assert.equal(refused.status(), 403);
            await shownMessage(viewer, 'You Have No Print Rights.....');
            assert.equal(await viewer.getByTestId('company-print').count(), 0);
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Company'`,
              TENANT,
              USERS.printViewer.user,
            );
          }
          const output = { heads, rows: body, date, page: pageNo };
          return {
            observation: `printed ${JSON.stringify(body)} under ${heads.join(' ')} on ${date}, page ${pageNo}; print right refused with the desktop text`,
            expected: { heads: columns, rows: expected },
            output,
          };
        }),
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
    C(
      'keyboard.full-workflow',
      'T17',
      'read-only',
      'MS_COMPANY.cs Enter chain by TabIndex (Pnl1 0-16, Pnl2 17-21, Pnl3 22-25) with tCoCode/tCoName → cboWithOldCoMast (:6483-6534), cboWithOldCoMast → tCoName or tAddress1 (:7303-7320), tStateCode → TState (:7209-7251), cboRptHader → SelectNextTab and tGstNo (:6748-6752), tJudrection → SelectNextTab and tBankName (:6656-6665), tRtgsNo → Save (:6737-6746); Ctrl+O and Ctrl+R (:6471-6480); tCoType Enter → Save (:7279-7290); F1 on the name opens credential panels the web keeps hidden (:6502-6521)',
      async (ctx) => {
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "STATE_MAST"(tenant_id,"STATE_CODE","STATE_NAME") VALUES ($1,'Z1','ZETA E2E STATE')`,
          TENANT,
        );
        try {
          return await keepCompany01(ctx, async (before) => {
            const { page } = await ctx.session();
            await open(page);
            // The focused control's accessible label and the section (fieldset legend) holding it.
            const focused = () =>
              page.evaluate(() => {
                const el = document.activeElement;
                const label =
                  el?.getAttribute('aria-label') ?? el?.labels?.[0]?.textContent ?? el?.textContent;
                // The shell wraps every page in a legend-less fieldset; a section is one with its own legend.
                const legend = el
                  ?.closest('fieldset:has(> legend)')
                  ?.querySelector(':scope > legend')?.textContent;
                return `${legend ?? '-'}: ${String(label).trim()}`;
              });
            const walk = async (limit = 40) => {
              const seen = [await focused()];
              // Stop on any Save: one more Enter would press it.
              for (let i = 0; i < limit && !seen.at(-1).endsWith(': Save'); i++) {
                await page.keyboard.press('Enter');
                seen.push(await focused());
              }
              return seen;
            };
            const save = page.getByRole('button', { name: 'Save', exact: true });
            const D = (label) => `Company Detail: ${label}`;
            const T = (label) => `Tax Detail: ${label}`;
            const B = (label) => `Bank Detail: ${label}`;
            const tail = [
              D('Work Type'),
              D('Metal Type'),
              D('Report Header'),
              T('GST No'),
              T('CST No'),
              T('PAN No'),
              T('Dhiran No'),
              T('Jurisdiction'),
              B('Bank Name'),
              B('Bank Area'),
              B('Bank Account No'),
              B('RTGS No'),
            ];

            // Edit: the whole chain from Code to Save, across both section switches.
            await page.getByRole('button', { name: 'Edit', exact: true }).click();
            await page.getByLabel('Name', { exact: true }).fill('KEYS E2E COMPANY');
            await page.getByLabel('State Code', { exact: true }).fill('Z1');
            await page.getByLabel('State', { exact: true }).fill('');
            await page.locator('#company-code').focus();
            const editChain = await walk();
            assert.deepEqual(editChain, [
              D('Code'),
              D('Name'),
              D('Address 1'),
              D('Address 2'),
              D('Address 3'),
              D('Country'),
              D('State Code'),
              D('State'),
              D('City'),
              D('Pin Code'),
              D('Phone'),
              D('Phone 2'),
              D('Mobile'),
              D('Mobile 2'),
              D('Email'),
              ...tail,
              '-: Save',
            ]);
            assert.equal(
              await page.getByLabel('State', { exact: true }).inputValue(),
              'ZETA E2E STATE',
              'a known state code fills the State box',
            );

            // F1 on the name: the credential panels stay hidden, focus stays.
            await page.getByLabel('Name', { exact: true }).focus();
            await page.keyboard.press('F1');
            assert.equal(await focused(), D('Name'));
            assert.equal(await page.getByRole('dialog').count(), 0);

            // Ctrl+O: Company Type unlocked and focused, Save disabled until Enter there.
            const type = page.getByLabel('Company Type', { exact: true });
            assert.equal(await type.isDisabled(), true, 'Company Type starts disabled');
            assert.equal(await save.isEnabled(), true);
            await page.keyboard.press('Control+o');
            assert.equal(await focused(), D('Company Type'));
            assert.equal(await type.isDisabled(), false);
            assert.equal(await save.isDisabled(), true, 'Ctrl+O disables Save');
            await page.keyboard.press('Enter');
            assert.equal(await focused(), '-: Save');
            assert.equal(await save.isEnabled(), true, 'Enter on Company Type re-enables Save');
            // RTGS No Enter is the other way back to Save.
            await page.keyboard.press('Control+o');
            assert.equal(await save.isDisabled(), true);
            await page.getByLabel('RTGS No', { exact: true }).focus();
            await page.keyboard.press('Enter');
            assert.equal(await focused(), '-: Save');
            assert.equal(await save.isEnabled(), true, 'Enter on RTGS No re-enables Save');

            // Ctrl+R: the in-page Reset Compnay box explains and changes nothing.
            await page.keyboard.press('Control+r');
            const reset = page.getByRole('dialog', { name: 'Reset Compnay' });
            await reset.waitFor();
            const resetText = (await reset.textContent()).trim();
            assert.match(resetText, /Not available on the web/);
            assert.equal(
              await page.getByLabel('Name', { exact: true }).inputValue(),
              'KEYS E2E COMPANY',
              'Ctrl+R did not reload the page',
            );
            await reset.getByRole('button', { name: 'Close', exact: true }).click();
            assert.equal(await page.getByRole('dialog').count(), 0);
            await page.getByRole('button', { name: 'Cancel', exact: true }).click();
            await page.waitForFunction(
              (name) => document.querySelector('#company-CO_NAME')?.value === name,
              before.CO_NAME ?? '',
            );

            // New: Code → With Old Company Master → blank Name refused → Name → With Old → Address 1; RTGS No → the
            // Year Create boxes → Save.
            await page.getByRole('button', { name: 'New', exact: true }).click();
            await page.locator('#company-code').focus();
            const newHead = [await focused()];
            for (let i = 0; i < 2; i++) {
              await page.keyboard.press('Enter');
              newHead.push(await focused());
            }
            await page.keyboard.press('Enter');
            newHead.push(await focused());
            await shownMessage(page, 'Please Insert Co Name ...');
            await page.keyboard.type('KEYS NEW');
            for (let i = 0; i < 2; i++) {
              await page.keyboard.press('Enter');
              newHead.push(await focused());
            }
            assert.deepEqual(newHead, [
              D('Code'),
              'Year Create: With Old Company Master',
              D('Name'),
              D('Name'),
              'Year Create: With Old Company Master',
              D('Address 1'),
            ]);
            await page.getByLabel('RTGS No', { exact: true }).focus();
            const newTail = await walk(6);
            assert.deepEqual(newTail, [
              B('RTGS No'),
              'Year Create: Year',
              'Year Create: Opening Date',
              'Year Create: Closing Date',
              '-: Save',
            ]);
            await page.getByRole('button', { name: 'Cancel', exact: true }).click();
            await recordShown(page);
            const after = await company01(ctx);
            assert.deepEqual(after, before, 'no key wrote company 01');
            return {
              observation: `Enter chain (edit) ${editChain.join(' → ')}; new ${[...newHead, ...newTail.slice(1)].join(' → ')}; Ctrl+O unlocked Company Type and disabled Save until Enter; Ctrl+R showed "${resetText}"; F1 inert`,
              expected:
                'desktop TabIndex order with the Tax and Bank section switches, ending on Save',
            };
          });
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "STATE_MAST" WHERE tenant_id=$1 AND "STATE_CODE"='Z1'`,
            TENANT,
          );
        }
      },
    ),
    C(
      'journey.login-new-company-voucher.pending',
      'T18',
      'mutation',
      'MS_COMPANY.cs:6194-6218 opens Year Create for the new company; MS_YEAR.cs:1508-1553 copies the old company (Import All Party: the location-00 accounts, :1512-1516; books, :1525-1528; head office, :1567-1571); the company is reopened (MS_OPNCOMP) and a Cash Received voucher is saved in it (TR_CASH, Cash_Ledr Ac_Ledr.cs:565-585: 01 party CR, 02 slot-1 cash DR)',
      async (ctx) =>
        withHeadOfficeSource(ctx, async () => {
          const { page } = await ctx.session(as(USERS.admin.user, 'company-master-journey'));
          await open(page);
          await createOnScreen(page, { source: '01', importAll: true });
          const me = await openNewCompany(page);
          await page.goto('/txn/receipt');
          const party = page.getByLabel('Party account', { exact: true });
          await party.waitFor();
          const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
          for (let i = 0; i < 50 && (await book.inputValue()) !== 'ZHO'; i++)
            await page.waitForTimeout(100);
          assert.equal(await book.inputValue(), 'ZHO', 'the copied CASH REC book is offered');
          await party.fill('00150');
          await party.locator('xpath=..').getByText('00150', { exact: true }).first().waitFor();
          await party.press('Enter');
          await page.getByLabel('Amount', { exact: true }).fill('100');
          const [response] = await Promise.all([
            page.waitForResponse(
              (r) =>
                new URL(r.url()).pathname === '/api/receipts' && r.request().method() === 'POST',
            ),
            page.getByRole('button', { name: 'Save Receipt', exact: true }).click(),
          ]);
          assert.equal(response.status(), 201, await response.text());
          const vchNo = String((await response.json()).vchNo).padStart(5, '0');
          const legs = await ctx.rows(
            `SELECT "AC_CODE" ac,coalesce("DR_AMT",0)::float dr,coalesce("CR_AMT",0)::float cr
               FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"='ZHO' AND "VCH_NO"=$3 ORDER BY "LEDR_KEY"`,
            NEW_COMPANY.code,
            vchNo,
          );
          assert.deepEqual(legs, [
            { ac: '00150', dr: 0, cr: 100 },
            { ac: '00097', dr: 100, cr: 0 },
          ]);
          return {
            observation: `created ${NEW_COMPANY.code} from 01, reopened it on ${me.coYear} at ${me.lcCode}, saved Cash Received ${vchNo}: ${JSON.stringify(legs)}`,
            expected: {
              session: [NEW_COMPANY.code, '00', NEW_COMPANY.year],
              legs: 'party CR 100, cash DR 100',
            },
            database: { legs },
            downstream: { voucher: vchNo },
          };
        }),
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
