import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Master → Tag Opening and Other → Only Tag Entry (desktop TR_TAG_OPBL, web /txn/tag-opening and
 * /txn/tag-opening?mode=TAG GEN).
 *
 * Desktop rules used for the expected values:
 * - The two menus open the same form on different book families: Tag Opening on OPSTK books, Only Tag Entry on
 *   TAG GEN books (MDI_FORM.cs:7700-7710, :8574-8584). Only Tag Entry shows and requires the stock item the tags are
 *   made from ("Stock item code Insert First...", TR_TAG_OPBL.cs:10813-10818).
 * - Fine = (net + ghat) × (touch + wastage) / 100 (TR_TAG_OPBL.cs:6590).
 * - Ac_Stock.Tag_Opbl_Stk (Ac_Stock.cs:22-36): an opening tag is a purchase-in row (TR_TYPE 'P', VCH_TYPE 'TAGOP',
 *   BOOK_NAME 'TAG OPBL', ITM_QTY 1); an Only Tag Entry tag is an issue-in row ('I', the book's short name, 'TAG GEN')
 *   and the stock item goes out once by the voucher's totals ('O', '-', TAG_NO 'N'). No ledger entry.
 * - A tag number typed twice: "Duplicate Tag No" (:8562). Delete asks "Are You Sure To Delete This Voucher now?"
 *   (:11387), writes DELETE_DATA and says "Delete Success." (:11431); a voucher whose tag is in a sale cannot be
 *   deleted ("You Cant Delete This Voucher Because  Tag Use in Sales Transection....", :11383).
 * - The voucher number box: Enter opens the typed voucher and moves to the date; F1 lists the vouchers
 *   (tVchNo_KeyDown, :11879).
 */
const OPEN_BOOK = 'TOP';
const TAG_GEN_BOOK = 'TGN';
const GOLD = ITEMS.gold.code;
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `tag-opening.${id}`,
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

const isApi = (r, method, prefix) =>
  r.request().method() === method && new URL(r.url()).pathname.startsWith(`/api${prefix}`);
const pad = (vchNo) => String(vchNo).padStart(5, '0');
// The voucher's Delete (the tag image panel has its own Delete button for the photograph).
const deleteButton = (page) => page.locator('button.danger').filter({ hasText: /^Delete$/ });

async function openScreen(page, { tagGen = false } = {}) {
  await page.goto(tagGen ? '/txn/tag-opening?mode=TAG%20GEN' : '/txn/tag-opening');
  await page
    .getByRole('heading', { name: tagGen ? /^Only Tag Entry/ : /^Tag Opening Balance/ })
    .waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  const want = tagGen ? TAG_GEN_BOOK : OPEN_BOOK;
  for (let i = 0; i < 60 && (await book.inputValue()) !== want; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), want, `the provisioned ${want} book is selected`);
}
async function pick(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}
const grid = (page, field, row) =>
  page.getByLabel(`Tag opening ${field} row ${row}`, { exact: true });
async function fillTag(page, row, t) {
  if (row > 1) {
    await page.getByRole('button', { name: '+ Add tag', exact: true }).click();
    await page.getByLabel(`Tag no row ${row}`, { exact: true }).waitFor();
  }
  if (t.tag) await page.getByLabel(`Tag no row ${row}`, { exact: true }).fill(t.tag);
  await pick(page, `Item code row ${row}`, t.item ?? GOLD);
  const fields = {
    tblCode: t.counter,
    pcs: t.pcs ?? '1',
    grossWt: t.gross,
    lessWt: t.less,
    netWt: t.net,
    touch: t.touch,
  };
  for (const [field, value] of Object.entries(fields))
    if (value !== undefined) await grid(page, field, row).fill(value);
  if (t.extra) {
    await page.getByText(`Tag row ${row} desktop fields`, { exact: true }).click();
    for (const [label, value] of Object.entries(t.extra))
      await page.getByLabel(`${label} row ${row}`, { exact: true }).fill(value);
  }
}
async function save(page, trigger) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        ['POST', 'PUT'].includes(r.request().method()) &&
        /\/api\/stock\/tag-opening(\/|$)/.test(new URL(r.url()).pathname),
    ),
    trigger
      ? trigger()
      : page.getByRole('button', { name: /^(Load Opening Stock|Update Opening)$/ }).click(),
  ]);
  return response;
}
async function enter(page, tags, { tagGen = false, stockItem } = {}) {
  await openScreen(page, { tagGen });
  if (stockItem) await pick(page, 'Stock Item Code', stockItem);
  for (const [i, t] of tags.entries()) await fillTag(page, i + 1, t);
  const response = await save(page);
  const body = await response.json();
  assert.equal(response.status(), 201, JSON.stringify(body));
  await page
    .getByText(/Saved — voucher #/)
    .first()
    .waitFor();
  return { vchNo: pad(body.vchNo), tagNos: body.tagNos };
}
/** Open a saved voucher through the voucher number box (Enter, as tVchNo_KeyDown). */
async function reopen(page, vchNo, { tagGen = false } = {}) {
  await openScreen(page, { tagGen });
  const box = page.getByLabel('Voucher No', { exact: true });
  await box.fill(vchNo);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `/stock/tag-opening/${vchNo}`)),
    box.press('Enter'),
  ]);
  await page.getByTestId('tag-opening-loaded').waitFor();
  return response;
}
async function removeVoucher(page, vchNo, { tagGen = false } = {}) {
  await reopen(page, vchNo, { tagGen });
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', `/stock/tag-opening/${vchNo}`)),
    deleteButton(page).click(),
  ]);
  return response;
}
const detl = (ctx, book, vchNo) =>
  ctx.rows(
    `SELECT "TAG_NO" tag, "IT_CODE" it, "TBL_CODE" ctr, coalesce("ITM_GWT",0)::float gwt, coalesce("ITM_NWT",0)::float nwt,
            coalesce("ITM_FINE",0)::float fine, coalesce("HM_ID2",'') hm2, coalesce("KR_COST",0)::float krcost,
            coalesce("DESIGN_NO",'') design
       FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
    book,
    vchNo,
  );
const stock = (ctx, book, vchNo) =>
  ctx.rows(
    `SELECT coalesce("SR_NO",0)::int sr, "VCH_TYPE" vt, "BOOK_NAME" bn, "IT_CODE" it, "TAG_NO" tag, "TR_TYPE" tr,
            "ITM_SIGN" sg, coalesce("ITM_QTY",0)::float qty, coalesce("ITM_GWT",0)::float gwt,
            coalesce("ITM_NWT",0)::float nwt, coalesce("ITM_FINE",0)::float fine, "TBL_CODE" ctr
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
    book,
    vchNo,
  );
const shape = (rows) =>
  rows.map((r) => [r.tr, r.sg, r.vt, r.bn, r.it, r.qty, r.gwt, r.nwt, r.fine]);

export const tagOpening = {
  feature: 'tag-opening',
  title: 'Master → Tag Opening and Other → Only Tag Entry (TR_TAG_OPBL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/tag-opening/page.tsx',
    'web/apps/api/src/modules/stock/stockVoucherLifecycle.ts',
    'web/apps/web/test/features/modules/tagOpening.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.menu-books',
      'T01',
      'read-only',
      'MDI_FORM.cs:7700-7710 and :8574-8584: Tag Opening opens on an opening book and hides the stock item; Only Tag Entry opens on a TAG GEN book and asks for the stock item',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        assert.equal(await page.getByLabel('Stock Item Code', { exact: true }).count(), 0);
        assert.equal(await deleteButton(page).count(), 0);
        assert.equal(await page.getByLabel('Voucher No', { exact: true }).inputValue(), '');
        await openScreen(page, { tagGen: true });
        await page.getByLabel('Stock Item Code', { exact: true }).waitFor();
        return {
          observation: 'Tag Opening: TOP, no stock item; Only Tag Entry: TGN with stock item',
          expected: 'the desktop menus',
        };
      },
    ),
    C(
      'field.only-tag-entry-stock',
      'T02',
      'mutation',
      'TR_TAG_OPBL.cs:10813-10818 and Ac_Stock.cs:22-36: Only Tag Entry needs the stock item, then the tags come in (I) and the stock item goes out once (O)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page, { tagGen: true });
        await fillTag(page, 1, { gross: '10.5', net: '10', touch: '91.6' });
        const refused = await save(page);
        assert.equal(refused.status(), 400);
        await page.getByText('Stock item code Insert First...', { exact: true }).waitFor();
        const saved = await enter(
          page,
          [
            { gross: '10.5', net: '10', touch: '91.6' },
            { gross: '5.25', net: '5', touch: '91.6' },
          ],
          { tagGen: true, stockItem: ITEMS.gold.code },
        );
        try {
          const rows = await stock(ctx, TAG_GEN_BOOK, saved.vchNo);
          // Fine (net × 91.6 / 100): 9.16 and 4.58; the stock item goes out by the totals 15.75 / 15 / 13.74.
          assert.deepEqual(shape(rows), [
            ['O', '-', 'TGEN', 'TAG GEN', GOLD, 1, 15.75, 15, 13.74],
            ['I', '+', 'TGEN', 'TAG GEN', GOLD, 1, 10.5, 10, 9.16],
            ['I', '+', 'TGEN', 'TAG GEN', GOLD, 1, 5.25, 5, 4.58],
          ]);
          assert.equal(rows[0].tag, 'N');
          return {
            observation: `refused without the stock item; then ${JSON.stringify(shape(rows))}`,
            expected: 'one O row by the totals and one I row per tag',
            database: { stock: rows },
            downstream: { tags: saved.tagNos },
          };
        } finally {
          await removeVoucher(page, saved.vchNo, { tagGen: true });
        }
      },
    ),
    C(
      'formula.fine-with-wastage',
      'T03',
      'mutation',
      'TR_TAG_OPBL.cs:6590: fine = (net + ghat) × (touch + wastage) / 100 — 10 × (91.6 + 2) / 100 = 9.36',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        await fillTag(page, 1, { gross: '10.5', less: '0.5', net: '10', touch: '91.6' });
        const fineCell = page.getByTestId('tag-opening-fine-row-1');
        const shownBefore = (await fineCell.innerText()).trim();
        await page.getByText('Tag row 1 desktop fields', { exact: true }).click();
        await page.getByLabel('West Pct row 1', { exact: true }).fill('2');
        const shownAfter = (await fineCell.innerText()).trim();
        const response = await save(page);
        const body = await response.json();
        assert.equal(response.status(), 201, JSON.stringify(body));
        const vchNo = pad(body.vchNo);
        try {
          const [d] = await detl(ctx, OPEN_BOOK, vchNo);
          const [s] = await stock(ctx, OPEN_BOOK, vchNo);
          assert.equal(shownBefore, '9.16');
          assert.equal(shownAfter, '9.36');
          assert.deepEqual([d.fine, s.fine], [9.36, 9.36]);
          return {
            observation: `grid fine ${shownBefore} → ${shownAfter} with 2% wastage; stored ${d.fine} / ${s.fine}`,
            expected: '9.16 then 9.36',
            database: { detail: d, stock: s },
            downstream: { fine: s.fine },
          };
        } finally {
          await removeVoucher(page, vchNo);
        }
      },
    ),
    C(
      'formula.karigar-block',
      'T03',
      'mutation',
      'TR_TAG_OPBL.cs:6679-6826 and :10975-11022 (N204): KrNwt = gross − KrOthWt = 10.5 − 0.5 = 10; KrFine = (10 + 0.25) × (92 + 1.5) / 100 = 9.584; BAR_DETL keeps the block and Tag_Opbl_Stk copies it to MAIN_STOCK (Ac_Stock.cs:28)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        await fillTag(page, 1, { gross: '10.5', less: '0.5', net: '10', touch: '91.6' });
        await page.getByText('Tag row 1 desktop fields', { exact: true }).click();
        const cell = (label) => page.getByLabel(`${label} row 1`, { exact: true });
        for (const [label, value] of [
          ['KrOthWt', '0.5'],
          ['KrGht%', '2.5'],
          ['KrGht', '0.25'],
          ['KrTouch', '92'],
          ['KrWst%', '1.5'],
        ])
          await cell(label).fill(value);
        // Leaving the cell runs CommPassTotal, which fills KrNwt and KrFine.
        await cell('KrWst%').press('Tab');
        const shown = {
          net: await cell('KrNwt').inputValue(),
          fine: await cell('KrFine').inputValue(),
        };
        const response = await save(page);
        const body = await response.json();
        assert.equal(response.status(), 201, JSON.stringify(body));
        const vchNo = pad(body.vchNo);
        try {
          const [bar] = await ctx.rows(
            `SELECT coalesce("KR_OTH_WT",0)::float oth, coalesce("KR_NET_WT",0)::float net,
                    coalesce("KR_GHT_PRC",0)::float ghtp, coalesce("KR_GHT_WT",0)::float ght,
                    coalesce("KR_TOUCH",0)::float touch, coalesce("KR_WEST_PRC",0)::float west,
                    coalesce("KR_FINE",0)::float fine
               FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
            OPEN_BOOK,
            vchNo,
          );
          const [kr] = await ctx.rows(
            `SELECT coalesce("KR_NWT",0)::float net, coalesce("KR_TOUCH",0)::float touch,
                    coalesce("KR_WEST",0)::float west, coalesce("KR_FINE",0)::float fine
               FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "TAG_NO"<>'N'`,
            OPEN_BOOK,
            vchNo,
          );
          assert.deepEqual(shown, { net: '10.000', fine: '9.584' });
          assert.deepEqual(bar, {
            oth: 0.5,
            net: 10,
            ghtp: 2.5,
            ght: 0.25,
            touch: 92,
            west: 1.5,
            fine: 9.584,
          });
          assert.deepEqual(kr, { net: 10, touch: 92, west: 1.5, fine: 9.584 });
          return {
            observation: `grid KrNwt ${shown.net}, KrFine ${shown.fine}; BAR_DETL ${JSON.stringify(bar)}; MAIN_STOCK ${JSON.stringify(kr)}`,
            expected: 'KrNwt 10.000 and KrFine 9.584 on the grid, in BAR_DETL and in MAIN_STOCK',
            database: { detail: bar, stock: kr },
            downstream: { karigarFine: kr.fine },
          };
        } finally {
          await removeVoucher(page, vchNo);
        }
      },
    ),
    C(
      'lookup.item-enter',
      'T04',
      'mutation',
      'The item code cell takes the item from the help list (TR_TAG_OPBL item help): typing the code and Enter picks it',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [
          { item: ITEMS.silver.code, gross: '20', net: '20', touch: '92.5' },
        ]);
        try {
          const [d] = await detl(ctx, OPEN_BOOK, saved.vchNo);
          assert.equal(d.it, ITEMS.silver.code);
          return {
            observation: `saved item ${d.it}`,
            expected: ITEMS.silver.code,
            database: { detail: d },
            downstream: { item: d.it },
          };
        } finally {
          await removeVoucher(page, saved.vchNo);
        }
      },
    ),
    C(
      'children.two-tags-auto-numbers',
      'T05',
      'mutation',
      'TR_TAG_OPBL: a blank tag number is generated from SRNO_MAST, one per row; each tag gets its own detail and stock row',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [
          { gross: '10.5', net: '10', touch: '91.6' },
          { gross: '8', net: '7.5', touch: '91.6' },
        ]);
        try {
          const rows = await detl(ctx, OPEN_BOOK, saved.vchNo);
          const posted = await stock(ctx, OPEN_BOOK, saved.vchNo);
          assert.equal(saved.tagNos.length, 2);
          assert.notEqual(saved.tagNos[0], saved.tagNos[1]);
          assert.deepEqual(
            rows.map((r) => r.tag),
            saved.tagNos,
          );
          assert.deepEqual(
            posted.map((r) => [r.tag, r.qty, r.gwt]),
            [
              [saved.tagNos[0], 1, 10.5],
              [saved.tagNos[1], 1, 8],
            ],
          );
          await page
            .getByText(`Barcodes: ${saved.tagNos.join(', ')}`, { exact: false })
            .first()
            .waitFor();
          return {
            observation: `tags ${saved.tagNos.join(', ')}`,
            expected: 'two distinct generated tags, two detail and two stock rows',
            database: { detail: rows, stock: posted },
            downstream: { tags: saved.tagNos },
          };
        } finally {
          await removeVoucher(page, saved.vchNo);
        }
      },
    ),
    C(
      'refusal.duplicate-tag',
      'T06',
      'refusal',
      'TR_TAG_OPBL.cs:8562: a tag number typed twice is refused with "Duplicate Tag No" and nothing is saved',
      async (ctx) => {
        const { page } = await ctx.session();
        const [{ n: before }] = await ctx.rows(
          `SELECT count(*)::int n FROM "BAR_DATA" WHERE tenant_id=$1`,
        );
        await openScreen(page);
        await fillTag(page, 1, { tag: 'TODUP1', gross: '1', net: '1', touch: '91.6' });
        await fillTag(page, 2, { tag: 'TODUP1', gross: '2', net: '2', touch: '91.6' });
        const response = await save(page);
        assert.equal(response.status(), 400);
        await page.getByText('Duplicate Tag No', { exact: true }).waitFor();
        const [{ n: after }] = await ctx.rows(
          `SELECT count(*)::int n FROM "BAR_DATA" WHERE tenant_id=$1`,
        );
        assert.equal(after, before);
        return {
          observation: 'refused with the desktop message',
          expected: 'Duplicate Tag No',
          database: { before, after },
        };
      },
    ),
    C(
      'create.opening-footprint',
      'T07',
      'mutation',
      'TR_TAG_OPBL save and Ac_Stock.Tag_Opbl_Stk: BAR_DATA, BAR_DETL and one P/TAGOP/TAG OPBL stock row with quantity 1, on the counter typed; no ledger entry',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [
          { counter: '002', gross: '10.5', less: '0.5', net: '10', touch: '91.6' },
        ]);
        try {
          const [header] = await ctx.rows(
            `SELECT "OP_STK" op, "STK_IT_CODE" stk FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
            OPEN_BOOK,
            saved.vchNo,
          );
          const rows = await detl(ctx, OPEN_BOOK, saved.vchNo);
          const posted = await stock(ctx, OPEN_BOOK, saved.vchNo);
          const ledger = await ctx.rows(
            `SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
            OPEN_BOOK,
            saved.vchNo,
          );
          assert.deepEqual(header, { op: 'Y', stk: null });
          assert.deepEqual(
            rows.map((r) => [r.it, r.ctr, r.gwt, r.nwt, r.fine]),
            [[GOLD, '002', 10.5, 10, 9.16]],
          );
          assert.deepEqual(shape(posted), [
            ['P', '+', 'TAGOP', 'TAG OPBL', GOLD, 1, 10.5, 10, 9.16],
          ]);
          assert.equal(posted[0].ctr, '002');
          assert.equal(ledger.length, 0);
          return {
            observation: `header ${JSON.stringify(header)}; detail ${JSON.stringify(rows)}; stock ${JSON.stringify(shape(posted))}`,
            expected: 'one P/TAGOP/TAG OPBL row on counter 002, no AC_DATA',
            database: { header, detail: rows, stock: posted },
            downstream: { ledger: ledger.length },
          };
        } finally {
          await removeVoucher(page, saved.vchNo);
        }
      },
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'TR_TAG_OPBL reload and save: reopening a tag and saving it unchanged keeps every field (hallmark id, karigar cost, design)',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [
          {
            gross: '10.5',
            net: '10',
            touch: '91.6',
            extra: { 'Hallmark Id2': 'HUID2A9Z', 'Karigar Cost': '1200' },
          },
        ]);
        try {
          const before = await detl(ctx, OPEN_BOOK, saved.vchNo);
          // Each layer in turn, so a failure names the one that lost the field: the saved row, the reopen answer, the
          // grid.
          assert.deepEqual(
            [before[0]?.hm2, before[0]?.krcost],
            ['HUID2A9Z', 1200],
            'the save stored the fields',
          );
          const opened = await (await reopen(page, saved.vchNo)).json();
          assert.deepEqual(
            [opened.lines?.[0]?.hallmarkId2, opened.lines?.[0]?.karigarCost],
            ['HUID2A9Z', 1200],
            'the reopen answer carries the fields',
          );
          await page.getByText('Tag row 1 desktop fields', { exact: true }).click();
          await page.waitForFunction(
            () =>
              document.querySelector('input[aria-label="Hallmark Id2 row 1"]')?.value ===
              'HUID2A9Z',
            undefined,
            { timeout: 5000 },
          );
          assert.equal(
            await page.getByLabel('Hallmark Id2 row 1', { exact: true }).inputValue(),
            'HUID2A9Z',
          );
          assert.equal(
            await page.getByLabel('Karigar Cost row 1', { exact: true }).inputValue(),
            '1200',
          );
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          const after = await detl(ctx, OPEN_BOOK, saved.vchNo);
          assert.deepEqual(after, before);
          assert.deepEqual([after[0].hm2, after[0].krcost], ['HUID2A9Z', 1200]);
          return {
            observation: `reopened and saved unchanged: ${JSON.stringify(after)}`,
            expected: 'the same BAR_DETL row, hallmark id and karigar cost kept',
            database: { before, after },
            downstream: { kept: true },
          };
        } finally {
          await removeVoucher(page, saved.vchNo);
        }
      },
    ),
    C(
      'edit.weights',
      'T09',
      'mutation',
      'TR_TAG_OPBL edit rewrites the voucher: a new gross and net weight replace the detail and the one stock row',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [{ gross: '10.5', net: '10', touch: '91.6' }]);
        try {
          await reopen(page, saved.vchNo);
          await grid(page, 'grossWt', 1).fill('12');
          await grid(page, 'netWt', 1).fill('11.5');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          const rows = await detl(ctx, OPEN_BOOK, saved.vchNo);
          const posted = await stock(ctx, OPEN_BOOK, saved.vchNo);
          // 11.5 × 91.6 / 100 = 10.534
          assert.deepEqual(
            rows.map((r) => [r.tag, r.gwt, r.nwt, r.fine]),
            [[saved.tagNos[0], 12, 11.5, 10.534]],
          );
          assert.deepEqual(
            posted.map((r) => [r.tag, r.gwt, r.nwt, r.fine]),
            [[saved.tagNos[0], 12, 11.5, 10.534]],
          );
          return {
            observation: `detail ${JSON.stringify(rows)}; stock ${JSON.stringify(posted.map((r) => [r.gwt, r.nwt]))}`,
            expected: 'one tag, 12 / 11.5 / 10.534',
            database: { detail: rows, stock: posted },
            downstream: { stockRows: posted.length },
          };
        } finally {
          await removeVoucher(page, saved.vchNo);
        }
      },
    ),
    C(
      'delete.audit',
      'T10',
      'mutation',
      'TR_TAG_OPBL.cs:11387-11431: Delete confirms, writes DELETE_DATA, removes the voucher and its stock, and says "Delete Success."',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [{ gross: '10.5', net: '10', touch: '91.6' }]);
        const response = await removeVoucher(page, saved.vchNo);
        assert.equal(response.status(), 200, await response.text());
        await page.getByText('Delete Success.', { exact: true }).waitFor();
        const header = await ctx.rows(
          `SELECT 1 FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          OPEN_BOOK,
          saved.vchNo,
        );
        const posted = await stock(ctx, OPEN_BOOK, saved.vchNo);
        // Voucher numbers are reused once the last voucher is deleted, so the audit is read for this tag only.
        const audit = await ctx.rows(
          `SELECT "VCH_DESC" d, coalesce("VCH_FINE_CR",0)::float fcr FROM "DELETE_DATA"
            WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "VCH_DESC" LIKE $4`,
          OPEN_BOOK,
          saved.vchNo,
          `%TagNo/${saved.tagNos[0]}`,
        );
        assert.equal(header.length, 0);
        assert.equal(posted.length, 0);
        assert.deepEqual(audit, [{ d: `ItCode/${GOLD} TagNo/${saved.tagNos[0]}`, fcr: 10 }]);
        return {
          observation: `deleted; audit ${JSON.stringify(audit)}`,
          expected: 'no voucher, no stock, one DELETE_DATA row',
          database: { header, stock: posted, audit },
          downstream: { deleted: true },
        };
      },
    ),
    pending('rights', 'T11', 'The catalogue clerk has no Tag Opening rights row yet.'),
    pending(
      'concurrency',
      'T12',
      'Two-session edit of one voucher needs a second operator slot and a version token.',
    ),
    pending('retry', 'T13', 'Idempotency (N52) is not on the stock vouchers yet.'),
    pending('rollback', 'T14', 'No fault injector in the harness yet (G173 / N166).'),
    pending(
      'settings',
      'T15',
      'The counter-mandatory setting (CNTR_STK, "Please Insert Counter Code and Try Because It is Mandatory...") needs a settings-variant fixture (N166).',
    ),
    C(
      'output.tag-stock-report',
      'T16',
      'output',
      'RP_TAG: an opened tag is in the Tag-Stock report until it is sold or deleted',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [{ gross: '10.5', net: '10', touch: '91.6' }]);
        try {
          await page.goto('/reports/tag-stock');
          await page.getByRole('heading', { name: 'Tag-Stock Report' }).waitFor();
          const row = page.locator('tbody tr', { hasText: saved.tagNos[0] }).first();
          await row.waitFor();
          const cells = (await row.locator('td').allInnerTexts()).map((t) => t.trim());
          // Tag, item, design, counter, pcs, gross, net, fine (9.16 = 10 × 91.6 / 100), MRP.
          assert.deepEqual(cells.slice(0, 8), [
            saved.tagNos[0],
            GOLD,
            '',
            '001',
            '1',
            '10.5',
            '10',
            '9.16',
          ]);
          const text = cells.join(' | ');
          return {
            observation: `report row: ${text}`,
            expected: `${saved.tagNos[0]} | ${GOLD} | | 001 | 1 | 10.5 | 10 | 9.16`,
            output: Buffer.from(text),
          };
        } finally {
          await removeVoucher(page, saved.vchNo);
        }
      },
    ),
    C(
      'keyboard.number-box-and-alt-s',
      'T17',
      'mutation',
      'TR_TAG_OPBL tVchNo_KeyDown (:11879): Enter opens the typed voucher and moves to the date, F1 lists the vouchers; BtnSave "&Save" (:3135): Alt+S saves',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        await fillTag(page, 1, { gross: '10.5', net: '10', touch: '91.6' });
        const response = await save(page, () => page.keyboard.press('Alt+s'));
        const body = await response.json();
        assert.equal(response.status(), 201, JSON.stringify(body));
        const vchNo = pad(body.vchNo);
        try {
          await openScreen(page);
          const box = page.getByLabel('Voucher No', { exact: true });
          await box.fill(vchNo);
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `/stock/tag-opening/${vchNo}`)),
            box.press('Enter'),
          ]);
          await page.getByTestId('tag-opening-loaded').waitFor();
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Date',
          );
          await box.focus();
          await box.press('F1');
          await page.getByRole('button', { name: '▾ Recent vouchers', exact: true }).waitFor();
          await page
            .locator('tbody tr', { hasText: vchNo })
            .locator('[data-voucher-load]')
            .first()
            .waitFor();
          return {
            observation: `Alt+S saved ${vchNo}; Enter reopened it and focused the date; F1 listed it`,
            expected: 'the desktop voucher number keys',
            database: { vchNo },
            downstream: { reopened: true },
          };
        } finally {
          await removeVoucher(page, vchNo);
        }
      },
    ),
    C(
      'journey.sold-tag-blocks-delete',
      'T18',
      'mutation',
      'TR_TAG_OPBL.cs:11376-11385: once the opened tag is sold through Sales Invoice, deleting the opening is refused with the desktop message',
      async (ctx) => {
        const { page } = await ctx.session();
        const saved = await enter(page, [{ gross: '10.5', net: '10', touch: '91.6' }]);
        const tagNo = saved.tagNos[0];
        await page.goto('/txn/sales');
        await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
        const party = page.getByPlaceholder('search accounts… (F1)').first();
        await party.fill(PARTIES.local.code);
        await party
          .locator('xpath=..')
          .getByText(PARTIES.local.code, { exact: true })
          .first()
          .waitFor();
        await party.press('Enter');
        const tagCell = page.locator('[data-grid-row="0"][data-grid-column="1"] input').first();
        await tagCell.fill(tagNo);
        await tagCell.locator('xpath=..').getByText(tagNo, { exact: true }).first().waitFor();
        await tagCell.press('Enter');
        await page.locator('[data-grid-row="0"][data-grid-column="2"] input').first().fill('1');
        await page.locator('[data-grid-row="0"][data-grid-column="6"] input').first().fill('6000');
        const [sale] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'POST' && new URL(r.url()).pathname === '/api/sales',
          ),
          page.getByRole('button', { name: 'Save Invoice', exact: true }).click(),
        ]);
        assert.equal(sale.status(), 201, await sale.text());
        const saleNo = pad((await sale.json()).vchNo);
        const sold = await ctx.rows(
          `SELECT "TR_TYPE" tr, "ITM_SIGN" sg FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2 AND "ITM_SIGN"='-'`,
          tagNo,
        );
        assert.equal(sold.length, 1, 'the sale took the tag out of stock');
        const refused = await removeVoucher(page, saved.vchNo);
        assert.equal(refused.status(), 400);
        await page
          .getByText('You Cant Delete This Voucher Because  Tag Use in Sales Transection....', {
            exact: true,
          })
          .waitFor();
        const still = await stock(ctx, OPEN_BOOK, saved.vchNo);
        assert.equal(still.length, 1);
        // Delete the sale through Sales Invoice; the tag is back in stock and the opening can go.
        await page.goto('/txn/sales');
        await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
        await page.getByLabel('Voucher No', { exact: true }).fill(saleNo);
        await page.getByRole('button', { name: 'Load', exact: true }).click();
        await page
          .getByTestId('sales-loaded')
          .filter({ hasText: `Loaded #${saleNo}` })
          .waitFor();
        const [saleDeleted] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && /\/api\/sales\//.test(r.url()),
          ),
          page.getByRole('button', { name: 'Delete', exact: true }).click(),
        ]);
        assert.equal(saleDeleted.status(), 200, await saleDeleted.text());
        const removed = await removeVoucher(page, saved.vchNo);
        assert.equal(removed.status(), 200, await removed.text());
        await page.getByText('Delete Success.', { exact: true }).waitFor();
        return {
          observation: `tag ${tagNo} sold on ${saleNo} (${JSON.stringify(sold)}); delete of opening ${saved.vchNo} refused; after the sale was deleted the opening deleted`,
          expected: 'the desktop refusal while sold; the opening deletes once the sale is gone',
          database: { sold, openingWhileSold: still },
          downstream: { sale: saleNo, openingDeleted: true },
        };
      },
    ),
  ],
};
