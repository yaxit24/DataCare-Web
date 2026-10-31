import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Transaction → Cash Received, Cash Payment, Bank Received and Bank Payment (desktop TR_CASH; web
 * /txn/receipt and /txn/payment, `?mode=BANK` for the bank menus).
 *
 * Desktop rules used for the expected values:
 * - The menu fixes the book family before the form opens (MDI_FORM.cs:8052-8099): CASH REC, BANK REC, CASH PAY,
 *   BANK PAY. A web-provisioned company has the generic RECEIPT (RCT) and PAYMENT (PAY) books.
 * - Cash_Ledr (Ac_Ledr.cs:565-585) posts each CASH_DATA row as legs keyed STR(SR_NO)+code: receipt 01 party CR
 *   REC_AMT against the book's slot 1 (cash), 02 cash DR REC_AMT; kasar 03 party CR KASAR_AMT against slot 2
 *   (kasar), 04 kasar DR KASAR_AMT. Payment 05 party DR, 06 cash CR, 07 party DR kasar, 08 kasar CR kasar.
 * - Save refusals (TR_CASH.cs:2903-2955): employee code when mandatory, the cash-received limit, company type B,
 *   a date outside the year, the lock date, edit rights and a missing voucher number, each with its message.
 */
const RECEIPT_BOOK = 'RCT';
const PAYMENT_BOOK = 'PAY';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `cash-bank.${id}`,
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

async function openForm(page, path) {
  await page.goto(path);
  await page.getByLabel('Party account', { exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
  return book;
}
async function pickParty(page, code) {
  const party = page.getByLabel('Party account', { exact: true });
  await party.fill(code);
  await party.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await party.press('Enter');
}
async function save(page, label) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/(receipts|payments)(\/|$)/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.getByRole('button', { name: label, exact: true }).click(),
  ]);
  return response;
}
/** A receipt or payment through the screen; returns its voucher number (5 digits). */
async function enter(page, { path, party, amount, kasar, label }) {
  await openForm(page, path);
  await pickParty(page, party);
  await page.getByLabel('Amount', { exact: true }).fill(String(amount));
  if (kasar) await page.getByLabel('Kasar ₹ (write-off)', { exact: true }).fill(String(kasar));
  const response = await save(page, label);
  assert.equal(response.status(), 201, await response.text());
  const vchNo = String((await response.json()).vchNo).padStart(5, '0');
  await page.getByText(`Saved — Voucher #${Number(vchNo)}`, { exact: false }).waitFor();
  return vchNo;
}
const legs = (ctx, book, vchNo) =>
  ctx.rows(
    `SELECT right("LEDR_KEY",2) code,"AC_CODE" ac,"LD_CODE" ld,"DR_AMT"::float dr,"CR_AMT"::float cr
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${book}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );
const partyBalance = async (ctx, ac) =>
  (
    await ctx.rows(
      `SELECT coalesce(sum("DR_AMT"),0)::float - coalesce(sum("CR_AMT"),0)::float bal FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
      ac,
    )
  )[0].bal;

export const cashBank = {
  feature: 'cash-bank',
  title: 'Transaction → Cash and Bank Received and Payment (TR_CASH)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/components/PaymentForm.tsx',
    'web/apps/api/src/modules/finance/finance.ts',
    'web/apps/web/test/features/modules/cashBank.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'catalogue defaults; the cash-limit case restores CASH_LIMIT',
  },
  cases: [
    C(
      'entry.menu-modes',
      'T01',
      'read-only',
      'MDI_FORM.cs:8052-8099: Cash Received/Payment open in cash mode, Bank Received/Payment (?mode=BANK) in bank mode',
      async (ctx) => {
        const { page } = await ctx.session();
        const seen = {};
        for (const path of [
          '/txn/receipt',
          '/txn/receipt?mode=BANK',
          '/txn/payment',
          '/txn/payment?mode=BANK',
        ]) {
          await openForm(page, path);
          seen[path] = await page.getByLabel('Mode', { exact: true }).inputValue();
        }
        assert.deepEqual(seen, {
          '/txn/receipt': 'cash',
          '/txn/receipt?mode=BANK': 'bank',
          '/txn/payment': 'cash',
          '/txn/payment?mode=BANK': 'bank',
        });
        return { observation: JSON.stringify(seen), expected: 'cash, bank, cash, bank' };
      },
    ),
    C(
      'create.cash-receipt-with-kasar',
      'T05',
      'mutation',
      'Cash_Ledr (Ac_Ledr.cs:565-585): 01 party CR / 02 cash DR the amount; 03 party CR / 04 kasar DR the kasar',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await partyBalance(ctx, PARTIES.local.code);
        const vchNo = await enter(page, {
          path: '/txn/receipt',
          party: PARTIES.local.code,
          amount: 5000,
          kasar: 50,
          label: 'Save Receipt',
        });
        const rows = await legs(ctx, RECEIPT_BOOK, vchNo);
        const shape = rows.map((r) => [r.code, r.ac, r.dr, r.cr]);
        assert.deepEqual(shape, [
          ['01', PARTIES.local.code, 0, 5000],
          ['02', 'CASH', 5000, 0],
          ['03', PARTIES.local.code, 0, 50],
          ['04', 'KASAR', 50, 0],
        ]);
        const after = await partyBalance(ctx, PARTIES.local.code);
        assert.equal(Math.round((before - after) * 100) / 100, 5050, 'the party owes 5,050 less');
        return {
          observation: `voucher ${vchNo}: ${JSON.stringify(shape)}`,
          expected: 'legs 01-04 as Cash_Ledr; party balance down 5,050',
          database: { legs: rows },
          downstream: { partyBalanceBefore: before, partyBalanceAfter: after },
        };
      },
    ),
    C(
      'create.cash-payment',
      'T05',
      'mutation',
      'Cash_Ledr (Ac_Ledr.cs:565-585): 05 party DR / 06 cash CR the amount',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, {
          path: '/txn/payment',
          party: PARTIES.local.code,
          amount: 3000,
          label: 'Save Payment',
        });
        const rows = await legs(ctx, PAYMENT_BOOK, vchNo);
        const shape = rows.map((r) => [r.code, r.ac, r.dr, r.cr]);
        assert.deepEqual(shape, [
          ['05', PARTIES.local.code, 3000, 0],
          ['06', 'CASH', 0, 3000],
        ]);
        return {
          observation: `voucher ${vchNo}: ${JSON.stringify(shape)}`,
          expected: 'legs 05-06 as Cash_Ledr',
          database: { legs: rows },
          downstream: { legs: shape.length },
        };
      },
    ),
    C(
      'reopen-edit-delete.receipt',
      'T09',
      'mutation',
      'TR_CASH: a saved receipt reopens, its amount can be changed and saved, and Delete ("Are You Sure To Delete This Voucher now?", :3215) reverses it',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await enter(page, {
          path: '/txn/receipt',
          party: PARTIES.interState.code,
          amount: 1200,
          label: 'Save Receipt',
        });
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        await page
          .locator('table.grid tr', { hasText: vchNo })
          .last()
          .getByRole('button', { name: 'Load' })
          .click();
        const amount = page.getByLabel('Amount', { exact: true });
        await page.waitForFunction(
          () => document.querySelector('input[aria-label="Amount"]')?.value === '1200',
        );
        await amount.fill('1500');
        const updated = await save(page, `Update #${vchNo}`);
        assert.equal(updated.status(), 200, await updated.text());
        const edited = await legs(ctx, RECEIPT_BOOK, vchNo);
        assert.deepEqual(
          edited.map((r) => [r.code, r.dr, r.cr]),
          [
            ['01', 0, 1500],
            ['02', 1500, 0],
          ],
        );
        // The harness accepts the desktop's confirm dialog (harness.mjs).
        await page.locator('form').getByRole('button', { name: 'Delete', exact: true }).click();
        for (let i = 0; i < 50 && (await legs(ctx, RECEIPT_BOOK, vchNo)).length; i++)
          await page.waitForTimeout(100);
        const remaining = await legs(ctx, RECEIPT_BOOK, vchNo);
        assert.equal(remaining.length, 0, 'the ledger legs are reversed');
        return {
          observation: `voucher ${vchNo}: edited to 1,500 then deleted (${remaining.length} legs left)`,
          expected: 'edit moves both legs to 1,500; delete removes them',
          database: { edited, remaining },
          downstream: { remaining: remaining.length },
        };
      },
    ),
    C(
      'refusal.cash-limit',
      'T04',
      'refusal',
      'TR_CASH.cs:2913-2922: with CASH_LIMIT set, cash received from a party beyond the limit is refused with the desktop message',
      async (ctx) => {
        const { page } = await ctx.session();
        const party = PARTIES.interState;
        const prior = (
          await ctx.rows(
            `SELECT coalesce(sum("CR_AMT"),0)::float v FROM "AC_DATA" a WHERE tenant_id=$1 AND "AC_CODE"=$2 AND "LD_CODE"='CASH'`,
            party.code,
          )
        )[0].v;
        const limit = prior + 10000;
        const setLimit = async (value) => {
          await page.goto('/settings');
          await page.getByRole('heading', { name: 'Company Settings', exact: true }).waitFor();
          const control = page.locator('[id="CO_SET.CASH_LIMIT"]');
          const tabs = page.getByRole('tab');
          for (let i = 0; i < (await tabs.count()) && !(await control.count()); i++)
            await tabs.nth(i).click();
          await control.fill(value);
          const [saved] = await Promise.all([
            page.waitForResponse(
              (r) =>
                new URL(r.url()).pathname === '/api/settings' && r.request().method() === 'POST',
            ),
            page.getByRole('button', { name: /^Save \d+ change\(s\)$/ }).click(),
          ]);
          assert.equal(saved.status(), 200, await saved.text());
        };
        await setLimit(String(limit));
        try {
          await openForm(page, '/txn/receipt');
          await pickParty(page, party.code);
          await page.getByLabel('Amount', { exact: true }).fill('10500');
          const before = await ctx.rows(
            `SELECT count(*)::int n FROM "CASH_DATA" WHERE tenant_id=$1`,
          );
          const refused = await save(page, 'Save Receipt');
          assert.equal(refused.status(), 400, await refused.text());
          const message = await page.locator('.msg.err').innerText();
          assert.match(message, /Cash Recieved Limit Amount = /);
          assert.match(message, /You Can Not Receive More Then Cash Limit/);
          const after = await ctx.rows(
            `SELECT count(*)::int n FROM "CASH_DATA" WHERE tenant_id=$1`,
          );
          assert.equal(after[0].n, before[0].n, 'nothing written');
          return {
            observation: `refused: ${message.slice(0, 160)}`,
            expected: 'the desktop cash-limit message; nothing written',
            database: { cashRowsBefore: before[0].n, cashRowsAfter: after[0].n },
          };
        } finally {
          await setLimit('');
        }
      },
    ),
    C(
      'print.receipt-voucher',
      'T16',
      'output',
      'TR_CASH print: the saved receipt prints as a receipt voucher with its amount',
      async (ctx) => {
        const { page } = await ctx.session();
        await enter(page, {
          path: '/txn/receipt',
          party: PARTIES.local.code,
          amount: 777,
          label: 'Save Receipt',
        });
        const documentRequest = page
          .context()
          .waitForEvent('request', (r) => /\/api\/finance\/receipt-voucher\?/.test(r.url()), {
            timeout: 15_000,
          });
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByRole('button', { name: 'View Receipt Voucher', exact: true }).click(),
        ]);
        const response = await page.request.get((await documentRequest).url());
        const html = await response.text();
        await popup.close();
        assert.equal(response.status(), 200, html.slice(0, 200));
        assert.ok(html.includes('777'), 'the voucher shows its amount');
        return {
          observation: `receipt voucher ${html.length} bytes`,
          expected: 'a receipt voucher',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.voucher-number-keys',
      'T17',
      'read-only',
      'TR_CASH tVchNo_KeyDown (as TR_SALE.cs:17068-17096): Down and Up step to the previous and next saved voucher, Enter opens the typed number and moves to the date',
      async (ctx) => {
        const { page } = await ctx.session();
        const first = await enter(page, {
          path: '/txn/receipt',
          party: PARTIES.local.code,
          amount: 101,
          label: 'Save Receipt',
        });
        const second = await enter(page, {
          path: '/txn/receipt',
          party: PARTIES.local.code,
          amount: 102,
          label: 'Save Receipt',
        });
        await openForm(page, '/txn/receipt');
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
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await box.fill(first);
        await page.keyboard.press('Enter');
        await loaded(first);
        await page.waitForFunction(
          () => document.activeElement?.getAttribute('aria-label') === 'Voucher date',
        );
        return {
          observation: `Down #${second}, Down #${first}, Up #${second}, Enter #${first} with the focus on the date`,
          expected: 'the desktop voucher number keys',
        };
      },
    ),
    pending(
      'calculations',
      'T03',
      'Covered by create.cash-receipt-with-kasar; multi-line totals follow with the grid cases.',
    ),
    pending(
      'settlement',
      'T06',
      'Card and UPI receipts (CARD_DATA, UPI_DATA) and bank cheques are the next cases of this module.',
    ),
    pending(
      'reopen',
      'T07',
      'Reopen is exercised inside reopen-edit-delete.receipt; a lossless reopen case follows.',
    ),
    pending('unchanged-save', 'T08', 'Follows the lossless reopen case.'),
    pending(
      'delete',
      'T10',
      'Delete is exercised inside reopen-edit-delete.receipt; the DELETE_DATA audit case follows.',
    ),
    pending(
      'rights',
      'T11',
      'The catalogue clerk has no cash/bank rights yet; a rights row follows.',
    ),
    pending(
      'concurrency',
      'T12',
      'Receipts and payments have no version token yet (N51 covers sales and purchases so far).',
    ),
    pending('retry', 'T13', 'Idempotency (N52) is not on the receipt routes yet.'),
    pending('rollback', 'T14', 'No fault injector in the harness yet (G173 / N166).'),
    pending(
      'settings',
      'T15',
      'The cash-limit setting is covered by refusal.cash-limit; employee-mandatory follows.',
    ),
    pending('journey', 'T18', 'The party ledger and cash book reports are checked in package L6.'),
    pending('branches', 'T02', 'Bank mode with a bank account and cheque number follows.'),
  ],
};
