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
    C(
      'rights.desktop-print-handoff',
      'T11',
      'refusal',
      'UT_BKP.cs:942-965 reads USER_SET FRM_PRINT under the caption Data Backup; :1203-1207 answers "You Have No Print Rights....." and returns before any backup',
      async (ctx) => {
        const before = await backupRuns(ctx);
        const grants = (view, print) =>
          ctx.owner.$executeRawUnsafe(
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Company','Data Backup',$3,'N','N',$4)`,
            ctx.tenantId,
            USERS.clerk.user,
            view,
            print,
          );
        const drop = () =>
          ctx.owner.$executeRawUnsafe(
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "SUB_MENU"='Data Backup' AND "USER_NAME"=$2`,
            ctx.tenantId,
            USERS.clerk.user,
          );
        await drop();
        try {
          const { page } = await ctx.session(as(USERS.clerk.user, 'backup-rights'));
          // No Data Backup row at all: refused, with the Print text the form itself uses (:1203-1207).
          const none = await page.request.get('/api/backup');
          assert.equal(none.status(), 403);
          assert.equal((await none.json()).message, 'You Have No Print Rights.....');
          // The menu right without Print: the form opens, Backup answers the Print refusal.
          await grants('Y', 'N');
          await open(page);
          await select(page);
          const [refused] = await Promise.all([
            page.waitForResponse(
              (r) => new URL(r.url()).pathname === '/api/backup' && r.request().method() === 'GET',
            ),
            page.getByRole('button', { name: 'Backup', exact: true }).click(),
          ]);
          assert.equal(refused.status(), 403);
          await page.getByText('You Have No Print Rights.....', { exact: true }).waitFor();
          assert.equal(
            await page.getByText('Backup Process Complete.', { exact: true }).count(),
            0,
          );
          assert.deepEqual(await backupRuns(ctx), before);
          // With Print the same user backs up, and the run is recorded under that user.
          await drop();
          await grants('Y', 'Y');
          await open(page);
          await select(page);
          const result = await download(page);
          verifyArchive(result.document);
          const after = await backupRuns(ctx);
          assert.equal(after.length, before.length + 1);
          assert.equal(after.at(-1).operator, USERS.clerk.user);
          return {
            observation:
              'no row: 403 "You Have No Print Rights....."; View only: "You Have No Print Rights....."; View+Print: the archive downloaded and was recorded under the clerk',
            expected: { none: 403, viewOnly: 403, viewPrint: 'downloaded' },
            database: { before: before.length, after: after.at(-1) },
            downstream: { operator: after.at(-1).operator },
          };
        } finally {
          await drop();
        }
      },
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
      'GET /backup needs the Data Backup menu right and its Print right (UT_BKP.cs:942-965, :1198-1204); a user without them is refused before any backup',
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
        const alert = page
          .locator('.panel')
          .getByRole('alert')
          .filter({ hasText: 'You Have No Print Rights.....' });
        await alert.waitFor();
        assert.equal((await alert.innerText()).trim(), 'You Have No Print Rights.....');
        assert.equal(await page.getByText('Backup Process Complete.', { exact: true }).count(), 0);
        assert.deepEqual(await backupRuns(ctx), before);
        return {
          observation:
            'a user without the Data Backup Print right got 403 and the desktop text, no success, and no audit row',
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
    C(
      'output.browser-download-handoff',
      'T16',
      'output',
      "UT_BKP.cs:1216-1250 kills any same-hour Next<YY>[_<type>]_ddMMyy_HH.BAK, writes the new file to the chosen folder and then shows \"Backup Process Complete.\". WEB ADAPTATION (D-BKP-2, offline single-PC mechanic): a hosted server cannot write to the operator's disk, so the web hands the archive to the browser as an attachment download with the same name pattern and records the run on the server; the physical save/overwrite is the browser's and the OS's. This case asserts that handoff in place of the desktop's physical-file confirmation",
      async (ctx) => {
        await seedScopeSentinels(ctx);
        const before = await backupRuns(ctx);
        const { page } = await ctx.session();
        await open(page);
        await select(page);
        const answer = page.waitForResponse(
          (r) => new URL(r.url()).pathname === '/api/backup' && r.request().method() === 'GET',
        );
        const started = new Date();
        const result = await download(page);
        const response = await answer;
        assert.equal(response.status(), 200);
        const headers = response.headers();
        // Fastify appends the charset to the route's application/json.
        assert.match(
          headers['content-type'] ?? '',
          /^application\/json(;\s*charset=utf-8)?$/i,
          `the archive is JSON: ${headers['content-type']}`,
        );
        const named = /^attachment; filename="([^"]+)"$/.exec(headers['content-disposition'] ?? '');
        assert(named, `offered as an attachment download: ${headers['content-disposition']}`);
        // The desktop name pattern (UT_BKP.cs:1218, 1236) with the web archive extension, for the hour of the run.
        const two = (n) => String(n).padStart(2, '0');
        const stamp = (d) =>
          `${two(d.getDate())}${two(d.getMonth() + 1)}${two(d.getFullYear() % 100)}_${two(d.getHours())}`;
        const hours = new Set([stamp(started), stamp(new Date())]);
        const match = /^Next\d{2}_R_(\d{6}_\d{2})\.json$/.exec(named[1]);
        assert(
          match && hours.has(match[1]),
          `${named[1]} follows Next<YY>_R_ddMMyy_HH for this hour`,
        );
        assert.equal(
          result.artifact.suggestedFilename(),
          named[1],
          'the browser saves under the server name',
        );
        // The saved file is the server's archive: it parses, every table and the archive checksum recompute
        // (verifyArchive), and the checksum equals the one the server recorded for this run. (Playwright keeps no
        // body for this ~1.8 MB gzip fetch, so a byte compare against response.body() is not possible.)
        verifyArchive(result.document);
        const after = await backupRuns(ctx);
        assert.equal(after.length, before.length + 1, 'the server records exactly one backup run');
        assert.equal(after.at(-1).checksum, result.document.checksum);
        assert.equal(after.at(-1).operator, USERS.admin.user);
        return {
          observation: `GET /api/backup → 200 ${headers['content-type']}, attachment "${named[1]}", the saved file verifies and carries the checksum the server recorded, "Backup Process Complete." shown, one company_backup_run recorded`,
          expected: {
            contentType: 'application/json',
            disposition: 'attachment; filename="Next<YY>_R_ddMMyy_HH.json"',
            message: 'Backup Process Complete.',
            serverRecord: 1,
          },
          database: { before: before.length, after: after.at(-1) },
          output: result.bytes,
        };
      },
      { requiredEvidence: ['browser', 'expected', 'database', 'output'] },
    ),
    C(
      'output.full-lite-fixture',
      'T16',
      'output',
      'D-BKP-3 requires proof for every Lite dataset: the archive holds every company table, with a row in each, and every hash verifies',
      async (ctx) => {
        const { page } = await ctx.session();
        await open(page);
        await select(page);
        const included = (await download(page)).document.manifest.tables
          .filter((table) => table.included)
          .map((table) => table.name);
        const added = [];
        const failed = [];
        try {
          for (const name of included) {
            const [{ n }] = await ctx.rows(
              `SELECT count(*)::int n FROM "${name}" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            );
            if (n > 0) continue;
            const columns = await ctx.owner.$queryRawUnsafe(
              `SELECT column_name name,data_type type,udt_name udt,character_maximum_length len,is_nullable nullable,
                      column_default dflt,is_generated gen,is_identity ident
                 FROM information_schema.columns WHERE table_schema='public' AND table_name=$1 ORDER BY ordinal_position`,
              name,
            );
            const names = [];
            const values = [];
            for (const c of columns) {
              const own =
                c.name === 'tenant_id' ? ctx.tenantId : c.name === 'CO_CODE' ? '01' : undefined;
              if (
                own === undefined &&
                (c.nullable === 'YES' || c.dflt !== null || c.gen === 'ALWAYS' || c.ident === 'YES')
              )
                continue;
              names.push(`"${c.name}"`);
              if (own !== undefined) values.push(`'${own}'`);
              else if (/char|text/.test(c.type))
                values.push(`'${'E'.repeat(Math.min(c.len ?? 3, 3))}'`);
              else if (/int|numeric|double|real|decimal/.test(c.type)) values.push('0');
              else if (c.type === 'date') values.push(`'2024-04-01'`);
              else if (/timestamp/.test(c.type)) values.push('now()');
              else if (c.type === 'boolean') values.push('false');
              else if (/json/.test(c.type)) values.push(`'{}'`);
              else if (c.type === 'bytea') values.push(`'\\x00'`);
              else if (c.type === 'USER-DEFINED')
                values.push(
                  `(SELECT e.enumlabel::text FROM pg_enum e JOIN pg_type t ON t.oid=e.enumtypid WHERE t.typname='${c.udt}' ORDER BY e.enumsortorder LIMIT 1)::${c.udt}`,
                );
              else values.push('NULL');
            }
            try {
              const [row] = await ctx.owner.$queryRawUnsafe(
                `INSERT INTO "${name}"(${names.join(',')}) VALUES (${values.join(',')}) RETURNING ctid::text AS ctid`,
              );
              added.push({ name, ctid: row.ctid });
            } catch (error) {
              failed.push(
                `${name}: ${String(error?.message ?? error)
                  .split('\n')
                  .pop()}`,
              );
            }
          }
          assert.deepEqual(failed, [], 'a row could be added to every empty company table');
          const result = await download(page);
          verifyArchive(result.document);
          const empty = Object.entries(result.document.tables)
            .filter(([, table]) => table.rowCount === 0)
            .map(([name]) => name);
          assert.deepEqual(empty, [], 'every company table carries at least one row');
          assert.equal(result.document.totals.companyTables, included.length);
          return {
            observation: `${included.length} company tables, ${added.length} filled for the case, every one with rows and a verified checksum`,
            expected: { tables: included.length, empty: 0 },
            output: result.bytes,
          };
        } finally {
          for (const { name, ctid } of added)
            await ctx.owner.$executeRawUnsafe(`DELETE FROM "${name}" WHERE ctid=$1::tid`, ctid);
        }
      },
      { requiredEvidence: ['browser', 'expected', 'output'] },
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
    C(
      'journey.scratch-zero-diff',
      'T18',
      'output',
      'D-BKP-3: the browser artifact is imported (replace) and the company reads back exactly as the artifact; web restore stays contained (POST /backup/restore 503)',
      async (ctx) => {
        await seedScopeSentinels(ctx);
        const { restoreCompany, backupCompany } =
          await import('../../../../api/dist/modules/ops/backup.js');
        const { page } = await ctx.session();
        await open(page);
        await select(page);
        const artifact = await download(page);
        // The company changes after the backup was taken: a renamed company and a stray account.
        const [{ name }] = await ctx.rows(
          `SELECT "CO_NAME" name FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_MAST" SET "CO_NAME"='PERTURBED AFTER BACKUP' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          ctx.tenantId,
        );
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','E2EPERT','STRAY AFTER BACKUP')`,
          ctx.tenantId,
        );
        const contained = await page.request.post('/api/backup/restore', { data: {} });
        assert.equal(contained.status(), 503, 'the web restore route stays contained');
        // An archive never carries a secret (D37): the credential columns come back empty from an import. The fixture's
        // users must still sign in for the modules that run after this one, so their values are put back afterwards.
        const secrets = [
          ['LOGIN_MAST', 'LOGIN_PWD', 'LOGIN_NAME'],
          ['CO_MAST', 'URL_PWD', 'CO_CODE'],
          ['CO_MAST', 'MAIL_API', 'CO_CODE'],
        ];
        // The two other secret columns hold nothing in the fixture; had they held a value, the import would erase it.
        const [{ other }] = await ctx.rows(
          `SELECT (SELECT count(*) FROM "BOOK_IDTL" WHERE tenant_id=$1 AND "SVR_PWD" IS NOT NULL)::int
                + (SELECT count(*) FROM "DG_GOLD_MAST" WHERE tenant_id=$1 AND "API_KEY" IS NOT NULL)::int other`,
        );
        assert.equal(other, 0, 'no other secret would be erased by the import');
        const kept = [];
        for (const [table, column, key] of secrets)
          for (const row of await ctx.rows(
            `SELECT "${key}"::text k,"${column}" v FROM "${table}" WHERE tenant_id=$1 AND "${column}" IS NOT NULL`,
          ))
            kept.push({ table, column, key, ...row });
        let result;
        try {
          result = await restoreCompany(
            ctx.stack.runtime,
            { tenantId: ctx.tenantId, companyCode: '01' },
            artifact.document,
          );
        } finally {
          for (const { table, column, key, k, v } of kept)
            await ctx.owner.$executeRawUnsafe(
              `UPDATE "${table}" SET "${column}"=$3 WHERE tenant_id=$1 AND "${key}"::text=$2`,
              ctx.tenantId,
              k,
              v,
            );
        }
        const after = await backupCompany(ctx.stack.runtime, ctx.tenantId, '01');
        assert.deepEqual(normalize(after), normalize(artifact.document));
        const [back] = await ctx.rows(
          `SELECT "CO_NAME" name,(SELECT count(*)::int FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"='E2EPERT') stray
             FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        assert.deepEqual(back, { name, stray: 0 });
        return {
          observation: `the artifact was imported (${result.restored} rows) and the company reads back with the same schema fingerprint and ${Object.keys(artifact.document.tables).length} identical table checksums; the later changes are gone. The tenantConfig section has no import path (X31) and is not part of this proof`,
          expected: { zeroDiff: true, restoreRoute: 503 },
          output: artifact.bytes,
        };
      },
      { requiredEvidence: ['browser', 'expected', 'output'] },
    ),
  ],
};
