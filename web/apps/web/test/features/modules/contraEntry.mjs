import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Transaction → Contra Entry (desktop TR_CONTRA, web /txn/contra).
 *
 * Desktop rules used for the expected values:
 * - The grid's first row is the main account (DR by default, TR_CONTRA.cs:1530-1545); every further row i writes a
 *   PAIR of CONTRA_DATA rows (TR_CONTRA.cs:2760-2866): LDR_TYPE '0' with row i's account and amounts against row 1
 *   (LD_CODE = row 1), and LDR_TYPE '1' with row 1's account and the amounts mirrored against row i.
 * - Contra_Ledr (Ac_Ledr.cs:840-) posts each CONTRA_DATA row as one leg keyed STR(SR_NO)+'01' for a credit and
 *   STR(SR_NO)+'02' for a debit, the counter-account in LD_CODE.
 * - Save refuses unequal totals with "You Cant Save This Voucher Becouse Cr Value and Dr Value is not same...."
 *   (TR_CONTRA.cs:2694); delete asks "Are You Sure To Delete This Voucher now?" (:2959).
 */
const BOOK = 'CON';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `contra.${id}`,
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
const pending = (name, group, reason) => ({
  ...C(`${name}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})),
  blocked: reason,
});

async function openContra(page) {
  await page.goto('/txn/contra');
  await page
    .getByRole('heading', { name: /Contra/ })
    .first()
    .waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
}
async function pickAccount(page, row, code) {
  const picker = page.getByLabel(`Account row ${row}`, { exact: true });
  await picker.fill(code);
  await picker.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await picker.press('Enter');
}
/** Fill grid row `row` (1-based): Dr/Cr, account and amount; adds the row when it does not exist yet. */
async function fillRow(page, row, { crdr, account, amount }) {
  if (!(await page.getByLabel(`Account row ${row}`, { exact: true }).count()))
    await page.getByRole('button', { name: '+ Add line', exact: true }).click();
  await page.getByLabel(`Dr/Cr row ${row}`, { exact: true }).selectOption(crdr);
  await pickAccount(page, row, account);
  await page.getByLabel(`Amount row ${row}`, { exact: true }).fill(String(amount));
}
async function save(page, label = 'Save Contra') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/contra(\/|$)/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.getByRole('button', { name: label, exact: true }).click(),
  ]);
  return response;
}
async function enter(page, rows) {
  await openContra(page);
  for (const [i, row] of rows.entries()) await fillRow(page, i + 1, row);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).vchNo).padStart(5, '0');
}
const contraRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"LDR_TYPE" ldr,"CRDR_TYPE" crdr,"AC_CODE" ac,"LD_CODE" ld,"DR_AMT"::float dr,"CR_AMT"::float cr
       FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const legs = (ctx, vchNo) =>
  ctx.rows(
    `SELECT right("LEDR_KEY",2) code,trim(substr("LEDR_KEY",length("LEDR_KEY")-11,10)) sr,"AC_CODE" ac,"LD_CODE" ld,
            "DR_AMT"::float dr,"CR_AMT"::float cr
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );

export const contraEntry = {
  feature: 'contra',
  title: 'Transaction → Contra Entry (TR_CONTRA)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/contra/page.tsx',
    'web/apps/api/src/modules/finance/contra.ts',
    'web/apps/web/test/features/modules/contraEntry.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'create.two-rows',
      'T05',
      'mutation',
      'TR_CONTRA.cs:2760-2866 and Contra_Ledr: row 1 BANK DR 3,300, row 2 CASH CR 3,300 -> SR 1 CASH CR (LD BANK, leg 01), SR 2 BANK DR (LD CASH, leg 02)',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, [
          { crdr: 'DR', account: 'BANK', amount: 3300 },
          { crdr: 'CR', account: 'CASH', amount: 3300 },
        ]);
        const rows = await contraRows(ctx, vchNo);
        assert.deepEqual(
          rows.map((r) => [r.sr, r.ldr, r.crdr, r.ac, r.ld, r.dr, r.cr]),
          [
            [1, '0', 'CR', 'CASH', 'BANK', 0, 3300],
            [2, '1', 'DR', 'BANK', 'CASH', 3300, 0],
          ],
          JSON.stringify(rows),
        );
        const posted = await legs(ctx, vchNo);
        assert.deepEqual(
          posted.map((r) => [r.sr, r.code, r.ac, r.ld, r.dr, r.cr]),
          [
            ['1', '01', 'CASH', 'BANK', 0, 3300],
            ['2', '02', 'BANK', 'CASH', 3300, 0],
          ],
          JSON.stringify(posted),
        );
        return {
          observation: `voucher ${vchNo}: ${rows.length} CONTRA_DATA rows, ${posted.length} legs`,
          expected: 'the desktop pair of rows and one leg per row',
          database: { rows, legs: posted },
          downstream: { legs: posted.length },
        };
      },
    ),
    C(
      'create.three-rows',
      'T05',
      'mutation',
      'TR_CONTRA multi-row grid: CASH CR 5,000 against BANK DR 3,000 and E2EBANK DR 2,000 -> a pair of rows per counter row',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, [
          { crdr: 'CR', account: 'CASH', amount: 5000 },
          { crdr: 'DR', account: 'BANK', amount: 3000 },
          { crdr: 'DR', account: PARTIES.bank.code, amount: 2000 },
        ]);
        const rows = await contraRows(ctx, vchNo);
        assert.deepEqual(
          rows.map((r) => [r.sr, r.ldr, r.ac, r.ld, r.dr, r.cr]),
          [
            [1, '0', 'BANK', 'CASH', 3000, 0],
            [2, '1', 'CASH', 'BANK', 0, 3000],
            [3, '0', PARTIES.bank.code, 'CASH', 2000, 0],
            [4, '1', 'CASH', PARTIES.bank.code, 0, 2000],
          ],
          JSON.stringify(rows),
        );
        const posted = await legs(ctx, vchNo);
        const cashCredit = posted.filter((r) => r.ac === 'CASH').reduce((sum, r) => sum + r.cr, 0);
        assert.equal(cashCredit, 5000);
        assert.equal(posted.length, 4);
        return {
          observation: `voucher ${vchNo}: ${rows.length} rows, ${posted.length} legs, cash credited ${cashCredit}`,
          expected: 'four rows and four legs; cash credited 5,000',
          database: { rows, legs: posted },
          downstream: { cashCredit },
        };
      },
    ),
    C(
      'refusal.unequal-totals',
      'T04',
      'refusal',
      'TR_CONTRA.cs:2694: unequal Dr and Cr totals are refused with "You Cant Save This Voucher Becouse Cr Value and Dr Value is not same...."',
      async (ctx) => {
        const { page } = await ctx.session();
        const [{ n: before }] = await ctx.rows(
          `SELECT count(*)::int n FROM "CONTRA_DATA" WHERE tenant_id=$1`,
        );
        await openContra(page);
        await fillRow(page, 1, { crdr: 'DR', account: 'BANK', amount: 3000 });
        await fillRow(page, 2, { crdr: 'CR', account: 'CASH', amount: 2500 });
        await page.getByRole('button', { name: 'Save Contra', exact: true }).click();
        await page
          .getByText('Cr Value and Dr Value is not same', { exact: false })
          .first()
          .waitFor();
        const [{ n: after }] = await ctx.rows(
          `SELECT count(*)::int n FROM "CONTRA_DATA" WHERE tenant_id=$1`,
        );
        assert.equal(after, before, 'nothing written');
        return {
          observation: 'refused with the desktop message; nothing written',
          expected: 'the desktop message',
          database: { before, after },
        };
      },
    ),
    C(
      'reopen-edit-delete',
      'T09',
      'mutation',
      'TR_CONTRA: a saved contra reopens with its rows, can be edited, and Delete reverses it',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, [
          { crdr: 'DR', account: 'BANK', amount: 1200 },
          { crdr: 'CR', account: 'CASH', amount: 1200 },
        ]);
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        await page
          .locator('table.grid tr', { hasText: vchNo })
          .last()
          .getByRole('button', { name: 'Load' })
          .click();
        await page.getByRole('button', { name: `Update #${vchNo}`, exact: true }).waitFor();
        assert.equal(await page.getByLabel('Amount row 2', { exact: true }).inputValue(), '1200');
        await page.getByLabel('Amount row 1', { exact: true }).fill('1500');
        await page.getByLabel('Amount row 2', { exact: true }).fill('1500');
        const updated = await save(page, `Update #${vchNo}`);
        assert.equal(updated.status(), 200, await updated.text());
        const edited = await legs(ctx, vchNo);
        assert.deepEqual(
          edited.map((r) => [r.code, r.dr, r.cr]),
          [
            ['01', 0, 1500],
            ['02', 1500, 0],
          ],
        );
        await page.locator('form').getByRole('button', { name: 'Delete', exact: true }).click();
        for (let i = 0; i < 50 && (await legs(ctx, vchNo)).length; i++)
          await page.waitForTimeout(100);
        const remaining = await legs(ctx, vchNo);
        assert.equal(remaining.length, 0);
        return {
          observation: `voucher ${vchNo}: reopened, edited to 1,500, deleted`,
          expected: 'legs follow the edit; delete removes them',
          database: { edited, remaining },
          downstream: { remaining: remaining.length },
        };
      },
    ),
    C(
      'print.contra-voucher',
      'T16',
      'output',
      'TR_CONTRA print: the saved contra prints as a contra voucher',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, [
          { crdr: 'DR', account: 'BANK', amount: 777 },
          { crdr: 'CR', account: 'CASH', amount: 777 },
        ]);
        const response = await page.request.get(
          `/api/contra/${vchNo}/print?coBook=${BOOK}&format=html`,
        );
        const html = await response.text();
        assert.equal(response.status(), 200, html.slice(0, 200));
        assert.ok(html.includes('777'));
        return {
          observation: `contra voucher ${html.length} bytes`,
          expected: 'a contra voucher',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.voucher-number-keys',
      'T17',
      'read-only',
      'TR_CONTRA tVchNo_KeyDown (as TR_SALE.cs:17068-17096): Down and Up step through saved contras, Enter opens the typed number',
      async (ctx) => {
        const { page } = await ctx.session();
        const first = await enter(page, [
          { crdr: 'DR', account: 'BANK', amount: 11 },
          { crdr: 'CR', account: 'CASH', amount: 11 },
        ]);
        const second = await enter(page, [
          { crdr: 'DR', account: 'BANK', amount: 12 },
          { crdr: 'CR', account: 'CASH', amount: 12 },
        ]);
        await openContra(page);
        const box = page.getByLabel('Voucher No', { exact: true });
        const loaded = (vchNo) =>
          page.getByRole('button', { name: `Update #${vchNo}`, exact: true }).waitFor();
        await box.focus();
        await page.keyboard.press('ArrowDown');
        await loaded(second);
        await page.keyboard.press('ArrowDown');
        await loaded(first);
        await page.keyboard.press('ArrowUp');
        await loaded(second);
        return {
          observation: `Down #${second}, Down #${first}, Up #${second}`,
          expected: 'the desktop voucher number keys',
        };
      },
    ),
    pending(
      'branches',
      'T02',
      'Metal (fine) contra rows (IT_TYPE other than A, CR_FINE/DR_FINE) follow.',
    ),
    pending('calculations', 'T03', 'Totals are covered by the unequal-totals refusal.'),
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'TR_CONTRA.cs:1530-1545: the screen opens on the CONTRA book with row 1 DR and row 2 CR',
      async (ctx) => {
        const { page } = await ctx.session();
        await openContra(page);
        const book = await page
          .getByRole('combobox', { name: 'Configured book', exact: true })
          .inputValue();
        const sides = [
          await page.getByLabel('Dr/Cr row 1', { exact: true }).inputValue(),
          await page.getByLabel('Dr/Cr row 2', { exact: true }).inputValue(),
        ];
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        sides.push(await page.getByLabel('Dr/Cr row 3', { exact: true }).inputValue());
        assert.equal(book, BOOK);
        assert.deepEqual(sides, ['DR', 'CR', 'CR']);
        return {
          observation: `book ${book}, rows ${sides.join('/')}`,
          expected: 'CON, DR/CR, and a new row opposite row 1',
        };
      },
    ),
    pending('settlement', 'T06', 'A contra has no tender.'),
    pending('reopen', 'T07', 'Reopen is exercised inside reopen-edit-delete.'),
    pending('unchanged-save', 'T08', 'An unchanged save follows.'),
    pending(
      'delete',
      'T10',
      'Delete is exercised inside reopen-edit-delete; the DELETE_DATA audit follows.',
    ),
    pending('rights', 'T11', 'The catalogue clerk has no contra rights yet.'),
    pending(
      'concurrency',
      'T12',
      'Contra has no version token yet (N51 covers sales and purchases so far).',
    ),
    pending('retry', 'T13', 'Idempotency (N52) is not on the contra route yet.'),
    pending('rollback', 'T14', 'No fault injector in the harness yet (G173 / N166).'),
    pending('settings', 'T15', 'Employee-code mandatory and the lock date follow.'),
    pending('journey', 'T18', 'The cash book and ledger reports are checked in package L6.'),
  ],
};
