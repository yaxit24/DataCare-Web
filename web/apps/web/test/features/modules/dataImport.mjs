import assert from 'node:assert/strict';
import { randomUUID } from 'node:crypto';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { liteFixture } from '../fixtures/liteImport.mjs';
import {
  SECOND_TENANT,
  TENANT,
  escLeavesWithNoFocus,
  purgeCompany,
  switchCompany,
} from '../harness.mjs';
import { changedTables, tenantFingerprint } from '../faults.mjs';

/**
 * Feature: Other → Data Import (desktop UT_IMPORT "Old Softwar Import", web /utilities/data-import), Lite Soft only.
 *
 * Desktop authority: MDI_FORM.cs:8606-8615 opens UT_IMPORT for the caption "Data Import" after AllBtn's FRM_VIEW check
 * (MDI_FORM.cs:7034-7046, "You Have No Rights....."). BtnLite_Click (UT_IMPORT.cs:8413-8445) asks "Are You Sure To Import
 * Old Software Data In Next Software ?", opens a .mdb, runs Lite_AcMast (:8694-8780), Wh_Item (:4241-4328), WH_AcOpbl
 * (:4330-4363), Lite_BarData (:8447-8692) and WH_ItOpbl (:3887-3965), sets YEAR_MAST.OP_DATE to today (:8439-8440),
 * says "Process Are Complete...." and exits. Owner decisions D-IMP-1..4: Lite Soft only; atomic, previewed, refuses a
 * company with data; in-process reader with caps; licence/trial updates not ported.
 *
 * No real Lite .mdb exists: the cases upload the table fixture (fixtures/liteImport.mjs) through the screen's file
 * chooser, which the API accepts only while DATACARE_IMPORT_FIXTURE_READER=1 (set here, in-process). Each importing
 * case uses a fresh company 07 of the shared tenant and removes it afterwards. Expected values are worked by hand from
 * the desktop rules (the same values as web/apps/api/test/dataImportLite.test.ts).
 */
const CO = '07';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `data-import.${id}`,
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

const QUESTION = 'Are You Sure To Import Old Software Data In Next Software ?';
const COMPLETE = 'Process Are Complete....';
const HAS_DATA =
  'This company already has vouchers, openings or tags. Old Software Import is only for a new company; nothing was imported.';

function fixtureOn() {
  process.env.DATACARE_IMPORT_FIXTURE_READER = '1';
}

/** A fresh company 07 (seedCompany: installer masters, one year), its year and close date. */
async function freshCompany(ctx) {
  await purgeCompany(ctx.owner, ctx.tenantId, CO);
  await ctx.stack.seedCompany(ctx.stack.runtime, TENANT, CO, {
    coName: 'E2E LITE IMPORT',
    lcCode: '01',
  });
  const [y] = await ctx.rows(
    `SELECT "CO_YEAR" y, left("OP_DATE",10) op, to_char("CL_DATE",'YYYY-MM-DD') cl FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    CO,
  );
  return { year: y.y, opDate: y.op, clDate: y.cl };
}
const dropCompany = (ctx) => purgeCompany(ctx.owner, ctx.tenantId, CO);

async function companyCounts(ctx) {
  const tables = [
    'AC_MAST',
    'AC_MAST_SRNO',
    'PRODUCT_MAST',
    'GROUP_MAST',
    'TABLE_MAST',
    'ITEM_MAST',
    'OP_DATA',
    'AC_DATA',
    'BAR_DATA',
    'BAR_DETL',
    'BAR_IDTL',
    'ITM_OPBL',
    'MAIN_STOCK',
  ];
  const out = {};
  for (const t of tables) {
    const [{ n }] = await ctx.rows(
      `SELECT count(*)::int n FROM "${t}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      CO,
    );
    out[t] = n;
  }
  return out;
}

const fileOf = (y, mutate) => {
  const f = liteFixture(CO, y.year, y.clDate);
  mutate?.(f);
  return {
    name: 'LITE.MDB',
    mimeType: 'application/octet-stream',
    buffer: Buffer.from(JSON.stringify(f)),
  };
};

/** The screen through the real menu (Lite: Other → Data Import; full navigation: Utilities → Data Import). */
async function openScreen(page, throughMenu = true) {
  if (throughMenu) {
    await page.goto('/dashboard');
    await page.getByRole('link', { name: 'Data Import', exact: true }).click();
  } else await page.goto('/utilities/data-import');
  await page.getByRole('heading', { name: 'Old Software Import', exact: true }).waitFor();
}

/** Lite Soft → the file chooser → the preview the screen shows. */
async function choose(page, file) {
  const [chooser] = await Promise.all([
    page.waitForEvent('filechooser'),
    page.getByRole('button', { name: 'Lite Soft', exact: true }).click(),
  ]);
  const previewed = page.waitForResponse(
    (r) => new URL(r.url()).pathname === '/api/utilities/data-import/lite/preview',
  );
  await chooser.setFiles(file);
  const r = await previewed;
  return { status: r.status(), body: await r.json() };
}

/** A session of its own, switched to company 07 (an import signs the session out, so one slot per case). */
async function companySession(ctx, slot) {
  const s = await ctx.session(
    as(USERS.admin.user, `data-import-${slot}-${randomUUID().slice(0, 8)}`),
  );
  await switchCompany(s.page, CO);
  return s;
}

/** Import through the screen and return the apply response. */
async function importThroughScreen(page, file) {
  const dialogs = [];
  page.removeAllListeners('dialog');
  page.on('dialog', (d) => {
    dialogs.push({ type: d.type(), message: d.message() });
    void d.accept();
  });
  const preview = await choose(page, file);
  assert.equal(preview.status, 200, JSON.stringify(preview.body));
  const applied = page.waitForResponse(
    (r) => new URL(r.url()).pathname === '/api/utilities/data-import/lite/apply',
  );
  await page.getByRole('button', { name: 'Import', exact: true }).click();
  const r = await applied;
  return {
    status: r.status(),
    body: await r.json(),
    headers: r.headers(),
    dialogs,
    preview: preview.body,
  };
}

/** Tables the business write set can change; a sign-in (auth_session) and a case's own rights row are not. */
const businessChanges = (before, after) =>
  changedTables(before, after).filter((t) => !['auth_session', 'USER_SET'].includes(t));

const steps = (body) => Object.fromEntries(body.steps.map((s) => [s.step, s.writes]));
const EXPECTED_STEPS = {
  Lite_AcMast: { AC_MAST: 2, AC_MAST_SRNO: 1, CO_SET: 1 },
  Wh_Item: { PRODUCT_MAST: 1, GROUP_MAST: 2, TABLE_MAST: 1, ITEM_MAST: 3 },
  WH_AcOpbl: { OP_DATA: 3, AC_DATA: 5 },
  Lite_BarData: { BAR_DATA: 2, BAR_DETL: 3, BAR_IDTL: 2, MAIN_STOCK: 3 },
  WH_ItOpbl: { ITM_OPBL: 2, MAIN_STOCK: 2 },
};

/** A fresh company imported through the screen; returns the company year and the evidence. */
async function importedCompany(ctx, slot) {
  fixtureOn();
  const y = await freshCompany(ctx);
  const s = await companySession(ctx, slot);
  await openScreen(s.page);
  const result = await importThroughScreen(s.page, fileOf(y));
  assert.equal(result.status, 200, JSON.stringify(result.body));
  await s.page.waitForURL('**/login', { timeout: 20_000 });
  return { y, result, session: s };
}

export const dataImport = {
  feature: 'data-import',
  title: 'Other → Data Import (UT_IMPORT, Lite Soft)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/utilities/data-import/page.tsx',
    'web/apps/web/lib/liteMenus.ts',
    'web/apps/api/src/routes/dataImport.ts',
    'web/apps/api/src/modules/utilities/dataImport.ts',
    'web/apps/api/src/modules/utilities/dataImportLite.ts',
    'web/apps/api/src/modules/utilities/dataImportLiteTags.ts',
    'web/apps/api/src/modules/utilities/dataImportAccess.ts',
    'web/apps/api/src/modules/utilities/dataImportSource.ts',
    'web/apps/web/test/features/fixtures/liteImport.mjs',
    'web/apps/web/test/features/modules/dataImport.mjs',
  ],
  fixtureManifest: {
    ...FIXTURE_MANIFEST,
    company: '07 E2E LITE IMPORT (seedCompany, created and removed per case)',
    source: 'fixtures/liteImport.mjs through DATACARE_IMPORT_FIXTURE_READER=1',
  },
  settingsManifest: { importer: 'Lite Soft only (D-IMP-1)' },
  cases: [
    C(
      'entry.menu-lite-soft-only',
      'T01',
      'read-only',
      'MDI_FORM.cs:8606-8615 opens UT_IMPORT for "Data Import"; UT_IMPORT.cs:3187 caption; D-IMP-1 keeps only Lite Soft (BtnLite :8413)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const buttons = await page.locator('main button').allInnerTexts();
        assert.deepEqual(buttons, ['Lite Soft']);
        assert.equal(
          await page
            .getByRole('button', { name: 'Lite Soft', exact: true })
            .evaluate((e) => e === document.activeElement),
          true,
        );
        assert.equal(await page.getByLabel('Process').innerText(), 'Data Import');
        return {
          observation:
            'Other → Data Import opens "Old Software Import" with Lite Soft focused and no other importer',
          expected: { heading: 'Old Software Import', buttons: ['Lite Soft'] },
        };
      },
    ),
    C(
      'field.choose-file-previews-steps',
      'T02',
      'refusal',
      'UT_IMPORT.cs:8420-8431 Lite Soft opens an MDB (*.mdb) dialog; D-IMP-2 shows the rows per step before the question',
      async (ctx) => {
        fixtureOn();
        try {
          const y = await freshCompany(ctx);
          const s = await companySession(ctx, 'preview');
          await openScreen(s.page);
          const before = await companyCounts(ctx);
          const preview = await choose(s.page, fileOf(y));
          assert.equal(preview.status, 200);
          assert.deepEqual(steps(preview.body), EXPECTED_STEPS);
          assert.equal(await s.page.getByLabel('Process').innerText(), 'Lite Software Import');
          const grid = await s.page.getByRole('table', { name: 'Import steps' }).innerText();
          for (const title of [
            'Account Master',
            'Item Master',
            'Party Opning',
            'Bar Data',
            'Item Opning',
          ])
            assert.match(grid, new RegExp(title));
          assert.match(await s.page.locator('main').innerText(), /ignored: MSYS_SOMETHING/);
          assert.deepEqual(await companyCounts(ctx), before, 'a preview writes nothing');
          return {
            observation:
              'the chosen file is read and its five steps shown with their row counts; nothing written',
            expected: EXPECTED_STEPS,
            database: { before, after: before },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'formula.openings-and-item-fine',
      'T03',
      'mutation',
      'UT_IMPORT.cs:4333-4350 Sum(CR-DR) formatted 0.00, gold/silver signed fine 0.000, C when > 0 else D; :3909-3921 fine = ClWt x AVG_TOUCH / 100 at 0.000',
      async (ctx) => {
        try {
          await importedCompany(ctx, 'formula');
          const openings = await ctx.rows(
            `SELECT "AC_CODE","OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN" FROM "OP_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
            CO,
          );
          // 00101: 1000 - 249.55 = 750.45 Cr, gold +10.5 - 2.25 = 8.25 Cr; 00102: 500 Dr, silver 100 Cr; 00001 -> CASH 2000 Cr
          assert.deepEqual(openings, [
            {
              AC_CODE: '00101',
              OP_AMT: 750.45,
              OP_SIGN: 'C',
              FINE_BAL: 8.25,
              FINE_SIGN: 'C',
              SL_FINE_BAL: 0,
              SL_FINE_SIGN: 'D',
            },
            {
              AC_CODE: '00102',
              OP_AMT: 500,
              OP_SIGN: 'D',
              FINE_BAL: 0,
              FINE_SIGN: 'D',
              SL_FINE_BAL: 100,
              SL_FINE_SIGN: 'C',
            },
            {
              AC_CODE: 'CASH',
              OP_AMT: 2000,
              OP_SIGN: 'C',
              FINE_BAL: 0,
              FINE_SIGN: 'D',
              SL_FINE_BAL: 0,
              SL_FINE_SIGN: 'D',
            },
          ]);
          const items = await ctx.rows(
            `SELECT "IT_CODE","VCH_NO","SR_NO","ITM_NWT"::float nwt,"ITM_TOUCH"::float t,"ITM_FINE"::float f FROM "ITM_OPBL" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "SR_NO"`,
            CO,
          );
          // CHN 15.5 x 91.6 / 100 = 14.198; SLB (1000 - 200) x 92.5 / 100 = 740
          assert.deepEqual(items, [
            { IT_CODE: 'CHN', VCH_NO: 'G', SR_NO: 1, nwt: 15.5, t: 91.6, f: 14.198 },
            { IT_CODE: 'SLB', VCH_NO: 'S', SR_NO: 2, nwt: 800, t: 92.5, f: 740 },
          ]);
          const legs = await ctx.rows(
            `SELECT "AC_CODE", "CR_AMT"::float cr, "DR_AMT"::float dr FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"='00101' AND "CR_AMT"<>0`,
            CO,
          );
          assert.deepEqual(legs, [{ AC_CODE: '00101', cr: 750.45, dr: 0 }]);
          return {
            observation: 'openings and item-opening fine are the desktop sums and roundings',
            expected: { openings, items },
            database: { openings, items },
            downstream: { ledgerLeg: legs },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    notApplicable(
      'lookup',
      'T04',
      'UT_IMPORT.cs:8413-8445 has no help box: the only input is the Open File dialog',
      'The screen has no lookup; the file chooser is exercised by every importing case.',
    ),
    notApplicable(
      'children',
      'T05',
      'UT_IMPORT.cs:3140-3190 shows buttons, a label and a progress bar only',
      'There is no editable grid; the BAR_IDTL child rows of a tag are checked in data-import.create.write-set.',
    ),
    C(
      'invalid.not-mdb-and-row-errors',
      'T06',
      'refusal',
      'D-IMP-3 refuses a non-Access file; an over-long value (BAR_DETL.KR_NAME, 5 characters) would stop the desktop INSERT mid-way, the web lists the row and imports nothing',
      async (ctx) => {
        fixtureOn();
        try {
          const y = await freshCompany(ctx);
          const s = await companySession(ctx, 'invalid');
          await openScreen(s.page);
          const before = await companyCounts(ctx);
          const notMdb = await choose(s.page, {
            name: 'NOTES.MDB',
            mimeType: 'application/octet-stream',
            buffer: Buffer.from('these are not database pages'),
          });
          assert.equal(notMdb.status, 400);
          await s.page
            .locator('.msg[role="alert"]', {
              hasText:
                'The chosen file is not a Microsoft Access (.mdb) database and was not read; nothing was imported.',
            })
            .waitFor();
          const bad = await choose(
            s.page,
            fileOf(y, (f) => {
              f.tables.BAR_DETL[0].KR_NAME = 'KARIGAR-TOO-LONG';
            }),
          );
          assert.equal(bad.status, 200);
          const errors = await s.page.getByRole('table', { name: 'Import errors' }).innerText();
          assert.match(errors, /BAR_DETL/);
          assert.match(errors, /KR_NAME "KARIGAR-TOO-LONG" is longer than 5 characters/);
          assert.equal(
            await s.page.getByRole('button', { name: 'Import', exact: true }).isDisabled(),
            true,
          );
          const forced = await s.page.request.post('/api/utilities/data-import/lite/apply', {
            data: {
              fileName: 'LITE.MDB',
              data: fileOf(y, (f) => {
                f.tables.BAR_DETL[0].KR_NAME = 'KARIGAR-TOO-LONG';
              }).buffer.toString('base64'),
              previewHash: bad.body.previewHash,
            },
          });
          assert.equal(forced.status(), 400);
          assert.deepEqual(await companyCounts(ctx), before);
          return {
            observation:
              'a non-Access file is refused unread; a row error is listed, Import is disabled and a forced apply writes nothing',
            expected: { notMdb: 400, rowError: 'BAR_DETL KR_NAME', apply: 400 },
            database: { before, after: before },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'create.write-set',
      'T07',
      'mutation',
      'UT_IMPORT.cs:8413-8445 the five steps, :8766 AC_MAST, :4298-4308 ITEM_MAST, :8506/:8649/:8684 BAR_DETL/BAR_IDTL/BAR_DATA, :3927 ITM_OPBL, :8439 OP_DATE; Ac_Stock.cs:11-26 MAIN_STOCK; :8443-8444 message and exit',
      async (ctx) => {
        try {
          const { y, result } = await importedCompany(ctx, 'create');
          assert.deepEqual(result.dialogs, [
            { type: 'confirm', message: QUESTION },
            { type: 'alert', message: COMPLETE },
          ]);
          assert.deepEqual(steps(result.body), EXPECTED_STEPS);
          const counts = await companyCounts(ctx);
          assert.equal(counts.BAR_DETL, 3);
          assert.equal(counts.BAR_IDTL, 2);
          assert.equal(counts.ITM_OPBL, 2);
          assert.equal(counts.MAIN_STOCK, 5);
          assert.equal(counts.OP_DATA, 3);
          const detl = await ctx.rows(
            `SELECT "VCH_NO","TAG_NO","VCH_SRNO","CO_BOOK","VCH_TYPE","BOOK_NAME","ITM_OTH_WT"::float oth,"DESIGN_NO","KR_FINE"::float kf,"TAG_TYPE",to_char("VCH_DATE",'YYYY-MM-DD') d
               FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "VCH_SRNO"`,
            CO,
          );
          const tagDay = new Date(`${y.opDate}T00:00:00Z`);
          tagDay.setUTCDate(tagDay.getUTCDate() - 1);
          assert.deepEqual(
            detl.map((d) => [d.VCH_NO, d.TAG_NO, d.VCH_SRNO, d.d]),
            [
              ['00001', 'C1', 1000011, tagDay.toISOString().slice(0, 10)],
              ['00002', 'R1', 1000021, tagDay.toISOString().slice(0, 10)],
              ['00002', 'R2', 1000022, tagDay.toISOString().slice(0, 10)],
            ],
          );
          assert.deepEqual(
            { ...detl[1], d: undefined },
            {
              VCH_NO: '00002',
              TAG_NO: 'R1',
              VCH_SRNO: 1000021,
              CO_BOOK: '000',
              VCH_TYPE: 'OPTAG',
              BOOK_NAME: 'OPSTK',
              oth: 0.5,
              DESIGN_NO: 'DESIGN-NUMBER-0',
              kf: 11.232,
              TAG_TYPE: 'G',
              d: undefined,
            },
          );
          const accounts = (
            await ctx.rows(
              `SELECT "AC_CODE" c FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
              CO,
            )
          ).map((a) => a.c);
          assert(
            accounts.includes('00101') && accounts.includes('CASH') && !accounts.includes('00001'),
          );
          const [year] = await ctx.rows(
            `SELECT "OP_DATE" op FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
            CO,
          );
          assert.equal(year.op, result.body.newOpeningDate);
          const [set] = await ctx.rows(
            `SELECT "VB_IMPORT" v FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
            CO,
          );
          assert.equal(set.v, 'Y');
          return {
            observation: `imported through the screen: ${JSON.stringify(counts)}; question, completion message, then signed out`,
            expected: EXPECTED_STEPS,
            database: { counts, detl, openingDate: year.op },
            downstream: { signedOut: '/login', vbImport: set.v },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'reopen.second-import-refused',
      'T08',
      'refusal',
      'D-IMP-2: the desktop deletes and re-imports (UT_IMPORT.cs:8459-8461 deletes the tags); the web refuses a company that already has data and writes nothing',
      async (ctx) => {
        try {
          const { y } = await importedCompany(ctx, 'reopen');
          const before = await tenantFingerprint(ctx);
          const s = await companySession(ctx, 'reopen-again');
          await openScreen(s.page);
          const again = await choose(s.page, fileOf(y));
          assert.equal(again.body.refusal, HAS_DATA);
          await s.page.locator('.msg[role="alert"]', { hasText: HAS_DATA }).waitFor();
          assert.equal(
            await s.page.getByRole('button', { name: 'Import', exact: true }).isDisabled(),
            true,
          );
          assert.deepEqual(businessChanges(before, await tenantFingerprint(ctx)), []);
          return {
            observation:
              'the same file on the imported company is refused with the company counts; nothing changed',
            expected: { refusal: HAS_DATA },
            database: { changed: [] },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    notApplicable(
      'edit',
      'T09',
      'UT_IMPORT.cs:8413-8445 has no edit path',
      'An import is a one-time create; imported rows are edited in their own masters.',
    ),
    C(
      'cancel.no-writes-nothing',
      'T10',
      'refusal',
      'UT_IMPORT.cs:8422: answering No to "Are You Sure To Import Old Software Data In Next Software ?" imports nothing',
      async (ctx) => {
        fixtureOn();
        try {
          const y = await freshCompany(ctx);
          const s = await companySession(ctx, 'cancel');
          await openScreen(s.page);
          const before = await companyCounts(ctx);
          await choose(s.page, fileOf(y));
          const asked = [];
          s.page.removeAllListeners('dialog');
          s.page.on('dialog', (d) => {
            asked.push(d.message());
            void d.dismiss();
          });
          await s.page.getByRole('button', { name: 'Import', exact: true }).click();
          await s.page.waitForTimeout(500);
          assert.deepEqual(asked, [QUESTION]);
          assert.equal(
            s.requests.filter((r) => r.path === '/api/utilities/data-import/lite/apply').length,
            0,
          );
          assert.deepEqual(await companyCounts(ctx), before);
          return {
            observation: 'No to the desktop question sends no import and writes nothing',
            expected: { question: QUESTION },
            database: { before, after: before },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'rights.caption-view',
      'T11',
      'refusal',
      'MDI_FORM.cs:7034-7046 AllBtn needs USER_SET FRM_VIEW for the caption, else "You Have No Rights....."; BtnLite_Click checks nothing more (UT_IMPORT.cs:8413-8445)',
      async (ctx) => {
        fixtureOn();
        const exec = (sql, ...p) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...p);
        const drop = () =>
          exec(
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "SUB_MENU"='Data Import' AND "USER_NAME"=$2`,
            USERS.clerk.user,
          );
        await drop();
        try {
          const y = { year: '2024-2025', clDate: '2025-03-31' };
          const body = {
            fileName: 'LITE.MDB',
            data: fileOf(y).buffer.toString('base64'),
          };
          const before = await tenantFingerprint(ctx);
          const { page } = await ctx.session(as(USERS.clerk.user, 'data-import-rights'));
          const refused = await page.request.post('/api/utilities/data-import/lite/preview', {
            data: body,
          });
          const refusedApply = await page.request.post('/api/utilities/data-import/lite/apply', {
            data: { ...body, previewHash: '0'.repeat(64) },
          });
          assert.equal(refused.status(), 403);
          assert.equal(refusedApply.status(), 403);
          assert.equal((await refused.json()).message, 'You Have No Rights.....');
          await exec(
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Other','Data Import','Y','N','N','N')`,
            USERS.clerk.user,
          );
          // With View the clerk reaches the importer; company 01 holds vouchers, so it is refused as not new.
          const allowed = await page.request.post('/api/utilities/data-import/lite/preview', {
            data: body,
          });
          assert.equal(allowed.status(), 200);
          assert.equal((await allowed.json()).refusal, HAS_DATA);
          const second = await tenantFingerprint({
            ...ctx,
            rows: (sql, ...p) => ctx.owner.$queryRawUnsafe(sql, SECOND_TENANT, ...p),
          });
          assert.deepEqual(businessChanges(before, await tenantFingerprint(ctx)), []);
          return {
            observation:
              'no caption row: 403 "You Have No Rights....."; View: preview allowed and the data company refused; nothing written',
            expected: { none: 403, view: 'refusal' },
            database: { changed: [], secondTenantTables: Object.keys(second).length },
          };
        } finally {
          await drop();
        }
      },
    ),
    C(
      'concurrency.two-imports-one-wins',
      'T12',
      'refusal',
      'D-IMP-2 with the import lock (dataImport.ts applyLiteImport): two operators importing into one new company at once import once',
      async (ctx) => {
        fixtureOn();
        try {
          const y = await freshCompany(ctx);
          const s = await companySession(ctx, 'race');
          await openScreen(s.page);
          const preview = await choose(s.page, fileOf(y));
          const data = {
            fileName: 'LITE.MDB',
            data: fileOf(y).buffer.toString('base64'),
            previewHash: preview.body.previewHash,
          };
          const [a, b] = await Promise.all(
            [randomUUID(), randomUUID()].map((key) =>
              s.page.request.post('/api/utilities/data-import/lite/apply', {
                data,
                headers: { 'idempotency-key': key },
              }),
            ),
          );
          const statuses = [a.status(), b.status()].sort();
          assert.deepEqual(statuses, [200, 409]);
          const counts = await companyCounts(ctx);
          assert.equal(counts.BAR_DETL, 3);
          return {
            observation:
              'two concurrent imports: one 200, one 409 (company no longer new); one write set',
            expected: { statuses: [200, 409], BAR_DETL: 3 },
            database: counts,
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'retry.same-key-replays',
      'T13',
      'refusal',
      'D18 (idempotency.ts): a retried import with the same Idempotency-Key answers the first result and imports once',
      async (ctx) => {
        fixtureOn();
        try {
          const y = await freshCompany(ctx);
          const s = await companySession(ctx, 'retry');
          await openScreen(s.page);
          const preview = await choose(s.page, fileOf(y));
          const key = randomUUID();
          const send = () =>
            s.page.request.post('/api/utilities/data-import/lite/apply', {
              data: {
                fileName: 'LITE.MDB',
                data: fileOf(y).buffer.toString('base64'),
                previewHash: preview.body.previewHash,
              },
              headers: { 'idempotency-key': key },
            });
          const first = await send();
          const after = await companyCounts(ctx);
          const second = await send();
          assert.equal(first.status(), 200);
          assert.equal(second.status(), 200);
          assert.equal(second.headers()['idempotency-replayed'], 'true');
          assert.deepEqual(await second.json(), await first.json());
          assert.deepEqual(await companyCounts(ctx), after);
          return {
            observation:
              'the replay answered the stored result with Idempotency-Replayed: true; counts unchanged',
            expected: { replayed: true },
            database: after,
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'rollback.fault-in-tag-step',
      'T14',
      'refusal',
      'D-IMP-2: the desktop runs the steps without a transaction (UT_IMPORT.cs:8432-8437); a failure in step 4 must leave steps 1-3 unwritten',
      async (ctx) => {
        fixtureOn();
        const y = await freshCompany(ctx);
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_data_import_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN IF NEW.tenant_id = '${TENANT}' AND NEW."CO_CODE" = '${CO}' THEN RAISE EXCEPTION 'injected import fault'; END IF; RETURN NEW; END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_data_import_fault BEFORE INSERT ON "BAR_IDTL" FOR EACH ROW EXECUTE FUNCTION e2e_data_import_fault()`,
        );
        try {
          const s = await companySession(ctx, 'rollback');
          await openScreen(s.page);
          const before = await tenantFingerprint(ctx);
          const result = await importThroughScreen(s.page, fileOf(y));
          assert.notEqual(result.status, 200);
          await s.page.locator('.msg[role="alert"]').waitFor();
          assert.equal(new URL(s.page.url()).pathname, '/utilities/data-import');
          const changed = businessChanges(before, await tenantFingerprint(ctx));
          assert.deepEqual(changed, []);
          return {
            observation: `fault on BAR_IDTL: ${result.status}, the screen stays and no table changed`,
            expected: { changed: [] },
            database: { changed },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DROP TRIGGER IF EXISTS e2e_data_import_fault ON "BAR_IDTL"`,
          );
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_data_import_fault()`);
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'config.data-after-preview-refused',
      'T15',
      'refusal',
      'D-IMP-2: the company is checked again inside the import transaction, so a voucher posted after the preview stops the import',
      async (ctx) => {
        fixtureOn();
        try {
          const y = await freshCompany(ctx);
          const s = await companySession(ctx, 'stale');
          await openScreen(s.page);
          await choose(s.page, fileOf(y));
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","CR_AMT","DR_AMT") VALUES ($1,$2,'01',$3,'SL','00001','CASH',10,0)`,
            TENANT,
            CO,
            y.year,
          );
          const before = await companyCounts(ctx);
          const applied = s.page.waitForResponse(
            (r) => new URL(r.url()).pathname === '/api/utilities/data-import/lite/apply',
          );
          await s.page.getByRole('button', { name: 'Import', exact: true }).click();
          const r = await applied;
          assert.equal(r.status(), 409);
          await s.page.locator('.msg[role="alert"]', { hasText: HAS_DATA }).waitFor();
          assert.deepEqual(await companyCounts(ctx), before);
          return {
            observation:
              'a voucher posted after the preview: the import answers 409 with the refusal and writes nothing',
            expected: { status: 409, message: HAS_DATA },
            database: { before, after: before },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'output.tag-stock-and-party-balance',
      'T16',
      'output',
      'Ac_Stock.cs:22-26 (Tag_Opbl_Stk) puts the imported tags in stock; Ac_Ledr.cs:9-28 (AcOp_Ledr) the openings in the ledger',
      async (ctx) => {
        try {
          await importedCompany(ctx, 'output');
          const s = await companySession(ctx, 'output-read');
          const tagStock = await (
            await s.page.request.get('/api/reports/tag-stock?tab=stock')
          ).text();
          for (const tag of ['R1', 'R2', 'C1']) assert.match(tagStock, new RegExp(`"${tag}"`));
          const balance = await (await s.page.request.get('/api/party/00101/balance')).text();
          assert.match(balance, /750\.45/);
          return {
            observation: 'Tag Stock lists R1, R2 and C1; party 00101 shows its 750.45 Cr opening',
            expected: { tags: ['R1', 'R2', 'C1'], balance: 750.45 },
            output: Buffer.from(JSON.stringify({ tagStock: tagStock.slice(0, 4000), balance })),
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    C(
      'keyboard.enter-opens-file-esc-leaves',
      'T17',
      'read-only',
      'UT_IMPORT.cs:3422-3430 Esc closes the form; Lite Soft is a button (Enter presses it)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        await page.getByRole('button', { name: 'Lite Soft', exact: true }).focus();
        const [chooser] = await Promise.all([
          page.waitForEvent('filechooser'),
          page.keyboard.press('Enter'),
        ]);
        assert.equal(chooser.isMultiple(), false);
        const esc = await escLeavesWithNoFocus(page, {
          heading: 'Old Software Import',
          path: '/utilities/data-import',
        });
        return {
          observation: `Enter on Lite Soft opens the file chooser; Esc leaves to ${esc.leftTo}`,
          expected: { enter: 'filechooser', esc: 'leaves' },
        };
      },
    ),
    C(
      'journey.imported-tag-sold',
      'T18',
      'mutation',
      'An imported opening tag (BAR_DETL + MAIN_STOCK TAGOP) is stock the Sales voucher issues (sales.ts issueTagTx); the sale moves it out of Tag Stock',
      async (ctx) => {
        try {
          await importedCompany(ctx, 'journey');
          const s = await companySession(ctx, 'journey-sale');
          const today = new Intl.DateTimeFormat('en-CA', { timeZone: 'Asia/Kolkata' }).format(
            new Date(),
          );
          const sale = await s.page.request.post('/api/sales', {
            data: {
              coBook: 'SL',
              acCode: '00101',
              vchDate: today,
              taxRatePct: 0,
              interState: false,
              lines: [
                {
                  itCode: 'RNG',
                  tagNo: 'R1',
                  vchSrno: 1000021,
                  pcs: 1,
                  grossWt: 12.5,
                  netWt: 12,
                  touch: 91.6,
                  metalAmount: 72000,
                },
              ],
              cashAmt: 72000,
            },
          });
          assert.equal(sale.status(), 201, await sale.text());
          const out = await ctx.rows(
            `SELECT "ITM_SIGN" s FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAG_NO"='R1' AND "VCH_SRNO"=1000021 ORDER BY row_id`,
            CO,
          );
          assert.deepEqual(
            out.map((r) => r.s),
            ['+', '-'],
          );
          const stock = await (await s.page.request.get('/api/reports/tag-stock?tab=stock')).text();
          assert.doesNotMatch(stock, /"R1"/);
          assert.match(stock, /"R2"/);
          return {
            observation:
              'imported tag R1 sold on book SL; its stock is +1 then -1 and it left Tag Stock',
            expected: { stock: ['+', '-'] },
            database: { stock: out },
            downstream: { tagStockHasR1: false },
          };
        } finally {
          await dropCompany(ctx);
        }
      },
    ),
    blocked(
      'source.real-lite-mdb',
      'T07',
      'UT_IMPORT.cs:3193-3202 TrfrConn opens the .mdb with Jet OLEDB 4.0',
      'no sample file in the repository; the owner must supply one sanitized or synthetic file',
    ),
  ],
};
