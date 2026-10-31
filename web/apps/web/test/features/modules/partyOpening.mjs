import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Master → Party Opening (desktop TR_AC_OPBL, web /txn/ac-opbl).
 *
 * Desktop rules used for the expected values:
 * - One OP_DATA row per party in book '000', voucher '00000', with Cr/Dr signs stored 'C'/'D' (TR_AC_OPBL.cs:2694-2722);
 *   the three combos start on Cr (CLEAR_DATA, :2232-2239). A save deletes and rewrites the row.
 * - AcOp_Ledr (Ac_Ledr.cs:9-28) writes one AC_DATA leg per non-zero head, dated the day before the year opens: 01 amount
 *   Cr, 02 amount Dr, 03 gold Cr ('+'), 04 gold Dr ('-'), 05 silver Cr ('+'), 06 silver Dr ('-'). The balance reads
 *   AC_DATA alone (DC_Main.MsAcBal), so the legs are the opening's whole ledger effect.
 * - Save without a party: "Please Enter Party First..." (:2682). Saved: "Data Are Saved." (:2830).
 * - Delete asks "Are You Sure To Delete This Record now?" (:2870), writes DELETE_DATA SR_NO 0 (amount, gold) and 1
 *   (silver), removes OP_DATA, OP_DETL and the legs, and says "Delete Success." (:2872-2879).
 *
 * Every case uses E2EINT and removes its opening at the end, so other modules see the party unchanged.
 */
const PARTY = PARTIES.interState;
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `party-opening.${id}`,
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

const isApi = (r, method, path) =>
  r.request().method() === method && new URL(r.url()).pathname === `/api${path}`;

async function openScreen(page) {
  await page.goto('/txn/ac-opbl');
  await page.getByRole('heading', { name: 'Party Opening', exact: true }).waitFor();
  await page.getByLabel('Party Code', { exact: true }).waitFor();
}
async function pickParty(page, code) {
  const input = page.getByLabel('Party Code', { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `/ac-opbl/${code}`)),
    input.press('Enter'),
  ]);
}
async function fillHeads(page, heads) {
  const box = {
    amount: 'Opening Amount',
    gold: 'Opening Gold Fine',
    silver: 'Opening Silver Fine',
  };
  for (const [key, label] of Object.entries(box)) {
    if (heads[key] !== undefined)
      await page.getByLabel(label, { exact: true }).fill(String(heads[key]));
    const sign = heads[`${key === 'amount' ? '' : key}${key === 'amount' ? 'sign' : 'Sign'}`];
    if (sign) await page.getByLabel(`${label} Cr or Dr`, { exact: true }).selectOption(sign);
  }
}
async function save(page, trigger) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'POST', '/ac-opbl')),
    trigger ? trigger() : page.getByRole('button', { name: 'Save', exact: true }).click(),
  ]);
  return response;
}
async function enter(page, heads) {
  await openScreen(page);
  await pickParty(page, PARTY.code);
  await fillHeads(page, heads);
  const response = await save(page);
  assert.equal(response.status(), 200, await response.text());
  await page.getByText('Data Are Saved.', { exact: true }).waitFor();
}
async function removeOpening(page) {
  await openScreen(page);
  await pickParty(page, PARTY.code);
  const button = page.getByRole('button', { name: 'Delete', exact: true });
  if (await button.isDisabled()) return;
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', `/ac-opbl/${PARTY.code}`)),
    button.click(),
  ]);
  await page.getByText('Delete Success.', { exact: true }).waitFor();
}
const opData = (ctx) =>
  ctx.rows(
    `SELECT "CO_BOOK" bk, "VCH_NO" vch, coalesce("OP_AMT",0)::float amt, "OP_SIGN" osg, coalesce("FINE_BAL",0)::float g,
            "FINE_SIGN" gsg, coalesce("SL_FINE_BAL",0)::float s, "SL_FINE_SIGN" ssg, "MAIN_USER" mu
       FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
    PARTY.code,
  );
const legs = (ctx) =>
  ctx.rows(
    `SELECT right(a."LEDR_KEY",2) code, coalesce(a."DR_AMT",0)::float dr, coalesce(a."CR_AMT",0)::float cr, a."IT_TYPE" it,
            a."SIGN" sg, coalesce(a."FINE_WT",0)::float fine, a."VCH_DATE"::date::text dt, (y."OP_DATE"::date - 1)::text expected
       FROM "AC_DATA" a LEFT JOIN "YEAR_MAST" y ON y.tenant_id=a.tenant_id AND y."CO_CODE"=a."CO_CODE" AND y."CO_YEAR"=a."CO_YEAR"
      WHERE a.tenant_id=$1 AND a."CO_BOOK"='000' AND a."VCH_TYPE"='ACOP' AND a."AC_CODE"=$2 ORDER BY a."LEDR_KEY"`,
    PARTY.code,
  );
const legShape = (rows) => rows.map((l) => [l.code, l.dr, l.cr, l.it, l.sg, l.fine]);

export const partyOpening = {
  feature: 'party-opening',
  title: 'Master → Party Opening (TR_AC_OPBL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/ac-opbl/page.tsx',
    'web/apps/api/src/modules/finance/partyOpening.ts',
    'web/apps/api/src/routes/partyOpening.ts',
    'web/apps/web/test/features/modules/partyOpening.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'TR_AC_OPBL.cs:2232-2239 and CLEAR_DATA: the three Cr/Dr combos start on Cr, the heads are empty and Delete needs a saved opening',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const signs = [];
        for (const label of ['Opening Amount', 'Opening Gold Fine', 'Opening Silver Fine']) {
          signs.push(await page.getByLabel(`${label} Cr or Dr`, { exact: true }).inputValue());
          assert.equal(await page.getByLabel(label, { exact: true }).inputValue(), '');
        }
        assert.deepEqual(signs, ['C', 'C', 'C']);
        assert.ok(await page.getByRole('button', { name: 'Delete', exact: true }).isDisabled());
        assert.equal(await page.getByLabel('Balance Type', { exact: true }).inputValue(), 'amount');
        return {
          observation: `signs ${signs.join('/')}, empty heads, Delete disabled`,
          expected: 'Cr/Cr/Cr',
        };
      },
    ),
    C(
      'field.gold-sign',
      'T02',
      'mutation',
      'AcOp_Ledr: gold Dr stores FINE_SIGN D and posts leg 04 with SIGN "-"; gold Cr posts leg 03 with "+"',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { gold: '5.5', goldSign: 'D' });
          const [op] = await opData(ctx);
          const posted = await legs(ctx);
          assert.deepEqual([op.g, op.gsg], [5.5, 'D']);
          assert.deepEqual(legShape(posted), [['04', 0, 0, 'G', '-', 5.5]]);
          return {
            observation: `FINE_SIGN ${op.gsg}; legs ${JSON.stringify(legShape(posted))}`,
            expected: 'FINE_SIGN D; leg 04 G - 5.5',
            database: { op, legs: posted },
            downstream: { legs: posted.length },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    C(
      'formula.rounding',
      'T03',
      'mutation',
      'TR_AC_OPBL formats the amount "0.00" and the fines "0.000" (MSG_TOT_FILL); the saved heads are rounded to those places',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { amount: '1234.567', sign: 'D', gold: '1.23456' });
          const [op] = await opData(ctx);
          assert.deepEqual([op.amt, op.g], [1234.57, 1.235]);
          assert.equal(
            await page.getByLabel('Opening Amount', { exact: true }).inputValue(),
            '1234.57',
          );
          assert.equal(
            await page.getByLabel('Opening Gold Fine', { exact: true }).inputValue(),
            '1.235',
          );
          const posted = await legs(ctx);
          assert.deepEqual(legShape(posted), [
            ['02', 1234.57, 0, 'A', '', 0],
            ['03', 0, 0, 'G', '+', 1.235],
          ]);
          return {
            observation: `saved ${op.amt} / ${op.g}`,
            expected: '1234.57 / 1.235',
            database: { op, legs: posted },
            downstream: { legs: posted.length },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    C(
      'lookup.switch-party',
      'T04',
      'read-only',
      'TR_AC_OPBL reloads the opening of the party typed in Party Code (:2534); choosing a party without one clears the heads',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { amount: '900', sign: 'D' });
          await openScreen(page);
          await pickParty(page, PARTY.code);
          assert.equal(
            await page.getByLabel('Opening Amount', { exact: true }).inputValue(),
            '900.00',
          );
          await pickParty(page, PARTIES.local.code);
          assert.equal(await page.getByLabel('Opening Amount', { exact: true }).inputValue(), '');
          assert.ok(await page.getByRole('button', { name: 'Delete', exact: true }).isDisabled());
          return {
            observation: 'E2EINT shows 900.00; E2ELOC shows an empty opening',
            expected: 'per-party reload',
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    pending(
      'bills',
      'T05',
      'The bill-wise opening grid (OP_DETL) is not on the web screen yet; a save keeps existing OP_DETL rows (DB test).',
    ),
    C(
      'refusal.no-party',
      'T06',
      'refusal',
      'TR_AC_OPBL.cs:2682: Save without a party says "Please Enter Party First..." and writes nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        const [{ n: before }] = await ctx.rows(
          `SELECT count(*)::int n FROM "OP_DATA" WHERE tenant_id=$1`,
        );
        await openScreen(page);
        await fillHeads(page, { amount: '100' });
        const response = await save(page);
        assert.equal(response.status(), 400);
        await page.getByText('Please Enter Party First...', { exact: true }).waitFor();
        const [{ n: after }] = await ctx.rows(
          `SELECT count(*)::int n FROM "OP_DATA" WHERE tenant_id=$1`,
        );
        assert.equal(after, before);
        return {
          observation: 'refused with the desktop message',
          expected: 'Please Enter Party First...',
          database: { before, after },
        };
      },
    ),
    C(
      'create.amount-and-gold',
      'T07',
      'mutation',
      'TR_AC_OPBL save and AcOp_Ledr: 25,000 Dr and 5.5 g gold Cr store one OP_DATA row (000/00000) and legs 02 and 03 dated the day before the year opens',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { amount: '25000', sign: 'D', gold: '5.5' });
          const op = await opData(ctx);
          const posted = await legs(ctx);
          assert.deepEqual(
            op.map((r) => [r.bk, r.vch, r.amt, r.osg, r.g, r.gsg, r.s, r.ssg]),
            [['000', '00000', 25000, 'D', 5.5, 'C', 0, 'C']],
          );
          assert.deepEqual(legShape(posted), [
            ['02', 25000, 0, 'A', '', 0],
            ['03', 0, 0, 'G', '+', 5.5],
          ]);
          for (const l of posted)
            assert.equal(l.dt, l.expected, 'leg date is the day before the year opens');
          const row = page
            .getByRole('region', { name: 'Opening list' })
            .locator('tr', { hasText: PARTY.code });
          await row.getByText('25,000.00', { exact: true }).waitFor();
          await page.getByText('₹25,000 Dr', { exact: true }).waitFor();
          return {
            observation: `OP_DATA ${JSON.stringify(op)}; legs ${JSON.stringify(legShape(posted))}; list and balance bar show 25,000 Dr`,
            expected: 'one OP_DATA row; legs 02 and 03',
            database: { op, legs: posted },
            downstream: { list: '25,000.00 Dr', balance: '₹25,000 Dr' },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'TR_AC_OPBL reload (:2534-2546) shows the saved heads; saving them unchanged keeps one OP_DATA row, the same legs and the first user',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { amount: '1200', silver: '2.25', silverSign: 'D' });
          const firstLegs = legShape(await legs(ctx));
          await openScreen(page);
          await pickParty(page, PARTY.code);
          assert.equal(
            await page.getByLabel('Opening Amount', { exact: true }).inputValue(),
            '1200.00',
          );
          assert.equal(
            await page.getByLabel('Opening Amount Cr or Dr', { exact: true }).inputValue(),
            'C',
          );
          assert.equal(
            await page.getByLabel('Opening Silver Fine', { exact: true }).inputValue(),
            '2.250',
          );
          assert.equal(
            await page.getByLabel('Opening Silver Fine Cr or Dr', { exact: true }).inputValue(),
            'D',
          );
          assert.ok(
            !(await page.getByRole('button', { name: 'Delete', exact: true }).isDisabled()),
          );
          const response = await save(page);
          assert.equal(response.status(), 200);
          const op = await opData(ctx);
          const again = legShape(await legs(ctx));
          assert.equal(op.length, 1);
          assert.deepEqual(again, firstLegs);
          assert.deepEqual(again, [
            ['01', 0, 1200, 'A', '', 0],
            ['06', 0, 0, 'S', '-', 2.25],
          ]);
          return {
            observation: `reopened 1200.00 Cr / 2.250 Dr; unchanged save kept ${op.length} row and legs ${JSON.stringify(again)}`,
            expected: 'one row, legs 01 and 06 unchanged',
            database: { op, legs: again },
            downstream: { legs: again.length },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    C(
      'edit.replaces-legs',
      'T09',
      'mutation',
      "TR_AC_OPBL save deletes the party's legs before AcOp_Ledr (:2770): changing 25,000 Dr + gold to 400 Cr leaves only leg 01",
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { amount: '25000', sign: 'D', gold: '5.5' });
          await openScreen(page);
          await pickParty(page, PARTY.code);
          await fillHeads(page, { amount: '400', sign: 'C', gold: '' });
          const response = await save(page);
          assert.equal(response.status(), 200);
          const op = await opData(ctx);
          const posted = await legs(ctx);
          assert.deepEqual(
            op.map((r) => [r.amt, r.osg, r.g]),
            [[400, 'C', 0]],
          );
          assert.deepEqual(legShape(posted), [['01', 0, 400, 'A', '', 0]]);
          await page.getByText('₹400 Cr', { exact: true }).waitFor();
          return {
            observation: `OP_DATA ${JSON.stringify(op)}; legs ${JSON.stringify(legShape(posted))}`,
            expected: '400 Cr; leg 01 only',
            database: { op, legs: posted },
            downstream: { balance: '₹400 Cr' },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    C(
      'delete.audit-and-remove',
      'T10',
      'mutation',
      'TR_AC_OPBL.cs:2856-2880: Delete confirms, writes DELETE_DATA SR_NO 0 and 1, removes OP_DATA and the legs, and says "Delete Success."',
      async (ctx) => {
        const { page } = await ctx.session();
        await enter(page, { amount: '3000', sign: 'D', silver: '2', silverSign: 'C' });
        await openScreen(page);
        await pickParty(page, PARTY.code);
        await Promise.all([
          page.waitForResponse((r) => isApi(r, 'DELETE', `/ac-opbl/${PARTY.code}`)),
          page.getByRole('button', { name: 'Delete', exact: true }).click(),
        ]);
        await page.getByText('Delete Success.', { exact: true }).waitFor();
        const op = await opData(ctx);
        const posted = await legs(ctx);
        const audit = await ctx.rows(
          `SELECT coalesce("SR_NO",0)::int sr, "VCH_TYPE" vt, coalesce("VCH_VAL_DR",0)::float dr, "FINE_TYPE" ft,
                  coalesce("VCH_FINE_CR",0)::float fcr
             FROM "DELETE_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2 AND "VCH_TYPE"='OPBAL' ORDER BY "DELETE_TIME" DESC, "SR_NO" LIMIT 2`,
          PARTY.code,
        );
        assert.equal(op.length, 0);
        assert.equal(posted.length, 0);
        assert.deepEqual(
          audit.map((a) => [a.sr, a.vt, a.dr, a.ft, a.fcr]),
          [
            [0, 'OPBAL', 3000, 'A', 0],
            [1, 'OPBAL', 0, 'S', 2],
          ],
        );
        assert.ok(await page.getByRole('button', { name: 'Delete', exact: true }).isDisabled());
        const region = page.getByRole('region', { name: 'Opening list' });
        await region.locator('tr', { hasText: PARTY.code }).first().waitFor({ state: 'detached' });
        const listed = await region.locator('tr', { hasText: PARTY.code }).count();
        assert.equal(listed, 0);
        return {
          observation: `removed; audit ${JSON.stringify(audit)}`,
          expected: 'no OP_DATA, no legs, two DELETE_DATA rows',
          database: { op, legs: posted, audit },
          downstream: { listed },
        };
      },
    ),
    pending('rights', 'T11', 'The catalogue clerk has no Party Opening rights row yet.'),
    pending(
      'concurrency',
      'T12',
      'Two-session save of one party: the party row lock serialises the saves; a browser case needs a second operator slot.',
    ),
    C(
      'retry.double-save',
      'T13',
      'mutation',
      "A save is a replace of the party's row (TR_AC_OPBL.cs:2694-2722), so sending it twice leaves one row and one set of legs",
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await openScreen(page);
          await pickParty(page, PARTY.code);
          await fillHeads(page, { amount: '777', sign: 'D' });
          const first = await save(page);
          assert.equal(first.status(), 200);
          // Replay the screen's own request (same headers, session context and body), as a lost acknowledgement would.
          const replay = (await page.request.fetch(first.request())).status();
          assert.equal(replay, 200);
          const op = await opData(ctx);
          const posted = await legs(ctx);
          assert.equal(op.length, 1);
          assert.deepEqual(legShape(posted), [['02', 777, 0, 'A', '', 0]]);
          return {
            observation: `replay answered ${replay}; ${op.length} row, legs ${JSON.stringify(legShape(posted))}`,
            expected: 'one row, one leg',
            database: { op, legs: posted },
            downstream: { replay },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    pending('rollback', 'T14', 'No fault injector in the harness yet (G173 / N166).'),
    pending(
      'config',
      'T15',
      'The A/B data type split is an Advance-edition feature; Standard has data type A only.',
    ),
    C(
      'output.list-by-type',
      'T16',
      'output',
      'TR_AC_OPBL.cs:2299-2311: the opening list shows the chosen balance type with Cr and Dr columns',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { amount: '700', gold: '1.25', goldSign: 'D', silver: '3' });
          const region = page.getByRole('region', { name: 'Opening list' });
          const cells = async () =>
            (
              await region.locator('tr', { hasText: PARTY.code }).locator('td').allInnerTexts()
            ).slice(1);
          await region.locator('tr', { hasText: PARTY.code }).waitFor();
          const amount = await cells();
          await Promise.all([
            page.waitForResponse(
              (r) => isApi(r, 'GET', '/ac-opbl') && r.url().includes('balanceType=gold'),
            ),
            page.getByLabel('Balance Type', { exact: true }).selectOption('gold'),
          ]);
          const gold = await cells();
          await Promise.all([
            page.waitForResponse(
              (r) => isApi(r, 'GET', '/ac-opbl') && r.url().includes('balanceType=silver'),
            ),
            page.getByLabel('Balance Type', { exact: true }).selectOption('silver'),
          ]);
          const silver = await cells();
          assert.deepEqual(amount, [PARTY.code, PARTY.name, '700.00', '']);
          assert.deepEqual(gold, [PARTY.code, PARTY.name, '', '1.250']);
          assert.deepEqual(silver, [PARTY.code, PARTY.name, '3.000', '']);
          const text = `amount ${amount.join('|')}; gold ${gold.join('|')}; silver ${silver.join('|')}`;
          return {
            observation: text,
            expected: 'Cr 700.00; Dr 1.250; Cr 3.000',
            output: Buffer.from(text),
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    C(
      'keyboard.alt-s',
      'T17',
      'mutation',
      'TR_AC_OPBL BtnSave is "&Save" (:1456): Alt+S saves the opening',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await openScreen(page);
          await pickParty(page, PARTY.code);
          await fillHeads(page, { amount: '50' });
          const response = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(response.status(), 200);
          await page.getByText('Data Are Saved.', { exact: true }).waitFor();
          const op = await opData(ctx);
          assert.deepEqual(
            op.map((r) => [r.amt, r.osg]),
            [[50, 'C']],
          );
          return {
            observation: 'Alt+S saved 50 Cr',
            expected: 'saved',
            database: { op },
            downstream: { saved: true },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
    C(
      'journey.balance-on-receipt',
      'T18',
      'mutation',
      'DC_Main.MsAcBal reads AC_DATA: the opening legs make the party balance on the Cash Received screen show the opening once',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await enter(page, { amount: '25000', sign: 'D' });
          await page.goto('/txn/receipt');
          const party = page.getByLabel('Party account', { exact: true });
          await party.waitFor();
          await party.fill(PARTY.code);
          await party.locator('xpath=..').getByText(PARTY.code, { exact: true }).first().waitFor();
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `/party/${PARTY.code}/balance`)),
            party.press('Enter'),
          ]);
          await page.getByText('₹25,000 Dr', { exact: true }).waitFor();
          return {
            observation: 'Cash Received shows ₹25,000 Dr for the party',
            expected: '₹25,000 Dr (not 50,000)',
            database: { legs: legShape(await legs(ctx)) },
            downstream: { receiptBalance: '₹25,000 Dr' },
          };
        } finally {
          await removeOpening(page);
        }
      },
    ),
  ],
};
