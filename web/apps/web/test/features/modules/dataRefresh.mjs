import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Company → Data Refresh (desktop MS_UPDATE).
 *
 * PR-1 deliberately proves only Approval Adj as a complete writer. Account and Stock expose exact proven
 * partial anomaly counts but cannot apply the unproved builder graphs. Field Update and Old Field await the
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
  ['data-refresh-field-update', 'Field Update'],
  ['data-refresh-image-data', 'Image Data'],
  ['data-refresh-old-field', 'Old Field'],
];
const hidden = ['Crm Data', 'Problem Qry', 'TagDiff Set', 'Mfg Refresh', 'Scheme Data'];
const apiPath = (response) => new URL(response.url()).pathname;
const isApi = (response, suffix) => apiPath(response) === `/api${suffix}`;
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

async function openScreen(page) {
  await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'Data Refresh', exact: true });
  await link.click();
  await page.getByRole('heading', { name: 'Data Refresh', exact: true }).waitFor();
  await page.getByRole('button', { name: 'Account', exact: true }).waitFor();
}

async function cleanApproval(ctx) {
  await ctx.owner.$transaction(async (tx) => {
    await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
    await tx.$executeRawUnsafe(
      `DELETE FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id='approval-reconcile'`,
      ctx.tenantId,
    );
    for (const table of ['APR_DETL', 'SL_DETL', 'RATE_CUT_ISU', 'BAR_DETL'])
      await tx.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1
          AND (coalesce("TAG_NO",'') LIKE 'DRF%' OR coalesce("VCH_NO",'') LIKE 'DRF%')`,
        ctx.tenantId,
      );
  });
}

async function seedApproval(ctx) {
  await cleanApproval(ctx);
  await exec(
    ctx,
    `INSERT INTO "APR_DETL"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","BOOK_NAME","TAG_NO","VCH_SRNO","ISU_REC")
     VALUES ($1,'01','01','2024-2025','AI','DRFI1',1,1,'APR ISU','DRF-APRRTN',901,'N'),
            ($1,'01','01','2024-2025','AI','DRFI2',1,2,'APR ISU','DRF-SALES',902,'N'),
            ($1,'01','01','2024-2025','AI','DRFI3',1,3,'APR ISU','DRF-WH',903,'N'),
            ($1,'01','01','2024-2025','AI','DRFI4',1,4,'APR ISU','DRF-RATE',904,'N'),
            ($1,'01','01','2024-2025','AI','DRFI5',1,5,'APR ISU','DRF-OPEN',905,'Y'),
            ($1,'01','02','2024-2025','AI','DRFI6',1,6,'APR ISU','DRF-OTHER-LC',906,'Y'),
            ($1,'01','01','2024-2025','ART','DRFR1',1,1,'APR RTN','N',0,'N')`,
  );
  await exec(
    ctx,
    `UPDATE "APR_DETL" SET "ISU_YRCD"='2024-2025 ',"ISU_DBCD"='AI ',"ISU_NO"='DRFI1  ',"ISU_SRNO"=1
      WHERE tenant_id=$1 AND "VCH_NO"='DRFR1'`,
  );
  await exec(
    ctx,
    `INSERT INTO "SL_DETL"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TAG_NO","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO")
     VALUES ($1,'01','01','2024-2025','SL','DRFS1',1,'SALES','N','2024-2025 ','AI ','DRFI2  ',2)`,
  );
  await exec(
    ctx,
    `INSERT INTO "RATE_CUT_ISU"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TAG_NO","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO")
     VALUES ($1,'01','01','2024-2025','WHS','DRFW1',1,'WH SALES','N','2024-2025 ','AI ','DRFI3  ',3),
            ($1,'01','01','2024-2025','RTC','DRFC1',1,'RATE CUT','N','2024-2025 ','AI ','DRFI4  ',4)`,
  );
  await exec(
    ctx,
    `INSERT INTO "BAR_DETL"
      (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TAG_NO","VCH_SRNO","IT_CODE","APR_ISU")
     VALUES ($1,'01','01','2024-2025','TAG','DRFB1',1,'TAG OPENING','DRF-APRRTN',901,'GLD22','Y'),
            ($1,'01','01','2024-2025','TAG','DRFB2',1,'TAG OPENING','DRF-SALES',902,'GLD22','Y'),
            ($1,'01','01','2024-2025','TAG','DRFB3',1,'TAG OPENING','DRF-WH',903,'GLD22','Y'),
            ($1,'01','01','2024-2025','TAG','DRFB4',1,'TAG OPENING','DRF-RATE',904,'GLD22','Y'),
            ($1,'01','01','2024-2025','TAG','DRFB5',1,'TAG OPENING','DRF-OPEN',905,'GLD22','N'),
            ($1,'01','02','2024-2025','TAG','DRFB6',1,'TAG OPENING','DRF-OTHER-LC',906,'GLD22','N')`,
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

async function previewApproval(page) {
  const [response] = await Promise.all([
    page.waitForResponse((value) =>
      isApi(value, '/utilities/data-repair/approval-reconcile/preview'),
    ),
    page.getByRole('button', { name: 'Approval Adj', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  return response.json();
}

async function applyApproval(page) {
  const [response] = await Promise.all([
    page.waitForResponse((value) =>
      isApi(value, '/utilities/data-repair/approval-reconcile/apply'),
    ),
    page.getByRole('button', { name: 'Apply Approval Adj', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  return response.json();
}

async function approvalLifecycle(ctx) {
  await seedApproval(ctx);
  const before = await flags(ctx);
  const { page } = await ctx.session(as(USERS.admin.user, 'data-refresh-approval'));
  await openScreen(page);
  const preview = await previewApproval(page);
  assert.deepEqual(preview.diffs, [
    { table: 'APR_DETL', insert: 0, update: 5, delete: 0 },
    { table: 'BAR_DETL', insert: 0, update: 5, delete: 0 },
  ]);
  const result = await applyApproval(page);
  await page.getByText('Approval Refersh Process Complete.', { exact: true }).waitFor();
  const after = await flags(ctx);
  assert.deepEqual(
    after.map((row) => [row.kind, row.tag, row.flag]),
    [
      ['APR', 'DRF-APRRTN', 'Y'],
      ['APR', 'DRF-OPEN', 'N'],
      ['APR', 'DRF-OTHER-LC', 'Y'],
      ['APR', 'DRF-RATE', 'Y'],
      ['APR', 'DRF-SALES', 'Y'],
      ['APR', 'DRF-WH', 'Y'],
      ['BAR', 'DRF-APRRTN', 'N'],
      ['BAR', 'DRF-OPEN', 'Y'],
      ['BAR', 'DRF-OTHER-LC', 'N'],
      ['BAR', 'DRF-RATE', 'N'],
      ['BAR', 'DRF-SALES', 'N'],
      ['BAR', 'DRF-WH', 'N'],
    ],
  );
  return { page, preview, result, before, after };
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
    'web/apps/api/src/routes/dataRepair.ts',
    'web/apps/web/app/(app)/utilities/data-refresh/page.tsx',
    'web/apps/web/app/(app)/utilities/data-repair/page.tsx',
    'web/apps/web/test/features/modules/dataRefresh.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { operationScope: 'company 01, location 01, year 2024-2025' },
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
      async (ctx) => {
        const result = await approvalLifecycle(ctx);
        return {
          observation:
            'consumed issue became Y, open issue became N, and BAR flags were their inverse',
          expected: result.preview.diffs,
          database: result.after,
          downstream: 'BAR_DETL now exposes only the unconsumed tag as APR_ISU=Y',
        };
      },
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
      'D-REF-3 and MS_UPDATE.cs:2334-3047,8825-9038: unproved full graphs must not partially apply',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const before = await flags(ctx);
        for (const id of [
          'data-refresh-account',
          'data-refresh-stock',
          'data-refresh-field-update',
          'data-refresh-image-data',
          'data-refresh-old-field',
        ]) {
          const response = await page.request.post(`/api/utilities/data-repair/${id}/apply`, {
            data: { previewHash: '0'.repeat(64) },
          });
          assert.equal(response.status(), 400);
          assert.equal((await response.json()).code, 'preview-only');
        }
        assert.deepEqual(await flags(ctx), before);
        return {
          observation: 'all direct applies refused with preview-only',
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
      async (ctx) => {
        const result = await approvalLifecycle(ctx);
        return {
          observation:
            'Approval Adj applied both two-row diffs and showed the source completion text',
          expected: result.preview.diffs,
          database: result.after,
          downstream: 'APR_DETL and BAR_DETL agree on consumed/open state',
        };
      },
    ),
    C(
      'reopen.clean-preview',
      'T08',
      'read-only',
      'D-REF-2: a fresh preview after apply is clean',
      async (ctx) => {
        const { page } = await approvalLifecycle(ctx);
        const preview = await previewApproval(page);
        assert.equal(preview.clean, true);
        assert.deepEqual(preview.diffs, []);
        return { observation: 'fresh Approval Adj preview was clean', expected: [] };
      },
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
            page.waitForResponse((value) => isApi(value, `/utilities/data-repair/${id}/preview`)),
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
        return {
          observation:
            'all five classifications state the unproved work and show no Apply or authority inputs',
          expected: 'preview-only',
        };
      },
    ),
    C(
      'history.compatibility-ledger',
      'T10',
      'read-only',
      'D-REF-2: previews and applies remain visible in the compatibility history',
      async (ctx) => {
        const { page } = await approvalLifecycle(ctx);
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
            await page.locator('#reason,#confirmation,#operatorPassword,#backupReference').count(),
            0,
          );
        }
        const history = await page.getByRole('table').last().innerText();
        assert.match(history, /approval-reconcile/);
        assert.match(history, /applied/);
        return {
          observation:
            'advanced Data Repair shows shared history and suppresses Apply and authority inputs for all five preview-only operations',
          expected: 'history retained; preview-only capability honored',
        };
      },
    ),
    blocked(
      'rights.caption-print-handoff',
      'T11',
      'MS_UPDATE.cs:2042-2050,2334-2342,2671-2679; owner adaptation gates all six through Data Refresh Print',
      'G225 remains open: existing Data Repair routes are admin-only, but the exact Data Refresh caption FRM_PRINT handoff requires active-owned route-policy/form-catalog work.',
    ),
    blocked(
      'concurrency.voucher-save-during-apply',
      'T12',
      'D-REF-2: a voucher saved while Approval Adj applies must invalidate the reviewed set without losing the voucher',
      'X27/P11-01: the browser stack has no approved synchronization hook at the apply lock; parallel previews are not accepted as a substitute for the required save/apply race.',
    ),
    C(
      'retry.replay-hash-deduplicates',
      'T13',
      'mutation',
      'D-REF-2: replaying the reviewed hash resolves to the existing applied run',
      async (ctx) => {
        const result = await approvalLifecycle(ctx);
        const replay = await result.page.request.post(
          '/api/utilities/data-repair/approval-reconcile/apply',
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
      },
    ),
    blocked(
      'rollback.browser-fault-boundary',
      'T14',
      'D-REF-2 and MS_UPDATE.cs:8815-8820',
      'The APR_DETL-to-BAR_DETL rollback is covered by the real-transaction DB test; the browser harness has no approved production fault-injection control.',
    ),
    C(
      'scope.location-sentinel',
      'T15',
      'mutation',
      'MS_UPDATE.cs:8815-8820 plus safe tenant/company/location/year containment',
      async (ctx) => {
        const result = await approvalLifecycle(ctx);
        const sentinels = result.after.filter((row) => String(row.tag).includes('OTHER-LC'));
        assert.deepEqual(
          sentinels.map((row) => row.flag),
          ['Y', 'N'],
        );
        return {
          observation: 'wrong-location issue and tag remained in deliberately opposite states',
          expected: ['Y', 'N'],
          database: sentinels,
          downstream: 'selected location only',
        };
      },
    ),
    C(
      'output.message-and-history',
      'T16',
      'output',
      'MS_UPDATE.cs:8821: exact message; this maintenance screen has no PDF/CSV output',
      async (ctx) => {
        const { page } = await approvalLifecycle(ctx);
        const text = await page
          .getByText('Approval Refersh Process Complete.', { exact: true })
          .innerText();
        const history = await page.getByRole('table').last().innerText();
        assert.match(history, /approval-reconcile/);
        return { observation: `${text}; history rendered`, expected: text, output: history };
      },
    ),
    C(
      'keyboard.native-order-no-secret-shortcut',
      'T17',
      'mutation',
      'MS_UPDATE.cs:1371-1504,1606-1615,2275-2301: desktop tab order; Ctrl+O tools excluded by D-REF-1',
      async (ctx) => {
        await seedApproval(ctx);
        const before = await flags(ctx);
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
            isApi(value, '/utilities/data-repair/approval-reconcile/preview'),
          ),
          page.keyboard.press('Enter'),
        ]);
        assert.equal(previewResponse.status(), 200, await previewResponse.text());
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
            isApi(value, '/utilities/data-repair/approval-reconcile/apply'),
          ),
          page.keyboard.press('Enter'),
        ]);
        assert.equal(applyResponse.status(), 200, await applyResponse.text());
        await page.getByText('Approval Refersh Process Complete.', { exact: true }).waitFor();
        await page.waitForFunction(
          (element) => document.activeElement === element,
          await operation.elementHandle(),
        );

        const after = await flags(ctx);
        return {
          observation: `Tab order ${order.join(' → ')}; focus Approval Adj → preview heading → Apply → Approval Adj; Ctrl+O inert`,
          expected: captions,
          database: { before, after },
          downstream: 'successful apply restored focus to its originating operation',
        };
      },
    ),
    blocked(
      'journey.account-full-builder',
      'T18',
      'MS_UPDATE.cs:2334-2669; playbook J23',
      'X27/P11-01: the complete Ac_Ledr, Ac_Rojmel and Ac_Tax builder graph is not proved, so Account remains preview-only.',
    ),
    blocked(
      'journey.stock-full-builder',
      'T18',
      'MS_UPDATE.cs:2671-3047; playbook J23',
      'X27/P11-01: the remaining StockRefresh and Ac_Stock builder graph is not proved, so Stock remains preview-only.',
    ),
    blocked(
      'journey.field-update-classification',
      'T18',
      'MS_UPDATE.cs:3958-8807; D-REF-3',
      'X27/P11-01: Field Update awaits PR-2 statement-by-statement classification.',
    ),
    blocked(
      'journey.old-field-classification',
      'T18',
      'MS_UPDATE.cs:9412-33074; D-REF-3',
      'X27/P11-01: Old Field awaits PR-2 statement-by-statement classification.',
    ),
    blocked(
      'journey.image-semantic-migration',
      'T18',
      'MS_UPDATE.cs:8825-9038; playbook J23',
      'X27/P11-01: no source proves web semantics for MOB_IMAGE, IMG_IMPORT or CONV_IMAGE or a legacy byte migration.',
    ),
  ],
};
