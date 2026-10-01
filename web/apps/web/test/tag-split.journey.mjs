import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { expectRows } from './journeySql.mjs';

/**
 * N19 (X20) real-browser journey: desktop TR_TAG_SPLIT on a TAG SPLIT book, driven through the screen alone, with
 * every stored row read back from the database independently of the web code.
 *
 * A whole ring (parent) is split into two half rings that conserve its fine; a child carries a diamond stone; the
 * conservation banner tracks the difference; the short-split guard refuses a save with no absorbing account; the
 * saved voucher is read back (LBR_DATA/LBR_ISU_DETL/LBR_ISU_IDTL/LBR_REC_DETL, BAR_DATA/BAR_DETL/BAR_IDTL,
 * MAIN_STOCK, DM_DATA, TEMP_BOOK_DATA), reopened by number, listed, and deleted — the delete audits each parent
 * line to DELETE_DATA and gives the parent back. The child tags are freshly minted, sellable BAR_DETL tags.
 *
 * The source parent tag — BAR_DETL, BAR_IDTL and its photograph — must never change.
 *
 * Expected figures are the desktop's, from TR_TAG_SPLIT.cs (`CommPassTotal_Pr`), Ac_Stock.cs (`Tag_Split_Stk`,
 * `Dm_Tag_Split_Detl`) and Ac_Ledr.cs (`Tag_Split_Ledr`).
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md.
 */
export const tagSplitFixtureTables = [
  'DM_DATA',
  'BAR_IDTL',
  'BAR_DETL',
  'LBR_ISU_IDTL',
  'LBR_ISU_DETL',
  'LBR_REC_DETL',
  'LBR_DATA',
  'MAIN_STOCK',
  'EMP_MAST',
];

const photo = readFileSync(
  new URL('../../api/test/fixtures/order-tag-landscape.jpg', import.meta.url),
);
const BOOKS = ['SPL'];
const SOURCE_BOOKS = ['STO', 'SSL'];
const ITEMS = ['SRNG', 'SRNGH', 'SDIA'];
const D = (iso) => new Date(`${iso}T00:00:00.000Z`);

const bar = (over) => ({
  CO_CODE: '01',
  LC_CODE: '01',
  CO_YEAR: '2024-2025',
  CO_BOOK: 'STO',
  VCH_NO: '00001',
  VCH_DATE: D('2024-04-05'),
  VCH_TYPE: 'TAGOP',
  BOOK_NAME: 'TAG OPBL',
  INOUT_TYPE: 'I',
  ENTRY_TYPE: 'O',
  IT_CODE: 'SRNG',
  TBL_CODE: '001',
  ITM_PCS: 1,
  BAG_WT: 0,
  ITM_OTH_WT: 0,
  ITM_GHT_PRC: 0,
  ITM_GHT_WT: 0,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 0,
  LBR_TYPE: 'G',
  LBR_RATE: 0,
  LBR_AMT: 0,
  OTH_AMT: 0,
  ITM_RATE: 0,
  ITM_AMT: 0,
  ITM_MRP: 0,
  KR_TOUCH: 91.6,
  KR_WEST_PRC: 0,
  RATE_TYPE: '',
  IT_TYPE: 'G',
  TAG_TYPE: 'R',
  PR_CODE: 'SR',
  EMP_ISU: 'N',
  DATA_TYPE: 'A',
  ...over,
});

const TAGS = [
  // The whole ring to split: net 10, fine 9.16, with a diamond stone and a photograph.
  bar({
    SR_NO: 1,
    OLD_SRNO: 1,
    TAG_NO: 'STAG001',
    VCH_SRNO: 930000001,
    DESIGN_NO: 'D-1',
    ITM_SIZE: '12',
    ITM_GWT: 10,
    ITM_NWT: 10,
    ITM_FINE: 9.16,
    KR_NAME: 'KJ',
    KR_NET_WT: 10,
    KR_FINE: 9.16,
    DESIGN_IMG_ID: 'IMG-1',
  }),
  // A sold ring: its stock balance is zero, so it cannot be split.
  bar({
    SR_NO: 2,
    OLD_SRNO: 2,
    TAG_NO: 'STAG009',
    VCH_SRNO: 930000009,
    ITM_GWT: 4,
    ITM_NWT: 4,
    ITM_FINE: 3.664,
    KR_NET_WT: 4,
    KR_FINE: 3.664,
  }),
];

async function insert(sql, table, row) {
  const columns = Object.keys(row);
  await sql(
    `INSERT INTO "${table}"(tenant_id,${columns.map((c) => `"${c}"`).join(',')})
     VALUES($1,${columns.map((_, i) => `$${i + 2}`).join(',')})`,
    ...columns.map((c) => row[c]),
  );
}

export async function seedTagSplit(sql) {
  await cleanupTagSplit(sql);
  // Trade fine on: any absorbing ledger's mirror legs need it (not exercised here, but the fixture is faithful).
  await expectRows(
    1,
    sql(`UPDATE "CO_SET" SET "TRAD_FINE"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`),
    'company 01 CO_SET row',
  );
  await insert(sql, 'BOOK_DATA', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_BOOK: 'SPL',
    BOOK_NAME: 'Tag Split',
    BOOK_SNAME: 'TGSPL',
    MAIN_BOOK: 'TAG SPLIT',
    BOOK_INOUT: 'O',
    CUR_USE: 'Y',
    BOOK_TBL_NAME: 'LBR_DATA',
  });
  await insert(sql, 'BOOK_DETL', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_BOOK: 'SPL',
    SR_NO: 5,
    AC_CODE: 'LBREXP',
  });
  for (const [code, name, type, pr, tagType, postsDiamonds] of [
    ['SRNG', 'Split Ring 22K', 'G', 'SR', 'R', 'N'],
    ['SRNGH', 'Split Half Ring', 'G', 'RH', 'H', 'N'],
    ['SDIA', 'Split Diamond', 'D', 'SD', 'R', 'Y'],
  ])
    await insert(sql, 'ITEM_MAST', {
      CO_CODE: '01',
      IT_CODE: code,
      IT_NAME: name,
      IT_TYPE: type,
      PR_CODE: pr,
      TAG_TYPE: tagType,
      RATE_TYPE: type === 'D' ? 'W' : '',
      OTH_DETL_POSTING: postsDiamonds,
    });
  await insert(sql, 'EMP_MAST', { CO_CODE: '01', EMP_CODE: '930', EMP_NAME: 'Split Karigar' });
  for (const tag of TAGS) {
    await insert(sql, 'BAR_DETL', tag);
    await insert(sql, 'MAIN_STOCK', {
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: '2024-2025',
      CO_BOOK: 'STO',
      VCH_NO: '00001',
      SR_NO: tag.SR_NO,
      ISR_NO: 1,
      VCH_DATE: D('2024-04-05'),
      STK_DATE: '2024-04-05',
      VCH_TYPE: 'TAGOP',
      BOOK_NAME: 'TAG OPBL',
      IT_CODE: tag.IT_CODE,
      TAG_NO: tag.TAG_NO,
      VCH_SRNO: tag.VCH_SRNO,
      TBL_CODE: tag.TBL_CODE,
      TR_TYPE: 'P',
      ITM_SIGN: '+',
      ITM_QTY: 1,
      ITM_PCS: 1,
      ITM_GWT: tag.ITM_GWT,
      ITM_NWT: tag.ITM_NWT,
      ITM_FINE: tag.ITM_FINE,
      DATA_TYPE: 'A',
    });
  }
  // STAG009 was sold: a '-' balances its '+'.
  await insert(sql, 'MAIN_STOCK', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'SSL',
    VCH_NO: '00007',
    SR_NO: 1,
    ISR_NO: 1,
    VCH_DATE: D('2024-05-01'),
    STK_DATE: '2024-05-01',
    VCH_TYPE: 'TGSL',
    BOOK_NAME: 'SALES',
    IT_CODE: 'SRNG',
    TAG_NO: 'STAG009',
    VCH_SRNO: 930000009,
    TBL_CODE: '001',
    TR_TYPE: 'S',
    ITM_SIGN: '-',
    ITM_QTY: 1,
    ITM_PCS: 1,
    ITM_GWT: 4,
    ITM_NWT: 4,
    ITM_FINE: 3.664,
    DATA_TYPE: 'A',
  });
  // The parent's diamond stone (an OTH_DETL_POSTING item, so the split posts the diamond register).
  await insert(sql, 'BAR_IDTL', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'STO',
    VCH_NO: '00001',
    SR_NO: 1,
    ISR_NO: 1,
    VCH_DATE: D('2024-04-05'),
    VCH_TYPE: 'TAGOP',
    BOOK_NAME: 'TAG OPBL',
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    TAG_NO: 'STAG001',
    VCH_SRNO: 930000001,
    IT_CODE: 'SDIA',
    IT_TYPE: 'D',
    IT_PCS: 10,
    IT_GWT: 0.5,
    KR_WT: 0.5,
    IT_CON_PRC: 1,
    IT_CON_WT: 0.5,
    IT_RATE_TYPE: 'W',
    IT_RATE: 2000,
    IT_AMT: 1000,
    IT_NET_AMT: 1000,
    KR_CON_WT: 0.5,
  });
  // The parent's photograph, keyed on the instance.
  await insert(sql, 'ENTITY_IMAGE', {
    CO_CODE: '01',
    LC_CODE: '01',
    ENTITY_TYPE: 'TAG',
    ENTITY_KEY: 'STAG001',
    INSTANCE: 930000001,
    IMAGE_TYPE: 'T',
    MIME_TYPE: 'image/jpeg',
    IMAGE_SIZE: photo.length,
    IMAGE_BYTES: photo,
  });
  // Nudge the tag serial counter high so children get recognisable numbers (RH9001, RH9002). The first tag
  // allocation creates SRNO_MAST lazily (vouchers/numbering.ts nextTagNoTx), so a clean database has no row to
  // update: upsert the exact (tenant, company, location) counter row, shaped like the lazily created one.
  await expectRows(
    1,
    sql(
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","TAG_SRNO","VCH_SRNO","TAG_NO","IT_CODE")
       VALUES($1,'01','01','9000','0','','')
       ON CONFLICT (tenant_id,"CO_CODE","LC_CODE") DO UPDATE SET "TAG_SRNO"=EXCLUDED."TAG_SRNO"`,
    ),
    'company 01 location 01 tag serial counter',
  );
}

export async function cleanupTagSplit(sql) {
  for (const table of [
    'DM_DATA',
    'BAR_IDTL',
    'BAR_DETL',
    'LBR_ISU_IDTL',
    'LBR_ISU_DETL',
    'LBR_REC_DETL',
    'LBR_DATA',
    'MAIN_STOCK',
    'DELETE_DATA',
    'TEMP_BOOK_DATA',
    'BOOK_DATA',
    'BOOK_DETL',
  ])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK" = ANY($2::text[])`, [
      ...BOOKS,
      ...SOURCE_BOOKS,
    ]);
  // The children the split minted (their tag numbers start with the child item's PR_CODE).
  for (const table of ['BAR_IDTL', 'BAR_DETL', 'MAIN_STOCK'])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO" LIKE 'RH%'`);
  for (const table of ['BAR_IDTL', 'BAR_DETL'])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO" LIKE 'STAG%'`);
  await sql(`DELETE FROM "ENTITY_IMAGE" WHERE tenant_id=$1 AND "ENTITY_KEY" LIKE 'STAG%'`);
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`, ITEMS);
  await sql(`DELETE FROM "EMP_MAST" WHERE tenant_id=$1 AND "EMP_CODE"='930'`);
  // Idempotent cleanup: removes the exact counter row the seed upserts; matches no row on a clean database.
  await sql(`DELETE FROM "SRNO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'`);
}

// ---- screen helpers ----------------------------------------------------------------------------------

async function pick(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}

async function bookValue(page, expected) {
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== expected; i++)
    await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), expected);
  return (await book.locator('option').allTextContents()).filter((text) => text.includes('—'));
}

async function settle(locator, expected, what) {
  for (let i = 0; i < 50 && (await locator.inputValue()) !== expected; i++)
    await locator.page().waitForTimeout(100);
  assert.equal(await locator.inputValue(), expected, what);
}
const value = (page, label, expected) =>
  settle(page.getByLabel(label, { exact: true }), expected, label);

async function text(page, testId, expected) {
  const node = page.getByTestId(testId);
  const matches = (actual) =>
    expected instanceof RegExp ? expected.test(actual) : actual.trim() === expected;
  for (let i = 0; i < 50 && !matches((await node.textContent().catch(() => '')) ?? ''); i++)
    await page.waitForTimeout(100);
  const actual = (await node.textContent()) ?? '';
  assert(matches(actual), `${testId}: expected ${expected}, got ${JSON.stringify(actual)}`);
}

/** Type a numeric child cell (data-testid tag-split-<cell>-<index>) and leave it with Tab. */
async function typeCell(page, cell, index, typed) {
  const input = page.getByTestId(`tag-split-${cell}-${index}`);
  await input.fill(typed);
  await input.press('Tab');
}

function acceptNextDialog(page) {
  return new Promise((resolve) => {
    page.once('dialog', async (dialog) => {
      const message = dialog.message();
      await dialog.accept();
      resolve(message);
    });
  });
}

export async function exerciseTagSplit(page, { checkpoint, owner, tenantId }) {
  const rows = (query, ...params) => owner.$queryRawUnsafe(query, tenantId, ...params);
  const none = async (table, book) =>
    assert.deepEqual(
      await rows(`SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2`, book),
      [],
      `${table} rows of ${book}`,
    );
  const live = async (tag, id) =>
    Number(
      (
        await rows(
          `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS n
             FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2 AND "VCH_SRNO"=$3`,
          tag,
          id,
        )
      )[0].n,
    ) > 0;
  // The source parent tag, its stone and photograph, as text: none of it may change.
  const sourceFingerprint = async () =>
    (
      await rows(
        `SELECT (SELECT string_agg(t::text,'|' ORDER BY t.row_id) FROM "BAR_DETL" t
                  WHERE tenant_id=$1 AND "TAG_NO" LIKE 'STAG%') AS bar,
                (SELECT string_agg(t::text,'|' ORDER BY t.row_id) FROM "BAR_IDTL" t
                  WHERE tenant_id=$1 AND "TAG_NO" LIKE 'STAG%') AS stones,
                (SELECT string_agg(md5(t."IMAGE_BYTES") || t."ENTITY_KEY" || t."INSTANCE"::text,'|')
                   FROM "ENTITY_IMAGE" t WHERE tenant_id=$1 AND "ENTITY_KEY" LIKE 'STAG%') AS images`,
      )
    )[0];
  const source = await sourceFingerprint();
  assert(source.bar && source.stones && source.images, 'fixture source rows');
  const sourceUnchanged = async (when) =>
    assert.deepEqual(await sourceFingerprint(), source, `source parent changed ${when}`);

  const header = async () =>
    (
      await rows(
        `SELECT "VCH_NO",left("VCH_DATE"::text,10) AS day,"HD_VCH_NO","AC_CODE","EMP_CODE","VCH_DESC","MAIN_USER",
                "IT_TYPE","ENTRY_TYPE",to_char("VCH_TIME",'HH24:MI:SS') AS clock
           FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SPL'`,
      )
    ).map(({ clock, ...rest }) => ({ ...rest, clockSet: /^\d\d:\d\d:\d\d$/.test(clock ?? '') }));
  const parentDetails = () =>
    rows(
      `SELECT "SR_NO"::int AS sr,"OLD_SRNO"::int AS old,"TAG_NO" AS tag,"VCH_SRNO"::float8 AS id,"IT_CODE" AS it,
              "ITM_NWT"::float8 AS nwt,"ITM_FINE"::float8 AS fine,"ENTRY_TYPE"
         FROM "LBR_ISU_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SPL' ORDER BY "SR_NO"`,
    );
  const childDetails = () =>
    rows(
      `SELECT "SR_NO"::int AS sr,"OLD_SRNO"::int AS old,"TAG_NO" AS tag,"IT_CODE" AS it,
              "ITM_NWT"::float8 AS nwt,"ITM_FINE"::float8 AS fine,"ENTRY_TYPE"
         FROM "LBR_REC_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SPL' ORDER BY "SR_NO"`,
    );
  const childBar = () =>
    rows(
      `SELECT "TAG_NO" AS tag,"IT_CODE" AS it,"ITM_NWT"::float8 AS nwt,"ITM_FINE"::float8 AS fine,"ENTRY_TYPE"
         FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SPL' ORDER BY "SR_NO"`,
    );
  const stock = () =>
    rows(
      `SELECT "SR_NO"::int AS sr,"ISR_NO"::int AS isr,"TAG_NO" AS tag,"IT_CODE" AS it,"ITM_SIGN" AS sign,
              "TR_TYPE" AS tr,"ITM_NWT"::float8 AS nwt,"ITM_FINE"::float8 AS fine,"VCH_TYPE","BOOK_NAME"
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SPL' ORDER BY "SR_NO","ISR_NO"`,
    );
  const diamonds = () =>
    rows(
      `SELECT "MAIN_SRNO"::int AS main,"IT_CODE" AS it,"DM_PCS"::float8 AS pcs,"DM_WT"::float8 AS wt,
              "DM_SIGN" AS sign,"TAG_NO" AS tag,"MAIN_IT_CODE" AS mainit,"INOUT_TYPE" AS io
         FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SPL' ORDER BY "MAIN_SRNO"`,
    );
  const audits = () =>
    rows(
      `SELECT "SR_NO"::int AS sr,"VCH_TYPE","BOOK_NAME","VCH_FINE_CR"::float8 AS fine_cr,"VCH_DESC","MAIN_USER",
              "DELETE_USER" FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SPL' ORDER BY "SR_NO"`,
    );

  // ==== Tag Split (X20) ============================================================================
  await page.goto('/txn/tag-split');
  await page.getByRole('heading', { name: 'Tag Split', exact: true }).waitFor();
  // Only the in-use TAG SPLIT book is offered, and chosen by itself.
  assert.deepEqual(await bookValue(page, 'SPL'), ['SPL — Tag Split']);
  await value(page, 'Vch No', '00001');
  await page.getByLabel('Vch Date', { exact: true }).fill('2024-06-10');
  await pick(page, 'Employee', '930');
  await page.getByText('Split Karigar', { exact: true }).waitFor();
  await page.getByTestId('tag-split-vch-desc').fill("worn'");
  await value(page, 'Vch Desc', 'WORN');

  // Parent: the whole ring, picked from the availability-filtered list, fills the read-only parent grid.
  await pick(page, 'TagNo parent 1', 'STAG001');
  await value(page, 'ItCode parent 1', 'SRNG');
  await value(page, 'NetWt parent 1', '10.000');
  await value(page, 'Fine parent 1', '9.160');
  // The parent's photograph comes with it.
  const preview = page.getByTestId('tag-split-image-preview');
  await preview.waitFor();
  assert.equal(await preview.getAttribute('alt'), 'Parent tag image STAG001');

  // Children: two half rings that conserve the fine. GrWt 6 @ touch 91.6 → net 6.000, fine 5.496.
  await pick(page, 'ItCode child 1', 'SRNGH');
  await typeCell(page, 'grossWt', 0, '6');
  await typeCell(page, 'touch', 0, '91.6');
  await value(page, 'NetWt child 1', '6.000');
  await value(page, 'Fine child 1', '5.496');
  // The conservation banner is short by 4 while only one child is entered.
  await text(page, 'tag-split-parent-net', /Parent net:\s*10\.000/);
  await text(page, 'tag-split-child-net', /Children net:\s*6\.000/);
  await text(page, 'tag-split-difference', /Short\s*4\.000/);

  // A short save with no absorbing account is refused (K7 guard) — client-side, nothing is written.
  await page.getByTestId('tag-split-save').click();
  await text(page, 'tag-split-error', /children must add up to the parent net weight/);
  await none('LBR_DATA', 'SPL');

  // Second child: GrWt 4 @ touch 91.6 → net 4.000, fine 3.664. Now the split conserves.
  await pick(page, 'ItCode child 2', 'SRNGH');
  await typeCell(page, 'grossWt', 1, '4');
  await typeCell(page, 'touch', 1, '91.6');
  await value(page, 'NetWt child 2', '4.000');
  await value(page, 'Fine child 2', '3.664');
  await text(page, 'tag-split-child-net', /Children net:\s*10\.000/);
  await text(page, 'tag-split-difference', 'Balanced');
  await checkpoint('tag-split-before-save', page);
  await page.getByTestId('tag-split-save').click();
  await text(page, 'tag-split-status', 'Saved voucher 00001');

  // ---- the stored voucher, read back from the database ------------------------------------------
  assert.deepEqual(await header(), [
    {
      VCH_NO: '00001',
      day: '2024-06-10',
      HD_VCH_NO: '00001',
      AC_CODE: '',
      EMP_CODE: '930',
      VCH_DESC: 'WORN',
      MAIN_USER: 'browser',
      IT_TYPE: 'G',
      ENTRY_TYPE: 'C',
      clockSet: true,
    },
  ]);
  assert.deepEqual(
    await rows(
      `SELECT "VCH_NO","BOOK_NAME" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SPL'`,
    ),
    [{ VCH_NO: '00001', BOOK_NAME: 'Tag Split' }],
  );
  // The parent line (issued, ENTRY_TYPE 'O').
  assert.deepEqual(await parentDetails(), [
    {
      sr: 1,
      old: 1,
      tag: 'STAG001',
      id: 930000001,
      it: 'SRNG',
      nwt: 10,
      fine: 9.16,
      ENTRY_TYPE: 'O',
    },
  ]);
  // The two children (received, ENTRY_TYPE 'O' on LBR_REC_DETL), each with a freshly minted RH-prefixed tag.
  const kids = await childDetails();
  assert.equal(kids.length, 2);
  assert.deepEqual(
    kids.map((k) => [k.sr, k.old, k.it, k.nwt, k.fine, k.ENTRY_TYPE]),
    [
      [2, 1, 'SRNGH', 6, 5.496, 'O'],
      [3, 2, 'SRNGH', 4, 3.664, 'O'],
    ],
  );
  for (const k of kids) assert.match(k.tag, /^RH0*9\d{3}$/);
  // The children are real, sellable BAR_DETL tags (ENTRY_TYPE 'I').
  const bars = await childBar();
  assert.deepEqual(
    bars.map((b) => [b.it, b.nwt, b.fine, b.ENTRY_TYPE]),
    [
      ['SRNGH', 6, 5.496, 'I'],
      ['SRNGH', 4, 3.664, 'I'],
    ],
  );
  // MAIN_STOCK (Tag_Split_Stk): the parent leaves ('-', O) and each child enters ('+', I); fine conserved.
  const moves = await stock();
  assert.deepEqual(
    moves.map((m) => [m.sr, m.sign, m.tr, m.nwt, m.fine, m.VCH_TYPE, m.BOOK_NAME]),
    [
      [1, '-', 'O', 10, 9.16, 'TGSPL', 'TAG SPLIT'],
      [2, '+', 'I', 6, 5.496, 'TGSPL', 'TAG SPLIT'],
      [2, '+', 'I', 4, 3.664, 'TGSPL', 'TAG SPLIT'],
    ],
  );
  const [conserved] = await rows(
    `SELECT sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_FINE" ELSE -"ITM_FINE" END)::float8 AS net
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SPL'`,
  );
  assert.equal(Number(conserved.net), 0, 'the split conserves the fine in stock');
  // Dm_Tag_Split_Detl: the parent's diamond stone goes OUT (MAIN_SRNO 1); the children carry no stones, so no IN.
  assert.deepEqual(await diamonds(), [
    { main: 1, it: 'SDIA', pcs: 10, wt: 0.5, sign: '-', tag: 'STAG001', mainit: 'SRNG', io: 'O' },
  ]);
  assert.equal(await live('STAG001', 930000001), false);
  // Each child is a live, sellable tag: its net signed balance is +1.
  for (const k of kids) {
    const [{ n }] = await rows(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS n
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      k.tag,
    );
    assert.equal(Number(n), 1, `child ${k.tag} is live`);
  }
  await sourceUnchanged('by the split');

  // The saved voucher is reloaded onto the screen.
  await page.getByRole('button', { name: 'Update', exact: true }).waitFor();
  await text(page, 'tag-split-hidden-no', /^00001 · browser · /);
  await value(page, 'NetWt parent 1', '10.000');
  await value(page, 'Fine child 1', '5.496');
  await checkpoint('tag-split-saved', page);

  // ---- reopen by number and the voucher list -----------------------------------------------------
  await page.getByTestId('tag-split-new').click();
  await value(page, 'Vch No', '00002');
  const vchNo = page.getByTestId('tag-split-vch-no');
  await vchNo.fill('1');
  await vchNo.press('Enter');
  await text(page, 'tag-split-status', 'Loaded voucher 00001');
  await value(page, 'Vch Desc', 'WORN');
  await value(page, 'Fine parent 1', '9.160');
  await page.getByTestId('tag-split-list-toggle').click();
  await text(page, 'tag-split-voucher-list', /00001[\s\S]*WORN[\s\S]*browser[\s\S]*2/);
  await page.getByTestId('tag-split-list-toggle').click();

  // ---- delete: DELETE_DATA per parent line, then the whole write set, and the parent back -----------
  const deletion = acceptNextDialog(page);
  await page.getByTestId('tag-split-delete').click();
  assert.equal(await deletion, 'Are You Sure To Delete This Voucher now?');
  await text(page, 'tag-split-status', 'Delete Success. Voucher 00001');
  assert.deepEqual(await audits(), [
    {
      sr: 1,
      VCH_TYPE: 'TGSPL',
      BOOK_NAME: 'Tag Split',
      fine_cr: 10,
      VCH_DESC: 'ItCode/SRNG TagNo/STAG001',
      MAIN_USER: 'browser',
      DELETE_USER: 'browser',
    },
  ]);
  for (const table of [
    'LBR_DATA',
    'LBR_ISU_DETL',
    'LBR_ISU_IDTL',
    'LBR_REC_DETL',
    'BAR_DATA',
    'BAR_DETL',
    'BAR_IDTL',
    'MAIN_STOCK',
    'DM_DATA',
    'TEMP_BOOK_DATA',
  ])
    await none(table, 'SPL');
  assert.equal(await live('STAG001', 930000001), true, 'the delete gives the parent back');
  await sourceUnchanged('by the delete');
  await value(page, 'Vch No', '00001');

  return {
    checks: [
      'the page offers only its own in-use TAG SPLIT book and the next voucher number',
      'a picked parent fills the read-only parent grid, its net and fine, and its photograph',
      'each child cell recomputes net and fine on the same core arithmetic the API writes with',
      'the conservation banner tracks parent net, children net and the short/surplus difference',
      'a short split with no absorbing account is refused before anything is written',
      'a conserving split saves: LBR_DATA (C), the parent line (O), two child lines and two child BAR_DETL tags (I)',
      'MAIN_STOCK moves the parent out and each child in, conserving the fine; DM_DATA sends the parent stone out',
      'the saved voucher reopens by number and appears in the voucher list with its child count',
      'delete writes DELETE_DATA per parent line, removes the whole write set and gives the parent back',
      'the source parent tag, its stone and its photograph never change',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture; not an independent desktop comparison or business acceptance',
  };
}
