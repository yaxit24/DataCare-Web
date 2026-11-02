import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { readFile } from 'node:fs/promises';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Company → Data Backup (desktop UT_BKP, web /backup).
 *
 * Desktop authority: MDI_FORM.cs:7471-7480 dispatches Data Backup. UT_BKP.cs:630-918 shows Backup Path,
 * Select, progress and Backup while Restore is hidden and Dattach is normally hidden; :925-936 selects a
 * folder; :942-965 loads rights; :1099-1135 loads/cancels/exits; :1198-1251 checks Print right and path,
 * replaces the same-hour Next<YY>[_<type>]_ddMMyy_HH.BAK, backs up company+NextMain and reports completion;
 * :1275-1285 advances cosmetic progress. The browser Save dialog is the accepted D-BKP-2 path adaptation.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `data-backup.${id}`,
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
const blocked = (name, group, source, reason) =>
  C(name, group, 'read-only', source, async () => ({}), { blocked: reason });

const countRequests = (requests, method, path) =>
  requests.filter((request) => request.method === method && request.path === path).length;
const backupRuns = (ctx) =>
  ctx.rows(
    `SELECT checksum,operator,table_count,row_count::text rows
       FROM "company_backup_run" WHERE tenant_id=$1 AND co_code='01' ORDER BY row_id`,
  );
const hashText = (value) => createHash('sha256').update(value, 'utf8').digest('hex');
const RECOVERY_WARNING =
  'Recovery limitation: This integrity-checked JSON company archive does not replace the production disaster-recovery backup. DataCare Web provides no operator restore path for this archive.';
const stable = (value) => {
  if (
    value === null ||
    typeof value === 'string' ||
    typeof value === 'boolean' ||
    typeof value === 'number'
  )
    return JSON.stringify(value);
  if (Array.isArray(value)) return `[${value.map(stable).join(',')}]`;
  return `{${Object.keys(value)
    .sort()
    .map((key) => `${JSON.stringify(key)}:${stable(value[key])}`)
    .join(',')}}`;
};
const verifyArchive = (document) => {
  for (const table of Object.values(document.tables))
    assert.equal(
      table.checksum,
      hashText(table.rows.map(stable).sort().join('\n')),
      'table checksum',
    );
  const schemaTables = [...document.manifest.tables]
    .sort((left, right) => left.name.localeCompare(right.name))
    .map((table) => ({
      name: table.name,
      scope: table.scope,
      included: table.included,
      exclusionReason: table.exclusionReason,
      primaryKey: table.primaryKey,
      dependencies: table.dependencies,
      rlsEnabled: table.rlsEnabled,
      rlsForced: table.rlsForced,
      constraints: table.constraints,
      indexes: table.indexes,
      policies: table.policies,
      triggers: table.triggers,
      columns: table.columns,
    }));
  assert.equal(document.manifest.fingerprint, hashText(stable(schemaTables)), 'schema fingerprint');
  const { checksum, ...payload } = document;
  assert.equal(checksum, hashText(stable(payload)), 'document checksum');
  return { checksum, schemaFingerprint: document.manifest.fingerprint };
};
const normalize = (document) => ({
  schema: document.manifest.fingerprint,
  tables: Object.fromEntries(
    Object.entries(document.tables)
      .sort(([a], [b]) => a.localeCompare(b))
      .map(([name, table]) => [name, { rows: table.rowCount, checksum: table.checksum }]),
  ),
});
async function bytesOf(download) {
  const path = await download.path();
  assert(path, 'browser download has no local artifact path');
  return readFile(path);
}
async function open(page, throughMenu = false) {
  if (throughMenu) {
    await page.goto('/dashboard');
    const companyGroup = page.locator('nav.sidebar > div', {
      has: page.locator('.group', { hasText: /^Company$/ }),
    });
    await companyGroup.getByRole('link', { name: 'Data Backup', exact: true }).click();
  } else await page.goto('/backup');
  await page.getByRole('heading', { name: 'Backup Data', exact: true }).waitFor();
}
async function assertRecoveryBoundary(page) {
  const warning = await page.getByLabel('Backup recovery limitation').innerText();
  assert.equal(warning.replace(/\s+/g, ' ').trim(), RECOVERY_WARNING);
  assert.equal(await page.getByRole('button', { name: /^(Restore|Dattach)$/i }).count(), 0);
  assert.doesNotMatch(
    await page.locator('main').innerText(),
    /can be restored|restorable|disaster-recovery ready/i,
  );
}
async function select(page) {
  await page.getByRole('button', { name: 'Select', exact: true }).click();
  assert.equal(
    await page.getByLabel('Backup Path', { exact: true }).inputValue(),
    'Browser Save dialog',
  );
}
async function download(page) {
  const pending = page.waitForEvent('download');
  await page.getByRole('button', { name: 'Backup', exact: true }).click();
  const artifact = await pending;
  const bytes = await bytesOf(artifact);
  await page.getByText('Backup Process Complete.', { exact: true }).waitFor();
  return { artifact, bytes, document: JSON.parse(bytes.toString('utf8')) };
}
async function seedScopeSentinels(ctx) {
  await ctx.owner.$executeRawUnsafe(
    `UPDATE "CO_MAST" SET "CO_TYPE"='R' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    ctx.tenantId,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME")
     SELECT $1::text,'01','02','BACKUP BRANCH SENTINEL'
      WHERE NOT EXISTS (SELECT 1 FROM "LOCT_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "LC_CODE"='02')`,
    ctx.tenantId,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE","CO_TYPE")
     VALUES ($1,'02','OTHER COMPANY BACKUP SENTINEL','01','S') ON CONFLICT DO NOTHING`,
    ctx.tenantId,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
     SELECT $1::text,'02','01','BKSENT','OTHER COMPANY ROW SENTINEL'
      WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='02' AND "AC_CODE"='BKSENT')`,
    ctx.tenantId,
  );
}

export const dataBackup = {
  feature: 'data-backup',
  title: 'Company → Data Backup (UT_BKP)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/backup/page.tsx',
    'web/apps/web/app/(app)/utilities/page.tsx',
    'web/apps/web/lib/nav.ts',
    'web/apps/web/lib/api.ts',
    'web/apps/api/src/app.ts',
    'web/apps/api/src/modules/ops/backup.ts',
    'web/apps/api/src/modules/ops/backupManifest.ts',
    'web/apps/api/src/modules/ops/backupDownload.ts',
    'web/apps/api/src/modules/ops/backupFilename.ts',
    'web/apps/web/test/features/modules/dataBackup.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    archive: 'company-backup-v2; 160 company-scoped tables; tenant-shared excluded',
  },
  cases: [
    C(
      'entry.visible-backup-only',
      'T01',
      'read-only',
      'MDI_FORM.cs:7471-7480; UT_BKP.cs:630-918; KB_master.md:225-253',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page, true);
        const controls = await page
          .locator('main input,main button,main progress')
          .allTextContents();
        const body = await page.locator('main').innerText();
        assert.match(body, /Backup Data/);
        assert.equal(await page.getByLabel('Backup Path', { exact: true }).isVisible(), true);
        assert.match(body, /Select/);
        assert.match(body, /Backup/);
        await assertRecoveryBoundary(page);
        return {
          observation:
            'opened through Data Backup menu with the recovery limitation and Select/Backup only',
          expected: { controls },
        };
      },
    ),
    C(
      'field.select-is-memory-only',
      'T02',
      'read-only',
      'UT_BKP.cs:925-936 selects a folder; D-BKP-2 maps this to the browser Save dialog without a server path',
      async (ctx) => {
        const { page, requests } = await ctx.session();
        await open(page);
        const before = requests.length;
        await select(page);
        assert.equal(countRequests(requests.slice(before), 'GET', '/api/backup'), 0);
        return {
          observation: 'Select acknowledged the Save dialog without any backup request',
          expected: { requests: 0 },
        };
      },
    ),
    notApplicable(
      'formula',
      'T03',
      'UT_BKP.cs:1198-1251 performs no business arithmetic',
      'Backup serializes rows and hashes bytes; it has no desktop calculation or rounding formula.',
    ),
    C(
      'lookup.select-focus',
      'T04',
      'read-only',
      'UT_BKP.cs:925-936 gives Select the destination-picker action; browser Save dialog is D-BKP-2',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        assert.equal(
          await page
            .getByRole('button', { name: 'Select', exact: true })
            .evaluate((e) => e === document.activeElement),
          true,
        );
        await page.keyboard.press('Enter');
        assert.equal(
          await page.getByLabel('Backup Path', { exact: true }).inputValue(),
          'Browser Save dialog',
        );
        return {
          observation: 'Select starts focused and Enter records the in-memory acknowledgement',
          expected: { destination: 'Browser Save dialog' },
        };
      },
    ),
    notApplicable(
      'children',
      'T05',
      'UT_BKP.cs:630-918 has no editable child grid',
      'The backup screen has no child-row workflow.',
    ),
    C(
      'required.missing-destination',
      'T06',
      'refusal',
      'UT_BKP.cs:1205-1210 says exactly "Please Select Path and Try" and returns',
      async (ctx) => {
        const before = await backupRuns(ctx);
        const { page, requests } = await ctx.session();
        await open(page);
        await page.getByRole('button', { name: 'Backup', exact: true }).click();
        await page.getByText('Please Select Path and Try', { exact: true }).waitFor();
        assert.equal(countRequests(requests, 'GET', '/api/backup'), 0);
        assert.equal(
          await page
            .getByRole('button', { name: 'Select', exact: true })
            .evaluate((e) => e === document.activeElement),
          true,
        );
        assert.deepEqual(await backupRuns(ctx), before);
        return {
          observation: 'exact refusal, Select focused, no GET and no audit',
          expected: { message: 'Please Select Path and Try' },
          database: { before, after: before },
        };
      },
    ),
    C(
      'create.download-and-audit',
      'T07',
      'output',
      'UT_BKP.cs:1198-1251 creates the company backup before "Backup Process Complete."; web recordCompanyBackup records generation before response handoff',
      async (ctx) => {
        await seedScopeSentinels(ctx);
        const before = await backupRuns(ctx);
        const { page, requests } = await ctx.session();
        await open(page);
        await select(page);
        const result = await download(page);
        const integrity = verifyArchive(result.document);
        assert.match(result.artifact.suggestedFilename(), /^Next\d{2}_R_\d{6}_\d{2}\.json$/);
        assert.match(result.document.checksum, /^[a-f0-9]{64}$/);
        assert.equal(countRequests(requests, 'GET', '/api/backup'), 1);
        const after = await backupRuns(ctx);
        assert.equal(after.length, before.length + 1);
        assert.equal(after.at(-1).checksum, result.document.checksum);
        assert.equal(after.at(-1).operator, USERS.admin.user);
        return {
          observation: `${result.artifact.suggestedFilename()} downloaded, all hashes verified and one company_backup_run recorded`,
          expected: { message: 'Backup Process Complete.', integrity },
          database: { before: before.length, after: after.at(-1) },
          output: result.bytes,
        };
      },
      { requiredEvidence: ['browser', 'expected', 'database', 'output'] },
    ),
    C(
      'reopen.repeat-normalized-stability',
      'T08',
      'output',
      'UT_BKP.cs:1216-1248 replaces the same generated name; D-BKP-2 preserves the same-hour suggested-name intent',
      async (ctx) => {
        await seedScopeSentinels(ctx);
        const { page } = await ctx.session();
        await open(page);
        await select(page);
        const first = await download(page);
        const second = await download(page);
        assert.equal(first.artifact.suggestedFilename(), second.artifact.suggestedFilename());
        assert.deepEqual(normalize(first.document), normalize(second.document));
        return {
          observation:
            'two same-hour downloads used one suggestion and identical normalized schema/table checksums',
          expected: { filename: first.artifact.suggestedFilename() },
          output: second.bytes,
        };
      },
    ),
    notApplicable(
      'business-edit',
      'T09',
      'UT_BKP.cs:1198-1251 creates an artifact and does not edit business records',
      'Backup has no owned business-edit workflow.',
    ),
    C(
      'cancel.clears-selection',
      'T10',
      'refusal',
      'UT_BKP.cs:1117-1120 CLEAR_DATA clears text boxes; Esc exits at :1147-1154',
      async (ctx) => {
        const before = await backupRuns(ctx);
        const { page, requests } = await ctx.session();
        await open(page);
        await select(page);
        await page.getByRole('button', { name: 'Cancel', exact: true }).click();
        assert.equal(await page.getByLabel('Backup Path', { exact: true }).inputValue(), '');
        await page.getByRole('button', { name: 'Backup', exact: true }).click();
        await page.getByText('Please Select Path and Try', { exact: true }).waitFor();
        await select(page);
        await page.goto('/dashboard');
        await page.goBack();
        await page.getByRole('heading', { name: 'Backup Data', exact: true }).waitFor();
        assert.equal(await page.getByLabel('Backup Path', { exact: true }).inputValue(), '');
        await page.getByRole('button', { name: 'Backup', exact: true }).click();
        await page.getByText('Please Select Path and Try', { exact: true }).waitFor();
        assert.equal(countRequests(requests, 'GET', '/api/backup'), 0);
        assert.deepEqual(await backupRuns(ctx), before);
        return {
          observation:
            'Cancel and a navigation round trip each cleared acknowledgement; Backup refused without request/audit',
          expected: { destination: '' },
          database: { before, after: before },
        };
      },
    ),
    C(
      'scope.all-company-years-no-sentinels',
      'T11',
      'output',
      'Current v2 tableScope includes only tenant_id+CO_CODE tables and backupCompany filters the authenticated tenant/company, across locations and years',
      async (ctx) => {
        await seedScopeSentinels(ctx);
        const { page } = await ctx.session();
        await open(page);
        await select(page);
        const result = await download(page);
        const raw = result.bytes.toString('utf8');
        const locations = result.document.tables.LOCT_MAST.rows.map((row) => row.LC_CODE);
        const years = result.document.tables.YEAR_MAST.rows.map((row) => row.CO_YEAR);
        assert(locations.includes('01') && locations.includes('02'));
        assert(years.includes('2024-2025') && years.some((year) => year !== '2024-2025'));
        assert(!raw.includes('OTHER COMPANY BACKUP SENTINEL'));
        assert(!raw.includes('OTHER COMPANY ROW SENTINEL'));
        assert(!raw.includes(SECOND_TENANT));
        return {
          observation: `locations ${locations.join(',')}; years ${years.join(',')}; other scopes absent`,
          expected: { tenant: ctx.tenantId, company: '01' },
          output: result.bytes,
        };
      },
    ),
    blocked(
      'rights.desktop-print-handoff',
      'T11',
      'UT_BKP.cs:942-965 and :1198-1204 use USER_SET.FRM_PRINT under caption Data Backup',
      'G225 remains the active cross-menu Print-right handoff. This milestone preserves the current authenticated/admin API policy and does not edit routePolicy/formCatalog owned by other work.',
    ),
    C(
      'concurrency.busy-suppresses-duplicate',
      'T12',
      'output',
      'UT_BKP.cs:1211-1251 runs one synchronous backup; the web must prevent duplicate dispatch while busy',
      async (ctx) => {
        const { page, requests } = await ctx.session();
        await open(page);
        await select(page);
        const pending = page.waitForEvent('download');
        await page.getByRole('button', { name: 'Backup', exact: true }).evaluate((button) => {
          button.click();
          button.click();
        });
        await page.getByRole('progressbar', { name: 'Backup progress' }).waitFor();
        assert.equal(
          await page.getByRole('button', { name: 'Backup', exact: true }).isDisabled(),
          true,
        );
        const artifact = await pending;
        const bytes = await bytesOf(artifact);
        await page.getByText('Backup Process Complete.', { exact: true }).waitFor();
        assert.equal(countRequests(requests, 'GET', '/api/backup'), 1);
        return {
          observation: 'two same-turn clicks produced one GET and one download',
          expected: { requests: 1 },
          output: bytes,
        };
      },
    ),
    C(
      'retry.failure-has-no-success',
      'T13',
      'refusal',
      'Current GET /backup policy is authenticated/admin; UT_BKP.cs:1198-1204 refuses unauthorized operators before backup',
      async (ctx) => {
        const before = await backupRuns(ctx);
        const { page } = await ctx.session(as(USERS.clerk.user, 'backup-clerk'));
        await open(page);
        await select(page);
        const [response] = await Promise.all([
          page.waitForResponse(
            (candidate) =>
              new URL(candidate.url()).pathname === '/api/backup' &&
              candidate.request().method() === 'GET',
          ),
          page.getByRole('button', { name: 'Backup', exact: true }).click(),
        ]);
        assert.equal(new URL(response.url()).pathname, '/api/backup');
        assert.equal(response.request().method(), 'GET');
        assert.equal(response.status(), 403);
        const alert = page.getByRole('alert');
        await alert.waitFor();
        assert.notEqual((await alert.innerText()).trim(), '');
        assert.equal(await page.getByText('Backup Process Complete.', { exact: true }).count(), 0);
        assert.deepEqual(await backupRuns(ctx), before);
        return {
          observation:
            'non-admin GET returned 403, displayed an error, no success, and no audit row',
          expected: { method: 'GET', path: '/api/backup', status: 403, success: false },
          database: { before, after: before },
        };
      },
    ),
    C(
      'rollback.restore-remains-contained',
      'T14',
      'refusal',
      'UT_BKP.cs:859 hides Restore; POST /backup/restore remains the logical-restore containment route',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        const response = await page.request.post('/api/backup/restore', { data: {} });
        const body = await response.json();
        assert.equal(response.status(), 503);
        assert.equal(body.operation, 'logical-restore');
        return {
          observation: 'direct restore POST returned the 503 logical-restore containment refusal',
          expected: { status: 503 },
          database: { mutation: 'none; contained before DB access' },
        };
      },
    ),
    C(
      'config.nextmain-allowlist',
      'T15',
      'output',
      'D-BKP-3 requires a versioned allowlist for selected tenant company/user/rights/menu configuration equivalent to NextMain',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        await select(page);
        const result = await download(page);
        const tenantConfig = result.document.tenantConfig;
        assert(
          tenantConfig && typeof tenantConfig === 'object' && !Array.isArray(tenantConfig),
          'archive is missing the versioned tenantConfig section',
        );
        assert(
          Number.isInteger(tenantConfig.version) && tenantConfig.version > 0,
          'tenantConfig.version must be a positive integer',
        );
        assert(
          Array.isArray(tenantConfig.allowlist) && tenantConfig.allowlist.length > 0,
          'tenantConfig.allowlist must be a non-empty array',
        );
        return {
          observation: `archive includes tenantConfig v${tenantConfig.version} with ${tenantConfig.allowlist.length} allowlisted entries`,
          expected: { versionedTenantConfig: true, nonEmptyAllowlist: true },
          output: result.bytes,
        };
      },
      {
        expected: { versionedTenantConfig: true, nonEmptyAllowlist: true },
        requiredEvidence: ['browser', 'expected', 'output'],
      },
    ),
    blocked(
      'output.physical-save-confirmation',
      'T16',
      'UT_BKP.cs:1216-1248 deletes/replaces a physical same-hour file; D-BKP-2 adapts this to a browser suggestion',
      'The current browser environment does not provide File System Access physical-save confirmation. Browser/OS overwrite or duplicate naming remains outside page control.',
    ),
    blocked(
      'output.full-lite-fixture',
      'T16',
      'D-BKP-3 requires proof for every Lite dataset',
      'The shared feature fixture exercises representative masters, vouchers, tags, openings and settings but does not populate every one of the 160 included tables. A large full-Lite fixture remains external evidence work; the existing 100,001-row DB test is cited rather than duplicated.',
    ),
    C(
      'keyboard.reference-workflow',
      'T17',
      'output',
      'UT_BKP.cs:925-936 Select; :1198-1251 Backup; :1147-1154 Esc; browser D-BKP-2 uses the same source order',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        assert.equal(
          await page
            .getByRole('button', { name: 'Select', exact: true })
            .evaluate((e) => e === document.activeElement),
          true,
        );
        await page.keyboard.press('Enter');
        await page.keyboard.press('Tab');
        const pending = page.waitForEvent('download');
        await page.keyboard.press('Enter');
        const artifact = await pending;
        const bytes = await bytesOf(artifact);
        await page.getByText('Backup Process Complete.', { exact: true }).waitFor();
        return {
          observation: 'keyboard Select → Backup initiated the named download',
          expected: { filename: artifact.suggestedFilename() },
          output: bytes,
        };
      },
    ),
    C(
      'journey.no-restore-ui-path',
      'T18',
      'read-only',
      'UT_BKP.cs:859 keeps Restore hidden and :899-901 keeps Dattach hidden in the ordinary operator screen',
      async (ctx) => {
        const { page, requests } = await ctx.session();
        await open(page);
        await assertRecoveryBoundary(page);
        assert.equal(
          requests.some((request) => request.path === '/api/backup/restore'),
          false,
        );
        return {
          observation: 'no Restore/Dattach control and no UI request path to restore',
          expected: { restoreVisible: false },
        };
      },
    ),
    blocked(
      'journey.scratch-zero-diff',
      'T18',
      'D-BKP-3 requires importing the actual browser artifact into scratch while web restore stays contained',
      'X31/G64/N80 remain open: milestone 1 has no approved offline import for the tenant-shared NextMain-equivalent set, so a zero-diff scratch proof cannot yet be produced without guessing or enabling web restore.',
    ),
  ],
};
