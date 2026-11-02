import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Other → Stock Adjust (desktop TR_TAG_CAN on a STOCK ADJUST book, web /txn/stock-adjust).
 *
 * Desktop authority for the expected values:
 * - MDI_FORM.cs:8616-8627 opens TR_TAG_CAN after CurBookHelp('STOCK ADJUST'); the provisioned book is the desktop's
 *   STADJ out book (MS_UPDATE.cs:24207, :25049).
 * - MSG_CLEAR (TR_TAG_CAN.cs:2514-2566): the Tag Cancel grid without LbrRate, LbrAmt and OthAmt, with Sign after Size, and
 *   TagLot / ItmLot only with Purchase LOT / Item With LOT Stock.
 * - Enter on a blank TagNo moves on (:3866), so a line can be a loose item; Enter on Sign needs + or - ("Please Insert
 *   Item Sign + or - then Try", :4259-4263); a new row starts with the row above's sign (CommPassAdd :2835-2838).
 * - Save writes the register with the line's sign (:5138-5145); Tag_Can_Stk posts MAIN_STOCK TR_TYPE 'I' for + and 'O'
 *   for - (Ac_Stock.cs:53); StkAdj_Lot posts LOT_DETL for a line with a TagLot (Ac_Stock.cs:642-646); DM_DATA is Tag
 *   Cancel's only (Ac_Stock.cs:824-828).
 * - Delete asks "Are You Sure To Delete This Voucher now?" (:5330-5360); Print prints TagCanBill (:5386-5440).
 * Each case seeds its own live tag (BAR_DETL + MAIN_STOCK '+', as a tag opening would) so cases never share one.
 */
const BOOK = 'SAJ';
const TENANT = 'feature-e2e';
const API = '/api/stock/stock-adjust';
const SIGN_REQUIRED = 'Please Insert Item Sign + or - then Try';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `stock-adjust.${id}`,
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
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-07-12`;
let seq = 0;

/** A live gold tag of the fixture item, in stock at location 01 for the current year. */
async function seedTag(ctx, { gross = 10.5, net = 10, touch = 91.6 } = {}) {
  seq += 1;
  const tag = `SAE${String(seq).padStart(5, '0')}`;
  const srno = 900200000000 + seq;
  const fine = Math.round(net * touch * 10) / 1000;
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_DATE",
       "BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE",
       "TBL_CODE","IT_TYPE","EMP_ISU")
     VALUES ($1::text,'01','01',$2::text,'TOP','09002',$3::float8,$3::float8,$4::date,'TAG OPENING','I',$5::text,$6::numeric,
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
     VALUES ($1::text,'01','01',$2::text,'TOP','09002',$3::float8,1,$4::date,$5::text,$6::text,$7::numeric,'P','+',1,1,
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
/** The signed loose net weight of an item, every book. */
const looseNet = async (ctx, itCode) =>
  Number(
    (
      await ctx.rows(
        `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_NWT" ELSE -"ITM_NWT" END),0)::text wt
           FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2 AND "TAG_NO"='N'`,
        itCode,
      )
    )[0]?.wt ?? 0,
  );
const adjRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"TAG_NO" tag,"IT_CODE" it,"ITM_SIGN" sign,coalesce("ITM_GWT",0)::float gwt,
            coalesce("ITM_NWT",0)::float nwt,coalesce("ITM_FINE",0)::float fine,coalesce("LOT_NO",'') lot
       FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const adjStock = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"TAG_NO" tag,"IT_CODE" it,"TR_TYPE" tr,"ITM_SIGN" sign,"VCH_TYPE" vt,"BOOK_NAME" bn,
            coalesce("ITM_NWT",0)::float nwt
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const vouchers = (ctx) =>
  ctx
    .rows(`SELECT count(*)::int n FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`)
    .then(([r]) => r.n);
const focusedLabel = (page) =>
  page.evaluate(
    () =>
      document.activeElement?.getAttribute('aria-label') ||
      document.activeElement?.textContent?.trim() ||
      '',
  );
const waitFocus = (page, label) =>
  page.waitForFunction(
    (want) => document.activeElement?.getAttribute('aria-label') === want,
    label,
  );
const cell = (page, label, line) => page.getByLabel(`${label} line ${line}`, { exact: true });
const alert = (page, text) => page.getByRole('alert').filter({ hasText: text }).waitFor();

async function open(ctx, user) {
  const session = await ctx.session(user);
  const { page } = session;
  await page.goto('/txn/stock-adjust');
  await page.getByRole('heading', { name: 'Stock Adjust', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned STOCK ADJUST book is selected');
  return { page, requests: session.requests };
}

async function pickTag(page, line, tag) {
  const input = cell(page, 'TagNo', line);
  await input.fill(tag);
  await input.locator('xpath=..').getByText(tag, { exact: true }).first().waitFor();
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === `${API}/source`),
    input.press('Enter'),
  ]);
  await page.waitForFunction(
    (n) => document.querySelector(`input[aria-label="ItCode line ${n}"]`)?.value,
    line,
  );
}

/** A loose line: Enter on the blank TagNo moves to ItCode (:3866), the item comes from its help, then the weights. */
async function looseLine(page, line, { gross, less = 0, touch = 0, sign }) {
  const tagBox = cell(page, 'TagNo', line);
  await tagBox.focus();
  await tagBox.press('Enter');
  await waitFocus(page, `ItCode line ${line}`);
  const item = cell(page, 'ItCode', line);
  await item.fill(ITEMS.gold.code);
  await item.locator('xpath=..').getByText(ITEMS.gold.code, { exact: true }).first().waitFor();
  await item.press('Enter');
  // The pick moves on to Counter (advanceOnPick), as the desktop's item help does.
  await waitFocus(page, `Counter line ${line}`);
  assert.equal(await item.inputValue(), ITEMS.gold.code);
  if (sign !== undefined) await cell(page, 'Sign', line).fill(sign);
  await cell(page, 'GrWt', line).fill(String(gross));
  await cell(page, 'GrWt', line).press('Enter');
  if (less) {
    await cell(page, 'LsWt', line).fill(String(less));
    await cell(page, 'LsWt', line).press('Enter');
  }
  if (touch) {
    await cell(page, 'Touch', line).fill(String(touch));
    await cell(page, 'Touch', line).press('Enter');
  }
}

async function save(page, method = 'POST') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === method &&
        /^\/api\/stock\/stock-adjust(\/\d+)?$/.test(new URL(r.url()).pathname),
    ),
    page.getByTestId('stock-adjust-save').click(),
  ]);
  return response;
}

async function reopen(page, voucherNo) {
  const box = page.getByLabel('Vch No', { exact: true });
  await box.fill(voucherNo);
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === `${API}/${voucherNo}`),
    box.press('Enter'),
  ]);
  await page
    .getByTestId('stock-adjust-status')
    .filter({ hasText: `Loaded voucher ${voucherNo}` })
    .waitFor();
}

/** A voucher with a + loose line of 10 g net and a - line of a fresh tag. */
async function createMixed(ctx, user) {
  const t = await seedTag(ctx, { gross: 9.5, net: 9 });
  const { page } = await open(ctx, user);
  await looseLine(page, 1, { gross: 10.5, less: 0.5, touch: 91.6, sign: '+' });
  await pickTag(page, 2, t.tag);
  await cell(page, 'Sign', 2).fill('-');
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const { voucherNo } = await response.json();
  return { page, t, voucherNo: String(voucherNo), response };
}

export const stockAdjust = {
  feature: 'stock-adjust',
  title: 'Other → Stock Adjust (TR_TAG_CAN, STOCK ADJUST)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/components/TagCancelForm.tsx',
    'web/apps/web/lib/tagCancelVoucher.ts',
    'web/apps/api/src/modules/stock/tagCancel.ts',
    'web/apps/api/src/modules/stock/tagCancelRows.ts',
    'web/apps/api/src/modules/stock/stockAdjustLots.ts',
    'web/apps/web/test/features/modules/stockAdjust.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'catalogue defaults; T15 turns CO_SET_NEW.PURC_LOT on and restores it',
  },
  cases: [
    C(
      'entry.stock-adjust-book-and-grid',
      'T01',
      'read-only',
      "MDI_FORM.cs:8616-8627 opens only CurBookHelp('STOCK ADJUST'); MSG_CLEAR (:2514-2566) the grid without LbrRate, LbrAmt and OthAmt, with Sign after Size, no lot columns while the lot settings are off",
      async (ctx) => {
        const { page } = await open(ctx);
        const books = await page
          .getByRole('combobox', { name: 'Configured book', exact: true })
          .locator('option')
          .evaluateAll((o) => o.map((x) => x.getAttribute('value')).filter(Boolean));
        assert.deepEqual(books, [BOOK]);
        const headers = (
          await page.getByTestId('stock-adjust-grid').locator('thead th').allInnerTexts()
        )
          .map((t) => t.trim())
          .filter(Boolean);
        for (const h of [
          'TagNo',
          'ItCode',
          'Size',
          'Sign',
          'BagWt',
          'GrWt',
          'NetWt',
          'Mrp',
          'KrCode',
        ])
          assert.ok(headers.includes(h), `grid shows ${h}: ${headers}`);
        for (const h of ['LbrRate', 'LbrAmt', 'OthAmt', 'TagLot', 'ItmLot', 'TrfrItm'])
          assert.ok(!headers.includes(h), `grid hides ${h}`);
        assert.equal(headers.indexOf('Sign'), headers.indexOf('Size') + 1, 'Sign follows Size');
        assert.equal(await page.getByTestId('stock-adjust-save').isDisabled(), true);
        await ctx.shot(page, 'entry');
        return {
          observation: `book ${books}; columns ${headers.join(' ')}`,
          expected: { books, headers },
        };
      },
    ),
    C(
      'branch.plus-tag-adds-stock',
      'T02',
      'mutation',
      "Ac_Stock.cs:53: a + line posts TR_TYPE 'I'; the tag stays an instance in stock, so its balance rises and its delete gives nothing back",
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        await pickTag(page, 1, t.tag);
        await cell(page, 'Sign', 1).fill('+');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const { voucherNo } = await response.json();
        const stock = await adjStock(ctx, voucherNo);
        assert.deepEqual(
          stock.map((r) => [r.tag, r.tr, r.sign, r.vt, r.bn]),
          [[t.tag, 'I', '+', 'STADJ', 'STOCK ADJUST']],
        );
        assert.equal(await balance(ctx, t.tag), 2);
        await reopen(page, voucherNo);
        await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'DELETE' &&
              new URL(r.url()).pathname === `${API}/${voucherNo}`,
          ),
          page.getByTestId('stock-adjust-delete').click(),
        ]);
        assert.equal(await balance(ctx, t.tag), 1);
        return {
          observation: `${t.tag} + made its balance 2; the delete brought it back to 1`,
          expected: 'I/+ STADJ row, balance 2 then 1',
          database: { stock },
          downstream: { balance: 1 },
        };
      },
    ),
    C(
      'formula.loose-net-and-fine',
      'T03',
      'mutation',
      'CommPassTotal (tagCancelRecompute): NetWt = GrWt - LsWt, Fine = NetWt x (Touch + West%) / 100; the register keeps what the grid shows',
      async (ctx) => {
        const { page } = await open(ctx);
        await looseLine(page, 1, { gross: 10.5, less: 0.5, touch: 91.6, sign: '+' });
        assert.equal(await cell(page, 'NetWt', 1).inputValue(), '10.000');
        assert.equal(await cell(page, 'Fine', 1).inputValue(), '9.160');
        const before = await looseNet(ctx, ITEMS.gold.code);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const { voucherNo } = await response.json();
        const lines = await adjRows(ctx, voucherNo);
        assert.deepEqual(
          lines.map((l) => [l.it, l.tag, l.sign, l.gwt, l.nwt, l.fine]),
          [[ITEMS.gold.code, 'N', '+', 10.5, 10, 9.16]],
        );
        const after = await looseNet(ctx, ITEMS.gold.code);
        assert.equal(Math.round((after - before) * 1000) / 1000, 10);
        return {
          observation: 'NetWt 10.000 and Fine 9.160 shown and stored; loose stock +10',
          expected: { net: 10, fine: 9.16 },
          database: { lines },
          downstream: { looseDelta: 10 },
        };
      },
    ),
    C(
      'lookup.tag-and-item-helps',
      'T04',
      'read-only',
      'TR_TAG_CAN.cs:3866-3960: the tag help lists live tags; a blank TagNo moves to ItCode, whose help lists the items',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const tagBox = cell(page, 'TagNo', 1);
        await tagBox.fill(t.tag.slice(0, 6));
        await tagBox.locator('xpath=..').getByText(t.tag, { exact: true }).first().waitFor();
        await tagBox.fill('');
        await tagBox.press('Enter');
        await waitFocus(page, 'ItCode line 1');
        const item = cell(page, 'ItCode', 1);
        await item.fill(ITEMS.gold.code.slice(0, 3).toLowerCase());
        await item
          .locator('xpath=..')
          .getByText(ITEMS.gold.code, { exact: true })
          .first()
          .waitFor();
        return {
          observation: `the tag help listed ${t.tag}; Enter on the blank tag went to ItCode; the item help listed ${ITEMS.gold.code}`,
          expected: 'both helps, and the blank-tag move',
        };
      },
    ),
    C(
      'children.lines-copy-the-sign',
      'T05',
      'mutation',
      "CommPassAdd (TR_TAG_CAN.cs:2835-2838): a new Stock Adjust row starts with the row above's sign; each line keeps its own",
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        await looseLine(page, 1, { gross: 2, sign: '-' });
        await pickTag(page, 2, t.tag);
        assert.equal(await cell(page, 'Sign', 2).inputValue(), '-', 'line 2 took the sign above');
        await looseLine(page, 3, { gross: 1.25 });
        assert.equal(await cell(page, 'Sign', 3).inputValue(), '-', 'line 3 took the sign above');
        await cell(page, 'Sign', 3).fill('+');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const { voucherNo } = await response.json();
        const lines = await adjRows(ctx, voucherNo);
        assert.deepEqual(
          lines.map((l) => [l.sr, l.tag, l.sign]),
          [
            [1, 'N', '-'],
            [2, t.tag, '-'],
            [3, 'N', '+'],
          ],
        );
        assert.equal(await balance(ctx, t.tag), 0);
        return {
          observation: 'three lines saved with - - +',
          expected: 'the copied signs and the changed one',
          database: { lines },
          downstream: { tagBalance: 0 },
        };
      },
    ),
    C(
      'required.sign-refusals',
      'T06',
      'refusal',
      'TEXT_ENTRY_KeyDown col 8 (TR_TAG_CAN.cs:4259-4263): Enter on a Sign that is not + or - says "Please Insert Item Sign + or - then Try"; the save refuses a line without one; nothing written',
      async (ctx) => {
        const before = await vouchers(ctx);
        const { page } = await open(ctx);
        await looseLine(page, 1, { gross: 3 });
        const sign = cell(page, 'Sign', 1);
        await sign.fill('x');
        await sign.press('Enter');
        await alert(page, SIGN_REQUIRED);
        assert.equal(await focusedLabel(page), 'Sign line 1');
        await sign.fill('');
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        assert.equal((await response.json()).message, SIGN_REQUIRED);
        await alert(page, SIGN_REQUIRED);
        assert.equal(await vouchers(ctx), before);
        return {
          observation: 'the Enter refusal kept the cursor; the save without a sign was refused',
          expected: SIGN_REQUIRED,
          database: { vouchers: before },
        };
      },
    ),
    C(
      'create.signed-register-and-stock',
      'T07',
      'mutation',
      'TR_TAG_CAN.cs:5103-5160 and Tag_Can_Stk (Ac_Stock.cs:53): the register keeps each sign; MAIN_STOCK gets I/+ and O/- rows under STADJ / STOCK ADJUST; no DM_DATA or LOT_DETL',
      async (ctx) => {
        const before = await looseNet(ctx, ITEMS.gold.code);
        const { voucherNo, t } = await createMixed(ctx);
        const lines = await adjRows(ctx, voucherNo);
        const stock = await adjStock(ctx, voucherNo);
        assert.deepEqual(
          lines.map((l) => [l.sr, l.tag, l.it, l.sign, l.nwt]),
          [
            [1, 'N', ITEMS.gold.code, '+', 10],
            [2, t.tag, ITEMS.gold.code, '-', 9],
          ],
        );
        assert.deepEqual(
          stock.map((r) => [r.sr, r.tag, r.tr, r.sign, r.vt, r.bn, r.nwt]),
          [
            [1, 'N', 'I', '+', 'STADJ', 'STOCK ADJUST', 10],
            [2, t.tag, 'O', '-', 'STADJ', 'STOCK ADJUST', 9],
          ],
        );
        const [extra] = await ctx.rows(
          `SELECT (SELECT count(*)::int FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2) dm,
                  (SELECT count(*)::int FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2) lot`,
          voucherNo,
        );
        assert.deepEqual(extra, { dm: 0, lot: 0 });
        assert.equal(await balance(ctx, t.tag), 0);
        const after = await looseNet(ctx, ITEMS.gold.code);
        assert.equal(Math.round((after - before) * 1000) / 1000, 10);
        return {
          observation: `voucher ${voucherNo}: +10 g loose and ${t.tag} out`,
          expected: 'signed register, I and O stock rows, no DM_DATA or LOT_DETL',
          database: { lines, stock, extra },
          downstream: { tagBalance: 0, looseDelta: 10 },
        };
      },
    ),
    C(
      'reopen.voucher-number-enter',
      'T08',
      'mutation',
      'TR_TAG_CAN.cs:4702-4880: Enter in Vch No reopens the saved lines with their signs and weights',
      async (ctx) => {
        const { page, voucherNo, t } = await createMixed(ctx);
        await page.getByTestId('stock-adjust-new').click();
        await reopen(page, voucherNo);
        const shown = [];
        for (const line of [1, 2])
          shown.push([
            await cell(page, 'TagNo', line).inputValue(),
            await cell(page, 'Sign', line).inputValue(),
            await cell(page, 'NetWt', line).inputValue(),
          ]);
        assert.deepEqual(shown, [
          ['', '+', '10.000'],
          [t.tag, '-', '9.000'],
        ]);
        return {
          observation: `reopened ${voucherNo}: ${JSON.stringify(shown)}`,
          expected: 'the saved lines',
          database: { lines: await adjRows(ctx, voucherNo) },
          downstream: { loaded: voucherNo },
        };
      },
    ),
    C(
      'edit.flip-a-sign',
      'T09',
      'mutation',
      "Save on a loaded voucher rewrites its lines and stock rows: a + line changed to - posts 'O' instead of 'I'",
      async (ctx) => {
        const before = await looseNet(ctx, ITEMS.gold.code);
        const { page, voucherNo, t } = await createMixed(ctx);
        await reopen(page, voucherNo);
        await cell(page, 'Sign', 1).fill('-');
        const response = await save(page, 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const stock = await adjStock(ctx, voucherNo);
        assert.deepEqual(
          stock.map((r) => [r.sr, r.tr, r.sign]),
          [
            [1, 'O', '-'],
            [2, 'O', '-'],
          ],
        );
        const after = await looseNet(ctx, ITEMS.gold.code);
        assert.equal(Math.round((after - before) * 1000) / 1000, -10);
        assert.equal(await balance(ctx, t.tag), 0);
        return {
          observation: `voucher ${voucherNo}: the loose line now takes 10 g out`,
          expected: 'O/- rows; loose stock -10',
          database: { stock },
          downstream: { looseDelta: -10, tagBalance: 0 },
        };
      },
    ),
    C(
      'delete.question-and-reversal',
      'T10',
      'mutation',
      'TR_TAG_CAN.cs:5330-5360: "Are You Sure To Delete This Voucher now?", then the register, stock rows and lots go; the tag is back in stock',
      async (ctx) => {
        const before = await looseNet(ctx, ITEMS.gold.code);
        const { page, voucherNo, t } = await createMixed(ctx);
        await reopen(page, voucherNo);
        const asked = [];
        page.removeAllListeners('dialog');
        page.on('dialog', (d) => {
          asked.push(d.message());
          void d.accept();
        });
        await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'DELETE' &&
              new URL(r.url()).pathname === `${API}/${voucherNo}`,
          ),
          page.getByTestId('stock-adjust-delete').click(),
        ]);
        assert.deepEqual(asked, ['Are You Sure To Delete This Voucher now?']);
        assert.deepEqual(await adjRows(ctx, voucherNo), []);
        assert.deepEqual(await adjStock(ctx, voucherNo), []);
        assert.equal(await balance(ctx, t.tag), 1);
        assert.equal(
          Math.round(((await looseNet(ctx, ITEMS.gold.code)) - before) * 1000) / 1000,
          0,
        );
        return {
          observation: `deleted ${voucherNo} after the question; ${t.tag} back in stock`,
          expected: 'no rows left, balance 1, loose stock as before',
          database: { lines: [], stock: [] },
          downstream: { tagBalance: 1 },
        };
      },
    ),
    C(
      'rights.no-stock-adjust-right',
      'T11',
      'refusal',
      "MS rights: a user without the Stock Adjust form right cannot list, save or print, and another tenant's voucher stays untouched",
      async (ctx) => {
        const { voucherNo } = await createMixed(ctx);
        const sentinelBefore = await ctx.owner.$queryRawUnsafe(
          `SELECT count(*)::int n FROM "BAR_CAN_DATA" WHERE tenant_id=$1`,
          SECOND_TENANT,
        );
        const clerk = await ctx.session(as(USERS.clerk.user));
        await clerk.page.goto('/txn/sales');
        const statuses = await clerk.page.evaluate(
          async ({ api, vch, book }) => {
            const list = await fetch(`${api}?coBook=${book}`, { credentials: 'include' });
            const create = await fetch(api, {
              method: 'POST',
              credentials: 'include',
              headers: { 'content-type': 'application/json' },
              body: JSON.stringify({
                coBook: book,
                lines: [{ itCode: 'X', itmSign: '+', grossWt: 1 }],
              }),
            });
            const print = await fetch(`${api}/${vch}/print?coBook=${book}&format=html`, {
              credentials: 'include',
            });
            return [list.status, create.status, print.status];
          },
          { api: API, vch: voucherNo, book: BOOK },
        );
        assert.deepEqual(statuses, [403, 403, 403]);
        const sentinelAfter = await ctx.owner.$queryRawUnsafe(
          `SELECT count(*)::int n FROM "BAR_CAN_DATA" WHERE tenant_id=$1`,
          SECOND_TENANT,
        );
        assert.deepEqual(sentinelAfter, sentinelBefore);
        return {
          observation: `clerk: list ${statuses[0]}, save ${statuses[1]}, print ${statuses[2]}`,
          expected: '403 for each, nothing written',
          database: { sentinel: sentinelAfter },
        };
      },
    ),
    C(
      'concurrency.two-operators-one-tag',
      'T12',
      'mutation',
      "Two operators adjusting the same tag out at once: the tag lock lets one voucher take it, the other is refused (the desktop's two saves would both post an O row)",
      async (ctx) => {
        const t = await seedTag(ctx);
        const a = (await open(ctx)).page;
        const b = (await open(ctx, as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
        for (const page of [a, b]) {
          await pickTag(page, 1, t.tag);
          await cell(page, 'Sign', 1).fill('-');
        }
        const before = await vouchers(ctx);
        const [first, second] = await Promise.all([save(a), save(b)]);
        const statuses = [first.status(), second.status()].sort();
        assert.equal(statuses[0], 201);
        assert.ok(statuses[1] >= 400, `the second save is refused: ${statuses}`);
        assert.equal(await vouchers(ctx), before + 1);
        assert.equal(await balance(ctx, t.tag), 0);
        return {
          observation: `statuses ${statuses.join(', ')}`,
          expected: 'one voucher, the tag out once',
          database: { vouchers: before + 1 },
          downstream: { tagBalance: 0 },
        };
      },
    ),
    C(
      'retry.replayed-tag-save',
      'T13',
      'mutation',
      'A replayed save of a tag line finds the tag already out and is refused; one voucher stays',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        await pickTag(page, 1, t.tag);
        await cell(page, 'Sign', 1).fill('-');
        const first = await save(page);
        assert.equal(first.status(), 201, await first.text());
        const before = await vouchers(ctx);
        const replay = await page.request.fetch(first.request());
        assert.ok(replay.status() >= 400, `replay refused: ${replay.status()}`);
        assert.equal(await vouchers(ctx), before);
        assert.equal(await balance(ctx, t.tag), 0);
        return {
          observation: `the replay answered ${replay.status()}`,
          expected: 'no second voucher',
          database: { vouchers: before },
          downstream: { tagBalance: 0 },
        };
      },
    ),
    C(
      'rollback.stock-write-fault',
      'T14',
      'mutation',
      'A fault on the stock write rolls the whole voucher back: no register rows, the tag still in stock',
      async (ctx) => {
        const t = await seedTag(ctx, { gross: 7.777, net: 7.777 });
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_stock_adjust_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN
             IF NEW."CO_BOOK" = '${BOOK}' AND NEW."ITM_NWT" = 7.777 THEN RAISE EXCEPTION 'e2e stock adjust fault'; END IF;
             RETURN NEW;
           END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_stock_adjust_fault BEFORE INSERT ON "MAIN_STOCK" FOR EACH ROW EXECUTE FUNCTION e2e_stock_adjust_fault()`,
        );
        try {
          const before = await vouchers(ctx);
          const { page } = await open(ctx);
          await pickTag(page, 1, t.tag);
          await cell(page, 'Sign', 1).fill('-');
          const response = await save(page);
          assert.ok(response.status() >= 400, `the save failed: ${response.status()}`);
          assert.equal(await vouchers(ctx), before);
          assert.equal(await balance(ctx, t.tag), 1);
          return {
            observation: `the save answered ${response.status()}; nothing kept`,
            expected: 'no voucher, the tag in stock',
            database: { vouchers: before },
            downstream: { tagBalance: 1 },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DROP TRIGGER IF EXISTS e2e_stock_adjust_fault ON "MAIN_STOCK"`,
          );
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_stock_adjust_fault()`);
        }
      },
    ),
    C(
      'settings.purchase-lot-tag-lot',
      'T15',
      'mutation',
      'MsPurcLot shows TagLot (MSG_CLEAR :2514-2526); its help lists LOT_DETL lots with a balance and fills the line (:4089-4135); StkAdj_Lot posts the signed LOT_DETL row (Ac_Stock.cs:642-646)',
      async (ctx) => {
        const lot = `E2ELT${String(Date.now() % 100000).padStart(5, '0')}`;
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "LOT_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
             "ENTRY_TYPE","IT_CODE","LOT_NO","IT_PCS","IT_GWT","IT_NWT","IT_SIGN")
           VALUES ($1,'01','01',$2,'PR','09003',1,$3::date,'L',$4,$5,2,6.5,6.2,'+')`,
          TENANT,
          YEAR,
          DAY,
          ITEMS.gold.code,
          lot,
        );
        const [{ n: hadRow }] = await ctx.rows(
          `SELECT count(*)::int n FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        const [{ v: previous } = { v: null }] = await ctx.rows(
          `SELECT "PURC_LOT" v FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01' LIMIT 1`,
        );
        if (hadRow)
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "CO_SET_NEW" SET "PURC_LOT"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            TENANT,
          );
        else
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","PURC_LOT") VALUES ($1,'01','Y')`,
            TENANT,
          );
        try {
          const { page } = await open(ctx);
          const headers = (
            await page.getByTestId('stock-adjust-grid').locator('thead th').allInnerTexts()
          ).map((t) => t.trim());
          assert.equal(
            headers.indexOf('TagLot'),
            headers.indexOf('TagNo') + 1,
            `TagLot after TagNo: ${headers}`,
          );
          const box = cell(page, 'TagLot', 1);
          await box.fill(lot.toLowerCase());
          await box.locator('xpath=..').getByText(lot, { exact: true }).first().waitFor();
          await box.press('Enter');
          await page.waitForFunction(
            () => document.querySelector('input[aria-label="GrWt line 1"]')?.value === '6.500',
          );
          const filled = {
            item: await cell(page, 'ItCode', 1).inputValue(),
            pcs: await cell(page, 'Pcs', 1).inputValue(),
            gross: await cell(page, 'GrWt', 1).inputValue(),
            less: await cell(page, 'LsWt', 1).inputValue(),
            net: await cell(page, 'NetWt', 1).inputValue(),
          };
          assert.deepEqual(filled, {
            item: ITEMS.gold.code,
            pcs: '2',
            gross: '6.500',
            less: '0.300',
            net: '6.200',
          });
          await cell(page, 'Sign', 1).fill('-');
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          const { voucherNo } = await response.json();
          const lots = await ctx.rows(
            `SELECT "LOT_NO" lot,"IT_CODE" it,"IT_SIGN" sign,"ENTRY_TYPE" et,"VCH_TYPE" vt,"IT_NWT"::float nwt
               FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
            voucherNo,
          );
          assert.deepEqual(lots, [
            { lot, it: ITEMS.gold.code, sign: '-', et: 'L', vt: 'STADJ', nwt: 6.2 },
          ]);
          const help = await (
            await page.request.get(`${API}/lots?kind=tag&q=${lot}&coBook=${BOOK}`)
          ).json();
          assert.deepEqual(help, [], 'the lot is used up, so its help leaves it out');
          return {
            observation: `TagLot ${lot} filled the line and the save posted its - LOT_DETL row`,
            expected: { filled, lots },
            database: { lots },
            downstream: { help },
          };
        } finally {
          if (hadRow)
            await ctx.owner.$executeRawUnsafe(
              `UPDATE "CO_SET_NEW" SET "PURC_LOT"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
              TENANT,
              previous,
            );
          else
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
              TENANT,
            );
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "LOT_DETL" WHERE tenant_id=$1 AND "LOT_NO"=$2 AND "CO_BOOK"='PR'`,
            TENANT,
            lot,
          );
        }
      },
    ),
    C(
      'print.tag-can-bill',
      'T16',
      'output',
      'TR_TAG_CAN.cs:5386-5440: TagCanBill for the Stock Adjust book: book name, ORIGINAL, the lines (TAG - item name on a tag line), Total, Vch Desc',
      async (ctx) => {
        const { page, voucherNo, t } = await createMixed(ctx);
        await reopen(page, voucherNo);
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByTestId('stock-adjust-print').click(),
        ]);
        await popup.waitForURL(/\/api\/stock\/stock-adjust\/\d+\/print/);
        await popup.waitForLoadState();
        const html = await popup.content();
        await ctx.shot(popup, 'tag-can-bill');
        await popup.close();
        for (const text of [
          'Stock Adjust',
          'ORIGINAL',
          'Vch No : ',
          'Item Name',
          ITEMS.gold.name,
          `${t.tag} - ${ITEMS.gold.name}`,
          '10.500',
          '9.000',
          'Total :',
        ])
          assert(html.includes(text), `TagCanBill shows ${text}`);
        return {
          observation: `TagCanBill for ${voucherNo}`,
          expected: 'the bill header, both lines and the total',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.enter-walk-and-alt-s',
      'T17',
      'mutation',
      'TEXT_ENTRY_KeyDown (TR_TAG_CAN.cs:3859-4300): Enter on a blank TagNo goes to ItCode, Enter walks the editable cells, the Sign refuses x, and &Save is Alt+S',
      async (ctx) => {
        const { page } = await open(ctx);
        await cell(page, 'TagNo', 1).focus();
        await page.keyboard.press('Enter');
        await waitFocus(page, 'ItCode line 1');
        await page.keyboard.type(ITEMS.gold.code);
        await cell(page, 'ItCode', 1)
          .locator('xpath=..')
          .getByText(ITEMS.gold.code, { exact: true })
          .first()
          .waitFor();
        await page.keyboard.press('Enter');
        await waitFocus(page, 'Counter line 1');
        await page.keyboard.press('Enter');
        await waitFocus(page, 'Design line 1');
        await page.keyboard.press('Enter');
        await waitFocus(page, 'Size line 1');
        await page.keyboard.press('Enter');
        await waitFocus(page, 'Sign line 1');
        await page.keyboard.type('x');
        await page.keyboard.press('Enter');
        await alert(page, SIGN_REQUIRED);
        assert.equal(await focusedLabel(page), 'Sign line 1');
        await page.keyboard.press('Backspace');
        await page.keyboard.type('+');
        await page.keyboard.press('Enter');
        await waitFocus(page, 'BagWt line 1');
        await page.keyboard.press('Enter');
        await waitFocus(page, 'Pcs line 1');
        await page.keyboard.press('Enter');
        await waitFocus(page, 'GrWt line 1');
        await page.keyboard.type('4.25');
        await page.keyboard.press('Enter');
        await waitFocus(page, 'LsWt line 1');
        await page.keyboard.press('Enter');
        assert.equal(await cell(page, 'NetWt', 1).inputValue(), '4.250');
        const before = await looseNet(ctx, ITEMS.gold.code);
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'POST' && new URL(r.url()).pathname === API,
          ),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        const after = await looseNet(ctx, ITEMS.gold.code);
        assert.equal(Math.round((after - before) * 1000) / 1000, 4.25);
        return {
          observation: 'the Enter walk reached GrWt through Sign; Alt+S saved +4.25 g',
          expected: 'every desktop key in order',
          database: { looseDelta: 4.25 },
          downstream: { saved: (await response.json()).voucherNo },
        };
      },
    ),
    C(
      'journey.adjusted-tag-leaves-the-sale-lookup',
      'T18',
      'mutation',
      'A tag adjusted out (O row) is not offered by the available-tags lookup every sale uses; its delete offers it again',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const offered = async () =>
          (
            await (await page.request.get(`/api/lookup/available-tags?q=${t.tag}&limit=10`)).json()
          ).some((r) => String(r.code ?? '').trim() === t.tag);
        assert.equal(await offered(), true);
        await pickTag(page, 1, t.tag);
        await cell(page, 'Sign', 1).fill('-');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const { voucherNo } = await response.json();
        assert.equal(await offered(), false, 'adjusted out');
        await reopen(page, voucherNo);
        await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'DELETE' &&
              new URL(r.url()).pathname === `${API}/${voucherNo}`,
          ),
          page.getByTestId('stock-adjust-delete').click(),
        ]);
        assert.equal(await offered(), true, 'offered again after the delete');
        return {
          observation: `${t.tag} left the sale lookup and came back after the delete`,
          expected: 'out, then in',
          database: { tagBalance: await balance(ctx, t.tag) },
          downstream: { offered: true },
        };
      },
    ),
  ],
};
