import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import {
  DAY,
  ISSUE_BOOK,
  RETURN_BOOK,
  TENANT,
  YEAR,
  approvalRows,
  approvalStock,
  as,
  createIssue,
  createReturn,
  fillIssue,
  isApi,
  label,
  openApproval,
  prepareReturn,
  reopenApproval,
  saveApproval,
  seedApprovalTag,
  tagState,
} from './approvalHelpers.mjs';

/** ExtraTran → Approval Rtn, the inward branch of desktop TR_APR_ISU. */
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `approval-return.${id}`,
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

async function issueFor(ctx, prefix = 'ARE') {
  const source = await seedApprovalTag(ctx, prefix);
  const issue = await createIssue(ctx, source.tag);
  return { ...issue, tag: source.tag, serial: source.serial };
}

export const approvalReturn = {
  feature: 'approval-return',
  title: 'ExtraTran → Approval Rtn (TR_APR_ISU, APR RTN)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/tour-return/page.tsx',
    'web/apps/api/src/modules/tour/approvalVoucher.ts',
    'web/apps/api/src/modules/tour/approvalRows.ts',
    'web/apps/api/src/modules/tour/approvalTypes.ts',
    'web/apps/api/src/modules/tour/approvalBill.ts',
    'web/apps/api/src/routes/approval.ts',
    'web/apps/web/test/features/modules/approvalReturn.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'catalogue defaults; every return starts from a real screen-created issue',
  },
  cases: [
    C(
      'entry.desktop-book',
      'T01',
      'read-only',
      "MDI_FORM.cs:8312-8317 calls CurBookHelp('APR RTN'); TR_APR_ISU.cs:5669-5677 shows Isu No for inward books.",
      async (ctx) => {
        const { page, book } = await openApproval(ctx, 'return');
        const values = await book
          .locator('option')
          .evaluateAll((o) => o.map((x) => x.getAttribute('value')).filter(Boolean));
        assert.deepEqual(values, [RETURN_BOOK]);
        assert.ok(await label(page, 'Original Issue Vch No').isVisible());
        await ctx.shot(page, 'entry');
        return { observation: `book ${values.join(',')}, Isu No visible`, expected: RETURN_BOOK };
      },
    ),
    C(
      'source.loads-open-lines',
      'T02',
      'read-only',
      "TR_APR_ISU.cs:4741-4760 loads APR ISU rows with ISU_REC='N' into Approval Rtn.",
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARL');
        const page = await prepareReturn(ctx, issue);
        assert.equal(await label(page, 'TagNo line 1').inputValue(), issue.tag);
        assert.equal(Number(await label(page, 'NetWt line 1').inputValue()), 10);
        return { observation: `loaded ${issue.tag}`, expected: 'one open source line' };
      },
    ),
    C(
      'formula.source-fine',
      'T03',
      'read-only',
      'TR_APR_ISU copies ITM_FINE from the selected issue; 10.000 × 91.6 / 100 = 9.160.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARF');
        const page = await prepareReturn(ctx, issue);
        await page.getByText(/Fine 9\.16(?:0)? g/).waitFor();
        return { observation: 'return fine 9.16 g', expected: 9.16 };
      },
    ),
    C(
      'refusal.missing-source',
      'T04',
      'read-only',
      "TR_APR_ISU inward lookup only admits an APR ISU row whose ISU_REC='N'; a missing number yields no selectable rows.",
      async (ctx) => {
        const { page } = await openApproval(ctx, 'return');
        await label(page, 'Original Issue Vch No').fill('99999');
        const [response] = await Promise.all([
          page.waitForResponse((r) => new URL(r.url()).pathname === '/api/tour/99999/lines'),
          page.getByTestId('approval-return-load-lines').click(),
        ]);
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(await response.json(), []);
        await page.getByRole('status').filter({ hasText: 'Loaded 0 open line(s)' }).waitFor();
        return {
          observation: 'missing issue returned an empty open-line set',
          expected: '200 and zero selectable rows',
          database: {},
        };
      },
    ),
    C(
      'refusal.duplicate-source',
      'T04',
      'refusal',
      'TR_APR_ISU.cs:4817-4824 refuses a repeated selected tag with exactly "Duplicate Tag No".',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARDU');
        const answer = await issue.page.evaluate(
          async ({ issueBook, returnBook, year, day, voucherNo, tag, serial }) => {
            const response = await fetch('/api/tour/return', {
              method: 'POST',
              credentials: 'include',
              headers: { 'content-type': 'application/json' },
              body: JSON.stringify({
                coBook: returnBook,
                origBook: issueBook,
                origYear: year,
                origVchNo: voucherNo,
                vchDate: day,
                partyAc: 'E2ELOC',
                empCode: 'E01',
                lines: [
                  { origSrNo: 1, itCode: 'GLD22', tagNo: tag, vchSrno: serial },
                  { origSrNo: 1, itCode: 'GLD22', tagNo: tag, vchSrno: serial },
                ],
              }),
            });
            return { status: response.status, body: await response.json() };
          },
          {
            issueBook: ISSUE_BOOK,
            returnBook: RETURN_BOOK,
            year: YEAR,
            day: DAY,
            voucherNo: issue.voucherNo,
            tag: issue.tag,
            serial: issue.serial,
          },
        );
        assert.equal(answer.status, 400);
        assert.equal(answer.body.message, 'Duplicate Tag No');
        const writes = await ctx.rows(
          `SELECT count(*)::int rows FROM "APR_DETL"
            WHERE tenant_id=$1 AND "CO_BOOK"='TRR' AND "ISU_NO"=$2`,
          issue.voucherNo,
        );
        assert.deepEqual(writes, [{ rows: 0 }]);
        assert.deepEqual(await tagState(ctx, issue.tag), { apr: 'Y', transfer: 'N', balance: 0 });
        return {
          observation: answer.body.message,
          expected: 'Duplicate Tag No and no write',
          database: { writes },
        };
      },
    ),
    C(
      'create.desktop-write-set',
      'T05',
      'mutation',
      "TR_APR_ISU.cs:6412-6421 marks the source ISU_REC='Y', clears BAR APR_ISU/APP_TRFR and Apr_Rtn_Stk writes I/+.",
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARC');
        const returned = await createReturn(ctx, issue);
        const rows = await approvalRows(ctx, RETURN_BOOK, returned.voucherNo);
        const stock = await approvalStock(ctx, RETURN_BOOK, returned.voucherNo);
        assert.deepEqual(
          rows.map((r) => [r.book, r.type, r.inout, r.tag, r.serial, r.fine]),
          [['APR RTN', 'TRR', 'I', issue.tag, issue.serial, 9.16]],
        );
        assert.deepEqual(
          stock.map((r) => [r.book, r.type, r.tr, r.sign]),
          [['APR RTN', 'TRR', 'I', '+']],
        );
        assert.deepEqual(await tagState(ctx, issue.tag), { apr: 'N', transfer: 'N', balance: 1 });
        const source = await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo);
        assert.equal(source[0].received, 'Y');
        await ctx.shot(returned.page, 'created');
        return {
          observation: returned.voucherNo,
          expected: 'APR RTN + I/+ + source closed',
          database: { rows, stock },
          downstream: { source },
        };
      },
    ),
    notApplicable(
      'settlement',
      'T06',
      'TR_APR_ISU and Ac_Stock.Apr_Rtn_Stk write no AC_DATA.',
      'Approval return restores custody only and has no tender branch.',
    ),
    C(
      'reopen.lossless',
      'T07',
      'mutation',
      'TR_APR_ISU.cs:5788-5981 DISPLAY_DATA restores Isu No, party, employee and returned lines.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARO');
        const returned = await createReturn(ctx, issue, 'return reopen');
        await returned.page.getByTestId('approval-return-new').click();
        await reopenApproval(returned.page, 'return', returned.voucherNo);
        const [header] = await ctx.rows(
          `SELECT to_char("VCH_TIME",'HH24:MI:SS') clock FROM "APR_DATA"
            WHERE tenant_id=$1 AND "CO_BOOK"='TRR' AND "VCH_NO"=$2`,
          returned.voucherNo,
        );
        assert.equal(await label(returned.page, 'Vch No').inputValue(), returned.voucherNo);
        assert.equal(await label(returned.page, 'Party Name').inputValue(), 'E2E LOCAL CUSTOMER');
        assert.equal(await label(returned.page, 'Employee Name').inputValue(), 'APPROVAL EMPLOYEE');
        assert.equal(await label(returned.page, 'Vch Time').inputValue(), header.clock);
        assert.equal(
          await label(returned.page, 'Original Issue Vch No').inputValue(),
          issue.voucherNo,
        );
        assert.equal(await label(returned.page, 'TagNo line 1').inputValue(), issue.tag);
        assert.equal(await label(returned.page, 'Vch Desc').inputValue(), 'RETURN REOPEN');
        return {
          observation: `reopened ${returned.voucherNo}`,
          expected: 'source and returned row',
          database: { rows: await approvalRows(ctx, RETURN_BOOK, returned.voucherNo) },
          downstream: { loaded: true },
        };
      },
    ),
    C(
      'edit.unchanged',
      'T08',
      'mutation',
      'An unchanged versioned Approval Rtn save preserves its APR, stock and source rows.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARU');
        const returned = await createReturn(ctx, issue);
        await reopenApproval(returned.page, 'return', returned.voucherNo);
        const before = {
          rows: await approvalRows(ctx, RETURN_BOOK, returned.voucherNo),
          stock: await approvalStock(ctx, RETURN_BOOK, returned.voucherNo),
          source: await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo),
        };
        const response = await saveApproval(returned.page, 'return', 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const after = {
          rows: await approvalRows(ctx, RETURN_BOOK, returned.voucherNo),
          stock: await approvalStock(ctx, RETURN_BOOK, returned.voucherNo),
          source: await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo),
        };
        assert.deepEqual(after, before);
        return {
          observation: 'unchanged return kept rows',
          expected: 'identical footprint',
          database: { before, after },
          downstream: { unchanged: true },
        };
      },
    ),
    C(
      'edit.description',
      'T09',
      'mutation',
      'TR_APR_ISU edit rewrites the same return and reapplies source/BAR effects without DELETE_DATA.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARM');
        const returned = await createReturn(ctx, issue);
        await reopenApproval(returned.page, 'return', returned.voucherNo);
        await label(returned.page, 'Vch Desc').fill('return changed');
        const response = await saveApproval(returned.page, 'return', 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const rows = await approvalRows(ctx, RETURN_BOOK, returned.voucherNo);
        assert.equal(rows[0].description, 'RETURN CHANGED');
        assert.deepEqual(await tagState(ctx, issue.tag), { apr: 'N', transfer: 'N', balance: 1 });
        return {
          observation: 'return description changed',
          expected: 'RETURN CHANGED',
          database: { rows },
          downstream: await tagState(ctx, issue.tag),
        };
      },
    ),
    C(
      'delete.reopens-source',
      'T10',
      'mutation',
      "TR_APR_ISU.cs:6674-6680 restores source ISU_REC='N' and BAR_DETL.APR_ISU='Y' when an APR RTN is deleted.",
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARD');
        const returned = await createReturn(ctx, issue);
        await reopenApproval(returned.page, 'return', returned.voucherNo);
        const confirmed = new Promise((resolve) => {
          returned.page.once('dialog', (dialog) => {
            assert.equal(dialog.message(), 'Are You Sure To Delete This Voucher now?');
            resolve(dialog.message());
          });
        });
        const [response] = await Promise.all([
          returned.page.waitForResponse((r) =>
            isApi(r, 'DELETE', `/tour/return/${returned.voucherNo}`),
          ),
          returned.page.getByTestId('approval-return-delete').click(),
        ]);
        await confirmed;
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(await approvalRows(ctx, RETURN_BOOK, returned.voucherNo), []);
        assert.equal((await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo))[0].received, 'N');
        assert.deepEqual(await tagState(ctx, issue.tag), { apr: 'Y', transfer: 'N', balance: 0 });
        const audit = await ctx.rows(
          `SELECT "DELETE_USER" "user","AC_NAME" account,"FINE_TYPE" type,
                  "VCH_FINE_CR"::float8 fine FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TRR' AND "VCH_NO"=$2`,
          returned.voucherNo,
        );
        assert.deepEqual(audit, [
          { user: USERS.admin.user, account: 'E2E LOCAL CUSTOMER', type: 'G', fine: 10 },
        ]);
        return {
          observation: 'return deleted/source reopened',
          expected: 'pending approval',
          database: { audit },
          downstream: await tagState(ctx, issue.tag),
        };
      },
    ),
    C(
      'rights.print-denied',
      'T11',
      'refusal',
      'TR_APR_ISU.cs:6712-6717 requires the Approval Rtn UserPrint right.',
      async (ctx) => {
        await ensureViewerRight(ctx);
        const issue = await issueFor(ctx, 'ARP');
        const returned = await createReturn(ctx, issue);
        const viewer = await ctx.session(as(USERS.printViewer.user));
        const source = await viewer.page.request.get(
          `/api/tour/${issue.voucherNo}/lines?coBook=TUR`,
        );
        assert.equal(source.status(), 200, await source.text());
        const answer = await viewer.page.request.get(
          `/api/tour/return/${returned.voucherNo}/print?coBook=TRR&format=html`,
        );
        assert.equal(answer.status(), 403);
        assert.equal((await tagState(ctx, issue.tag)).balance, 1);
        return {
          observation: 'view-only user refused return print',
          expected: 403,
          database: { balance: 1 },
        };
      },
    ),
    C(
      'concurrency.stale-edit',
      'T12',
      'refusal',
      'D17 hardening rejects the second editor after a return was changed in another session.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARX');
        const returned = await createReturn(ctx, issue);
        const second = await ctx.session(as(USERS.admin.user, 'approval-return-second'));
        await openApproval(ctx, 'return', second);
        await reopenApproval(returned.page, 'return', returned.voucherNo);
        await reopenApproval(second.page, 'return', returned.voucherNo);
        await label(returned.page, 'Vch Desc').fill('first return wins');
        assert.equal((await saveApproval(returned.page, 'return', 'PUT')).status(), 200);
        await label(second.page, 'Vch Desc').fill('stale return');
        const stale = await saveApproval(second.page, 'return', 'PUT');
        assert.equal(stale.status(), 409, await stale.text());
        return {
          observation: 'second return editor received 409',
          expected: 'voucher-version-conflict',
          database: { rows: await approvalRows(ctx, RETURN_BOOK, returned.voucherNo) },
        };
      },
    ),
    blocked(
      'retry',
      'T13',
      'Approval Rtn POST has no idempotency-key contract; duplicate/lost acknowledgement remains open.',
    ),
    blocked(
      'rollback',
      'T14',
      'The feature harness has no declared mid-write database fault injector (G173/N166).',
    ),
    C(
      'config.lock-date',
      'T15',
      'refusal',
      'TR_APR_ISU.cs:6036-6041 refuses an APR RTN dated on or before the lock date with the desktop text.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARK');
        const page = await prepareReturn(ctx, issue);
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_SET" SET "LOCK_DATE"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          TENANT,
          DAY,
        );
        try {
          const response = await saveApproval(page, 'return');
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
        assert.deepEqual(await tagState(ctx, issue.tag), { apr: 'Y', transfer: 'N', balance: 0 });
        return {
          observation: 'locked return refused',
          expected: 'source remains pending',
          database: await tagState(ctx, issue.tag),
        };
      },
    ),
    C(
      'print.apr-bill',
      'T16',
      'output',
      'TR_APR_ISU.cs:6742,6771-6772 selects AprBill for APR RTN too; AprBill.spec.json binds the same APR tables.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARB');
        const returned = await createReturn(ctx, issue, 'return print');
        await reopenApproval(returned.page, 'return', returned.voucherNo);
        const [popup] = await Promise.all([
          returned.page.waitForEvent('popup'),
          returned.page.getByTestId('approval-return-print').click(),
        ]);
        await popup.waitForLoadState();
        const html = await popup.content();
        await ctx.shot(popup, 'apr-return-bill');
        await popup.close();
        for (const text of [
          'Approval Return',
          'ORIGINAL',
          'Item Name',
          issue.tag,
          'Total :',
          'RETURN PRINT',
          'Party signature.',
        ])
          assert(html.includes(text), `AprBill contains ${text}`);
        return {
          observation: `AprBill ${html.length} bytes`,
          expected: 'APR RTN AprBill layout',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'TR_APR_ISU &Save applies to APR RTN; Alt+S invokes the marked return save.',
      async (ctx) => {
        const issue = await issueFor(ctx, 'ARS');
        const page = await prepareReturn(ctx, issue);
        const [response] = await Promise.all([
          page.waitForResponse((r) => isApi(r, 'POST', '/tour/return')),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        assert.equal((await tagState(ctx, issue.tag)).balance, 1);
        return {
          observation: 'Alt+S returned the tag',
          expected: 'I/+ return',
          database: await tagState(ctx, issue.tag),
          downstream: { returned: true },
        };
      },
    ),
    C(
      'journey.partial-return',
      'T18',
      'mutation',
      'KB_transaction.md:331-357 and TR_APR_ISU.cs:6412-6421: return selected tags and leave the rest pending.',
      async (ctx) => {
        const one = await seedApprovalTag(ctx, 'ARJ');
        const two = await seedApprovalTag(ctx, 'ARJ');
        const { page } = await openApproval(ctx);
        await fillIssue(page, one.tag, 'partial return source');
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        const second = label(page, 'TagNo line 2');
        await second.fill(two.tag);
        await second.locator('xpath=..').getByText(two.tag, { exact: false }).first().waitFor();
        await second.press('Enter');
        const issueResponse = await saveApproval(page);
        assert.equal(issueResponse.status(), 201, await issueResponse.text());
        const issueResult = await issueResponse.json();
        const issue = { voucherNo: String(issueResult.voucherNo), tag: one.tag };
        const returnPage = await prepareReturn(ctx, issue);
        await returnPage.getByRole('button', { name: 'Remove line 2', exact: true }).click();
        const response = await saveApproval(returnPage, 'return');
        assert.equal(response.status(), 201, await response.text());
        assert.deepEqual(await tagState(ctx, one.tag), { apr: 'N', transfer: 'N', balance: 1 });
        assert.deepEqual(await tagState(ctx, two.tag), { apr: 'Y', transfer: 'N', balance: 0 });
        const source = await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo);
        assert.deepEqual(
          source.map((r) => [r.tag, r.received]),
          [
            [one.tag, 'Y'],
            [two.tag, 'N'],
          ],
        );
        return {
          observation: `${one.tag} returned; ${two.tag} pending`,
          expected: 'partial source closure',
          database: { source },
          downstream: {
            returned: await tagState(ctx, one.tag),
            pending: await tagState(ctx, two.tag),
          },
        };
      },
    ),
  ],
};

async function ensureViewerRight(ctx) {
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     SELECT $1::text,'01','01',$2::text,'Sales','Approval Rtn','Y','N','N','N'
      WHERE NOT EXISTS (SELECT 1 FROM "USER_SET" WHERE tenant_id=$1::text AND "USER_NAME"=$2::text AND "MAIN_MENU"='Sales' AND "SUB_MENU"='Approval Rtn')`,
    TENANT,
    USERS.printViewer.user,
  );
}
