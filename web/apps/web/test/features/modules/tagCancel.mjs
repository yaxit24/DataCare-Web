import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

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
async function seedTag(
  ctx,
  { gross = 10.5, net = 10, touch = 91.6, counter = '001', component = false } = {},
) {
  seq += 1;
  const tag = `TCE${String(seq).padStart(5, '0')}`;
  const srno = 900100000000 + seq;
  const fine = Math.round(net * touch * 10) / 1000;
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_DATE",
       "BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE",
       "TBL_CODE","IT_TYPE","EMP_ISU")
     VALUES ($1::text,'01','01',$2::text,'TOP','09001',$3::float8,$3::float8,$4::date,'TAG OPENING','I',$5::text,$6::numeric,
             $7::text,1,$8::float8,$9::float8,$10::float8,$11::float8,$12::text,'G','N')`,
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
    counter,
  );
  if (component) {
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
         "BOOK_NAME","INOUT_TYPE","ENTRY_TYPE","TAG_NO","VCH_SRNO","IT_CODE","IT_TYPE","IT_PCS","IT_GWT","KR_WT",
         "IT_CON_PRC","IT_CON_WT","IT_RATE_TYPE","IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT","KR_CON_WT")
       VALUES ($1,'01','01',$2,'TOP','09001',$3,1,$4::date,'TAG OPENING','I','O',$5,$6,$7,'D',2,0.4,0.4,0,0.4,'W',100,40,0,0,40,0.4)`,
      TENANT,
      YEAR,
      seq,
      DAY,
      tag,
      srno,
      ITEMS.silver.code,
    );
  }
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
       "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
     VALUES ($1::text,'01','01',$2::text,'TOP','09001',$3::float8,1,$4::date,$5::text,$6::text,$7::numeric,'P','+',1,1,
             $8::float8,$9::float8,$10::float8)`,
    TENANT,
    YEAR,
    seq,
    DAY,
    ITEMS.gold.code,
    tag,
    srno,
    gross,
    net,
    fine,
  );
  return { tag, srno, gross, net, fine, counter, sourceLine: seq };
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
const json = (value) =>
  JSON.stringify(value, (_key, item) => (typeof item === 'bigint' ? item.toString() : item));
async function tenantSnapshot(ctx) {
  const tables = await ctx.owner.$queryRawUnsafe(
    `SELECT table_name name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id' AND table_name<>'audit_log'
      GROUP BY table_name ORDER BY table_name`,
  );
  const snapshot = {};
  for (const { name } of tables) {
    snapshot[name] = (await ctx.rows(`SELECT * FROM "${name}" WHERE tenant_id=$1`))
      .map(json)
      .sort();
  }
  return snapshot;
}
const auditSnapshot = (ctx) =>
  ctx.rows(
    `SELECT id::text id,login_name login,co_code company,action,path,status
       FROM audit_log WHERE tenant_id=$1 ORDER BY id`,
  );
async function assertAuditAppend(ctx, before, expected) {
  const beforeById = new Map(before.map((row) => [row.id, row]));
  const expectedCounts = new Map();
  for (const fact of expected) {
    const key = json(fact);
    expectedCounts.set(key, (expectedCounts.get(key) ?? 0) + 1);
  }
  const matched = (rows) => {
    const counts = new Map();
    for (const { id, ...fact } of rows) {
      if (beforeById.has(id)) continue;
      const key = json(fact);
      counts.set(key, (counts.get(key) ?? 0) + 1);
    }
    return [...expectedCounts].every(([key, count]) => (counts.get(key) ?? 0) >= count);
  };
  let after = [];
  const deadline = Date.now() + 5_000;
  do {
    after = await auditSnapshot(ctx);
    if (matched(after)) break;
    await new Promise((resolve) => setTimeout(resolve, 50));
  } while (Date.now() < deadline);

  const afterById = new Map(after.map((row) => [row.id, row]));
  for (const row of before) {
    assert.deepEqual(afterById.get(row.id), row, `existing audit row ${row.id} stays unchanged`);
  }
  const additions = after.filter((row) => !beforeById.has(row.id));
  assert.ok(matched(after), `required audit appends not found in ${json(additions)}`);
  const remaining = [...additions];
  const required = [];
  for (const expectedFact of expected) {
    const at = remaining.findIndex(({ id: _id, ...fact }) => json(fact) === json(expectedFact));
    assert.notEqual(at, -1, `missing audit append ${json(expectedFact)}`);
    required.push(remaining.splice(at, 1)[0]);
  }
  const duplicateExpectedFacts = remaining.filter(({ id: _id, ...fact }) =>
    expectedCounts.has(json(fact)),
  );
  assert.deepEqual(
    duplicateExpectedFacts,
    [],
    `unexpected duplicate audit facts ${json(duplicateExpectedFacts)}`,
  );
  for (const row of required) assert.match(row.id, /^[1-9][0-9]*$/);
  return required;
}
const sourceRows = (ctx, tag) =>
  ctx.rows(
    `SELECT source,row FROM (
       SELECT 'BAR_DETL' source,to_jsonb(b) row FROM "BAR_DETL" b WHERE tenant_id=$1 AND "TAG_NO"=$2
       UNION ALL SELECT 'BAR_IDTL',to_jsonb(i) FROM "BAR_IDTL" i WHERE tenant_id=$1 AND "TAG_NO"=$2
     ) x ORDER BY source`,
    tag,
  );
const writeCounts = async (ctx) => {
  const out = {};
  for (const table of [
    'TEMP_BOOK_DATA',
    'BAR_CAN_DATA',
    'BAR_CAN_DETL',
    'BAR_CAN_IDTL',
    'MAIN_STOCK',
    'DM_DATA',
  ]) {
    const [row] = await ctx.rows(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
    );
    out[table] = row.n;
  }
  return out;
};
const countDelta = (before, after) =>
  Object.fromEntries(Object.keys(after).map((table) => [table, after[table] - before[table]]));

async function tagStockApi(page, tab, counter) {
  const response = await page.request.get(
    `/api/reports/tag-stock?tab=${tab}&tblCode=${encodeURIComponent(counter)}`,
  );
  assert.equal(response.status(), 200, await response.text());
  return response.json();
}
async function openTagStock(page, counter) {
  await Promise.all([
    page.waitForResponse(
      (r) =>
        new URL(r.url()).pathname === '/api/reports/tag-stock' && r.request().method() === 'GET',
    ),
    page.keyboard.press('F12'),
  ]);
  await page.getByRole('heading', { name: 'Tag-Stock Report', exact: true }).waitFor();
  await page.getByLabel('Counter', { exact: true }).fill(counter);
  await Promise.all([
    page.waitForResponse((r) => {
      const url = new URL(r.url());
      return (
        url.pathname === '/api/reports/tag-stock' && url.searchParams.get('tblCode') === counter
      );
    }),
    page.getByRole('button', { name: 'Apply', exact: true }).click(),
  ]);
}
async function selectTagStockTab(page, tab, label, counter) {
  const button = page.getByRole('button', { name: label, exact: true });
  const alreadySelected = ((await button.getAttribute('class')) ?? '')
    .split(/\s+/)
    .includes('primary');
  await Promise.all([
    page.waitForResponse((r) => {
      const url = new URL(r.url());
      return (
        url.pathname === '/api/reports/tag-stock' &&
        url.searchParams.get('tab') === tab &&
        url.searchParams.get('tblCode') === counter
      );
    }),
    alreadySelected
      ? page.getByRole('button', { name: 'Apply', exact: true }).click()
      : button.click(),
  ]);
}
async function assertTagStock(page, tab, label, counter, expectedTags, expectedTotals) {
  await selectTagStockTab(page, tab, label, counter);
  const report = await tagStockApi(page, tab, counter);
  assert.deepEqual(report.rows.map((row) => row.tagNo).sort(), [...expectedTags].sort());
  assert.deepEqual(report.totals, expectedTotals);
  await page.waitForFunction(
    ({ activeLabel, tags, totals }) => {
      const active = [...document.querySelectorAll('button.primary')].some(
        (button) => button.textContent?.trim() === activeLabel,
      );
      const renderedTags = [...document.querySelectorAll('table.grid tbody tr')]
        .map((row) => row.querySelector('td')?.textContent?.trim() ?? '')
        .filter((tag) => tag && tag !== 'No tags for this view.')
        .sort();
      const kpis = [...document.querySelectorAll('.tile .kpi')].map((node) =>
        Number((node.textContent ?? '').replaceAll(',', '')),
      );
      return (
        active &&
        JSON.stringify(renderedTags) === JSON.stringify([...tags].sort()) &&
        kpis[0] === totals.count &&
        kpis[1] === totals.netWt &&
        kpis[2] === totals.fine &&
        kpis[3] === totals.mrp
      );
    },
    { activeLabel: label, tags: expectedTags, totals: expectedTotals },
  );
  const visible = await page
    .locator('table.grid tbody tr')
    .evaluateAll((rows) =>
      rows
        .map((row) => [...row.querySelectorAll('td')].map((cell) => cell.textContent.trim()))
        .filter((row) => row[0] && row[0] !== 'No tags for this view.'),
    );
  assert.deepEqual(visible.map((row) => row[0]).sort(), [...expectedTags].sort());
  const kpis = await page.locator('.tile .kpi').allInnerTexts();
  assert.equal(Number(kpis[0].replaceAll(',', '')), expectedTotals.count);
  assert.equal(Number(kpis[1].replaceAll(',', '')), expectedTotals.netWt);
  assert.equal(Number(kpis[2].replaceAll(',', '')), expectedTotals.fine);
  assert.equal(Number(kpis[3].replaceAll(',', '')), expectedTotals.mrp);
  return { report, visible };
}

async function openScreen(page) {
  await page.goto('/txn/tag-cancel');
  await page.getByRole('heading', { name: 'Tag Cancel', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned TAG CANCEL book is selected');
  return page;
}

async function open(ctx, who) {
  const { page } = await ctx.session(who);
  return openScreen(page);
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
    'web/apps/web/app/(app)/reports/tag-stock/page.tsx',
    'web/apps/api/src/modules/stock/tagCancel.ts',
    'web/apps/api/src/modules/stock/tagCancelBill.ts',
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
      'scope.caption-rights-exact',
      'T11',
      'refusal',
      "MDI_FORM.cs:7034-7046 and TR_TAG_CAN.cs:4403-4412,4980-4985,5342-5345,5390-5394: USER_SET is keyed by the exact 'Tag Cancel' caption and gates view/create, edit/delete and print.",
      async (ctx) => {
        const allowedTag = await seedTag(ctx);
        const deleteTag = await seedTag(ctx);
        const deniedTag = await seedTag(ctx);
        const user = USERS.clerk.user;
        const oldRows = await ctx.rows(
          `SELECT row_id::text id,"CO_CODE" co,"LC_CODE" lc,"MAIN_SRNO" main_srno,
                  "SUB_SRNO" sub_srno,"USER_NAME" user_name,"MAIN_MENU" main,"SUB_MENU" sub,
                  "FRM_VIEW" view,"FRM_EDIT" edit,"FRM_DELETE" del,"FRM_PRINT" print
             FROM "USER_SET" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
               AND "USER_NAME"=$2 AND "SUB_MENU" IN ('Tag Cancel','Tag Cancelled') ORDER BY row_id`,
          user,
        );
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
             AND "USER_NAME"=$2 AND "SUB_MENU" IN ('Tag Cancel','Tag Cancelled')`,
          TENANT,
          user,
        );
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES ($1,'01','01',$2,'Other','Tag Cancel','Y','Y','Y','Y')`,
          TENANT,
          user,
        );
        try {
          const { page } = await ctx.session(as(user, 'tag-cancel-caption-clerk'));
          const allowedAudit = await auditSnapshot(ctx);
          const source = await page.request.get(
            `/api/stock/tag-cancel/source?coBook=${BOOK}&tagNo=${allowedTag.tag}`,
          );
          assert.equal(source.status(), 200, await source.text());
          const created = await page.request.post('/api/stock/tag-cancel', {
            data: { coBook: BOOK, vchDate: DAY, lines: [{ tagNo: allowedTag.tag }] },
          });
          assert.equal(created.status(), 201, await created.text());
          const voucherNo = String((await created.json()).voucherNo);
          const list = await page.request.get(`/api/stock/tag-cancel?coBook=${BOOK}`);
          const read = await page.request.get(`/api/stock/tag-cancel/${voucherNo}?coBook=${BOOK}`);
          assert.equal(read.status(), 200, await read.text());
          const view = await read.json();
          const editPayload = {
            coBook: BOOK,
            vchDate: view.vchDate,
            vchDesc: 'RIGHTS EDIT',
            lines: view.lines.map((line) => ({
              tagNo: line.tagNo,
              vchSrno: line.vchSrno,
              oldSrNo: line.oldSrNo,
            })),
          };
          const updated = await page.request.put(`/api/stock/tag-cancel/${voucherNo}`, {
            data: editPayload,
          });
          const printed = await page.request.get(
            `/api/stock/tag-cancel/${voucherNo}/print?coBook=${BOOK}&format=html`,
          );
          const deleteCreated = await page.request.post('/api/stock/tag-cancel', {
            data: { coBook: BOOK, vchDate: DAY, lines: [{ tagNo: deleteTag.tag }] },
          });
          assert.equal(deleteCreated.status(), 201, await deleteCreated.text());
          const deleteVoucherNo = String((await deleteCreated.json()).voucherNo);
          const removed = await page.request.delete(
            `/api/stock/tag-cancel/${deleteVoucherNo}?coBook=${BOOK}`,
          );
          const allowed = [list, read, updated, printed, removed];
          assert.deepEqual(
            allowed.map((response) => response.status()),
            [200, 200, 200, 200, 200],
          );
          assert.match(await printed.text(), /Tag Cancel/);
          assert.equal(await balance(ctx, deleteTag.tag), 1);
          await assertAuditAppend(ctx, allowedAudit, [
            { login: user, company: '01', action: 'POST', path: '/stock/tag-cancel', status: 201 },
            {
              login: user,
              company: '01',
              action: 'PUT',
              path: '/stock/tag-cancel/:vchNo',
              status: 200,
            },
            { login: user, company: '01', action: 'POST', path: '/stock/tag-cancel', status: 201 },
            {
              login: user,
              company: '01',
              action: 'DELETE',
              path: '/stock/tag-cancel/:vchNo',
              status: 200,
            },
          ]);

          await ctx.owner.$executeRawUnsafe(
            `UPDATE "USER_SET" SET "SUB_MENU"='Tag Cancelled'
              WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
                AND "USER_NAME"=$2 AND "SUB_MENU"='Tag Cancel'`,
            TENANT,
            user,
          );
          const beforeDenied = await tenantSnapshot(ctx);
          const beforeDeniedAudit = await auditSnapshot(ctx);
          const deniedSource = await sourceRows(ctx, deniedTag.tag);
          const denied = [
            await page.request.get(`/api/stock/tag-cancel?coBook=${BOOK}`),
            await page.request.get(`/api/stock/tag-cancel/${voucherNo}?coBook=${BOOK}`),
            await page.request.get(
              `/api/stock/tag-cancel/source?coBook=${BOOK}&tagNo=${deniedTag.tag}`,
            ),
            await page.request.post('/api/stock/tag-cancel', {
              data: { coBook: BOOK, vchDate: DAY, lines: [{ tagNo: deniedTag.tag }] },
            }),
            await page.request.put(`/api/stock/tag-cancel/${voucherNo}`, {
              data: { ...editPayload, vchDesc: 'DENIED EDIT' },
            }),
            await page.request.delete(`/api/stock/tag-cancel/${voucherNo}?coBook=${BOOK}`),
            await page.request.get(
              `/api/stock/tag-cancel/${voucherNo}/print?coBook=${BOOK}&format=html`,
            ),
          ];
          assert.deepEqual(
            denied.map((response) => response.status()),
            [403, 403, 403, 403, 403, 403, 403],
          );
          await assertAuditAppend(ctx, beforeDeniedAudit, [
            { login: user, company: '01', action: 'POST', path: '/stock/tag-cancel', status: 403 },
            {
              login: user,
              company: '01',
              action: 'PUT',
              path: '/stock/tag-cancel/:vchNo',
              status: 403,
            },
            {
              login: user,
              company: '01',
              action: 'DELETE',
              path: '/stock/tag-cancel/:vchNo',
              status: 403,
            },
          ]);
          assert.deepEqual(await tenantSnapshot(ctx), beforeDenied);
          assert.deepEqual(await sourceRows(ctx, deniedTag.tag), deniedSource);
          assert.equal(await balance(ctx, allowedTag.tag), 0);
          assert.equal(await balance(ctx, deleteTag.tag), 1);
          assert.equal(await balance(ctx, deniedTag.tag), 1);
          const foreign = await ctx.owner.$queryRawUnsafe(
            `SELECT "AC_NAME" name,"NET_AMT"::float net FROM "SL_DATA" WHERE tenant_id=$1`,
            SECOND_TENANT,
          );
          assert.deepEqual(foreign, [{ name: 'SENTINEL', net: 111 }]);
          return {
            observation: `exact caption allowed source/create/list/view/edit/print/delete; near miss returned ${denied.map((response) => response.status()).join('/')}`,
            expected: 'exact Tag Cancel grants configured actions; near-miss caption grants none',
            database: { deniedNoWrite: true, balances: [0, 1, 1], foreign },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
               AND "USER_NAME"=$2 AND "SUB_MENU" IN ('Tag Cancel','Tag Cancelled')`,
            TENANT,
            user,
          );
          for (const row of oldRows) {
            await ctx.owner.$executeRawUnsafe(
              `INSERT INTO "USER_SET"(tenant_id,row_id,"CO_CODE","LC_CODE","MAIN_SRNO","SUB_SRNO","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
               VALUES ($1,$2::bigint,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13)`,
              TENANT,
              row.id,
              row.co,
              row.lc,
              row.main_srno,
              row.sub_srno,
              row.user_name,
              row.main,
              row.sub,
              row.view,
              row.edit,
              row.del,
              row.print,
            );
          }
        }
      },
    ),
    C(
      'concurrency.two-browsers-one-tag',
      'T12',
      'mutation',
      'TR_TAG_CAN.cs:4950-5290 writes one cancel owner; signed MAIN_STOCK makes the same source unavailable after the winning transaction.',
      async (ctx) => {
        const tag = await seedTag(ctx);
        const sourceBefore = await sourceRows(ctx, tag.tag);
        const before = await writeCounts(ctx);
        const a = await open(ctx);
        const second = await ctx.session(
          as(USERS.admin.user, `${USERS.admin.user}#tag-cancel-race`),
        );
        await second.page.goto('/txn/tag-cancel');
        await second.page.getByRole('heading', { name: 'Tag Cancel', exact: true }).waitFor();
        const secondBook = second.page.getByRole('combobox', {
          name: 'Configured book',
          exact: true,
        });
        await secondBook.selectOption(BOOK);
        await Promise.all([pickTag(a, 1, tag.tag), pickTag(second.page, 1, tag.tag)]);
        const responses = await Promise.all([save(a), save(second.page)]);
        assert.deepEqual(
          responses.map((response) => response.status()).sort((x, y) => x - y),
          [201, 400],
        );
        const winner = responses.find((response) => response.status() === 201);
        const loser = responses.find((response) => response.status() !== 201);
        assert.ok(winner && loser);
        assert.match(await loser.text(), /TagNotAvailableError|not available/i);
        const voucherNo = String((await winner.json()).voucherNo);
        const after = await writeCounts(ctx);
        assert.deepEqual(countDelta(before, after), {
          TEMP_BOOK_DATA: 1,
          BAR_CAN_DATA: 1,
          BAR_CAN_DETL: 1,
          BAR_CAN_IDTL: 0,
          MAIN_STOCK: 1,
          DM_DATA: 0,
        });
        const owners = await ctx.rows(
          `SELECT h."VCH_NO" voucher,d."TAG_NO" tag,s."TR_TYPE" tr,s."ITM_SIGN" sign
             FROM "BAR_CAN_DATA" h JOIN "BAR_CAN_DETL" d USING (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO")
             JOIN "MAIN_STOCK" s ON s.tenant_id=d.tenant_id AND s."CO_CODE"=d."CO_CODE" AND s."LC_CODE"=d."LC_CODE"
               AND s."CO_YEAR"=d."CO_YEAR" AND s."CO_BOOK"=d."CO_BOOK" AND s."VCH_NO"=d."VCH_NO" AND s."TAG_NO"=d."TAG_NO"
            WHERE h.tenant_id=$1 AND h."CO_BOOK"='${BOOK}' AND d."TAG_NO"=$2`,
          tag.tag,
        );
        assert.deepEqual(owners, [{ voucher: voucherNo, tag: tag.tag, tr: 'O', sign: '-' }]);
        assert.equal(await balance(ctx, tag.tag), 0);
        assert.deepEqual(await sourceRows(ctx, tag.tag), sourceBefore);
        const listing = await a.request.get(`/api/stock/tag-cancel?coBook=${BOOK}`);
        assert.equal(listing.status(), 200, await listing.text());
        assert.equal(
          (await listing.json()).nextVoucherNo,
          String(Number(voucherNo) + 1).padStart(5, '0'),
        );
        const numbers = await ctx.rows(
          `SELECT 'visible' kind,"VCH_NO" no FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2
           UNION ALL SELECT 'hidden',"VCH_NO" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2
           ORDER BY kind`,
          voucherNo,
        );
        assert.deepEqual(numbers, [
          { kind: 'hidden', no: voucherNo },
          { kind: 'visible', no: voucherNo },
        ]);
        return {
          observation: `concurrent saves ${responses.map((response) => response.status()).join('/')}; ${voucherNo} alone owns ${tag.tag}`,
          expected: 'one 201, one refusal, one visible and hidden number, one O/- row',
          database: { owners, numbers, delta: countDelta(before, after) },
          downstream: { balance: 0 },
        };
      },
    ),
    C(
      'concurrency.two-operators-one-tag',
      'T12',
      'mutation',
      'Two operators cancelling the same tag at once: the tag lock lets one voucher take it, the other is refused',
      async (ctx) => {
        const t = await seedTag(ctx);
        const a = await open(ctx);
        const b = await open(ctx, as(USERS.admin.user, `${USERS.admin.user}#2`));
        for (const page of [a, b]) await pickTag(page, 1, t.tag);
        const before = await vouchers(ctx);
        const [first, second] = await Promise.all([save(a), save(b)]);
        const statuses = [first.status(), second.status()].sort();
        assert.equal(statuses[0], 201, `statuses ${statuses}`);
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
      'retry.replayed-save',
      'T13',
      'mutation',
      'A replayed save finds the tag already cancelled and is refused; one voucher stays (the desktop has no idempotency key either)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const page = await open(ctx);
        await pickTag(page, 1, t.tag);
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
      'A fault on the stock write rolls the whole cancel voucher back: no header, no lines, the tag still in stock',
      async (ctx) => {
        const t = await seedTag(ctx, { gross: 7.777, net: 7.777 });
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_tag_cancel_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN
             IF NEW."CO_BOOK" = '${BOOK}' AND NEW."ITM_NWT" = 7.777 THEN RAISE EXCEPTION 'e2e tag cancel fault'; END IF;
             RETURN NEW;
           END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_tag_cancel_fault BEFORE INSERT ON "MAIN_STOCK" FOR EACH ROW EXECUTE FUNCTION e2e_tag_cancel_fault()`,
        );
        try {
          const before = await vouchers(ctx);
          const page = await open(ctx);
          await pickTag(page, 1, t.tag);
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
            `DROP TRIGGER IF EXISTS e2e_tag_cancel_fault ON "MAIN_STOCK"`,
          );
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_tag_cancel_fault()`);
        }
      },
    ),
    C(
      'rollback.deepest-dm-data',
      'T14',
      'mutation',
      'TR_TAG_CAN.cs:4950-5290: a component whose item posts other detail reaches DM_DATA after register, detail, component and stock writes; the whole save must roll back.',
      async (ctx) => {
        const [setting] = await ctx.rows(
          `SELECT "OTH_DETL_POSTING" value FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
          ITEMS.silver.code,
        );
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "ITEM_MAST" SET "OTH_DETL_POSTING"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
          TENANT,
          ITEMS.silver.code,
        );
        const tag = await seedTag(ctx, { gross: 6.75, net: 6.25, component: true });
        const functionName = 'e2e_tag_cancel_dm_fault';
        const triggerName = 'e2e_tag_cancel_dm_fault';
        try {
          await ctx.owner.$executeRawUnsafe(
            `CREATE FUNCTION ${functionName}() RETURNS trigger LANGUAGE plpgsql AS $fault$
             BEGIN
               IF NEW.tenant_id='${TENANT}' AND NEW."TAG_NO"='${tag.tag}' THEN
                 RAISE EXCEPTION 'e2e tag cancel fault after DM_DATA';
               END IF;
               RETURN NEW;
             END $fault$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER ${triggerName} AFTER INSERT ON "DM_DATA" FOR EACH ROW EXECUTE FUNCTION ${functionName}()`,
          );
          const page = await open(ctx);
          await pickTag(page, 1, tag.tag);
          const before = await tenantSnapshot(ctx);
          const beforeAudit = await auditSnapshot(ctx);
          const beforeCounts = await writeCounts(ctx);
          const failed = await save(page);
          assert.ok(failed.status() >= 400, await failed.text());
          assert.deepEqual(await tenantSnapshot(ctx), before);
          await assertAuditAppend(ctx, beforeAudit, [
            {
              login: USERS.admin.user,
              company: '01',
              action: 'POST',
              path: '/stock/tag-cancel',
              status: failed.status(),
            },
          ]);
          assert.equal(await balance(ctx, tag.tag), 1);
          await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS ${triggerName} ON "DM_DATA"`);
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS ${functionName}()`);
          const retried = await save(page);
          assert.equal(retried.status(), 201, await retried.text());
          const voucherNo = String((await retried.json()).voucherNo);
          const afterCounts = await writeCounts(ctx);
          assert.deepEqual(countDelta(beforeCounts, afterCounts), {
            TEMP_BOOK_DATA: 1,
            BAR_CAN_DATA: 1,
            BAR_CAN_DETL: 1,
            BAR_CAN_IDTL: 1,
            MAIN_STOCK: 1,
            DM_DATA: 1,
          });
          return {
            observation: `DM_DATA trigger failed the complete save; retry used ${voucherNo}`,
            expected: 'exact pre-save tenant after the fault; one complete voucher after retry',
            database: { rollback: true, voucherNo, delta: countDelta(beforeCounts, afterCounts) },
            downstream: { balance: await balance(ctx, tag.tag) },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS ${triggerName} ON "DM_DATA"`);
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS ${functionName}()`);
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "ITEM_MAST" SET "OTH_DETL_POSTING"=$3 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
            TENANT,
            ITEMS.silver.code,
            setting?.value ?? null,
          );
        }
      },
    ),
    notApplicable(
      'settings',
      'T15',
      'TR_TAG_CAN.cs:2514-2535',
      'Only the STOCK ADJUST book reads MsPurcLot and MsItmWitLotStk (TagLot / ItmLot columns); the TAG CANCEL book has no company-setting variant. The setting columns are tested in the stock-adjust module (T15).',
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
      'output.tag-stock-after-create',
      'T16',
      'output',
      'TR_TAG_CAN.cs:4950-5290 and Ac_Stock: Tag Cancel writes TGCAN O/-; Tag Stock derives Out from signed MAIN_STOCK and In Stock from retained BAR_DETL availability.',
      async (ctx) => {
        const counter = 'C16';
        const tag = await seedTag(ctx, { gross: 7.5, net: 7.25, touch: 80, counter });
        const { page, voucherNo } = await create(ctx, [tag]);
        await openTagStock(page, counter);
        const stock = await assertTagStock(page, 'stock', 'In Stock', counter, [], {
          count: 0,
          pcs: 0,
          netWt: 0,
          fine: 0,
          mrp: 0,
        });
        const out = await assertTagStock(page, 'out', 'Out', counter, [tag.tag], {
          count: 1,
          pcs: 1,
          netWt: 7.25,
          fine: 5.8,
          mrp: 0,
        });
        const [{ d: savedDate }] = await ctx.rows(
          `SELECT "VCH_DATE"::date::text d FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 LIMIT 1`,
          voucherNo,
        );
        assert.deepEqual(out.report.rows, [
          {
            tagNo: tag.tag,
            itCode: ITEMS.gold.code,
            designNo: '',
            tblCode: counter,
            vchType: 'TGCAN',
            vchDate: savedDate,
            pcs: 1,
            grossWt: 7.5,
            netWt: 7.25,
            fine: 5.8,
            mrp: 0,
          },
        ]);
        return {
          observation: `${tag.tag} absent from In Stock and present once in Out as TGCAN for ${voucherNo}`,
          expected: 'In Stock zero; Out one tag, 7.25 net and 5.8 fine',
          output: { stock: stock.visible, out: out.visible, totals: out.report.totals },
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
    C(
      'journey.tag-stock-create-edit-delete',
      'T18',
      'mutation',
      'TR_TAG_CAN.cs:4950-5290,5331-5362: create/edit rebuild the current TGCAN O/- rows and delete removes them; retained BAR_DETL makes every released source tag live in Tag Stock again.',
      async (ctx) => {
        const counter = 'J18';
        const first = await seedTag(ctx, { gross: 4.5, net: 4, touch: 91.6, counter });
        const kept = await seedTag(ctx, { gross: 6.25, net: 6, touch: 75, counter });
        const { page, voucherNo } = await create(ctx, [first, kept]);
        await openTagStock(page, counter);
        const createdStock = await assertTagStock(page, 'stock', 'In Stock', counter, [], {
          count: 0,
          pcs: 0,
          netWt: 0,
          fine: 0,
          mrp: 0,
        });
        const createdOut = await assertTagStock(
          page,
          'out',
          'Out',
          counter,
          [first.tag, kept.tag],
          { count: 2, pcs: 2, netWt: 10, fine: 8.164, mrp: 0 },
        );
        assert.ok(createdOut.report.rows.every((row) => row.vchType === 'TGCAN'));

        const added = await seedTag(ctx, { gross: 8, net: 7.5, touch: 80, counter });
        await openScreen(page);
        await reopen(page, voucherNo);
        await page.getByLabel('TagNo line 1', { exact: true }).click();
        await page.keyboard.press('Control+d');
        await page.getByLabel('TagNo line 1', { exact: true }).waitFor();
        assert.equal(await page.getByLabel('TagNo line 1', { exact: true }).inputValue(), kept.tag);
        await pickTag(page, 2, added.tag);
        const edited = await save(page, 'PUT');
        assert.equal(edited.status(), 200, await edited.text());
        await openTagStock(page, counter);
        const editedStock = await assertTagStock(page, 'stock', 'In Stock', counter, [first.tag], {
          count: 1,
          pcs: 1,
          netWt: 4,
          fine: 3.664,
          mrp: 0,
        });
        const editedOut = await assertTagStock(page, 'out', 'Out', counter, [kept.tag, added.tag], {
          count: 2,
          pcs: 2,
          netWt: 13.5,
          fine: 10.5,
          mrp: 0,
        });
        assert.ok(editedOut.report.rows.every((row) => row.vchType === 'TGCAN'));

        await openScreen(page);
        await reopen(page, voucherNo);
        const [removed] = await Promise.all([
          page.waitForResponse(
            (response) =>
              response.request().method() === 'DELETE' &&
              new URL(response.url()).pathname === `/api/stock/tag-cancel/${voucherNo}`,
          ),
          page.getByTestId('tag-cancel-delete').click(),
        ]);
        assert.equal(removed.status(), 200, await removed.text());
        await openTagStock(page, counter);
        const deletedStock = await assertTagStock(
          page,
          'stock',
          'In Stock',
          counter,
          [first.tag, kept.tag, added.tag],
          { count: 3, pcs: 3, netWt: 17.5, fine: 14.164, mrp: 0 },
        );
        const deletedOut = await assertTagStock(page, 'out', 'Out', counter, [], {
          count: 0,
          pcs: 0,
          netWt: 0,
          fine: 0,
          mrp: 0,
        });
        assert.deepEqual(await cancelRows(ctx, voucherNo), []);
        assert.deepEqual(
          await Promise.all([first, kept, added].map((tag) => balance(ctx, tag.tag))),
          [1, 1, 1],
        );
        return {
          observation: `create ${first.tag}/${kept.tag}; edit dropped ${first.tag} and added ${added.tag}; delete restored all three`,
          expected: 'only current cancel tags are Out; released BAR_DETL tags are In Stock',
          database: { deletedCancelRows: [], balances: [1, 1, 1] },
          downstream: {
            created: { stock: createdStock.report, out: createdOut.report },
            edited: { stock: editedStock.report, out: editedOut.report },
            deleted: { stock: deletedStock.report, out: deletedOut.report },
          },
        };
      },
    ),
    C(
      'journey.cancelled-tag-leaves-the-sale-lookup',
      'T18',
      'mutation',
      'A cancelled tag (O row) is not offered by the available-tags lookup every sale uses; the voucher delete offers it again (the Tag Stock report reads the same rows)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const page = await open(ctx);
        const offered = async () =>
          (
            await (await page.request.get(`/api/lookup/available-tags?q=${t.tag}&limit=10`)).json()
          ).some((r) => String(r.code ?? '').trim() === t.tag);
        assert.equal(await offered(), true);
        await pickTag(page, 1, t.tag);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const { voucherNo } = await response.json();
        assert.equal(await offered(), false, 'cancelled');
        await reopen(page, String(voucherNo));
        await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'DELETE' &&
              new URL(r.url()).pathname === `/api/stock/tag-cancel/${voucherNo}`,
          ),
          page.getByTestId('tag-cancel-delete').click(),
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
