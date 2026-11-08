import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import {
  DAY,
  ISSUE_BOOK,
  RETURN_BOOK,
  TENANT,
  approvalRows,
  approvalStock,
  approvalWriteCounts,
  as,
  createIssue,
  createReturn,
  fillIssue,
  isApi,
  label,
  openApproval,
  reopenApproval,
  saveApproval,
  seedApprovalStone,
  seedApprovalTag,
  tagState,
  withRemarkFault,
} from './approvalHelpers.mjs';

/**
 * ExtraTran → Approval Isu. Authority: MDI_FORM.cs:8300-8305; TR_APR_ISU.cs:5788-5981,
 * 6015-6431,6608-6772; Ac_Stock.cs:60-72,887-890; AprBill.spec.json.
 */
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `approval-issue.${id}`,
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
const blocked = (id, group, reason) => ({
  ...C(`${id}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})),
  blocked: reason,
});
const notApplicable = (id, group, source, reason) => ({
  ...C(`${id}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

export const approvalIssue = {
  feature: 'approval-issue',
  title: 'ExtraTran → Approval Isu (TR_APR_ISU, APR ISU)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/tour/page.tsx',
    'web/apps/api/src/modules/tour/approvalVoucher.ts',
    'web/apps/api/src/modules/tour/approvalRows.ts',
    'web/apps/api/src/modules/tour/approvalTypes.ts',
    'web/apps/api/src/modules/tour/approvalBill.ts',
    'web/apps/api/src/routes/approval.ts',
    'web/apps/web/test/features/modules/approvalIssue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; cases seed live BAR_DETL tags' },
  cases: [
    C(
      'entry.desktop-book',
      'T01',
      'read-only',
      "MDI_FORM.cs:8300-8305 calls CurBookHelp('APR ISU'); CLEAR_DATA TR_APR_ISU.cs:5697-5786 starts a new voucher.",
      async (ctx) => {
        const { page, book } = await openApproval(ctx);
        const values = await book
          .locator('option')
          .evaluateAll((o) => o.map((x) => x.getAttribute('value')).filter(Boolean));
        assert.deepEqual(values, [ISSUE_BOOK]);
        assert.match(await label(page, 'Vch Date').inputValue(), /^\d{4}-\d{2}-\d{2}$/);
        await ctx.shot(page, 'entry');
        return { observation: `book ${values.join(',')}`, expected: ISSUE_BOOK };
      },
    ),
    C(
      'book.family-guard',
      'T02',
      'refusal',
      "MDI_FORM.cs:8301 limits this menu to MAIN_BOOK 'APR ISU'.",
      async (ctx) => {
        const { page } = await openApproval(ctx);
        const answer = await page.evaluate(
          async ({ day, returnBook }) => {
            const response = await fetch('/api/tour/issue', {
              method: 'POST',
              credentials: 'include',
              headers: { 'content-type': 'application/json' },
              body: JSON.stringify({
                coBook: returnBook,
                vchDate: day,
                partyAc: 'E2ELOC',
                lines: [{ itCode: 'GLD22', pcs: 1 }],
              }),
            });
            return { status: response.status, text: await response.text() };
          },
          { day: DAY, returnBook: RETURN_BOOK },
        );
        assert.equal(answer.status, 400);
        assert.match(answer.text, /MAIN_BOOK='APR ISU'/);
        return {
          observation: `wrong family answered ${answer.status}: ${answer.text}`,
          expected: "400 MAIN_BOOK='APR ISU'",
          database: {},
        };
      },
    ),
    C(
      'formula.fine',
      'T03',
      'read-only',
      'TR_APR_ISU CommPassTotal and Ac_Stock.cs:68 copy ITM_FINE; 10.000 × 91.6 / 100 = 9.160.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIF');
        const { page } = await openApproval(ctx);
        await fillIssue(page, tag.tag);
        await page.getByText(/Fine 9\.16(?:0)? g/).waitFor();
        return { observation: '10.000 × 91.6% displayed as 9.16 g', expected: 9.16 };
      },
    ),
    C(
      'formula.net-discount-rounding',
      'T03',
      'mutation',
      'TR_APR_ISU.cs:3936-3942 derives LDiscAmt from labour × LDisc% and formats NetAmt as 0.0; :6218-6225 saves both.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIA');
        const { page } = await openApproval(ctx);
        await fillIssue(page, tag.tag, 'amount rounding');
        await page.getByTestId('approval-issue-grid-mode').click();
        const itemGrid = page.locator('table.grid').first();
        await itemGrid.getByLabel('ItAmt row 1', { exact: true }).fill('100.04');
        await itemGrid.getByLabel('LbrAmt row 1', { exact: true }).fill('20.05');
        await itemGrid.getByLabel('OthAmt row 1', { exact: true }).fill('0.02');
        await itemGrid.getByLabel('LDisc% row 1', { exact: true }).fill('10');
        assert.equal(
          await itemGrid.getByLabel('LDiscAmt row 1', { exact: true }).inputValue(),
          '2.01',
        );
        assert.equal(
          await itemGrid.getByLabel('NetAmt row 1', { exact: true }).inputValue(),
          '118.1',
        );
        const response = await saveApproval(page);
        assert.equal(response.status(), 201, await response.text());
        const result = await response.json();
        const rows = await ctx.rows(
          `SELECT "DISC_AMT"::float8 discount,"NET_AMT"::float8 net FROM "APR_DETL"
            WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2`,
          result.voucherNo,
        );
        assert.deepEqual(rows, [{ discount: 2.01, net: 118.1 }]);
        return {
          observation: 'LDiscAmt 2.01 and NetAmt 118.1 shown and saved',
          expected: { discount: 2.01, net: 118.1 },
          database: { rows },
          downstream: await tagState(ctx, tag.tag),
        };
      },
    ),
    C(
      'refusal.unknown-stone-item',
      'T04',
      'refusal',
      'TR_APR_ISU.cs:6324-6331 saves coded stone rows selected from ITEM_MAST; an unknown code cannot enter APR_IDTL.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIU');
        const { page } = await openApproval(ctx);
        await fillIssue(page, tag.tag, 'unknown stone');
        const before = await ctx.rows(
          `SELECT count(*)::int rows FROM "APR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
        );
        await label(page, 'ItCode row 1').fill('ZZZ99');
        await label(page, 'ItCode row 1').press('Escape');
        await label(page, 'NetAmt row 1').fill('1');
        const response = await saveApproval(page);
        assert.equal(response.status(), 400, await response.text());
        await page
          .getByRole('alert')
          .filter({ hasText: 'approval stone item not found' })
          .waitFor();
        const after = await ctx.rows(
          `SELECT count(*)::int rows FROM "APR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
        );
        assert.deepEqual(after, before);
        assert.deepEqual(await tagState(ctx, tag.tag), { apr: 'N', transfer: 'N', balance: 1 });
        return {
          observation: 'unknown ZZZ99 stone refused with no voucher or tag change',
          expected: '400 approval stone item not found',
          database: { before, after },
        };
      },
    ),
    C(
      'refusal.party-required',
      'T04',
      'refusal',
      'TR_APR_ISU.cs:6055-6060: "Please Insert Party and try" after year/lock/employee checks.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIR');
        const { page } = await openApproval(ctx);
        await label(page, 'Vch Date').fill(DAY);
        const tagInput = label(page, 'TagNo line 1');
        await tagInput.fill(tag.tag);
        await tagInput.locator('xpath=..').getByText(tag.tag, { exact: false }).first().waitFor();
        await tagInput.press('Enter');
        const response = await saveApproval(page);
        assert.equal(response.status(), 400, await response.text());
        await page.getByRole('alert').filter({ hasText: 'Please Insert Party and try' }).waitFor();
        assert.equal((await tagState(ctx, tag.tag)).balance, 1);
        return {
          observation: 'desktop party refusal, tag unchanged',
          expected: 'no write',
          database: { balance: 1 },
        };
      },
    ),
    C(
      'create.desktop-write-set',
      'T05',
      'mutation',
      'TR_APR_ISU.cs:6123-6431 and Ac_Stock.cs:60-72: APR rows, O/- stock and BAR_DETL.APR_ISU=Y; no money ledger.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIC');
        const created = await createIssue(ctx, tag.tag);
        const rows = await approvalRows(ctx, ISSUE_BOOK, created.voucherNo);
        const stock = await approvalStock(ctx, ISSUE_BOOK, created.voucherNo);
        assert.deepEqual(
          rows.map((r) => [r.book, r.type, r.inout, r.tag, r.serial, r.net, r.fine]),
          [['APR ISU', 'TUR', 'O', tag.tag, tag.serial, 10, 9.16]],
        );
        assert.deepEqual(
          stock.map((r) => [r.book, r.type, r.tr, r.sign]),
          [['APR ISU', 'TUR', 'O', '-']],
        );
        assert.deepEqual(await tagState(ctx, tag.tag), { apr: 'Y', transfer: 'N', balance: 0 });
        await ctx.shot(created.page, 'created');
        return {
          observation: created.voucherNo,
          expected: 'APR ISU + O/- + pending',
          database: { rows, stock },
          downstream: { balance: 0 },
        };
      },
    ),
    C(
      'entry.tag-stone-hydration',
      'T05',
      'mutation',
      'TR_APR_ISU.cs:5044-5137 copies BAR_DETL and :5153-5202 copies BAR_IDTL on tag pick.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIZ');
        await seedApprovalStone(ctx, tag);
        const { page } = await openApproval(ctx);
        await fillIssue(page, tag.tag, 'stone hydration');
        assert.equal(await label(page, 'ItCode row 1').inputValue(), 'DIAE1');
        assert.equal(await label(page, 'DmCode row 1').inputValue(), 'RD');
        assert.equal(Number(await label(page, 'Weight row 1').inputValue()), 0.25);
        await page.getByTestId('approval-issue-grid-mode').click();
        assert.equal(await label(page, 'LotNo row 1').inputValue(), 'LOT-E2E');
        assert.equal(await label(page, 'HmId2 row 1').inputValue(), 'HUID2');
        assert.equal(
          await page.locator('table.grid').first().getByLabel('ItType row 1').inputValue(),
          'G',
        );
        const response = await saveApproval(page);
        assert.equal(response.status(), 201, await response.text());
        const result = await response.json();
        const stones = await ctx.rows(
          `SELECT "IT_CODE" item,"DM_CODE" diamond,"IT_GWT"::float8 weight,"IT_NET_AMT"::float8 net,
                  "ISR_NO"::int stone,"HD_VCH_NO" hidden FROM "APR_IDTL"
            WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2`,
          result.voucherNo,
        );
        assert.deepEqual(stones, [
          {
            item: 'DIAE1',
            diamond: 'RD',
            weight: 0.25,
            net: 1275,
            stone: 7,
            hidden: result.voucherNo,
          },
        ]);
        return {
          observation: `${tag.tag} hydrated one stone`,
          expected: 'BAR fields and APR_IDTL persisted',
          database: { stones },
          downstream: await tagState(ctx, tag.tag),
        };
      },
    ),
    notApplicable(
      'settlement',
      'T06',
      'TR_APR_ISU and Ac_Stock.Apr_Isu_Stk write no AC_DATA.',
      'Approval issue is custody only; money is posted only by the later sale.',
    ),
    C(
      'reopen.lossless',
      'T07',
      'mutation',
      'TR_APR_ISU.cs:5788-5981 DISPLAY_DATA restores the header, item grid and APR_IDTL rows.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIL');
        const created = await createIssue(ctx, tag.tag, 'lossless note');
        // DISPLAY_DATA restores the stored ITM_PCS value; zero must not fall back to CommPassAdd's new-row 1.
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "APR_DETL" SET "ITM_PCS"=0 WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2`,
          TENANT,
          created.voucherNo,
        );
        await pageNew(created.page);
        await reopenApproval(created.page, 'issue', created.voucherNo);
        const [header] = await ctx.rows(
          `SELECT to_char("VCH_TIME",'HH24:MI:SS') clock FROM "APR_DATA"
            WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2`,
          created.voucherNo,
        );
        assert.equal(await label(created.page, 'Vch No').inputValue(), created.voucherNo);
        assert.equal(await label(created.page, 'Party Code').inputValue(), 'E2ELOC');
        assert.equal(await label(created.page, 'Party Name').inputValue(), 'E2E LOCAL CUSTOMER');
        assert.equal(await label(created.page, 'Employee Name').inputValue(), 'APPROVAL EMPLOYEE');
        assert.equal(await label(created.page, 'Vch Time').inputValue(), header.clock);
        assert.equal(await label(created.page, 'TagNo line 1').inputValue(), tag.tag);
        assert.equal(await label(created.page, 'Pcs line 1').inputValue(), '0');
        assert.equal(await label(created.page, 'Vch Desc').inputValue(), 'LOSSLESS NOTE');
        return {
          observation: `reopened ${created.voucherNo}`,
          expected: 'party, tag and description',
          database: { rows: await approvalRows(ctx, ISSUE_BOOK, created.voucherNo) },
          downstream: { loaded: true },
        };
      },
    ),
    C(
      'edit.unchanged',
      'T08',
      'mutation',
      'TR_APR_ISU DISPLAY_DATA followed by Save preserves the voucher; web no-ops an identical versioned body.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIN');
        await seedApprovalStone(ctx, tag);
        const created = await createIssue(ctx, tag.tag);
        const stones = () =>
          ctx.rows(
            `SELECT row_id::text id,"SR_NO"::int parent,"ISR_NO"::int stone,"IT_CODE" item,
                    "IT_PCS"::float8 pcs,"IT_GWT"::float8 weight,"KR_WT"::float8 karigar,
                    "IT_NET_AMT"::float8 net FROM "APR_IDTL"
              WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2 ORDER BY "SR_NO","ISR_NO"`,
            created.voucherNo,
          );
        const before = {
          rows: await approvalRows(ctx, ISSUE_BOOK, created.voucherNo),
          stock: await approvalStock(ctx, ISSUE_BOOK, created.voucherNo),
          stones: await stones(),
        };
        await reopenApproval(created.page, 'issue', created.voucherNo);
        const response = await saveApproval(created.page, 'issue', 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const result = await response.json();
        const after = {
          rows: await approvalRows(ctx, ISSUE_BOOK, created.voucherNo),
          stock: await approvalStock(ctx, ISSUE_BOOK, created.voucherNo),
          stones: await stones(),
        };
        assert.equal(result.version, created.result.version);
        assert.deepEqual(after, before);
        assert.equal(after.stones[0].stone, 7);
        return {
          observation: 'unchanged stone-bearing PUT kept version and physical rows',
          expected: 'identical footprint and ISR_NO 7',
          database: { before, after },
          downstream: { unchanged: true },
        };
      },
    ),
    C(
      'edit.append-after-stable-id-gap',
      'T09',
      'mutation',
      'TR_APR_ISU.cs:3414-3421 keeps an edited row OLD_SRNO and assigns a newly appended row above the retained maximum.',
      async (ctx) => {
        const first = await seedApprovalTag(ctx, 'AIGA');
        const retained = await seedApprovalTag(ctx, 'AIGB');
        const appended = await seedApprovalTag(ctx, 'AIGC');
        const { page } = await openApproval(ctx);
        await fillIssue(page, first.tag, 'stable ids');
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        const second = label(page, 'TagNo line 2');
        await second.fill(retained.tag);
        await second
          .locator('xpath=..')
          .getByText(retained.tag, { exact: false })
          .first()
          .waitFor();
        await second.press('Enter');
        const created = await saveApproval(page);
        assert.equal(created.status(), 201, await created.text());
        const result = await created.json();
        const voucherNo = String(result.voucherNo);
        await reopenApproval(page, 'issue', voucherNo);
        await page.getByRole('button', { name: 'Remove line 1', exact: true }).click();
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        const third = label(page, 'TagNo line 2');
        await third.fill(appended.tag);
        await third.locator('xpath=..').getByText(appended.tag, { exact: false }).first().waitFor();
        await third.press('Enter');
        const edited = await saveApproval(page, 'issue', 'PUT');
        assert.equal(edited.status(), 200, await edited.text());
        const rows = await ctx.rows(
          `SELECT "SR_NO"::int sr,"OLD_SRNO"::int old,"TAG_NO" tag FROM "APR_DETL"
            WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
          voucherNo,
        );
        assert.deepEqual(rows, [
          { sr: 1, old: 2, tag: retained.tag },
          { sr: 2, old: 3, tag: appended.tag },
        ]);
        return {
          observation: `removed OLD_SRNO 1; retained ${retained.tag}=2; appended ${appended.tag}=3`,
          expected: 'OLD_SRNO 2,3',
          database: { rows },
          downstream: {
            removed: await tagState(ctx, first.tag),
            retained: await tagState(ctx, retained.tag),
            appended: await tagState(ctx, appended.tag),
          },
        };
      },
    ),
    C(
      'edit.description',
      'T09',
      'mutation',
      'TR_APR_ISU.cs:5841-5913,6170-6178,6223-6251 preserves consumed fields when an issue is edited.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIE');
        const created = await createIssue(ctx, tag.tag);
        await createReturn(ctx, created, 'consume before edit', { page: created.page });
        await openApproval(ctx, 'issue', { page: created.page });
        await reopenApproval(created.page, 'issue', created.voucherNo);
        await label(created.page, 'Vch Desc').fill('changed after return');
        const response = await saveApproval(created.page, 'issue', 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const rows = await approvalRows(ctx, ISSUE_BOOK, created.voucherNo);
        assert.equal(rows[0].description, 'CHANGED AFTER RETURN');
        assert.equal(rows[0].received, 'Y');
        assert.deepEqual(await tagState(ctx, tag.tag), { apr: 'N', transfer: 'N', balance: 1 });
        return {
          observation: 'description edited after return without reopening source',
          expected: 'ISU_REC=Y and APR_ISU=N',
          database: { rows },
          downstream: await tagState(ctx, tag.tag),
        };
      },
    ),
    C(
      'delete.audit-and-stock',
      'T10',
      'mutation',
      'TR_APR_ISU.cs:6648-6704 audits each line, clears APR_ISU and removes the O/- stock row.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AID');
        const created = await createIssue(ctx, tag.tag);
        await reopenApproval(created.page, 'issue', created.voucherNo);
        const confirmed = new Promise((resolve) => {
          created.page.once('dialog', (dialog) => {
            assert.equal(dialog.message(), 'Are You Sure To Delete This Voucher now?');
            resolve(dialog.message());
          });
        });
        const [response] = await Promise.all([
          created.page.waitForResponse((r) => isApi(r, 'DELETE', `/tour/${created.voucherNo}`)),
          created.page.getByTestId('approval-issue-delete').click(),
        ]);
        await confirmed;
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(await approvalRows(ctx, ISSUE_BOOK, created.voucherNo), []);
        assert.deepEqual(await tagState(ctx, tag.tag), { apr: 'N', transfer: 'N', balance: 1 });
        const audits = await ctx.rows(
          `SELECT "DELETE_USER" "user","AC_NAME" account,"FINE_TYPE" type,
                  "VCH_FINE_CR"::float8 fine FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2`,
          created.voucherNo,
        );
        assert.deepEqual(audits, [
          { user: USERS.admin.user, account: 'E2E LOCAL CUSTOMER', type: 'G', fine: 10 },
        ]);
        return {
          observation: 'deleted and audited',
          expected: 'tag available',
          database: { audits },
          downstream: { balance: 1 },
        };
      },
    ),
    C(
      'rights.print-denied',
      'T11',
      'refusal',
      'TR_APR_ISU.cs:6712-6717: UserPrint is required before AprBill opens.',
      async (ctx) => {
        await ensureViewerRight(ctx);
        const tag = await seedApprovalTag(ctx, 'AIP');
        const created = await createIssue(ctx, tag.tag);
        const viewer = await ctx.session(as(USERS.printViewer.user));
        const answer = await viewer.page.request.get(
          `/api/tour/${created.voucherNo}/print?coBook=TUR&format=html`,
        );
        assert.equal(answer.status(), 403);
        assert.equal((await tagState(ctx, tag.tag)).balance, 0);
        return {
          observation: 'view-only user refused print',
          expected: 403,
          database: { balance: 0 },
        };
      },
    ),
    C(
      'concurrency.stale-edit',
      'T12',
      'refusal',
      'D17 hardening: two loaded TR_APR_ISU editors cannot silently overwrite the first committed edit.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIX');
        const first = await createIssue(ctx, tag.tag);
        const secondSession = await ctx.session(as(USERS.admin.user, 'approval-issue-second'));
        await openApproval(ctx, 'issue', secondSession);
        await reopenApproval(first.page, 'issue', first.voucherNo);
        await reopenApproval(secondSession.page, 'issue', first.voucherNo);
        await label(first.page, 'Vch Desc').fill('first wins');
        assert.equal((await saveApproval(first.page, 'issue', 'PUT')).status(), 200);
        await label(secondSession.page, 'Vch Desc').fill('second loses');
        const stale = await saveApproval(secondSession.page, 'issue', 'PUT');
        assert.equal(stale.status(), 409, await stale.text());
        return {
          observation: 'second editor received 409',
          expected: 'voucher-version-conflict',
          database: { rows: await approvalRows(ctx, ISSUE_BOOK, first.voucherNo) },
        };
      },
    ),
    C(
      'concurrency.same-tag-two-sessions',
      'T12',
      'refusal',
      'TR_APR_ISU.cs:5015-5061 lets a tag be picked only while it is live stock; Ac_Stock.cs:60-72 takes it out on save. Two operators who picked the same tag cannot both issue it: the second save is refused and the tag carries one approval line.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIT');
        const first = await openApproval(ctx);
        const secondSession = await ctx.session(as(USERS.admin.user, 'approval-issue-race'));
        await openApproval(ctx, 'issue', secondSession);
        await fillIssue(first.page, tag.tag, 'race first');
        await fillIssue(secondSession.page, tag.tag, 'race second');
        const won = await saveApproval(first.page);
        assert.equal(won.status(), 201, await won.text());
        const lost = await saveApproval(secondSession.page);
        assert.ok(
          lost.status() >= 400 && lost.status() < 500,
          `the second save of the same tag answered ${lost.status()}: ${await lost.text()}`,
        );
        const lines = await ctx.rows(
          `SELECT "CO_BOOK" book,"VCH_NO" voucher FROM "APR_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
          tag.tag,
        );
        assert.equal(lines.length, 1, JSON.stringify(lines));
        assert.deepEqual(await tagState(ctx, tag.tag), { apr: 'Y', transfer: 'N', balance: 0 });
        return {
          observation: `first 201, second ${lost.status()}`,
          expected: 'one approval line; the tag out once',
          database: { lines, tag: await tagState(ctx, tag.tag) },
        };
      },
    ),
    blocked(
      'retry',
      'T13',
      'Approval POST has no idempotency-key contract; duplicate/lost acknowledgement remains open.',
    ),
    C(
      'rollback.last-write-fault',
      'T14',
      'mutation',
      'TR_APR_ISU.cs:6123-6431 writes APR_DATA, APR_DETL, MAIN_STOCK, the BAR_DETL flag and REMARK_DATA as one save; a fault on REMARK_DATA, the last write, must leave none of them, and the same screen then saves.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIF');
        const remark = 'rollback probe issue';
        const { page } = await openApproval(ctx);
        await fillIssue(page, tag.tag, remark);
        const before = await approvalWriteCounts(ctx);
        const failed = await withRemarkFault(ctx, ISSUE_BOOK, remark, () => saveApproval(page));
        assert.ok(failed.status() >= 400, `the faulted save answered ${failed.status()}`);
        assert.deepEqual(await approvalWriteCounts(ctx), before);
        assert.deepEqual(await tagState(ctx, tag.tag), { apr: 'N', transfer: 'N', balance: 1 });
        const retried = await saveApproval(page);
        assert.equal(retried.status(), 201, await retried.text());
        const voucherNo = String((await retried.json()).voucherNo);
        const after = await approvalWriteCounts(ctx);
        const delta = Object.fromEntries(
          Object.keys(after)
            .map((table) => [table, after[table] - before[table]])
            .filter(([, n]) => n !== 0),
        );
        assert.deepEqual(delta, {
          APR_DATA: 1,
          APR_DETL: 1,
          MAIN_STOCK: 1,
          REMARK_DATA: 1,
          TEMP_BOOK_DATA: 1,
        });
        assert.deepEqual(await tagState(ctx, tag.tag), { apr: 'Y', transfer: 'N', balance: 0 });
        return {
          observation: `faulted save ${failed.status()} kept nothing; retry saved ${voucherNo}`,
          expected: 'pre-save counts and tag after the fault; one complete voucher after retry',
          database: { before, delta },
          downstream: await tagState(ctx, tag.tag),
        };
      },
    ),
    C(
      'config.lock-date',
      'T15',
      'refusal',
      'TR_APR_ISU.cs:6036-6041 uses the exact lock-date refusal before employee/party checks.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIK');
        const { page } = await openApproval(ctx);
        await fillIssue(page, tag.tag);
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_SET" SET "LOCK_DATE"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          TENANT,
          DAY,
        );
        try {
          const response = await saveApproval(page);
          assert.equal(response.status(), 400, await response.text());
          await page
            .getByRole('alert')
            .filter({ hasText: 'You Cant Save and Delete This Voucher Becouse Lock Date is =' })
            .waitFor();
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            TENANT,
          );
        }
        assert.equal((await tagState(ctx, tag.tag)).balance, 1);
        return {
          observation: 'locked date refused',
          expected: 'desktop text/no write',
          database: { balance: 1 },
        };
      },
    ),
    C(
      'print.apr-bill',
      'T16',
      'output',
      'TR_APR_ISU.cs:6742,6771-6772 selects AprBill; AprBill.spec.json fixes title, columns, totals and signatures.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIO');
        const created = await createIssue(ctx, tag.tag, 'print note');
        await reopenApproval(created.page, 'issue', created.voucherNo);
        const [popup] = await Promise.all([
          created.page.waitForEvent('popup'),
          created.page.getByTestId('approval-issue-print').click(),
        ]);
        await popup.waitForLoadState();
        const html = await popup.content();
        await ctx.shot(popup, 'apr-bill');
        await popup.close();
        for (const text of [
          'Approval Issue',
          'ORIGINAL',
          'Item Name',
          `${tag.tag} - ${'GOLD 22K ORNAMENT'}`,
          'Total :',
          'PRINT NOTE',
          'Party signature.',
        ])
          assert(html.includes(text), `AprBill contains ${text}`);
        return {
          observation: `AprBill ${html.length} bytes`,
          expected: 'AprBill layout',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'TR_APR_ISU Save is the desktop &Save mnemonic; Alt+S invokes the marked web save.',
      async (ctx) => {
        const tag = await seedApprovalTag(ctx, 'AIS');
        const { page } = await openApproval(ctx);
        await fillIssue(page, tag.tag);
        const [response] = await Promise.all([
          page.waitForResponse((r) => isApi(r, 'POST', '/tour/issue')),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        assert.equal((await tagState(ctx, tag.tag)).balance, 0);
        return {
          observation: 'Alt+S saved',
          expected: 'tag pending approval',
          database: { balance: 0 },
          downstream: { pending: true },
        };
      },
    ),
    blocked(
      'downstream-sale',
      'T18',
      'Approval Return is covered by its own module; the retained-item Sales Apr No journey and reversal remain open.',
    ),
  ],
};

async function pageNew(page) {
  await page.getByTestId('approval-issue-new').click();
}

async function ensureViewerRight(ctx) {
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     SELECT $1::text,'01','01',$2::text,'Sales','Approval Isu','Y','N','N','N'
      WHERE NOT EXISTS (SELECT 1 FROM "USER_SET" WHERE tenant_id=$1::text AND "USER_NAME"=$2::text AND "MAIN_MENU"='Sales' AND "SUB_MENU"='Approval Isu')`,
    TENANT,
    USERS.printViewer.user,
  );
}
