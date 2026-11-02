import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Other → Tag Cancel (desktop TR_TAG_CAN on a TAG CANCEL book, web /txn/tag-cancel).
 *
 * Desktop authority for the expected values:
 * - MDI_FORM.cs:8585-8595 opens TR_TAG_CAN after CurBookHelp('TAG CANCEL').
 * - Choosing a tag fills the line from BAR_DETL (TR_TAG_CAN.cs:4002-4110); a tag typed twice is refused with
 *   "Duplicate Tag No" (:3933).
 * - Save (:4950-5120) refuses a date outside the year, a company of type B on a new voucher and the lock date with the
 *   desktop texts, then writes BAR_CAN_DATA / BAR_CAN_DETL and takes the tag out of stock: MAIN_STOCK TR_TYPE 'O',
 *   ITM_SIGN '-', VCH_TYPE the book's short name, BOOK_NAME 'TAG CANCEL' (Ac_Stock).
 * - Delete (:5330-5360) asks "Are You Sure To Delete This Voucher now?" and returns the tag to stock.
 * - Print (:5386-5440) needs UserPrint and prints TagCanBill: book name, ORIGINAL, Vch Date / Vch No, the SNO / Item
 *   Name / Pcs. / Gr Wt. / Net Wt / Rate / Item Amt / Oth Amt / Net Amount columns, TAG - item name, Total, Vch Desc.
 *
 * Each case seeds its own live tag (BAR_DETL + MAIN_STOCK '+', as a tag opening would) so cases never share a tag.
 */
const BOOK = 'TGC';
const TENANT = 'feature-e2e';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `tag-cancel.${id}`,
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
const blocked = (name, group, reason) => ({
  ...C(`${name}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})),
  blocked: reason,
});
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-07-10`;
let seq = 0;

/** A live gold tag of the fixture item, in stock at location 01 for the current year. */
async function seedTag(ctx, { gross = 10.5, net = 10, touch = 91.6 } = {}) {
  seq += 1;
  const tag = `TCE${String(seq).padStart(5, '0')}`;
  const srno = 900100000000 + seq;
  const fine = Math.round(net * touch * 10) / 1000;
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_DATE",
       "BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE",
       "TBL_CODE","IT_TYPE","EMP_ISU")
     VALUES ($1::text,'01','01',$2::text,'TOP','09001',$3::float8,$3::float8,$4::date,'TAG OPENING','I',$5::text,$6::numeric,
             $7::text,1,$8::float8,$9::float8,$10::float8,$11::float8,'001','G','N')`,
    TENANT,
    YEAR,
    seq,
    DAY,
    tag,
    srno,
    ITEMS.gold.code,
    gross,
    net,
    touch,
    fine,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
       "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1::text,'01','01',$2::text,'TOP','09001',$3::float8,1,$4::date,$5::text,$6::text,$7::numeric,'P','+',1,1,
             $8::float8,$9::float8)`,
    TENANT,
    YEAR,
    seq,
    DAY,
    ITEMS.gold.code,
    tag,
    srno,
    gross,
    net,
  );
  return { tag, srno, gross, net };
}

const balance = async (ctx, tag) =>
  Number(
    (
      await ctx.rows(
        `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int bal FROM "MAIN_STOCK"
          WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        tag,
      )
    )[0]?.bal ?? 0,
  );
const cancelRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"TAG_NO" tag,"IT_CODE" it,coalesce("ITM_GWT",0)::float gwt,coalesce("ITM_NWT",0)::float nwt
       FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const stockOut = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "TAG_NO" tag,"VCH_TYPE" vt,"BOOK_NAME" bn,"TR_TYPE" tr,"ITM_SIGN" sign
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "TAG_NO"`,
    vchNo,
  );
const vouchers = (ctx) =>
  ctx
    .rows(`SELECT count(*)::int n FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`)
    .then(([r]) => r.n);

async function open(ctx) {
  const { page } = await ctx.session();
  await page.goto('/txn/tag-cancel');
  await page.getByRole('heading', { name: 'Tag Cancel', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned TAG CANCEL book is selected');
  return page;
}

async function pickTag(page, line, tag) {
  const input = page.getByLabel(`TagNo line ${line}`, { exact: true });
  await input.fill(tag);
  await input.locator('xpath=..').getByText(tag, { exact: true }).first().waitFor();
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === '/api/stock/tag-cancel/source'),
    input.press('Enter'),
  ]);
  await page.waitForFunction(
    ({ line: n }) => {
      const el = document.querySelector(`input[aria-label="ItCode line ${n}"]`);
      return el && el.value;
    },
    { line },
  );
}

async function save(page, method = 'POST') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === method &&
        /^\/api\/stock\/tag-cancel(\/\d+)?$/.test(new URL(r.url()).pathname),
    ),
    page.getByTestId('tag-cancel-save').click(),
  ]);
  return response;
}

async function create(ctx, tags, { desc } = {}) {
  const page = await open(ctx);
  if (desc) await page.getByLabel('Vch Desc', { exact: true }).fill(desc);
  for (const [i, t] of tags.entries()) await pickTag(page, i + 1, t.tag);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const { voucherNo } = await response.json();
  return { page, voucherNo: String(voucherNo) };
}

/**
 * Wait until the Vch No box shows `expected`. The input has no aria-label attribute; it is named by
 * `<label for>`, so resolve it through that association exactly as `getByLabel('Vch No')` does.
 */
async function waitForVoucherNo(page, expected) {
  await page.waitForFunction((value) => {
    const label = [...document.querySelectorAll('label')].find(
      (candidate) => candidate.textContent?.trim() === 'Vch No',
    );
    const input = label?.htmlFor ? document.getElementById(label.htmlFor) : null;
    return input instanceof HTMLInputElement && input.value === value;
  }, expected);
}

async function reopen(page, voucherNo) {
  const box = page.getByLabel('Vch No', { exact: true });
  await box.fill(voucherNo);
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === `/api/stock/tag-cancel/${voucherNo}`),
    box.press('Enter'),
  ]);
  await page
    .getByTestId('tag-cancel-status')
    .filter({ hasText: `Loaded voucher ${voucherNo}` })
    .waitFor();
}

export const tagCancel = {
  feature: 'tag-cancel',
  title: 'Other → Tag Cancel (TR_TAG_CAN, TAG CANCEL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/components/TagCancelForm.tsx',
    'web/apps/api/src/modules/stock/tagCancel.ts',
    'web/apps/api/src/modules/stock/tagCancelBill.ts',
    'web/apps/api/src/modules/vouchers/numbering.ts',
    'web/apps/web/test/features/modules/tagCancel.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; cases seed their own live tags' },
  cases: [
    C(
      'entry.tag-cancel-book',
      'T01',
      'read-only',
      "MDI_FORM.cs:8585-8595: Tag Cancel opens only CurBookHelp('TAG CANCEL'); Save waits for a line.",
      async (ctx) => {
        const page = await open(ctx);
        const books = await page
          .getByRole('combobox', { name: 'Configured book', exact: true })
          .locator('option')
          .evaluateAll((o) => o.map((x) => x.getAttribute('value')).filter(Boolean));
        assert.deepEqual(books, [BOOK]);
        // MSG_CLEAR (TR_TAG_CAN.cs:2604-2629): the Tag Cancel grid has the labour columns and none of Stock Adjust's
        // (Sign, TagLot, ItmLot, :2514-2566), although the three menus share the form.
        const headers = (
          await page.getByTestId('tag-cancel-grid').locator('thead th').allInnerTexts()
        )
          .map((t) => t.trim())
          .filter(Boolean);
        for (const h of ['LbrRate', 'LbrAmt', 'OthAmt', 'Mrp', 'KrCode'])
          assert.ok(headers.includes(h), `Tag Cancel shows ${h}: ${headers}`);
        for (const h of ['Sign', 'TagLot', 'ItmLot', 'TrfrItm'])
          assert.ok(!headers.includes(h), `Tag Cancel hides ${h}`);
        await ctx.shot(page, 'entry');
        return {
          observation: `books ${books.join(',')}; columns ${headers.join(' ')}`,
          expected: BOOK,
        };
      },
    ),
    notApplicable(
      'branches',
      'T02',
      'TR_TAG_CAN TAG CANCEL mode has no tender or party branch.',
      'Tag Transfer (the other mode) is covered by tagCancel.routes.db.test.ts.',
    ),
    C(
      'formula.tag-fill',
      'T03',
      'read-only',
      'TR_TAG_CAN.cs:4002-4110: choosing a tag fills item, gross and net weight from BAR_DETL.',
      async (ctx) => {
        const t = await seedTag(ctx, { gross: 8.25, net: 8 });
        const page = await open(ctx);
        await pickTag(page, 1, t.tag);
        const it = await page.getByLabel('ItCode line 1', { exact: true }).inputValue();
        const gross = await page.getByLabel('GrWt line 1', { exact: true }).inputValue();
        const net = await page.getByLabel('NetWt line 1', { exact: true }).inputValue();
        assert.equal(it, ITEMS.gold.code);
        assert.equal(Number(gross), 8.25);
        assert.equal(Number(net), 8);
        return {
          observation: `${t.tag}: ${it} ${gross}/${net}`,
          expected: `${ITEMS.gold.code} 8.25/8`,
        };
      },
    ),
    C(
      'refusal.duplicate-tag-no-write',
      'T04',
      'refusal',
      'TR_TAG_CAN.cs:3933: the same tag on two lines is refused with "Duplicate Tag No".',
      async (ctx) => {
        const t = await seedTag(ctx);
        const before = await vouchers(ctx);
        const page = await open(ctx);
        await pickTag(page, 1, t.tag);
        const second = page.getByLabel('TagNo line 2', { exact: true });
        await second.fill(t.tag);
        await second.locator('xpath=..').getByText(t.tag, { exact: true }).first().waitFor();
        await second.press('Enter');
        await page
          .getByRole('alert')
          .filter({ hasText: `Duplicate Tag No: ${t.tag}` })
          .waitFor();
        assert.equal(await vouchers(ctx), before);
        assert.equal(await balance(ctx, t.tag), 1);
        return {
          observation: 'second line refused with Duplicate Tag No',
          expected: 'desktop message, no voucher',
          database: { vouchers: before, balance: 1 },
        };
      },
    ),
    C(
      'refusal.lock-date-no-write',
      'T04',
      'refusal',
      'TR_TAG_CAN.cs:4974-4978: "You Cant Save and Delete This Voucher Becouse Lock Date is = dd/MM/yyyy ...."',
      async (ctx) => {
        const t = await seedTag(ctx);
        const before = await vouchers(ctx);
        const page = await open(ctx);
        await page.getByLabel('Vch Date', { exact: true }).fill(DAY);
        await pickTag(page, 1, t.tag);
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "CO_SET" SET "LOCK_DATE"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          TENANT,
          DAY,
        );
        try {
          const response = await save(page);
          assert.equal(response.status(), 400, await response.text());
          const [y, m, d] = DAY.split('-');
          await page
            .getByRole('alert')
            .filter({
              hasText: `You Cant Save and Delete This Voucher Becouse Lock Date is = ${d}/${m}/${y} ....`,
            })
            .waitFor();
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            TENANT,
          );
        }
        assert.equal(await vouchers(ctx), before);
        assert.equal(await balance(ctx, t.tag), 1);
        return {
          observation: 'locked date refused with the desktop text',
          expected: 'no voucher, the tag stays in stock',
          database: { vouchers: before, balance: 1 },
        };
      },
    ),
    C(
      'create.tag-out-of-stock',
      'T05',
      'mutation',
      'TR_TAG_CAN.cs:4990-5120 and Ac_Stock: the cancel writes BAR_CAN rows and takes the tag out (O, -, TGCAN, TAG CANCEL).',
      async (ctx) => {
        const t = await seedTag(ctx, { gross: 9.5, net: 9 });
        const { page, voucherNo } = await create(ctx, [t], { desc: 'broken clasp' });
        const lines = await cancelRows(ctx, voucherNo);
        const stock = await stockOut(ctx, voucherNo);
        assert.deepEqual(lines, [{ sr: 1, tag: t.tag, it: ITEMS.gold.code, gwt: 9.5, nwt: 9 }]);
        assert.deepEqual(stock, [
          { tag: t.tag, vt: 'TGCAN', bn: 'TAG CANCEL', tr: 'O', sign: '-' },
        ]);
        assert.equal(await balance(ctx, t.tag), 0);
        await ctx.shot(page, 'saved');
        return {
          observation: `voucher ${voucherNo} cancelled ${t.tag}`,
          expected: 'one BAR_CAN_DETL line and one O/- stock row; the tag balance is 0',
          database: { lines, stock },
          downstream: { balance: 0 },
        };
      },
    ),
    notApplicable(
      'settlement',
      'T06',
      'TR_TAG_CAN writes stock only.',
      'A tag cancel has no tender or ledger.',
    ),
    C(
      'reopen.voucher-number-enter',
      'T07',
      'mutation',
      'TR_TAG_CAN.cs:4702-4880: Enter in Vch No reopens the saved lines.',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page, voucherNo } = await create(ctx, [t]);
        await page.getByTestId('tag-cancel-new').click();
        await reopen(page, voucherNo);
        const tag = await page.getByLabel('TagNo line 1', { exact: true }).inputValue();
        assert.equal(tag, t.tag);
        return {
          observation: `reopened ${voucherNo} with ${tag}`,
          expected: t.tag,
          database: { lines: await cancelRows(ctx, voucherNo) },
          downstream: { loaded: voucherNo },
        };
      },
    ),
    C(
      'edit.add-a-tag',
      'T09',
      'mutation',
      'TR_TAG_CAN save on a loaded voucher rewrites its lines: an added tag leaves stock, the kept one stays out.',
      async (ctx) => {
        const first = await seedTag(ctx);
        const second = await seedTag(ctx);
        const { page, voucherNo } = await create(ctx, [first]);
        await reopen(page, voucherNo);
        await pickTag(page, 2, second.tag);
        const response = await save(page, 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const lines = await cancelRows(ctx, voucherNo);
        assert.deepEqual(
          lines.map((l) => l.tag),
          [first.tag, second.tag],
        );
        assert.equal(await balance(ctx, first.tag), 0);
        assert.equal(await balance(ctx, second.tag), 0);
        return {
          observation: `voucher ${voucherNo} now cancels ${lines.map((l) => l.tag).join(', ')}`,
          expected: 'both tags out of stock',
          database: { lines },
          downstream: { balances: [0, 0] },
        };
      },
    ),
    C(
      'edit.unchanged-save',
      'T08',
      'mutation',
      'An unchanged save of a loaded cancel keeps its lines and stock rows.',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page, voucherNo } = await create(ctx, [t]);
        await reopen(page, voucherNo);
        const before = {
          lines: await cancelRows(ctx, voucherNo),
          stock: await stockOut(ctx, voucherNo),
        };
        const response = await save(page, 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const after = {
          lines: await cancelRows(ctx, voucherNo),
          stock: await stockOut(ctx, voucherNo),
        };
        assert.deepEqual(after, before);
        return {
          observation: `unchanged save of ${voucherNo}`,
          expected: 'identical lines and stock rows',
          database: { before, after },
          downstream: { unchanged: true },
        };
      },
    ),
    C(
      'delete.tag-back-in-stock',
      'T10',
      'mutation',
      'TR_TAG_CAN.cs:5330-5360: "Are You Sure To Delete This Voucher now?" then the tag returns to stock.',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page, voucherNo } = await create(ctx, [t]);
        await reopen(page, voucherNo);
        await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'DELETE' &&
              new URL(r.url()).pathname === `/api/stock/tag-cancel/${voucherNo}`,
          ),
          page.getByTestId('tag-cancel-delete').click(),
        ]);
        assert.deepEqual(await cancelRows(ctx, voucherNo), []);
        assert.equal(await balance(ctx, t.tag), 1);
        return {
          observation: `deleted ${voucherNo}; ${t.tag} back in stock`,
          expected: 'no cancel lines, balance 1',
          database: { lines: [] },
          downstream: { balance: 1 },
        };
      },
    ),
    C(
      'scope.print-rights',
      'T11',
      'refusal',
      'TR_TAG_CAN.cs:5390-5393: a user without UserPrint is refused TagCanBill.',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { voucherNo } = await create(ctx, [t]);
        const clerk = await ctx.session(as(USERS.clerk.user));
        await clerk.page.goto('/txn/sales');
        const status = await clerk.page.evaluate(
          async (u) => (await fetch(u, { credentials: 'include' })).status,
          `/api/stock/tag-cancel/${voucherNo}/print?coBook=${BOOK}&format=html`,
        );
        assert.equal(status, 403);
        return {
          observation: `clerk without Tag Cancel rights: ${status}`,
          expected: '403',
          database: { unchanged: true },
        };
      },
    ),
    blocked(
      'concurrency',
      'T12',
      'Two-writer races are covered in tagCancelLifecycle.db.test.ts (V7).',
    ),
    blocked('retry', 'T13', 'Tag Cancel POST has no idempotency key yet.'),
    blocked('rollback', 'T14', 'No fault injector in the harness yet (G173 / N166).'),
    blocked(
      'settings',
      'T15',
      'Company type B and the fiscal year are covered through HTTP in tagCancel.routes.db.test.ts.',
    ),
    C(
      'settings.stock-adjust-numbering-is-isolated',
      'T15',
      'read-only',
      'The forward legacy-number reservation applies only when BOOK_DATA.MAIN_BOOK is STOCK ADJUST; TAG CANCEL keeps BAR_CAN_DATA numbering.',
      async (ctx) => {
        const marker = 'e2e-tgcan-no';
        const [{ max }] = await ctx.rows(
          `SELECT coalesce(max(CASE WHEN "VCH_NO"::text ~ '^[0-9]+$' THEN "VCH_NO"::int END),0)::int max
             FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
               AND "CO_YEAR"=$2 AND "CO_BOOK"='${BOOK}'`,
          YEAR,
        );
        const expected = String(Number(max) + 1).padStart(5, '0');
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
             "VCH_DATE","VCH_TYPE","BOOK_NAME","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","MAIN_USER")
           VALUES ($1,'01','01',$2,'${BOOK}','90000',1,2,$3::date,'TGCAN','TAG CANCEL',$4,'N',0,'A','+', $5)`,
          TENANT,
          YEAR,
          DAY,
          ITEMS.gold.code,
          marker,
        );
        try {
          const page = await open(ctx);
          await waitForVoucherNo(page, expected);
          assert.equal(await page.getByLabel('Vch No', { exact: true }).inputValue(), expected);
          return {
            observation: `TAG CANCEL displayed ${expected} despite unrelated MAIN_STOCK voucher 90000`,
            expected: 'Tag Cancel still numbers from its configured BAR_CAN_DATA register only',
            database: { mainStockSentinel: '90000', nextVoucherNo: expected },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
               AND "CO_YEAR"=$2 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"='90000' AND "MAIN_USER"=$3`,
            TENANT,
            YEAR,
            marker,
          );
        }
      },
    ),
    C(
      'print.tag-can-bill',
      'T16',
      'output',
      'TR_TAG_CAN.cs:5386-5440, TagCanBill.spec.json: book name, ORIGINAL, columns, TAG - item, Total, Vch Desc, signatures.',
      async (ctx) => {
        const t = await seedTag(ctx, { gross: 7.5, net: 7.25 });
        const { page, voucherNo } = await create(ctx, [t], { desc: 'loose stone' });
        await reopen(page, voucherNo);
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByTestId('tag-cancel-print').click(),
        ]);
        await popup.waitForURL(/\/api\/stock\/tag-cancel\/\d+\/print/);
        await popup.waitForLoadState();
        const html = await popup.content();
        await ctx.shot(popup, 'tag-can-bill');
        await popup.close();
        for (const text of [
          'Tag Cancel',
          'ORIGINAL',
          'Vch No : ',
          'SNO',
          'Item Name',
          'Net Amount',
          `${t.tag} - ${ITEMS.gold.name}`,
          '7.500',
          '7.250',
          'Total :',
          'LOOSE STONE',
          'Party signature.',
        ])
          assert(html.includes(text), `TagCanBill shows ${text}`);
        return {
          observation: `TagCanBill for ${voucherNo}`,
          expected: 'the report header, columns, line, total and footer',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'TR_TAG_CAN &Save is the Alt+S mnemonic.',
      async (ctx) => {
        const t = await seedTag(ctx);
        const page = await open(ctx);
        await pickTag(page, 1, t.tag);
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'POST' &&
              new URL(r.url()).pathname === '/api/stock/tag-cancel',
          ),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        assert.equal(await balance(ctx, t.tag), 0);
        return {
          observation: 'Alt+S saved the cancel',
          expected: 'tag out of stock',
          database: { balance: 0 },
          downstream: { balance: 0 },
        };
      },
    ),
    blocked('downstream-report', 'T18', 'The Tag Stock report (L6) is checked in its own module.'),
  ],
};
