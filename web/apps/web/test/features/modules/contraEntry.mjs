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
const DATE_OUTSIDE_YEAR_MESSAGE =
  'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...';
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
  const exact = picker.locator('xpath=..').getByText(code, { exact: true }).first();
  await exact.waitFor();
  await exact.dispatchEvent('mousedown');
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

const counts = async (ctx) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(DISTINCT "VCH_NO") FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int vch,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ac`,
    )
  )[0];
const balance = async (ctx, ac) =>
  (
    await ctx.rows(
      `SELECT round(coalesce(sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)),0)::numeric,2)::float n
         FROM "AC_DATA" WHERE tenant_id=$1 AND btrim("AC_CODE")=$2`,
      ac,
    )
  )[0].n;
const yearOf = async (ctx) =>
  (
    await ctx.rows(
      `SELECT left("OP_DATE"::text,10) op,"CL_DATE"::date::text cl FROM "YEAR_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "OP_DATE" DESC LIMIT 1`,
    )
  )[0];
const shift = (iso, days) => {
  const d = new Date(`${iso}T00:00:00Z`);
  d.setUTCDate(d.getUTCDate() + days);
  return d.toISOString().slice(0, 10);
};
const dmy = (iso) => iso.split('-').reverse().join('/');
const recentRow = async (page, vchNo) => {
  const toggle = page.getByRole('button', { name: '▸ Recent vouchers', exact: true });
  if (await toggle.isVisible().catch(() => false)) await toggle.click();
  const cell = page.getByRole('cell', { name: vchNo, exact: true }).last();
  await cell.waitFor();
  return cell.locator('xpath=..');
};
const loadFromList = async (page, vchNo) => {
  const row = await recentRow(page, vchNo);
  await row.getByRole('button', { name: 'Load' }).click();
  await page.getByRole('button', { name: `Update #${vchNo}`, exact: true }).waitFor();
};
const deleteLoaded = async (page, vchNo) => {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        new URL(r.url()).pathname === `/api/contra/${vchNo}` && r.request().method() === 'DELETE',
    ),
    page.locator('form').getByRole('button', { name: 'Delete', exact: true }).click(),
  ]);
  return response;
};
const deleteFromList = async (page, vchNo) => {
  const row = await recentRow(page, vchNo);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        new URL(r.url()).pathname === `/api/contra/${vchNo}` && r.request().method() === 'DELETE',
    ),
    row.getByRole('button', { name: 'Delete', exact: true }).click(),
  ]);
  return response;
};
/** Clicks Save and reports the response, or null when the screen sent nothing within 4 s. */
const trySave = async (page) => {
  const response = page
    .waitForResponse(
      (r) =>
        /\/api\/contra(\/|$)/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
      { timeout: 4000 },
    )
    .catch(() => null);
  const button = page.getByRole('button', { name: 'Save Contra', exact: true });
  if (await button.isEnabled()) await button.click();
  return response;
};
const DEPOSIT = [
  { crdr: 'DR', account: 'BANK', amount: 12345.67 },
  { crdr: 'CR', account: 'CASH', amount: 12345.67 },
];

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
    C(
      'create.withdrawal',
      'T02',
      'mutation',
      'The other direction: cash withdrawn from the bank, row 1 CASH DR 2,000 and row 2 BANK CR 2,000, posts Dr CASH and Cr BANK',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, [
          { crdr: 'DR', account: 'CASH', amount: 2000 },
          { crdr: 'CR', account: 'BANK', amount: 2000 },
        ]);
        const posted = await legs(ctx, vchNo);
        assert.deepEqual(posted.map((r) => [r.ac.trim(), r.dr, r.cr]).sort(), [
          ['BANK', 0, 2000],
          ['CASH', 2000, 0],
        ]);
        return {
          observation: `voucher ${vchNo}: ${JSON.stringify(posted.map((r) => [r.ac, r.dr, r.cr]))}`,
          expected: 'Dr CASH 2,000, Cr BANK 2,000',
          database: { legs: posted },
          downstream: { legs: posted.length },
        };
      },
    ),
    C(
      'formula.totals',
      'T03',
      'read-only',
      'TR_CONTRA.cs:2692: the grid totals both sides (Dr 5,000 · Cr 4,000 is unbalanced); amounts keep their paise (Conversion.Val, :2797)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openContra(page);
        await fillRow(page, 1, { crdr: 'DR', account: 'BANK', amount: 5000 });
        await fillRow(page, 2, { crdr: 'CR', account: 'CASH', amount: 4000 });
        const footer = (await page.locator('tfoot').innerText()).replace(/\s+/g, ' ').trim();
        await page.getByText('Dr must equal Cr', { exact: true }).waitFor();
        await page.getByLabel('Amount row 2', { exact: true }).fill('5000.25');
        await page.getByLabel('Amount row 1', { exact: true }).fill('5000.25');
        await page.getByText('Balanced ✓', { exact: true }).waitFor();
        const balanced = (await page.locator('tfoot').innerText()).replace(/\s+/g, ' ').trim();
        assert.match(footer, /Dr 5,000 · Cr 4,000/);
        assert.match(balanced, /Dr 5,000\.25 · Cr 5,000\.25/);
        return {
          observation: `${footer}; then ${balanced}`,
          expected: 'Dr 5,000 · Cr 4,000 unbalanced; Dr 5,000.25 · Cr 5,000.25 balanced',
        };
      },
    ),
    C(
      'refusal.date-outside-year',
      'T06',
      'refusal',
      'TR_CONTRA.cs:2681-2682: a contra dated the day before the year opens is refused ("Voucher Date Not In Current Year"), and nothing is written',
      async (ctx) => {
        const { page } = await ctx.session();
        const { op } = await yearOf(ctx);
        const before = await counts(ctx);
        await openContra(page);
        await page.getByLabel('Voucher date', { exact: true }).fill(shift(op, -1));
        await fillRow(page, 1, { crdr: 'DR', account: 'BANK', amount: 700 });
        await fillRow(page, 2, { crdr: 'CR', account: 'CASH', amount: 700 });
        const response = await trySave(page);
        assert(response, 'the screen did not send the out-of-year contra to the server');
        const body = await response.text();
        assert.equal(response.status(), 400, body);
        assert.match(
          body,
          new RegExp(DATE_OUTSIDE_YEAR_MESSAGE.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')),
        );
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `dated ${shift(op, -1)} (year opens ${op}): 400 ${DATE_OUTSIDE_YEAR_MESSAGE}`,
          expected: { status: 400, message: DATE_OUTSIDE_YEAR_MESSAGE, written: 0 },
          database: { before },
        };
      },
      {
        expected: { status: 400, message: DATE_OUTSIDE_YEAR_MESSAGE, written: 0 },
        observe: async (ctx) => ({ year: await yearOf(ctx), counts: await counts(ctx) }),
      },
    ),
    C(
      'create.first-day-of-year',
      'T04',
      'mutation',
      'TR_CONTRA.cs:2681 allows the opening date itself: a contra dated the first day of the year saves with that date on every leg',
      async (ctx) => {
        const { page } = await ctx.session();
        const { op } = await yearOf(ctx);
        await openContra(page);
        await page.getByLabel('Voucher date', { exact: true }).fill(op);
        await fillRow(page, 1, { crdr: 'DR', account: 'BANK', amount: 650 });
        await fillRow(page, 2, { crdr: 'CR', account: 'CASH', amount: 650 });
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const dates = await ctx.rows(
          `SELECT DISTINCT "VCH_DATE"::date::text d FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.deepEqual(
          dates.map((r) => r.d),
          [op],
        );
        return {
          observation: `voucher ${vchNo} dated ${op}`,
          expected: { date: op },
          database: { dates },
          downstream: { dated: op },
        };
      },
    ),
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
    C(
      'reopen.recent-list-total',
      'T07',
      'read-only',
      'TR_CONTRA.cs:3144: the voucher list shows each contra with its amount; the recent list shows 12,345.67, not 0',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, DEPOSIT);
        const row = await recentRow(page, vchNo);
        const total = (await row.locator('td').nth(3).innerText()).trim();
        assert.equal(total, '12,345.67', `the recent list shows Total ${total}`);
        return { observation: `recent list ${vchNo}: total ${total}`, expected: '12,345.67' };
      },
      { expected: { total: '12,345.67' }, observe: async (ctx) => ({ counts: await counts(ctx) }) },
    ),
    C(
      'edit.unchanged-save',
      'T08',
      'mutation',
      'An unchanged save of a reopened contra keeps its number, hidden number, date and legs',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, DEPOSIT);
        const snapshot = () =>
          ctx.rows(
            `SELECT "SR_NO"::int sr,"AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr,"HD_VCH_NO" hd,"VCH_DATE"::date::text d
               FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
            vchNo,
          );
        const before = await snapshot();
        const legsBefore = await legs(ctx, vchNo);
        await loadFromList(page, vchNo);
        const response = await save(page, `Update #${vchNo}`);
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(await snapshot(), before);
        assert.deepEqual(await legs(ctx, vchNo), legsBefore);
        return {
          observation: `voucher ${vchNo}: unchanged save kept ${before.length} rows and ${legsBefore.length} legs`,
          expected: 'nothing changes',
          database: { before },
          downstream: { legs: legsBefore.length },
        };
      },
    ),
    C(
      'delete.audit',
      'T10',
      'mutation',
      'TR_CONTRA.cs:2957-2969: delete removes the rows and legs and restores the balances; DELETE_DATA gets one row per CONTRA_DATA row (INSERT … SELECT FROM CONTRA_DATA, :2961), each naming the user',
      async (ctx) => {
        const { page } = await ctx.session();
        const cash0 = await balance(ctx, 'CASH');
        const vchNo = await enter(page, DEPOSIT);
        const removed = await deleteFromList(page, vchNo);
        assert.equal(removed.status(), 200, await removed.text());
        assert.deepEqual([await contraRows(ctx, vchNo), await legs(ctx, vchNo)], [[], []]);
        assert.equal(Math.round(((await balance(ctx, 'CASH')) - cash0) * 100) / 100, 0);
        const audit = await ctx.rows(
          `SELECT "SR_NO"::int sr,btrim("DELETE_USER"::text) du FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
          vchNo,
        );
        assert.deepEqual(
          audit.map((a) => [a.sr, a.du]),
          [
            [1, USERS.admin.user],
            [2, USERS.admin.user],
          ],
        );
        return {
          observation: `voucher ${vchNo} deleted; DELETE_USER ${audit[0]?.du}`,
          expected: { remaining: 0, deleteUser: USERS.admin.user },
          database: { audit },
          downstream: { remaining: 0 },
        };
      },
    ),
    C(
      'rights.voucher-list-needs-contra-view',
      'T11',
      'refusal',
      'N207: the recent-voucher list reads a book only for a user who may open its menu (TR_CONTRA.cs:3136-3146; MDI_FORM.cs:8100-8111).',
      async (ctx) => {
        const clerk = await ctx.session(as(USERS.clerk.user));
        await clerk.page.goto('/txn/sales');
        const answer = await clerk.page.evaluate(async () => {
          const r = await fetch('/api/vouchers/recent?table=CONTRA_DATA&book=CON', {
            credentials: 'include',
          });
          return { status: r.status, body: await r.text() };
        });
        assert.equal(answer.status, 403, answer.body);
        const { page } = await ctx.session();
        await openContra(page);
        const admin = await page.evaluate(async () => {
          const r = await fetch('/api/vouchers/recent?table=CONTRA_DATA&book=CON', {
            credentials: 'include',
          });
          return r.status;
        });
        assert.equal(admin, 200);
        return {
          observation: `Sales-only clerk ${answer.status}, admin ${admin}`,
          expected: '403 for a user without Contra rights, 200 for the admin',
          database: { unchanged: true },
        };
      },
    ),
    C(
      'rights.print-denied',
      'T11',
      'refusal',
      'TR_CONTRA.cs:3000-3004: a user who may view Contra Entry but has no UserPrint is refused the ContraBill print.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, [
          { crdr: 'DR', account: 'BANK', amount: 31 },
          { crdr: 'CR', account: 'CASH', amount: 31 },
        ]);
        const before = await contraRows(ctx, vchNo);
        const viewer = await ctx.session(as(USERS.printViewer.user));
        await openContra(viewer.page);
        const response = await viewer.page.request.get(
          `/api/contra/${vchNo}/print?coBook=${BOOK}&format=html`,
        );
        const body = await response.text();
        assert.equal(response.status(), 403, body.slice(0, 200));
        assert.match(body, /"action":"print"/);
        const after = await contraRows(ctx, vchNo);
        assert.deepEqual(after, before);
        return {
          observation: `view-allowed user refused the print of contra ${vchNo}`,
          expected: '403 print and no change',
          database: { before, after },
        };
      },
    ),
    C(
      'rights.fine-jv-book-refused',
      'T11',
      'refusal',
      "MDI_FORM.cs:8100-8111 opens Contra Entry only on CurBookHelp('CONTRA'); a Fine JV voucher in the shared CONTRA_DATA table may not be read, printed or deleted through the Contra routes.",
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/txn/fine-jv');
        await page.getByRole('heading', { name: 'Fine Jv Entry', exact: true }).waitFor();
        const created = await page.evaluate(async () => {
          const response = await fetch('/api/fine-jv', {
            method: 'POST',
            credentials: 'include',
            headers: { 'content-type': 'application/json' },
            body: JSON.stringify({
              coBook: 'FJV',
              metal: 'G',
              lines: [
                { crdr: 'DR', acCode: 'E2ELOC', fine: 1.5 },
                { crdr: 'CR', acCode: 'E2EINT', fine: 1.5 },
              ],
            }),
          });
          return { status: response.status, body: await response.text() };
        });
        assert.equal(created.status, 201, created.body);
        const fineNo = String(JSON.parse(created.body).vchNo).padStart(5, '0');
        const fineRows = () =>
          ctx.rows(
            `SELECT "SR_NO"::int sr,"AC_CODE" ac,coalesce("CR_FINE",0)::float cr,coalesce("DR_FINE",0)::float dr
               FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='FJV' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
            fineNo,
          );
        const before = await fineRows();
        const answers = [];
        for (const [method, url] of [
          ['GET', `/api/contra/${fineNo}?coBook=FJV`],
          ['GET', `/api/contra/${fineNo}/print?coBook=FJV&format=html`],
          ['DELETE', `/api/contra/${fineNo}?coBook=FJV`],
        ]) {
          const answer = await page.evaluate(
            async ({ m, u }) => {
              const response = await fetch(u, { method: m, credentials: 'include' });
              return { status: response.status, body: await response.text() };
            },
            { m: method, u: url },
          );
          assert.equal(answer.status, 400, `${method} ${url} => ${answer.body}`);
          assert.match(answer.body, /MAIN_BOOK='CONTRA'/);
          answers.push([method, url, answer.status]);
        }
        const after = await fineRows();
        assert.deepEqual(after, before);
        return {
          observation: `Contra read, print and delete refused Fine JV ${fineNo}: ${JSON.stringify(answers)}`,
          expected: "400 MAIN_BOOK='CONTRA' and the Fine JV rows unchanged",
          database: { before, after },
        };
      },
    ),
    C(
      'rights.clerk-no-contra',
      'T11',
      'refusal',
      'USER_SET grants the clerk Sales Invoice only ("You Have No Rights", TR_CONTRA.cs:2700): the clerk cannot save a contra',
      async (ctx) => {
        const clerk = await ctx.session(as(USERS.clerk.user));
        const before = await counts(ctx);
        await clerk.page.goto('/txn/contra');
        await clerk.page.waitForTimeout(1500);
        let status = null;
        if (
          await clerk.page
            .getByLabel('Account row 1', { exact: true })
            .isVisible()
            .catch(() => false)
        ) {
          await fillRow(clerk.page, 1, DEPOSIT[0]).catch(() => {});
          await fillRow(clerk.page, 2, DEPOSIT[1]).catch(() => {});
          status = (await trySave(clerk.page).catch(() => null))?.status() ?? null;
          assert.notEqual(status, 201);
        }
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `clerk save answered ${status ?? 'nothing'}`,
          expected: 'no write',
          database: { before },
        };
      },
    ),
    C(
      'concurrency.double-delete',
      'T12',
      'refusal',
      'Two operators delete the same contra: the second is refused and the cash is restored once',
      async (ctx) => {
        const first = await ctx.session(as(USERS.admin.user, 'operator-1'));
        const vchNo = await enter(first.page, DEPOSIT);
        const second = await ctx.session(as(USERS.admin.user, 'operator-2'));
        await openContra(second.page);
        await loadFromList(second.page, vchNo);
        await loadFromList(first.page, vchNo);
        const before = await balance(ctx, 'CASH');
        const one = (await deleteLoaded(first.page, vchNo)).status();
        const two = (await deleteLoaded(second.page, vchNo)).status();
        const after = await balance(ctx, 'CASH');
        assert.equal(one, 200);
        assert(two >= 400 && two < 500, `second delete answered ${two}`);
        assert.equal(Math.round((after - before) * 100) / 100, 12345.67);
        return {
          observation: `first delete ${one}, second ${two}; cash ${before} → ${after}`,
          expected: 'second refused; cash restored once',
          database: { before, after },
        };
      },
    ),
    C(
      'retry.double-click',
      'T13',
      'mutation',
      'A double-click on Save creates one contra',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openContra(page);
        for (const [i, row] of DEPOSIT.entries()) await fillRow(page, i + 1, row);
        await page.getByRole('button', { name: 'Save Contra', exact: true }).dblclick();
        await page.waitForTimeout(2500);
        const after = await counts(ctx);
        assert.equal(after.vch - before.vch, 1);
        return {
          observation: `${after.vch - before.vch} contra created`,
          expected: 1,
          database: { before, after },
          downstream: { created: after.vch - before.vch },
        };
      },
    ),
    C(
      'rollback.ledger-write-fault',
      'T14',
      'refusal',
      'A fault on the ledger write, after the CONTRA_DATA rows are written, rolls the whole contra back: no CONTRA_DATA or AC_DATA rows',
      async (ctx) => {
        const { page } = await ctx.session();
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_contra_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN
             IF NEW."CO_BOOK" = '${BOOK}' AND (NEW."DR_AMT" = 777.77 OR NEW."CR_AMT" = 777.77) THEN RAISE EXCEPTION 'e2e contra fault'; END IF;
             RETURN NEW;
           END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_contra_fault BEFORE INSERT ON "AC_DATA" FOR EACH ROW EXECUTE FUNCTION e2e_contra_fault()`,
        );
        try {
          const before = await counts(ctx);
          await openContra(page);
          await fillRow(page, 1, { crdr: 'DR', account: 'BANK', amount: 777.77 });
          await fillRow(page, 2, { crdr: 'CR', account: 'CASH', amount: 777.77 });
          const response = await save(page);
          assert.ok(response.status() >= 400, `the save failed: ${response.status()}`);
          assert.deepEqual(await counts(ctx), before);
          return {
            observation: `the save answered ${response.status()}; the counts are unchanged`,
            expected: 'no contra rows',
            database: { before, after: await counts(ctx) },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS e2e_contra_fault ON "AC_DATA"`);
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_contra_fault()`);
        }
      },
    ),
    C(
      'settings.lock-date',
      'T15',
      'refusal',
      'TR_CONTRA.cs:2686-2691: a contra dated on or before CO_SET.LOCK_DATE is refused with the lock-date text after the year check passes; the setting is set for this case and cleared',
      async (ctx) => {
        const { page } = await ctx.session();
        const { op } = await yearOf(ctx);
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          'feature-e2e',
          op,
        );
        try {
          const before = await counts(ctx);
          await openContra(page);
          await page.getByLabel('Voucher date', { exact: true }).fill(op);
          await fillRow(page, 1, { crdr: 'DR', account: 'BANK', amount: 710 });
          await fillRow(page, 2, { crdr: 'CR', account: 'CASH', amount: 710 });
          const response = await trySave(page);
          assert(response, 'the screen did not send the locked-date contra to the server');
          const body = await response.text();
          assert.equal(response.status(), 400, body);
          assert.match(body, new RegExp(`Lock Date is = ${dmy(op)} \\.\\.\\.\\.`), body);
          assert.deepEqual(await counts(ctx), before);
          return {
            observation: `dated ${op} (the lock date): 400 with the lock-date text`,
            expected: { status: 400, lockDate: dmy(op), written: 0 },
            database: { before, after: await counts(ctx) },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            'feature-e2e',
          );
        }
      },
    ),
    C(
      'report.contra-register',
      'T16',
      'read-only',
      'The Contra Register lists the saved contra with its date as dd/MM/yyyy (D19), the from and to accounts and the amount',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, DEPOSIT);
        const [{ d }] = await ctx.rows(
          `SELECT DISTINCT "VCH_DATE"::date::text d FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        await page.goto('/reports/contra-register');
        await page.getByRole('button', { name: 'Run', exact: true }).click();
        const row = page.locator('table.grid tr', { hasText: `${BOOK}/${vchNo}` }).first();
        await row.waitFor({ timeout: 8000 });
        const text = (await row.innerText()).replace(/\s+/g, ' ').trim();
        assert(
          text.startsWith(dmy(d)),
          `the register shows the date as ${text.split(' ')[0]}, not ${dmy(d)}`,
        );
        assert.match(text, /CASH ON HAND/);
        assert.match(text, /BANK A\/C/);
        assert.match(text, /12,?345\.67/);
        return {
          observation: `register row: ${text}`,
          expected: `${dmy(d)} ${BOOK}/${vchNo} CASH ON HAND → BANK A/C 12,345.67`,
        };
      },
      { expected: { date: 'dd/MM/yyyy', amount: 12345.67 } },
    ),
    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'The desktop &Save mnemonic: Alt+S saves the contra',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openContra(page);
        for (const [i, row] of DEPOSIT.entries()) await fillRow(page, i + 1, row);
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => new URL(r.url()).pathname === '/api/contra' && r.request().method() === 'POST',
          ),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        const after = await counts(ctx);
        return {
          observation: 'Alt+S saved the contra',
          expected: 'save',
          database: { before, after },
          downstream: { created: after.vch - before.vch },
        };
      },
    ),
    C(
      'journey.deposit-then-withdraw',
      'T18',
      'mutation',
      'Deposit 12,345.67 into the bank, then withdraw 2,345.67: the bank ends 10,000 up and the cash 10,000 down',
      async (ctx) => {
        const { page } = await ctx.session();
        const [cash0, bank0] = [await balance(ctx, 'CASH'), await balance(ctx, 'BANK')];
        const deposit = await enter(page, DEPOSIT);
        const withdrawal = await enter(page, [
          { crdr: 'DR', account: 'CASH', amount: 2345.67 },
          { crdr: 'CR', account: 'BANK', amount: 2345.67 },
        ]);
        const [cash1, bank1] = [await balance(ctx, 'CASH'), await balance(ctx, 'BANK')];
        const delta = (a, b) => Math.round((a - b) * 100) / 100;
        const back = (await legs(ctx, withdrawal)).map((r) => [r.ac.trim(), r.dr, r.cr]).sort();
        assert.deepEqual(
          back,
          [
            ['BANK', 0, 2345.67],
            ['CASH', 2345.67, 0],
          ],
          `withdrawal legs ${JSON.stringify(back)}`,
        );
        assert.deepEqual([delta(bank1, bank0), delta(cash1, cash0)], [10000, -10000]);
        return {
          observation: `deposit ${deposit}, withdrawal ${withdrawal}: bank Δ ${delta(bank1, bank0)}, cash Δ ${delta(cash1, cash0)}`,
          expected: { bankDelta: 10000, cashDelta: -10000 },
          database: { cash0, cash1, bank0, bank1 },
          downstream: { bankDelta: delta(bank1, bank0) },
        };
      },
    ),
  ],
};
