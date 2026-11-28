import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { holdAdvisoryLock } from '../harness.mjs';
import { changedTables, tenantFingerprint } from '../faults.mjs';

/**
 * Feature: Company → Data Refresh (desktop MS_UPDATE).
 *
 * PR-1 deliberately proves only Approval Adj as a complete writer. Account and Stock expose exact proven
 * partial anomaly counts but cannot apply the unproved builder graphs. Field Update runs its two class-a repairs; Old Field awaits the
 * PR-2 statement classification. Image Data is schema architecture, not a runtime DDL operation on the web.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `data-refresh.${id}`,
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
const notApplicable = (id, group, source, reason) => ({
  ...C(id, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});
const blocked = (id, group, source, reason) => ({
  ...C(id, group, 'read-only', source, async () => ({})),
  blocked: reason,
});

const captions = ['Account', 'Stock', 'Field Update', 'Approval Adj', 'Image Data', 'Old Field'];
const previewOnlyOperations = [
  ['data-refresh-account', 'Account'],
  ['data-refresh-stock', 'Stock'],
  ['data-refresh-old-field', 'Old Field'],
];
const hidden = ['Crm Data', 'Problem Qry', 'TagDiff Set', 'Mfg Refresh', 'Scheme Data'];
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const PADDED_YEAR = `${YEAR} `;
const WRONG_YEAR = `${startYear - 1}-${startYear}`;
const apiPath = (response) => new URL(response.url()).pathname;
const isApi = (response, suffix) => apiPath(response) === `/api${suffix}`;
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

async function openScreen(page) {
  await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'Data Refresh', exact: true });
  await link.click();
  await page.getByRole('heading', { name: 'Data Refresh', exact: true }).waitFor();
  await page.getByRole('button', { name: 'Account', exact: true }).waitFor();
  // The operation buttons are disabled while the screen loads, and a disabled button cannot take focus.
  await page.locator('main[aria-busy="false"]').waitFor();
}

async function cleanApprovalFixtures(ctx, tx = ctx.owner) {
  for (const table of ['APR_DETL', 'SL_DETL', 'RATE_CUT_ISU', 'BAR_DETL'])
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=$1
        AND (coalesce("TAG_NO",'') LIKE 'DRF%' OR coalesce("VCH_NO",'') LIKE 'DRF%')`,
      ctx.tenantId,
    );
}

async function approvalSnapshot(ctx) {
  const [apr, bars, runs] = await Promise.all([
    ctx.rows(
      `SELECT row_id::text id,"ISU_REC" flag FROM "APR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"=$2
          AND "BOOK_NAME"='APR ISU' ORDER BY row_id`,
      YEAR,
    ),
    ctx.rows(
      `SELECT row_id::text id,"APR_ISU" flag FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"=$2
        ORDER BY row_id`,
      YEAR,
    ),
    ctx.rows(
      `SELECT row_id::text id FROM "data_repair_run"
        WHERE tenant_id=$1 AND operation_id='approval-reconcile' ORDER BY row_id`,
    ),
  ]);
  return { apr, bars, runIds: runs.map((row) => row.id) };
}

async function restoreApprovalSnapshot(ctx, snapshot) {
  await ctx.owner.$transaction(async (tx) => {
    await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
    await cleanApprovalFixtures(ctx, tx);
    if (snapshot.runIds.length) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "data_repair_run"
          WHERE tenant_id=$1 AND operation_id='approval-reconcile'
            AND NOT (row_id::text = ANY($2::text[]))`,
        ctx.tenantId,
        snapshot.runIds,
      );
    } else {
      await tx.$executeRawUnsafe(
        `DELETE FROM "data_repair_run"
          WHERE tenant_id=$1 AND operation_id='approval-reconcile'`,
        ctx.tenantId,
      );
    }
    for (const row of snapshot.apr)
      await tx.$executeRawUnsafe(
        `UPDATE "APR_DETL" SET "ISU_REC"=$3
          WHERE tenant_id=$1 AND row_id=$2::bigint AND "ISU_REC" IS DISTINCT FROM $3`,
        ctx.tenantId,
        row.id,
        row.flag,
      );
    for (const row of snapshot.bars)
      await tx.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "APR_ISU"=$3
          WHERE tenant_id=$1 AND row_id=$2::bigint AND "APR_ISU" IS DISTINCT FROM $3`,
        ctx.tenantId,
        row.id,
        row.flag,
      );
  });
}

async function withApprovalFixtures(ctx, run) {
  await cleanApprovalFixtures(ctx);
  const snapshot = await approvalSnapshot(ctx);
  try {
    await seedApproval(ctx);
    return await run();
  } finally {
    // Approval Adj intentionally normalizes the whole selected scope. Restore every pre-existing flag and remove
    // this case's fixture/history so repeated cases cannot affect one another or modules that run afterward.
    await restoreApprovalSnapshot(ctx, snapshot);
  }
}

async function seedApproval(ctx) {
  await exec(
    ctx,
    `INSERT INTO "APR_DETL"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","BOOK_NAME","TAG_NO","VCH_SRNO","ISU_REC")
     VALUES ($1,'01','01',$2,'AI','DRFI1',1,1,'APR ISU','DRF-APRRTN',901,'N'),
            ($1,'01','01',$2,'AI','DRFI2',1,2,'APR ISU','DRF-SALES',902,'N'),
            ($1,'01','01',$2,'AI','DRFI3',1,3,'APR ISU','DRF-WH',903,'N'),
            ($1,'01','01',$2,'AI','DRFI4',1,4,'APR ISU','DRF-RATE',904,'N'),
            ($1,'01','01',$2,'AI','DRFI5',1,5,'APR ISU','DRF-OPEN',905,'Y'),
            ($1,'01','02',$2,'AI','DRFI6',1,6,'APR ISU','DRF-OTHER-LC',906,'Y'),
            ($1,'01','01',$3,'AI','DRFI7',1,7,'APR ISU','DRF-WRONG-YR',907,'Y'),
            ($1,'01','01',$2,'ART','DRFR1',1,1,'APR RTN','N',0,'N')`,
    YEAR,
    WRONG_YEAR,
  );
  await exec(
    ctx,
    `UPDATE "APR_DETL" SET "ISU_YRCD"=$2,"ISU_DBCD"='AI ',"ISU_NO"='DRFI1  ',"ISU_SRNO"=1
      WHERE tenant_id=$1 AND "VCH_NO"='DRFR1'`,
    PADDED_YEAR,
  );
  await exec(
    ctx,
    `INSERT INTO "SL_DETL"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TAG_NO","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO")
     VALUES ($1,'01','01',$2,'SL','DRFS1',1,'SALES','N',$3,'AI ','DRFI2  ',2),
            ($1,'01','01',$2,'SL','DRFS2',1,'SALES','N',$3,'AI ',' DRFI5',5)`,
    YEAR,
    PADDED_YEAR,
  );
  await exec(
    ctx,
    `INSERT INTO "RATE_CUT_ISU"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TAG_NO","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO")
     VALUES ($1,'01','01',$2,'WHS','DRFW1',1,'WH SALES','N',$3,'AI ','DRFI3  ',3),
            ($1,'01','01',$2,'RTC','DRFC1',1,'RATE CUT','N',$3,'AI ','DRFI4  ',4)`,
    YEAR,
    PADDED_YEAR,
  );
  await exec(
    ctx,
    `INSERT INTO "BAR_DETL"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TAG_NO","VCH_SRNO","IT_CODE","APR_ISU")
     VALUES ($1,'01','01',$2,'TAG','DRFB1',1,'TAG OPENING','DRF-APRRTN',901,'GLD22','Y'),
            ($1,'01','01',$2,'TAG','DRFB2',1,'TAG OPENING','DRF-SALES',902,'GLD22','Y'),
            ($1,'01','01',$2,'TAG','DRFB3',1,'TAG OPENING','DRF-WH',903,'GLD22','Y'),
            ($1,'01','01',$2,'TAG','DRFB4',1,'TAG OPENING','DRF-RATE',904,'GLD22','Y'),
            ($1,'01','01',$2,'TAG','DRFB5',1,'TAG OPENING','DRF-OPEN',905,'GLD22','N'),
            ($1,'01','02',$2,'TAG','DRFB6',1,'TAG OPENING','DRF-OTHER-LC',906,'GLD22','N'),
            ($1,'01','01',$3,'TAG','DRFB7',1,'TAG OPENING','DRF-WRONG-YR',907,'GLD22','N')`,
    YEAR,
    WRONG_YEAR,
  );
}

const flags = (ctx) =>
  ctx.rows(
    `SELECT 'APR' kind,"TAG_NO" tag,"ISU_REC" flag FROM "APR_DETL"
      WHERE tenant_id=$1 AND "TAG_NO" LIKE 'DRF%'
     UNION ALL
     SELECT 'BAR',"TAG_NO","APR_ISU" FROM "BAR_DETL"
      WHERE tenant_id=$1 AND "TAG_NO" LIKE 'DRF%'
     ORDER BY kind,tag`,
  );

const rtrimSpaces = (value) => String(value ?? '').replace(/ +$/u, '');
const sqlEqual = (left, right) => left != null && right != null && left === right;

/**
 * Independent source oracle for MS_UPDATE.cs:8815-8820. The queries only fetch raw rows; JavaScript performs the
 * four-source trailing-space match and then derives every issue and BAR flag in the selected whole scope.
 */
async function approvalOracle(ctx) {
  const [issues, sources, bars] = await Promise.all([
    ctx.rows(
      `SELECT row_id::text id,"CO_CODE" co,"LC_CODE" lc,"CO_YEAR" yr,"CO_BOOK" book,
              "VCH_NO" vch,"OLD_SRNO" oldsr,"TAG_NO" tag,"VCH_SRNO" vchsr,
              coalesce("ISU_REC",'') stored
         FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
          AND "CO_YEAR"=$2 AND "BOOK_NAME"='APR ISU' ORDER BY row_id`,
      YEAR,
    ),
    ctx.rows(
      `SELECT 'APR_DETL' source,"CO_CODE" co,"LC_CODE" lc,"BOOK_NAME" bookname,
              "ISU_YRCD" isuyr,"ISU_DBCD" isubook,"ISU_NO" isuno,"ISU_SRNO" isusr
         FROM "APR_DETL" WHERE tenant_id=$1
       UNION ALL
       SELECT 'SL_DETL',"CO_CODE","LC_CODE","BOOK_NAME","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO"
         FROM "SL_DETL" WHERE tenant_id=$1
       UNION ALL
       SELECT 'RATE_CUT_ISU',"CO_CODE","LC_CODE","BOOK_NAME","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO"
         FROM "RATE_CUT_ISU" WHERE tenant_id=$1`,
    ),
    ctx.rows(
      `SELECT row_id::text id,"CO_CODE" co,"LC_CODE" lc,"CO_YEAR" yr,"TAG_NO" tag,
              "VCH_SRNO" vchsr,coalesce("APR_ISU",'') stored
         FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
          AND "CO_YEAR"=$2 ORDER BY row_id`,
      YEAR,
    ),
  ]);
  const acceptedBook = (row) =>
    (row.source === 'APR_DETL' && row.bookname === 'APR RTN') ||
    (row.source === 'SL_DETL' && row.bookname === 'SALES') ||
    (row.source === 'RATE_CUT_ISU' && ['WH SALES', 'RATE CUT'].includes(row.bookname));
  const consumed = (issue) =>
    sources.some(
      (source) =>
        acceptedBook(source) &&
        rtrimSpaces(source.isuno) !== '' &&
        sqlEqual(source.co, issue.co) &&
        sqlEqual(source.lc, issue.lc) &&
        rtrimSpaces(source.isuyr) === rtrimSpaces(issue.yr) &&
        rtrimSpaces(source.isubook) === rtrimSpaces(issue.book) &&
        rtrimSpaces(source.isuno) === rtrimSpaces(issue.vch) &&
        source.isusr != null &&
        issue.oldsr != null &&
        Number(source.isusr) === Number(issue.oldsr),
    );
  const issueStates = issues.map((issue) => ({ ...issue, consumed: consumed(issue) }));
  const issueUpdates = issueStates.filter(
    (issue) => issue.stored !== (issue.consumed ? 'Y' : 'N'),
  ).length;
  const barUpdates = bars.filter((bar) => {
    const unconsumed = issueStates.some(
      (issue) =>
        !issue.consumed &&
        sqlEqual(issue.co, bar.co) &&
        sqlEqual(issue.lc, bar.lc) &&
        sqlEqual(issue.yr, bar.yr) &&
        sqlEqual(issue.tag, bar.tag) &&
        issue.vchsr != null &&
        bar.vchsr != null &&
        Number(issue.vchsr) === Number(bar.vchsr),
    );
    return bar.stored !== (unconsumed ? 'Y' : 'N');
  }).length;
  return [
    ...(issueUpdates ? [{ table: 'APR_DETL', insert: 0, update: issueUpdates, delete: 0 }] : []),
    ...(barUpdates ? [{ table: 'BAR_DETL', insert: 0, update: barUpdates, delete: 0 }] : []),
  ];
}

function assertApprovalFixture(rows) {
  assert.deepEqual(
    rows.map((row) => [row.kind, row.tag, row.flag]),
    [
      ['APR', 'DRF-APRRTN', 'Y'],
      ['APR', 'DRF-OPEN', 'N'],
      ['APR', 'DRF-OTHER-LC', 'Y'],
      ['APR', 'DRF-RATE', 'Y'],
      ['APR', 'DRF-SALES', 'Y'],
      ['APR', 'DRF-WH', 'Y'],
      ['APR', 'DRF-WRONG-YR', 'Y'],
      ['BAR', 'DRF-APRRTN', 'N'],
      ['BAR', 'DRF-OPEN', 'Y'],
      ['BAR', 'DRF-OTHER-LC', 'N'],
      ['BAR', 'DRF-RATE', 'N'],
      ['BAR', 'DRF-SALES', 'N'],
      ['BAR', 'DRF-WH', 'N'],
      ['BAR', 'DRF-WRONG-YR', 'N'],
    ],
  );
}

async function previewApproval(page) {
  const [response] = await Promise.all([
    page.waitForResponse((value) =>
      isApi(value, '/utilities/data-refresh/approval-reconcile/preview'),
    ),
    page.getByRole('button', { name: 'Approval Adj', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  return response.json();
}

async function applyApproval(page) {
  const [response] = await Promise.all([
    page.waitForResponse((value) =>
      isApi(value, '/utilities/data-refresh/approval-reconcile/apply'),
    ),
    page.getByRole('button', { name: 'Apply Approval Adj', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  return response.json();
}

async function approvalLifecycle(ctx, inspect) {
  return withApprovalFixtures(ctx, async () => {
    const before = await flags(ctx);
    const expectedDiffs = await approvalOracle(ctx);
    const { page } = await ctx.session(as(USERS.admin.user, 'data-refresh-approval'));
    await openScreen(page);
    const preview = await previewApproval(page);
    assert.deepEqual(preview.diffs, expectedDiffs);
    const result = await applyApproval(page);
    assert.deepEqual(result.applied, expectedDiffs);
    await page.getByText('Approval Refersh Process Complete.', { exact: true }).waitFor();
    const after = await flags(ctx);
    assertApprovalFixture(after);
    return inspect({ page, preview, result, before, after, expectedDiffs });
  });
}

/**
 * Account check-and-repair on Contra (owner decision 2026-11-27): a contra saved through the normal route, one ledger
 * amount damaged in the database, found by the screen's check, repaired by its apply, and clean on the next check.
 */
const CONTRA_TABLES = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA', 'REMARK_DATA', 'TEMP_BOOK_DATA'];
async function contraPostings(ctx, vchNo) {
  const out = {};
  for (const table of ['AC_DATA', 'ROJ_MEL_DATA', 'TAX_DATA'])
    out[table] = await ctx.rows(
      `SELECT to_jsonb(t) - 'row_id' AS r FROM "${table}" t
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"=$2 AND "CO_BOOK"='CON' AND "VCH_NO"=$3
        ORDER BY to_jsonb(t)::text`,
      YEAR,
      vchNo,
    );
  return out;
}

async function checkContra(page) {
  const [response] = await Promise.all([
    page.waitForResponse((value) =>
      isApi(value, '/utilities/data-refresh/data-refresh-account-contra/preview'),
    ),
    page.getByRole('button', { name: 'Check vouchers', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  return response.json();
}

async function accountContraLifecycle(ctx) {
  const { page } = await ctx.session(as(USERS.admin.user, 'data-refresh-account-contra'));
  await openScreen(page);
  const today = new Date();
  const vchDate = `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, '0')}-${String(today.getDate()).padStart(2, '0')}`;
  const created = await page.evaluate(async (date) => {
    const response = await fetch('/api/contra', {
      method: 'POST',
      credentials: 'include',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({
        coBook: 'CON',
        vchDate: date,
        lines: [
          { crdr: 'DR', acCode: 'BANK', amount: 321.5, itDesc: 'DRF account check' },
          { crdr: 'CR', acCode: 'CASH', amount: 321.5 },
        ],
      }),
    });
    return { status: response.status, body: await response.text() };
  }, vchDate);
  assert.equal(created.status, 201, created.body);
  const vchNo = String(JSON.parse(created.body).vchNo).padStart(5, '0');
  const checksum = `${'d'.repeat(48)}${String(Date.now()).slice(-16).padStart(16, '0')}`;
  try {
    const writer = await contraPostings(ctx, vchNo);
    await exec(
      ctx,
      `UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+1
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"=$2 AND "CO_BOOK"='CON' AND "VCH_NO"=$3
          AND "DR_AMT"<>0`,
      YEAR,
      vchNo,
    );
    await exec(
      ctx,
      `INSERT INTO "company_backup_run"(tenant_id,co_code,checksum,document_version,generated_at,table_count,row_count,operator)
       VALUES ($1,'01',$2,1,now(),1,0,$3)`,
      checksum,
      USERS.admin.user,
    );
    const [accountResponse] = await Promise.all([
      page.waitForResponse((value) =>
        isApi(value, '/utilities/data-refresh/data-refresh-account/preview'),
      ),
      page.getByRole('button', { name: 'Account', exact: true }).click(),
    ]);
    assert.equal(accountResponse.status(), 200, await accountResponse.text());
    await page.locator('#account-family').selectOption('contra');
    const first = await checkContra(page);
    const differing = first.detail.vouchers.filter((v) =>
      ['differs', 'missing'].includes(v.status),
    );
    assert.deepEqual(
      differing.map((v) => [v.coBook, v.vchNo, v.status]),
      [['CON', vchNo, 'differs']],
    );
    assert.deepEqual(first.diffs, [{ table: 'AC_DATA', insert: 0, update: 1, delete: 0 }]);
    const row = page.locator(`tr[data-voucher="CON/${vchNo}"]`);
    await row.getByText('AC_DATA: 0 missing, 0 extra, 1 changed (DR_AMT)').waitFor();
    await page.locator('#account-reason').fill('repair the damaged contra ledger leg');
    await page.locator('#account-confirmation').fill(first.requiresConfirmation);
    await page.locator('#account-backup').fill(checksum);
    await page.locator('#account-password').fill(process.env.FEATURE_E2E_PASSWORD ?? '');
    const [applyResponse] = await Promise.all([
      page.waitForResponse((value) =>
        isApi(value, '/utilities/data-refresh/data-refresh-account-contra/apply'),
      ),
      page.getByRole('button', { name: 'Apply Contra repair', exact: true }).click(),
    ]);
    assert.equal(applyResponse.status(), 200, await applyResponse.text());
    const applied = await applyResponse.json();
    assert.deepEqual(applied.applied, first.diffs);
    await page.getByText(/Account Refersh Process Complete\./).waitFor();
    const repaired = await contraPostings(ctx, vchNo);
    assert.deepEqual(repaired, writer, 'the apply restores the rows the contra writer posted');
    const second = await checkContra(page);
    assert.equal(
      second.detail.vouchers.some((v) => v.vchNo === vchNo && v.coBook === 'CON'),
      false,
    );
    const [run] = await ctx.rows(
      `SELECT jsonb_array_length(before_rows) n FROM "data_repair_run"
        WHERE tenant_id=$1 AND operation_id='data-refresh-account-contra' AND state='applied'
        ORDER BY row_id DESC LIMIT 1`,
    );
    assert.equal(Number(run.n), 1);
    return { vchNo, first, applied, second, writer, repaired };
  } finally {
    await ctx.owner.$transaction(async (tx) => {
      await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
      for (const table of CONTRA_TABLES)
        await tx.$executeRawUnsafe(
          `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_BOOK"='CON' AND "VCH_NO"=$2`,
          ctx.tenantId,
          vchNo,
        );
      await tx.$executeRawUnsafe(
        `DELETE FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id='data-refresh-account-contra'`,
        ctx.tenantId,
      );
      await tx.$executeRawUnsafe(
        `DELETE FROM "company_backup_run" WHERE tenant_id=$1 AND checksum=$2`,
        ctx.tenantId,
        checksum,
      );
    });
  }
}

export const dataRefresh = {
  feature: 'data-refresh',
  title: 'Company → Data Refresh (MS_UPDATE, /utilities/data-refresh)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'unified/src/csharp/DataCareNext/MS_UPDATE.cs',
    'web/apps/api/src/modules/utilities/dataRepair.ts',
    'web/apps/api/src/modules/utilities/dataRepairOps.ts',
    'web/apps/api/src/modules/utilities/dataRefreshOps.ts',
    'web/apps/api/src/modules/shared/postingAccounts.ts',
    'web/apps/api/src/routes/dataRepair.ts',
    'web/apps/web/app/(app)/utilities/data-refresh/page.tsx',
    'web/apps/web/app/(app)/utilities/data-repair/page.tsx',
    'web/apps/web/test/features/modules/dataRefresh.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    operationScope: `company 01, location 01, year ${YEAR} (current April-March)`,
  },
  cases: [
    C(
      'entry.six-visible-actions',
      'T01',
      'read-only',
      'MS_UPDATE.cs:1371-1504,1606-1615,2275-2301: six default buttons in tab order; Ctrl+O/vendor controls hidden',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const actual = await page
          .getByRole('group', { name: 'Data refresh operations' })
          .getByRole('button')
          .allTextContents();
        assert.deepEqual(actual, captions);
        for (const name of hidden)
          assert.equal(await page.getByText(name, { exact: true }).count(), 0);
        return { observation: `visible actions: ${actual.join(', ')}`, expected: captions };
      },
    ),
    C(
      'routing.each-action-previews',
      'T02',
      'read-only',
      'MS_UPDATE.cs:2334-3047,3958-9038,9412-33074; D-REF-1 through D-REF-3',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        for (const caption of captions) {
          const [response] = await Promise.all([
            page.waitForResponse((value) => apiPath(value).endsWith('/preview')),
            page.getByRole('button', { name: caption, exact: true }).click(),
          ]);
          assert.equal(response.status(), 200, `${caption}: ${await response.text()}`);
          await page.getByRole('heading', { name: `${caption} preview`, exact: true }).waitFor();
        }
        return { observation: 'all six actions produced audited previews', expected: captions };
      },
    ),
    C(
      'formula.approval-four-consumed-sources',
      'T03',
      'mutation',
      'MS_UPDATE.cs:8815-8820: APR RTN, SALES, WH SALES and RATE CUT consume APR ISU by issue year/book/no/old serial',
      async (ctx) =>
        approvalLifecycle(ctx, async (result) => ({
          observation:
            'consumed issue became Y, open issue became N, and BAR flags were their inverse',
          expected: result.preview.diffs,
          database: result.after,
          downstream: 'BAR_DETL now exposes only the unconsumed tag as APR_ISU=Y',
        })),
    ),
    notApplicable(
      'lookup.not-applicable',
      'T04',
      'MS_UPDATE.cs:1371-1986',
      'The six-button MS_UPDATE operator surface has no lookup or editable lookup-backed field.',
    ),
    notApplicable(
      'children.not-applicable',
      'T05',
      'MS_UPDATE.cs:1371-1986',
      'The six-button MS_UPDATE operator surface has no editable child grid.',
    ),
    C(
      'refusal.preview-only-direct-apply',
      'T06',
      'refusal',
      'D-REF-3 and MS_UPDATE.cs:2334-3047,9412-33074: unproved full graphs must not partially apply',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const before = await flags(ctx);
        for (const id of ['data-refresh-account', 'data-refresh-stock', 'data-refresh-old-field']) {
          const response = await page.request.post(`/api/utilities/data-refresh/${id}/apply`, {
            data: { previewHash: '0'.repeat(64) },
          });
          assert.equal(response.status(), 400);
          assert.equal((await response.json()).code, 'preview-only');
        }
        assert.deepEqual(await flags(ctx), before);
        return {
          observation: 'the three direct applies refused with preview-only',
          expected: 'preview-only',
          database: before,
        };
      },
    ),
    C(
      'create.approval-single-transaction',
      'T07',
      'mutation',
      'MS_UPDATE.cs:8815-8821; D-REF-2: preview then one audited transaction',
      async (ctx) =>
        approvalLifecycle(ctx, async (result) => ({
          observation:
            'Approval Adj applied both two-row diffs and showed the source completion text',
          expected: result.preview.diffs,
          database: result.after,
          downstream: 'APR_DETL and BAR_DETL agree on consumed/open state',
        })),
    ),
    C(
      'reopen.clean-preview',
      'T08',
      'read-only',
      'D-REF-2: a fresh preview after apply is clean',
      async (ctx) =>
        approvalLifecycle(ctx, async ({ page }) => {
          const preview = await previewApproval(page);
          assert.equal(preview.clean, true);
          assert.deepEqual(preview.diffs, []);
          return { observation: 'fresh Approval Adj preview was clean', expected: [] };
        }),
    ),
    C(
      'edit.account-stock-classification',
      'T09',
      'read-only',
      'MS_UPDATE.cs:2334-3047: safe anomaly prefixes are classified; complete builder graphs remain unavailable',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        for (const [id, caption] of previewOnlyOperations) {
          const [response] = await Promise.all([
            page.waitForResponse((value) => isApi(value, `/utilities/data-refresh/${id}/preview`)),
            page.getByRole('button', { name: caption, exact: true }).click(),
          ]);
          assert.equal(response.status(), 200, `${caption}: ${await response.text()}`);
          const preview = await response.json();
          assert.equal(preview.applyAvailable, false);
          assert.equal(preview.requiresConfirmation, null);
          assert.deepEqual(preview.authority, {
            confirmation: null,
            reason: false,
            reauthentication: false,
            backupReference: false,
          });
          await page.getByRole('heading', { name: `${caption} preview`, exact: true }).waitFor();
          await page.getByText(/Preview only:/).waitFor();
          assert.equal(
            await page.getByRole('button', { name: `Apply ${caption}`, exact: true }).count(),
            0,
          );
          assert.equal(
            await page.locator('#reason,#confirmation,#operatorPassword,#backupReference').count(),
            0,
          );
        }
        // Image Data (MS_UPDATE.cs:8825-9038) only builds schema the web migrations own: it verifies and is clean.
        const [imageResponse] = await Promise.all([
          page.waitForResponse((value) =>
            isApi(value, '/utilities/data-refresh/data-refresh-image-data/preview'),
          ),
          page.getByRole('button', { name: 'Image Data', exact: true }).click(),
        ]);
        assert.equal(imageResponse.status(), 200, await imageResponse.text());
        const image = await imageResponse.json();
        assert.equal(image.applyAvailable, true);
        assert.equal(image.clean, true);
        assert.match(image.samples.join('\n'), /TAG_IMAGE_DATA has CO_CODE, LC_CODE, TAG_NO/);
        await page.getByText('No records need adjustment.', { exact: true }).waitFor();
        assert.equal(await page.getByText(/Preview only:/).count(), 0);
        // Field Update is no longer a preview-only classification: its two class-a repairs
        // (MS_UPDATE.cs:7214 AC_MAIN_GR, MS_UPDATE.cs:8608 DEFAULTER_AC) apply after a preview.
        const [fieldResponse] = await Promise.all([
          page.waitForResponse((value) =>
            isApi(value, '/utilities/data-refresh/data-refresh-field-update/preview'),
          ),
          page.getByRole('button', { name: 'Field Update', exact: true }).click(),
        ]);
        assert.equal(fieldResponse.status(), 200, await fieldResponse.text());
        const field = await fieldResponse.json();
        assert.equal(field.applyAvailable, true);
        await page.getByRole('heading', { name: 'Field Update preview', exact: true }).waitFor();
        await (
          field.clean
            ? page.getByText('No records need adjustment.', { exact: true })
            : page.getByRole('button', { name: 'Apply Field Update', exact: true })
        ).waitFor();
        assert.equal(await page.getByText(/Preview only:/).count(), 0);
        return {
          observation:
            'the three unproved classifications show no Apply or authority inputs; Image Data verifies and is clean; Field Update previews as an applicable repair',
          expected: { previewOnly: previewOnlyOperations.map(([id]) => id), field: true },
        };
      },
    ),
    C(
      'history.compatibility-ledger',
      'T10',
      'read-only',
      'D-REF-2: previews and applies remain visible in the compatibility history',
      async (ctx) =>
        approvalLifecycle(ctx, async ({ page }) => {
          await page.goto('/utilities/data-repair');
          await page.getByRole('heading', { name: /Data Repair/ }).waitFor();
          const operationTable = page.getByRole('table').first();
          for (const [id, caption] of previewOnlyOperations) {
            const row = operationTable.locator(`tr[data-operation-id="${id}"]`);
            const [response] = await Promise.all([
              page.waitForResponse((value) => isApi(value, `/utilities/data-repair/${id}/preview`)),
              row.getByRole('button', { name: 'Preview', exact: true }).click(),
            ]);
            assert.equal(response.status(), 200, `${caption}: ${await response.text()}`);
            await page.getByText(/Preview only:/).waitFor();
            assert.equal(
              await page.getByRole('button', { name: 'Apply repair', exact: true }).count(),
              0,
            );
            assert.equal(
              await page
                .locator('#reason,#confirmation,#operatorPassword,#backupReference')
                .count(),
              0,
            );
          }
          const history = await page.getByRole('table').last().innerText();
          assert.match(history, /approval-reconcile/);
          assert.match(history, /applied/);
          return {
            observation:
              'advanced Data Repair shows shared history and suppresses Apply and authority inputs for all four preview-only operations',
            expected: 'history retained; preview-only capability honored',
          };
        }),
    ),
    C(
      'rights.caption-print-handoff',
      'T11',
      'refusal',
      'MS_UPDATE.cs:2042-2050 reads USER_SET FRM_PRINT under the caption Data Refresh; :2338-2342, :2675-2679 answer "You Have No Print Rights....."; the owner applies the Print boundary to all six actions (G225)',
      async (ctx) =>
        withApprovalFixtures(ctx, async () => {
          const rights = (view, print) =>
            exec(
              ctx,
              `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
               VALUES ($1,'01','01',$2,'Company','Data Refresh',$3,'N','N',$4)`,
              USERS.clerk.user,
              view,
              print,
            );
          const drop = () =>
            exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "SUB_MENU"='Data Refresh' AND "USER_NAME"=$2`,
              USERS.clerk.user,
            );
          await drop();
          try {
            const before = await flags(ctx);
            const { page } = await ctx.session(as(USERS.clerk.user, 'data-refresh-rights'));
            const attempt = async () => ({
              operations: (
                await page.request.get('/api/utilities/data-refresh/operations')
              ).status(),
              preview: (
                await page.request.post('/api/utilities/data-refresh/approval-reconcile/preview', {
                  data: {},
                })
              ).status(),
              apply: (
                await page.request.post('/api/utilities/data-refresh/approval-reconcile/apply', {
                  data: { previewHash: '0'.repeat(64) },
                })
              ).status(),
            });
            const refusedNone = await attempt();
            const message = (
              await (await page.request.get('/api/utilities/data-refresh/operations')).json()
            ).message;
            await rights('Y', 'N');
            const refusedViewOnly = await attempt();
            for (const result of [refusedNone, refusedViewOnly])
              assert.deepEqual(result, { operations: 403, preview: 403, apply: 403 });
            assert.equal(message, 'You Have No Print Rights.....');
            // The administrator-only advanced console is not opened by the Data Refresh right.
            assert.equal(
              (await page.request.get('/api/utilities/data-repair/operations')).status(),
              403,
            );
            assert.deepEqual(await flags(ctx), before, 'a refused user changes nothing');
            // With the Print right the same user runs Approval Adj through the screen.
            await drop();
            await rights('Y', 'Y');
            await openScreen(page);
            const preview = await previewApproval(page);
            const result = await applyApproval(page);
            assert.deepEqual(result.applied, preview.diffs);
            await page.getByText('Approval Refersh Process Complete.', { exact: true }).waitFor();
            assertApprovalFixture(await flags(ctx));
            const [{ operator }] = await ctx.rows(
              `SELECT operator FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id='approval-reconcile'
                 AND state='applied' ORDER BY row_id DESC LIMIT 1`,
            );
            assert.equal(operator, USERS.clerk.user);
            return {
              observation: `no row and View-only refused (${message}); View+Print previewed and applied, recorded under ${operator}`,
              expected: { refused: 403, viewPrint: 'applied' },
              database: { before, after: await flags(ctx), operator },
              downstream: { advancedConsole: 403 },
            };
          } finally {
            await drop();
          }
        }),
    ),
    C(
      'concurrency.voucher-save-during-apply',
      'T12',
      'mutation',
      'D-REF-2: a voucher saved while Approval Adj waits at the repair lock invalidates the reviewed set (stale-preview) and is not lost; MS_UPDATE.cs:8815-8820 selects what the voucher now consumes',
      async (ctx) =>
        withApprovalFixtures(ctx, async () => {
          const { page } = await ctx.session(as(USERS.admin.user, 'data-refresh-race'));
          await openScreen(page);
          const preview = await previewApproval(page);
          const lock = await holdAdvisoryLock(
            ctx.owner,
            'hashtext',
            `repair:${ctx.tenantId}:approval-reconcile`,
          );
          let released = false;
          try {
            const answer = page.waitForResponse((value) =>
              isApi(value, '/utilities/data-refresh/approval-reconcile/apply'),
            );
            await page.getByRole('button', { name: 'Apply Approval Adj', exact: true }).click();
            let waiting = 0;
            for (let i = 0; i < 100 && waiting < 1; i += 1) {
              [{ n: waiting }] = await ctx.owner.$queryRawUnsafe(
                `SELECT count(*)::int n FROM pg_locks WHERE locktype='advisory' AND NOT granted`,
              );
              if (waiting < 1) await page.waitForTimeout(100);
            }
            assert.equal(waiting, 1, 'the apply is waiting at the repair lock');
            // The voucher save: a Sales row that consumes issue DRFI5 commits while the apply waits (SL_DETL is what
            // the Sales save writes; the screen's own save is covered by the sales module).
            await exec(
              ctx,
              `INSERT INTO "SL_DETL"
                (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TAG_NO","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO")
               VALUES ($1,'01','01',$2::text,'SL','DRFS3',1,'SALES','N',$2::text,'AI','DRFI5',5)`,
              YEAR,
            );
            await lock.release();
            released = true;
            const response = await answer;
            assert.equal(response.status(), 400, await response.text());
            assert.equal((await response.json()).code, 'stale-preview');
            await page.locator('.msg[role="alert"]').waitFor();
            assert.equal(
              await page.getByText('Approval Refersh Process Complete.', { exact: true }).count(),
              0,
            );
            const kept = await ctx.rows(
              `SELECT "VCH_NO" FROM "SL_DETL" WHERE tenant_id=$1 AND "VCH_NO"='DRFS3'`,
            );
            assert.equal(kept.length, 1, 'the saved voucher is not lost');
            // Nothing of the reviewed set was applied; the new preview shows the changed set and applies it.
            const second = await previewApproval(page);
            assert.notEqual(second.previewHash, preview.previewHash);
            assert.deepEqual(second.diffs, await approvalOracle(ctx));
            const applied = await applyApproval(page);
            assert.deepEqual(applied.applied, second.diffs);
            return {
              observation:
                'the voucher saved during the wait made the reviewed set stale; it was kept; a fresh review applied the new set',
              expected: { first: 'stale-preview', second: second.diffs },
              database: {
                voucherKept: kept.length,
                reviewed: preview.diffs,
                current: second.diffs,
              },
              downstream: { applied: applied.applied },
            };
          } finally {
            if (!released) await lock.release().catch(() => {});
          }
        }),
    ),
    C(
      'retry.replay-hash-deduplicates',
      'T13',
      'mutation',
      'D-REF-2: replaying the reviewed hash resolves to the existing applied run',
      async (ctx) =>
        approvalLifecycle(ctx, async (result) => {
          const replay = await result.page.request.post(
            '/api/utilities/data-refresh/approval-reconcile/apply',
            {
              data: { previewHash: result.preview.previewHash },
            },
          );
          assert.equal(replay.status(), 200);
          const body = await replay.json();
          assert.equal(body.deduplicated, true);
          return {
            observation: 'same hash returned deduplicated=true',
            expected: true,
            database: result.after,
            downstream: 'no repeated writes',
          };
        }),
    ),
    C(
      'rollback.browser-fault-boundary',
      'T14',
      'refusal',
      'D-REF-2 and MS_UPDATE.cs:8815-8820: the APR_DETL update and the BAR_DETL update are one transaction',
      async (ctx) =>
        withApprovalFixtures(ctx, async () => {
          const { page } = await ctx.session(as(USERS.admin.user, 'data-refresh-rollback'));
          await openScreen(page);
          const preview = await previewApproval(page);
          const before = await flags(ctx);
          // A BEFORE UPDATE trigger on BAR_DETL (the second write) fails for the fixture's tags only; the test
          // installs it on its own connection and drops it again.
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_refresh_fault() RETURNS trigger LANGUAGE plpgsql SECURITY DEFINER AS $f$
             BEGIN
               IF NEW.tenant_id = '${ctx.tenantId}' AND NEW."TAG_NO" LIKE 'DRF%' THEN
                 RAISE EXCEPTION 'e2e fault on BAR_DETL';
               END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_refresh_fault BEFORE UPDATE ON "BAR_DETL" FOR EACH ROW EXECUTE FUNCTION e2e_refresh_fault()`,
          );
          let faulted;
          try {
            const fingerprint = await tenantFingerprint(ctx);
            const [response] = await Promise.all([
              page.waitForResponse((value) =>
                isApi(value, '/utilities/data-refresh/approval-reconcile/apply'),
              ),
              page.getByRole('button', { name: 'Apply Approval Adj', exact: true }).click(),
            ]);
            faulted = response.status();
            assert.ok(faulted >= 400, `the faulted apply answered ${faulted}`);
            await page.locator('.msg[role="alert"]').waitFor();
            assert.equal(
              await page.getByText('Approval Refersh Process Complete.', { exact: true }).count(),
              0,
            );
            assert.deepEqual(
              await flags(ctx),
              before,
              'the APR_DETL update was rolled back with the BAR_DETL one',
            );
            assert.deepEqual(changedTables(fingerprint, await tenantFingerprint(ctx)), []);
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_refresh_fault ON "BAR_DETL"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_refresh_fault()`);
          }
          // The fault is gone: the reviewed set still applies, whole.
          await page.getByRole('button', { name: 'Apply Approval Adj', exact: true }).click();
          await page.getByText('Approval Refersh Process Complete.', { exact: true }).waitFor();
          assertApprovalFixture(await flags(ctx));
          return {
            observation: `a failed BAR_DETL write (answer ${faulted}) left every tenant table as before; the retry applied the reviewed set`,
            expected: { faulted: '>= 400', unchanged: true, retry: preview.diffs },
            database: { before, after: await flags(ctx) },
            downstream: { retried: preview.diffs },
          };
        }),
    ),
    C(
      'scope.location-sentinel',
      'T15',
      'mutation',
      'MS_UPDATE.cs:8815-8820 plus safe tenant/company/location/year containment',
      async (ctx) =>
        approvalLifecycle(ctx, async (result) => {
          const sentinels = result.after.filter((row) =>
            /OTHER-LC|WRONG-YR/u.test(String(row.tag)),
          );
          assert.deepEqual(
            sentinels.map((row) => [row.tag, row.flag]),
            [
              ['DRF-OTHER-LC', 'Y'],
              ['DRF-WRONG-YR', 'Y'],
              ['DRF-OTHER-LC', 'N'],
              ['DRF-WRONG-YR', 'N'],
            ],
          );
          return {
            observation: 'wrong-location and wrong-year issue/tag sentinels remained unchanged',
            expected: ['Y', 'Y', 'N', 'N'],
            database: sentinels,
            downstream: 'selected location and current April-March year only',
          };
        }),
    ),
    C(
      'scope.defaulter-repair-all-locations',
      'T15',
      'mutation',
      'MS_UPDATE.cs:8608 repairs NULL DEFAULTER_AC in every location of the company; MS_UPDATE.cs:7214 repairs AC_MAIN_GR only in the session location',
      async (ctx) => {
        const accounts = () =>
          ctx.rows(
            `SELECT row_id::text id,"AC_CODE" code,"LC_CODE" lc,"AC_GR" gr,"AC_MAIN_GR" mg,"DEFAULTER_AC" df
               FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY row_id`,
          );
        const original = await accounts();
        // The preview lists the first 20 accounts by code, so take the two that sort first.
        const [here, there] = original
          .filter((row) => row.lc === '01')
          .sort((x, y) => (x.code < y.code ? -1 : 1));
        assert.ok(here && there, 'two accounts in the session location');
        try {
          // The account group owns main group M1. Both accounts drift to Z and lose their defaulter flag; one of them
          // sits in location 02, which is not the session location (01).
          await exec(
            ctx,
            `INSERT INTO "AC_GROUP"(tenant_id,"CO_CODE","AC_GR","AC_MAIN_GR") VALUES ($1,'01','DRG','M1')`,
          );
          await exec(
            ctx,
            `UPDATE "AC_MAST" SET "AC_GR"='DRG',"AC_MAIN_GR"='Z',"DEFAULTER_AC"=NULL
              WHERE tenant_id=$1 AND row_id IN ($2::bigint,$3::bigint)`,
            here.id,
            there.id,
          );
          await exec(
            ctx,
            `UPDATE "AC_MAST" SET "LC_CODE"='02' WHERE tenant_id=$1 AND row_id=$2::bigint`,
            there.id,
          );
          const before = await accounts();
          const { page } = await ctx.session();
          await openScreen(page);
          const [previewResponse] = await Promise.all([
            page.waitForResponse((value) =>
              isApi(value, '/utilities/data-refresh/data-refresh-field-update/preview'),
            ),
            page.getByRole('button', { name: 'Field Update', exact: true }).click(),
          ]);
          assert.equal(previewResponse.status(), 200, await previewResponse.text());
          const preview = await previewResponse.json();
          const mine = preview.samples.filter(
            (line) =>
              line.startsWith(`AC_MAST ${here.code}:`) || line.startsWith(`AC_MAST ${there.code}:`),
          );
          assert.deepEqual(
            mine.sort(),
            [
              `AC_MAST ${here.code}: main group Z -> M1; defaulter blank -> N`,
              `AC_MAST ${there.code}: defaulter blank -> N`,
            ].sort(),
          );
          await page.getByRole('heading', { name: 'Field Update preview', exact: true }).waitFor();
          const [applyResponse] = await Promise.all([
            page.waitForResponse((value) =>
              isApi(value, '/utilities/data-refresh/data-refresh-field-update/apply'),
            ),
            page.getByRole('button', { name: 'Apply Field Update', exact: true }).click(),
          ]);
          assert.equal(applyResponse.status(), 200, await applyResponse.text());
          await page
            .getByText('Field Is Update ok....Please Re open Software', { exact: true })
            .waitFor();
          const after = await accounts();
          const pick = (rows, id) => rows.find((row) => row.id === id);
          const sessionRow = pick(after, here.id);
          const otherRow = pick(after, there.id);
          assert.deepEqual([sessionRow.mg, sessionRow.df], ['M1', 'N']);
          assert.deepEqual([otherRow.lc, otherRow.mg, otherRow.df], ['02', 'Z', 'N']);
          return {
            observation: `${there.code} in location 02: defaulter NULL -> N, main group Z kept; ${here.code} in location 01: both repaired`,
            expected: { location02: ['Z', 'N'], location01: ['M1', 'N'] },
            database: {
              before: [pick(before, here.id), pick(before, there.id)],
              after: [sessionRow, otherRow],
            },
            downstream: { previewSamples: mine },
          };
        } finally {
          for (const row of original)
            await exec(
              ctx,
              `UPDATE "AC_MAST" SET "LC_CODE"=$3,"AC_GR"=$4,"AC_MAIN_GR"=$5,"DEFAULTER_AC"=$6
                WHERE tenant_id=$1 AND row_id=$2::bigint`,
              row.id,
              row.lc,
              row.gr,
              row.mg,
              row.df,
            );
          await exec(
            ctx,
            `DELETE FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_GR"='DRG'`,
          );
        }
      },
    ),
    C(
      'output.message-and-history',
      'T16',
      'output',
      'MS_UPDATE.cs:8821: exact message; this maintenance screen has no PDF/CSV output',
      async (ctx) =>
        approvalLifecycle(ctx, async ({ page }) => {
          const text = await page
            .getByText('Approval Refersh Process Complete.', { exact: true })
            .innerText();
          const history = await page.getByRole('table').last().innerText();
          assert.match(history, /approval-reconcile/);
          return { observation: `${text}; history rendered`, expected: text, output: history };
        }),
    ),
    C(
      'keyboard.native-order-no-secret-shortcut',
      'T17',
      'mutation',
      'MS_UPDATE.cs:1371-1504,1606-1615,2275-2301: desktop tab order; Ctrl+O tools excluded by D-REF-1',
      async (ctx) =>
        withApprovalFixtures(ctx, async () => {
          const before = await flags(ctx);
          const expectedDiffs = await approvalOracle(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await page.getByRole('button', { name: 'Account', exact: true }).focus();
          const order = [];
          for (let index = 0; index < captions.length; index++) {
            order.push(await page.evaluate(() => document.activeElement?.textContent?.trim()));
            if (index < captions.length - 1) await page.keyboard.press('Tab');
          }
          assert.deepEqual(order, captions);
          await page.keyboard.press('Control+O');
          for (const name of hidden)
            assert.equal(await page.getByText(name, { exact: true }).count(), 0);

          const operation = page.getByRole('button', { name: 'Approval Adj', exact: true });
          await operation.focus();
          const [previewResponse] = await Promise.all([
            page.waitForResponse((value) =>
              isApi(value, '/utilities/data-refresh/approval-reconcile/preview'),
            ),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(previewResponse.status(), 200);
          const preview = await previewResponse.json();
          assert.deepEqual(preview.diffs, expectedDiffs);
          const heading = page.getByRole('heading', { name: 'Approval Adj preview', exact: true });
          await heading.waitFor();
          await page.waitForFunction(
            (element) => document.activeElement === element,
            await heading.elementHandle(),
          );

          const apply = page.getByRole('button', { name: 'Apply Approval Adj', exact: true });
          await apply.waitFor();
          await page.waitForFunction(
            (element) => !(element instanceof HTMLButtonElement) || !element.disabled,
            await apply.elementHandle(),
          );
          await page.keyboard.press('Tab');
          assert.equal(await apply.evaluate((element) => document.activeElement === element), true);
          const [applyResponse] = await Promise.all([
            page.waitForResponse((value) =>
              isApi(value, '/utilities/data-refresh/approval-reconcile/apply'),
            ),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(applyResponse.status(), 200);
          assert.deepEqual((await applyResponse.json()).applied, expectedDiffs);
          await page.getByText('Approval Refersh Process Complete.', { exact: true }).waitFor();
          await page.waitForFunction(
            (element) => document.activeElement === element,
            await operation.elementHandle(),
          );

          const after = await flags(ctx);
          assertApprovalFixture(after);
          return {
            observation: `Tab order ${order.join(' → ')}; focus Approval Adj → preview heading → Apply → Approval Adj; Ctrl+O inert`,
            expected: { captions, diffs: expectedDiffs },
            database: { before, after },
            downstream: 'successful apply restored focus to its originating operation',
          };
        }),
    ),
    blocked(
      'journey.account-full-builder',
      'T18',
      'MS_UPDATE.cs:2334-2669; playbook J23',
      'Partly built: per the owner decision of 27 Nov 2026 Account is check-and-repair per voucher family, and Contra and Fine Jv apply (case account.contra-check-and-repair); the other families remain. The desktop Account button deletes AC_DATA, ROJ_MEL_DATA, TAX_DATA, DHRN_DATA and re-posts every voucher of the year through about 120 builder methods (Ac_Ledr 55, Ac_Rojmel 44, Ac_Tax 48; MS_UPDATE.cs:2401-2663). The web writes those rows inside each voucher save with its own posting rules, so an equal rebuild needs a per-voucher-type re-posting engine the web does not have. D-REF-3 (owner, 2 Nov 2026) says ship preview-only when the effect cannot be reproduced exactly. The proven prefix (book flags, clearing dates, bank reconciliation) is applied by the advanced operation ledger-normalise, covered by dataRepair.db.test.ts. Owner question: approve a re-posting engine, or accept preview-only for good.',
    ),
    blocked(
      'journey.stock-full-builder',
      'T18',
      'MS_UPDATE.cs:2671-3047; playbook J23',
      'Not built, and not an external limit: StockRefresh deletes MAIN_STOCK, LOT_DETL, DM_DATA and DM_KR_DATA and rebuilds them through about 70 Ac_Stock builder methods (MS_UPDATE.cs:2852-3047). The web writes stock rows in each voucher save, so an equal rebuild needs a re-posting engine for every voucher type. D-REF-3 says ship preview-only when the effect cannot be reproduced exactly. The proven prefix (missing tag fine weight) is applied by the advanced operation stock-fine-refresh. Owner question: approve a stock re-posting engine, or accept preview-only for good.',
    ),
    blocked(
      'journey.old-field-classification',
      'T18',
      'MS_UPDATE.cs:9412-33074; D-REF-3',
      'Not done, and not an external limit: Old Field is about 22,900 lines, 1,570 statements (826 ALTER, 493 INSERT, 429 UPDATE, 51 CREATE) that D-REF-3 requires to be classified one by one (a repair, b anomaly query returning 0, c migration loader) before anything is built. Field Update was classified this way in orchestration/work/WP-24/field-update.md (520 statements); Old Field has no such table yet. Until it exists the button stays a classification preview with no Apply.',
    ),
    C(
      'journey.image-semantic-migration',
      'T18',
      'mutation',
      'MS_UPDATE.cs:8825-9038 (J23): the desktop action is schema work only (side database, TAG_IMAGE_DATA, flag columns); the web schema is migration-owned, so the action changes no business row and runs no DDL',
      async (ctx) => {
        const columns = () =>
          ctx.rows(
            `SELECT column_name FROM information_schema.columns
              WHERE table_schema='public' AND table_name='TAG_IMAGE_DATA' AND $1::text IS NOT NULL ORDER BY ordinal_position`,
          );
        await exec(ctx, `DELETE FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "TAG_NO"='DRF-IMG'`);
        await exec(
          ctx,
          `INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE") VALUES ($1,'01','01','DRF-IMG',1,'T')`,
        );
        try {
          const { page } = await ctx.session(as(USERS.admin.user, 'data-refresh-image'));
          await openScreen(page);
          const schema = await columns();
          const before = await tenantFingerprint(ctx);
          const [response] = await Promise.all([
            page.waitForResponse((value) =>
              isApi(value, '/utilities/data-refresh/data-refresh-image-data/preview'),
            ),
            page.getByRole('button', { name: 'Image Data', exact: true }).click(),
          ]);
          assert.equal(response.status(), 200, await response.text());
          const preview = await response.json();
          assert.equal(preview.clean, true);
          await page.getByText('No records need adjustment.', { exact: true }).waitFor();
          // A direct apply of the reviewed hash is accepted, writes no business row and returns the audited run.
          const apply = await page.request.post(
            '/api/utilities/data-refresh/data-refresh-image-data/apply',
            { data: { previewHash: preview.previewHash } },
          );
          assert.equal(apply.status(), 200, await apply.text());
          assert.deepEqual((await apply.json()).applied, []);
          const after = await tenantFingerprint(ctx);
          assert.deepEqual(changedTables(before, after), ['data_repair_run']);
          assert.deepEqual(await columns(), schema, 'no runtime DDL: the table keeps its columns');
          const kept = await ctx.rows(
            `SELECT "TAG_NO","VCH_SRNO"::int sr,"IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "TAG_NO"='DRF-IMG'`,
          );
          assert.equal(kept.length, 1);
          return {
            observation:
              'Image Data verified the committed image table, reported nothing to adjust and changed no business row or column',
            expected: { clean: true, changedTables: ['data_repair_run'] },
            database: { kept, schema },
            downstream: { auditOnly: changedTables(before, after) },
          };
        } finally {
          await exec(ctx, `DELETE FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "TAG_NO"='DRF-IMG'`);
        }
      },
    ),
    C(
      'account.contra-check-and-repair',
      'T07',
      'mutation',
      'Owner decision 2026-11-27 (docs/handbook/web/data-refresh.md): Account is check-and-repair per family; MS_UPDATE.cs:2334-2669 with Contra_Ledr Ac_Ledr.cs:840-848 and Contra_Rojmel Ac_Rojmel.cs:336-340',
      async (ctx) => {
        const result = await accountContraLifecycle(ctx);
        return {
          observation: `Contra ${result.vchNo}: the check showed the damaged DR_AMT, the apply restored the writer's rows, the second check did not list it`,
          expected: result.first.diffs,
          database: { writer: result.writer, repaired: result.repaired },
          downstream: { secondCheck: result.second.detail.summary },
        };
      },
    ),
  ],
};
