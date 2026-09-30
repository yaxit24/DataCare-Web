import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';

/**
 * N18 real-browser journey: desktop TR_TAG_CAN on its two menus — Tag Cancel (X19, a TAG CANCEL book) and Tag
 * Transfer (X18, a TAG TRFR book) — driven through the screen alone, with every stored row read back from the
 * database independently of the web code.
 *
 * Tag Cancel: a picked tag with a stone and a photograph, a typed tag, the three refusals the grid gives at entry
 * ("Duplicate Tag No", a sold tag, an ambiguous number), the live instance picked by its serial, a loose line; then an
 * edit that removes a line with Ctrl+D, changes a stone and a touch; a reopen by number; the voucher list; and a delete
 * that audits every line and gives every tag back. Tag Transfer: a tag whose gross weight is edited (so the hidden
 * labour is recomputed) and a second tag that takes the previous row's transfer item (`CommPassAdd`), saved and
 * deleted, with the metal conserved on the loose item.
 *
 * Throughout, the source tags — BAR_DETL, BAR_IDTL, TAG_IMAGE_DATA and the image bytes — must not change.
 *
 * Expected figures are the desktop's, worked by hand from TR_TAG_CAN.cs (`CommPassTotal`, `CommPassTotal_Idtl`,
 * `BtnSave_Click`, `BtnDelete_Click`) and Ac_Stock.cs (`Tag_Can_Stk`, `Dm_Tag_Cancel_Detl`).
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-29-n18/contract.md.
 */
export const tagCancelTransferFixtureTables = [
  'DM_DATA',
  'BAR_CAN_IDTL',
  'BAR_CAN_DETL',
  'BAR_CAN_DATA',
  'LOT_DETL',
  'TAG_STOCK',
  'BAR_IDTL',
  'BAR_DETL',
  'MAIN_STOCK',
  'EMP_MAST',
];

const photo = readFileSync(
  new URL('../../api/test/fixtures/order-tag-landscape.jpg', import.meta.url),
);
const BOOKS = ['TGC', 'TTR', 'TGX'];
const SOURCE_BOOKS = ['JTO', 'JSL'];
const ITEMS = ['JRNG', 'JOG', 'JDIA'];
const D = (iso) => new Date(`${iso}T00:00:00.000Z`);

const bar = (over) => ({
  CO_CODE: '01',
  LC_CODE: '01',
  CO_YEAR: '2024-2025',
  CO_BOOK: 'JTO',
  VCH_NO: '00001',
  VCH_DATE: D('2024-04-05'),
  VCH_TYPE: 'TAGOP',
  BOOK_NAME: 'TAG OPBL',
  INOUT_TYPE: 'I',
  ENTRY_TYPE: 'O',
  IT_CODE: 'JRNG',
  TBL_CODE: '001',
  ITM_PCS: 1,
  BAG_WT: 0,
  ITM_OTH_WT: 0,
  ITM_GHT_PRC: 0,
  ITM_GHT_WT: 0,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 0,
  LBR_PRC: 0,
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
  PR_CODE: 'JR',
  EMP_ISU: 'N',
  DATA_TYPE: 'A',
  ...over,
});

// Every tag's karigar block is self-consistent (KR_FINE = KR_NET_WT × purity), so leaving one of its cells, which
// recomputes the row as the desktop's LeaveCell does, cannot move a figure the journey asserts — except JTAG001's,
// whose three-decimal KR_NET_WT exercises the tag fill's two-place format (9.905 → 9.91).
const TAGS = [
  bar({
    SR_NO: 1,
    OLD_SRNO: 1,
    TAG_NO: 'JTAG001',
    VCH_SRNO: 910000001,
    DESIGN_NO: 'D-101',
    ITM_SIZE: '12',
    BAG_WT: 0.05,
    ITM_GWT: 10.5,
    ITM_OTH_WT: 0.5,
    ITM_NWT: 10,
    ITM_WEST_PRC: 2,
    ITM_FINE: 9.36,
    LBR_TYPE: 'N',
    LBR_RATE: 150,
    LBR_AMT: 1500,
    OTH_AMT: 1200,
    KR_NAME: 'KJ',
    KR_NET_WT: 9.905,
    KR_TOUCH: 90,
    KR_WEST_PRC: 1.5,
    KR_FINE: 9.15,
    DESIGN_IMG_ID: 'IMG-101',
  }),
  bar({
    SR_NO: 2,
    OLD_SRNO: 2,
    TAG_NO: 'JTAG002',
    VCH_SRNO: 910000002,
    TBL_CODE: '002',
    DESIGN_NO: 'D-202',
    ITM_GWT: 6.2,
    ITM_NWT: 6.2,
    ITM_TOUCH: 75,
    ITM_FINE: 4.65,
    KR_NAME: 'AB',
    KR_NET_WT: 6.2,
    KR_TOUCH: 75,
    KR_FINE: 4.65,
  }),
  bar({
    SR_NO: 3,
    OLD_SRNO: 3,
    TAG_NO: 'JTAG003',
    VCH_SRNO: 910000003,
    ITM_GWT: 8,
    ITM_NWT: 8,
    ITM_FINE: 7.328,
    LBR_TYPE: 'N',
    LBR_RATE: 100,
    LBR_AMT: 800,
    KR_NAME: 'KJ',
    KR_NET_WT: 8,
    KR_FINE: 7.328,
  }),
  // One number, two live instances: the save must take exactly the one the operator picked.
  bar({
    SR_NO: 4,
    OLD_SRNO: 4,
    TAG_NO: 'JTAG004',
    VCH_SRNO: 910000004,
    ITM_GWT: 5,
    ITM_NWT: 5,
    ITM_FINE: 4.58,
    KR_NET_WT: 5,
    KR_FINE: 4.58,
  }),
  bar({
    SR_NO: 5,
    OLD_SRNO: 5,
    TAG_NO: 'JTAG004',
    VCH_SRNO: 910000005,
    ITM_GWT: 7,
    ITM_NWT: 7,
    ITM_FINE: 6.412,
    KR_NET_WT: 7,
    KR_FINE: 6.412,
  }),
  // Sold: its stock balance is zero.
  bar({
    SR_NO: 6,
    OLD_SRNO: 6,
    TAG_NO: 'JTAG009',
    VCH_SRNO: 910000009,
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

export async function seedTagCancelTransfer(sql) {
  await cleanupTagCancelTransfer(sql);
  for (const [book, name, shortName, mainBook, use] of [
    ['TGC', 'Tag Cancel', 'TGCAN', 'TAG CANCEL', 'Y'],
    ['TTR', 'Tag Transfer', 'TAGTR', 'TAG TRFR', 'Y'],
    // Not in use: CurBookHelp never offers it.
    ['TGX', 'Old Tag Cancel', 'TGCX', 'TAG CANCEL', 'N'],
  ])
    await insert(sql, 'BOOK_DATA', {
      CO_CODE: '01',
      LC_CODE: '01',
      CO_BOOK: book,
      BOOK_NAME: name,
      BOOK_SNAME: shortName,
      MAIN_BOOK: mainBook,
      BOOK_INOUT: 'O',
      CUR_USE: use,
      BOOK_TBL_NAME: 'BAR_CAN_DATA',
    });
  for (const [code, name, type, pr, rateType, postsDiamonds] of [
    ['JRNG', 'Journey Ring 22K', 'G', 'JR', '', 'N'],
    ['JOG', 'Journey Old Gold', 'G', 'JO', '', 'N'],
    ['JDIA', 'Journey Diamond', 'D', 'JD', 'W', 'Y'],
  ])
    await insert(sql, 'ITEM_MAST', {
      CO_CODE: '01',
      IT_CODE: code,
      IT_NAME: name,
      IT_TYPE: type,
      PR_CODE: pr,
      RATE_TYPE: rateType,
      OTH_DETL_POSTING: postsDiamonds,
    });
  await insert(sql, 'EMP_MAST', { CO_CODE: '01', EMP_CODE: '901', EMP_NAME: 'Journey Karigar' });
  for (const tag of TAGS) {
    await insert(sql, 'BAR_DETL', tag);
    await insert(sql, 'MAIN_STOCK', {
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: '2024-2025',
      CO_BOOK: 'JTO',
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
  await insert(sql, 'MAIN_STOCK', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'JSL',
    VCH_NO: '00007',
    SR_NO: 1,
    ISR_NO: 1,
    VCH_DATE: D('2024-05-01'),
    STK_DATE: '2024-05-01',
    VCH_TYPE: 'TGSL',
    BOOK_NAME: 'SALES',
    IT_CODE: 'JRNG',
    TAG_NO: 'JTAG009',
    VCH_SRNO: 910000009,
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
  // JTAG001's stone: a diamond whose item posts to the diamond register (OTH_DETL_POSTING Y).
  await insert(sql, 'BAR_IDTL', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'JTO',
    VCH_NO: '00001',
    SR_NO: 1,
    ISR_NO: 1,
    VCH_DATE: D('2024-04-05'),
    VCH_TYPE: 'TAGOP',
    BOOK_NAME: 'TAG OPBL',
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    TAG_NO: 'JTAG001',
    VCH_SRNO: 910000001,
    IT_CODE: 'JDIA',
    IT_TYPE: 'D',
    IT_PCS: 10,
    IT_GWT: 0.5,
    KR_WT: 0.5,
    IT_CON_PRC: 1,
    IT_CON_WT: 0.5,
    IT_RATE_TYPE: 'W',
    IT_RATE: 2000,
    IT_AMT: 1000,
    IT_LBR_RATE: 20,
    IT_LBR_AMT: 200,
    IT_NET_AMT: 1200,
    KR_CON_WT: 0.5,
  });
  // JTAG001's photograph, keyed on the instance.
  await insert(sql, 'TAG_IMAGE_DATA', {
    CO_CODE: '01',
    LC_CODE: '01',
    TAG_NO: 'JTAG001',
    VCH_SRNO: 910000001,
    IMAGE_TYPE: 'T',
  });
  await insert(sql, 'ENTITY_IMAGE', {
    CO_CODE: '01',
    LC_CODE: '01',
    ENTITY_TYPE: 'TAG',
    ENTITY_KEY: 'JTAG001',
    INSTANCE: 910000001,
    IMAGE_TYPE: 'T',
    MIME_TYPE: 'image/jpeg',
    IMAGE_SIZE: photo.length,
    IMAGE_BYTES: photo,
  });
}

export async function cleanupTagCancelTransfer(sql) {
  for (const table of [
    'DM_DATA',
    'BAR_CAN_IDTL',
    'BAR_CAN_DETL',
    'BAR_CAN_DATA',
    'LOT_DETL',
    'MAIN_STOCK',
    'DELETE_DATA',
    'TEMP_BOOK_DATA',
    'BOOK_DATA',
  ])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK" = ANY($2::text[])`, [
      ...BOOKS,
      ...SOURCE_BOOKS,
    ]);
  for (const table of ['BAR_IDTL', 'BAR_DETL', 'TAG_IMAGE_DATA', 'TAG_STOCK'])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO" LIKE 'JTAG%'`);
  await sql(`DELETE FROM "ENTITY_IMAGE" WHERE tenant_id=$1 AND "ENTITY_KEY" LIKE 'JTAG%'`);
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`, ITEMS);
  await sql(`DELETE FROM "EMP_MAST" WHERE tenant_id=$1 AND "EMP_CODE"='901'`);
}

// ---- screen helpers ----------------------------------------------------------------------------------

/** Type into a picker, wait for the code in its list, and take it with Enter (the desktop's F1 help). */
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
const cell = (page, testId, expected) => settle(page.getByTestId(testId), expected, testId);

async function text(page, testId, expected) {
  const node = page.getByTestId(testId);
  const matches = (actual) =>
    expected instanceof RegExp ? expected.test(actual) : actual.trim() === expected;
  for (let i = 0; i < 50 && !matches((await node.textContent().catch(() => '')) ?? ''); i++)
    await page.waitForTimeout(100);
  const actual = (await node.textContent()) ?? '';
  assert(matches(actual), `${testId}: expected ${expected}, got ${JSON.stringify(actual)}`);
}

/** Type a numeric cell and leave it with Tab, as the operator does (MSG_LeaveCell). */
async function typeCell(page, label, typed) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(typed);
  await input.press('Tab');
}

/** A confirm dialog, answered yes; its text is returned for the assertion (a throw inside a handler is lost). */
function acceptNextDialog(page) {
  return new Promise((resolve) => {
    page.once('dialog', async (dialog) => {
      const message = dialog.message();
      await dialog.accept();
      resolve(message);
    });
  });
}

export async function exerciseTagCancelTransfer(page, { checkpoint, owner, tenantId }) {
  const rows = (query, ...params) => owner.$queryRawUnsafe(query, tenantId, ...params);
  const none = async (table, book) =>
    assert.deepEqual(
      await rows(`SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2`, book),
      [],
      `${table} rows of ${book}`,
    );
  // An instance is in stock while its signed MAIN_STOCK balance is positive (the tag entry query, :3860).
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
  // The source tags, their stones and their photograph, as text: none of it may change.
  const sourceFingerprint = async () =>
    (
      await rows(
        `SELECT (SELECT string_agg(t::text,'|' ORDER BY t.row_id) FROM "BAR_DETL" t
                  WHERE tenant_id=$1 AND "TAG_NO" LIKE 'JTAG%') AS bar,
                (SELECT string_agg(t::text,'|' ORDER BY t.row_id) FROM "BAR_IDTL" t
                  WHERE tenant_id=$1 AND "TAG_NO" LIKE 'JTAG%') AS stones,
                (SELECT string_agg(t::text,'|' ORDER BY t."TAG_NO") FROM "TAG_IMAGE_DATA" t
                  WHERE tenant_id=$1 AND "TAG_NO" LIKE 'JTAG%') AS tag_images,
                (SELECT string_agg(md5(t."IMAGE_BYTES") || t."ENTITY_KEY" || t."INSTANCE"::text,'|')
                   FROM "ENTITY_IMAGE" t WHERE tenant_id=$1 AND "ENTITY_KEY" LIKE 'JTAG%') AS images`,
      )
    )[0];
  const source = await sourceFingerprint();
  assert(source.bar && source.stones && source.tag_images && source.images, 'fixture source rows');
  const sourceUnchanged = async (when) =>
    assert.deepEqual(await sourceFingerprint(), source, `source tags changed ${when}`);
  const details = (book) =>
    rows(
      `SELECT "SR_NO"::int AS sr,"OLD_SRNO"::int AS old,"TAG_NO" AS tag,"VCH_SRNO"::float8 AS id,"IT_CODE" AS it,
              "TRFR_IT_CODE" AS trfr,"ITM_GWT"::float8 AS gwt,"ITM_OTH_WT"::float8 AS less,"ITM_NWT"::float8 AS nwt,
              "ITM_FINE"::float8 AS fine,"LBR_AMT"::float8 AS lbr,"OTH_AMT"::float8 AS oth,
              "KR_NET_WT"::float8 AS kr_nwt,"KR_FINE"::float8 AS kr_fine
         FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO"`,
      book,
    );
  const stamps = (book) =>
    rows(
      `SELECT DISTINCT "VCH_TYPE","BOOK_NAME","INOUT_TYPE","ENTRY_TYPE","ITM_SIGN","HD_VCH_NO","MAIN_USER"
         FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      book,
    );
  const stones = (book) =>
    rows(
      `SELECT "SR_NO"::int AS sr,"ISR_NO"::int AS isr,"TAG_NO" AS tag,"VCH_SRNO"::float8 AS id,"IT_CODE" AS it,
              "IT_PCS"::float8 AS pcs,"IT_GWT"::float8 AS gwt,"IT_AMT"::float8 AS amt,"IT_LBR_AMT"::float8 AS lbr,
              "IT_NET_AMT"::float8 AS net
         FROM "BAR_CAN_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO","ISR_NO"`,
      book,
    );
  const stock = (book) =>
    rows(
      `SELECT "SR_NO"::int AS sr,"ISR_NO"::int AS isr,"TAG_NO" AS tag,"VCH_SRNO"::float8 AS id,"IT_CODE" AS it,
              "ITM_SIGN" AS sign,"TR_TYPE" AS tr,"TBL_CODE" AS tbl,"ITM_GWT"::float8 AS gwt,"ITM_NWT"::float8 AS nwt,
              "ITM_FINE"::float8 AS fine,"LBR_AMT"::float8 AS lbr,"OTH_AMT"::float8 AS oth
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO","ISR_NO"`,
      book,
    );
  const stockStamps = (book) =>
    rows(
      `SELECT DISTINCT "VCH_TYPE","BOOK_NAME","DATA_TYPE" FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      book,
    );
  const diamonds = (book) =>
    rows(
      `SELECT "SR_NO"::int AS sr,"ISR_NO"::int AS isr,"BOOK_NAME" AS book,"IT_CODE" AS it,"DM_PCS"::float8 AS pcs,
              "DM_WT"::float8 AS wt,"DM_SIGN" AS sign,"DM_RATE"::float8 AS rate,"DM_AMT"::float8 AS amt,
              "TAG_NO" AS tag,"MAIN_IT_CODE" AS main,"INOUT_TYPE" AS io
         FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO","ISR_NO"`,
      book,
    );
  const header = async (book) =>
    (
      await rows(
        `SELECT "VCH_NO",left("VCH_DATE"::text,10) AS day,"HD_VCH_NO","AC_CODE","EMP_CODE","VCH_DESC","MAIN_USER",
                "DATA_TRFR","USER_UPDATE","USER_DELETE",to_char("VCH_TIME",'HH24:MI:SS') AS clock
           FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
        book,
      )
    ).map(({ clock, ...rest }) => ({ ...rest, clockSet: /^\d\d:\d\d:\d\d$/.test(clock ?? '') }));
  const audits = (book) =>
    rows(
      `SELECT "SR_NO"::int AS sr,"VCH_NO","VCH_TYPE","BOOK_NAME","FINE_TYPE","VCH_FINE_DR"::float8 AS fine_dr,
              "VCH_FINE_CR"::float8 AS fine_cr,"VCH_DESC","HD_VCH_NO","MAIN_USER","DELETE_USER",
              left("VCH_DATE"::text,10) AS day
         FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO"`,
      book,
    );

  // ==== Tag Cancel (X19) ===========================================================================
  await page.goto('/txn/tag-cancel');
  await page.getByRole('heading', { name: 'Tag Cancel', exact: true }).waitFor();
  // CurBookHelp("TAG CANCEL"): only the in-use TAG CANCEL book is offered, and chosen by itself.
  assert.deepEqual(await bookValue(page, 'TGC'), ['TGC — Tag Cancel']);
  // CLEAR_DATA: the next number is MAX(VCH_NO) + 1 of the book.
  await value(page, 'Vch No', '00001');
  await page.getByLabel('Vch Date', { exact: true }).fill('2024-06-10');
  await pick(page, 'Employee', '901');
  await page.getByText('Journey Karigar', { exact: true }).waitFor();
  // KeyPreview upper-cases every key and swallows the apostrophe.
  await page.getByLabel('Vch Desc', { exact: true }).fill("damaged'");
  await value(page, 'Vch Desc', 'DAMAGED');

  // Line 1: a tag picked from the availability-filtered list fills its row from BAR_DETL (tag entry, :4020-4085).
  await pick(page, 'TagNo line 1', 'JTAG001');
  await value(page, 'ItCode line 1', 'JRNG');
  await value(page, 'Counter line 1', '001');
  await value(page, 'Design line 1', 'D-101');
  await value(page, 'Size line 1', '12');
  await value(page, 'BagWt line 1', '0.050');
  await value(page, 'GrWt line 1', '10.500');
  await value(page, 'LsWt line 1', '0.500');
  await value(page, 'NetWt line 1', '10.000');
  await value(page, 'Touch line 1', '91.60');
  await value(page, 'West% line 1', '2.00');
  await value(page, 'Fine line 1', '9.360');
  await value(page, 'LbrRate line 1', '150.00');
  await value(page, 'LbrAmt line 1', '1500.00');
  await value(page, 'OthAmt line 1', '1200.00');
  await value(page, 'KrCode line 1', 'KJ');
  // MSG_EnterCell: ItCode, Counter, Pcs and KrCode are read-only once the row holds a tag.
  for (const label of ['ItCode line 1', 'Counter line 1', 'Pcs line 1', 'KrCode line 1'])
    assert.equal(await page.getByLabel(label, { exact: true }).isEditable(), false, label);
  await text(page, 'tag-cancel-item-name', 'Journey Ring 22K : It Name');
  // Its stone (MSG_IDTL) and its photograph come with it.
  await value(page, 'ItCode row 1', 'JDIA');
  await cell(page, 'tag-cancel-stone-pcs-0', '10');
  await cell(page, 'tag-cancel-stone-netAmount-0', '1200.00');
  const preview = page.getByTestId('tag-cancel-image-preview');
  await preview.waitFor();
  assert.equal(await preview.getAttribute('alt'), 'Tag image JTAG001');

  // Line 2: a typed number resolves on leaving the cell when it names one live instance.
  const second = page.getByLabel('TagNo line 2', { exact: true });
  await second.fill('JTAG002');
  await second.locator('xpath=..').getByText('JTAG002', { exact: true }).first().waitFor();
  await second.press('Escape');
  await second.press('Tab');
  await value(page, 'Counter line 2', '002');
  await value(page, 'Fine line 2', '4.650');

  // Line 3, three refusals at entry. "Duplicate Tag No" (:3907-3915) …
  const third = page.getByLabel('TagNo line 3', { exact: true });
  await pick(page, 'TagNo line 3', 'JTAG001');
  await text(page, 'tag-cancel-error', 'Duplicate Tag No: JTAG001');
  // … and a row still holding an unresolved number cannot be saved (web adaptation A13).
  await page.getByTestId('tag-cancel-save').click();
  await text(page, 'tag-cancel-error', 'Row 3: resolve tag JTAG001 before saving');
  await none('BAR_CAN_DATA', 'TGC');
  await third.fill('');
  await third.press('Escape');
  // A sold tag is not available.
  await third.fill('JTAG009');
  await third.press('Tab');
  await text(page, 'tag-cancel-error', 'tag not available for issue: JTAG009');
  await page.keyboard.press('Escape');
  // A number with two live instances is refused until one is picked (web adaptation A1: fail closed) …
  await third.fill('JTAG004');
  await third
    .locator('xpath=..')
    .getByText(/#910000005/)
    .first()
    .waitFor();
  await third.press('Escape');
  await third.press('Tab');
  await text(
    page,
    'tag-cancel-error',
    'Tag JTAG004 has 2 live instances; pick one from the list (F1)',
  );
  await page.keyboard.press('Escape');
  // … and the list names each instance by its serial.
  await third.click();
  await third
    .locator('xpath=..')
    .getByText(/#910000005/)
    .first()
    .click();
  await value(page, 'GrWt line 3', '7.000');
  await value(page, 'Fine line 3', '6.412');

  // Line 4: a loose line. GrWt 2 → net 2, fine 2 (no purity); Touch 75 → fine 2 × 75 / 100 = 1.500.
  await pick(page, 'ItCode line 4', 'JOG');
  await typeCell(page, 'GrWt line 4', '2');
  await value(page, 'NetWt line 4', '2.000');
  await value(page, 'Fine line 4', '2.000');
  await typeCell(page, 'Touch line 4', '75');
  await value(page, 'Fine line 4', '1.500');
  // MSG_TOT_FILL.
  await text(page, 'tag-cancel-total-pcs', '3');
  await text(page, 'tag-cancel-total-grossWt', '25.700');
  await text(page, 'tag-cancel-total-netWt', '25.200');
  await text(page, 'tag-cancel-total-fine', '21.922');
  await text(page, 'tag-cancel-total-lbrAmt', '1500.00');
  await text(page, 'tag-cancel-total-othAmt', '1200.00');
  await page.getByTestId('tag-cancel-row-0').locator('td').first().click();
  await preview.waitFor();
  await checkpoint('tag-cancel-before-save', page);
  await page.getByTestId('tag-cancel-save').click();
  await text(page, 'tag-cancel-status', 'Saved voucher 00001');

  // ---- the stored voucher, read back from the database ------------------------------------------
  assert.deepEqual(await header('TGC'), [
    {
      VCH_NO: '00001',
      day: '2024-06-10',
      HD_VCH_NO: '00001',
      AC_CODE: '',
      EMP_CODE: '901',
      VCH_DESC: 'DAMAGED',
      MAIN_USER: 'browser',
      DATA_TRFR: 'N',
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
      clockSet: true,
    },
  ]);
  assert.deepEqual(
    await rows(
      `SELECT "VCH_NO","BOOK_NAME" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TGC'`,
    ),
    [{ VCH_NO: '00001', BOOK_NAME: 'Tag Cancel' }],
  );
  const RING = { it: 'JRNG', trfr: null };
  const line1 = {
    tag: 'JTAG001',
    id: 910000001,
    ...RING,
    gwt: 10.5,
    less: 0.5,
    nwt: 10,
    fine: 9.36,
    lbr: 1500,
    oth: 1200,
    // The tag fill's two-place karigar net (TR_TAG_CAN.cs:4053): 9.905 is saved as 9.91.
    kr_nwt: 9.91,
    kr_fine: 9.15,
  };
  const line2 = { tag: 'JTAG002', id: 910000002, ...RING, gwt: 6.2, less: 0, nwt: 6.2, fine: 4.65 };
  const line3 = { tag: 'JTAG004', id: 910000005, ...RING, gwt: 7, less: 0, nwt: 7, fine: 6.412 };
  const loose = { tag: 'N', id: 0, it: 'JOG', trfr: null, gwt: 2, less: 0, nwt: 2, fine: 1.5 };
  const noMoney = { lbr: 0, oth: 0 };
  assert.deepEqual(await details('TGC'), [
    { sr: 1, old: 1, ...line1 },
    { sr: 2, old: 2, ...line2, ...noMoney, kr_nwt: 6.2, kr_fine: 4.65 },
    { sr: 3, old: 3, ...line3, ...noMoney, kr_nwt: 7, kr_fine: 6.412 },
    { sr: 4, old: 4, ...loose, ...noMoney, kr_nwt: 2, kr_fine: 1.5 },
  ]);
  const cancelStamp = {
    VCH_TYPE: 'TGCAN',
    BOOK_NAME: 'TAG CANCEL',
    INOUT_TYPE: 'O',
    ENTRY_TYPE: 'T',
    ITM_SIGN: '-',
    HD_VCH_NO: '00001',
    MAIN_USER: 'browser',
  };
  assert.deepEqual(await stamps('TGC'), [cancelStamp]);
  assert.deepEqual(
    await rows(
      `SELECT "SR_NO"::int AS sr,"LBR_TYPE","DESIGN_IMG_ID" FROM "BAR_CAN_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK"='TGC' AND "SR_NO" IN (1,4) ORDER BY "SR_NO"`,
    ),
    [
      { sr: 1, LBR_TYPE: 'N', DESIGN_IMG_ID: 'IMG-101' },
      // CommPassAdd: a loose row on the company labour basis (blank → G) with Image N.
      { sr: 4, LBR_TYPE: 'G', DESIGN_IMG_ID: 'N' },
    ],
  );
  const diamond = { sr: 1, isr: 1, tag: 'JTAG001', id: 910000001, it: 'JDIA', gwt: 0.5, amt: 1000 };
  assert.deepEqual(await stones('TGC'), [{ ...diamond, pcs: 10, lbr: 200, net: 1200 }]);
  // Tag_Can_Stk insert 1: every line leaves stock.
  const out = (sr, line, money = noMoney) => ({
    sr,
    isr: 1,
    tag: line.tag,
    id: line.id,
    it: line.it,
    sign: '-',
    tr: 'O',
    tbl: line.tbl ?? '001',
    gwt: line.gwt,
    nwt: line.nwt,
    fine: line.fine,
    ...money,
  });
  assert.deepEqual(await stock('TGC'), [
    out(1, line1, { lbr: 1500, oth: 1200 }),
    out(2, { ...line2, tbl: '002' }),
    out(3, line3),
    out(4, { ...loose, tbl: '' }),
  ]);
  assert.deepEqual(await stockStamps('TGC'), [
    { VCH_TYPE: 'TGCAN', BOOK_NAME: 'TAG CANCEL', DATA_TYPE: 'A' },
  ]);
  // Dm_Tag_Cancel_Detl: the diamond register takes the stone of an OTH_DETL_POSTING item.
  const dm = {
    sr: 1,
    isr: 1,
    book: 'TGCAN',
    it: 'JDIA',
    wt: 0.5,
    sign: '-',
    rate: 2000,
    amt: 1000,
  };
  const dmTail = { tag: 'JTAG001', main: 'JRNG', io: 'O' };
  assert.deepEqual(await diamonds('TGC'), [{ ...dm, pcs: 10, ...dmTail }]);
  assert.equal(await live('JTAG001', 910000001), false);
  assert.equal(await live('JTAG002', 910000002), false);
  assert.equal(await live('JTAG004', 910000005), false);
  assert.equal(await live('JTAG004', 910000004), true, 'the other instance of JTAG004 stays');
  await sourceUnchanged('by the cancel');
  // The saved voucher is reloaded onto the screen: every figure shown is the stored one.
  await page.getByRole('button', { name: 'Update', exact: true }).waitFor();
  await text(page, 'tag-cancel-hidden-no', /^00001 · browser · /);
  await value(page, 'TagNo line 3', 'JTAG004');
  await value(page, 'Fine line 4', '1.500');
  await checkpoint('tag-cancel-saved', page);

  // ---- edit: Ctrl+D a line, change a stone and a touch ------------------------------------------------
  const removal = acceptNextDialog(page);
  await page.getByLabel('Design line 2', { exact: true }).press('Control+d');
  assert.equal(await removal, 'This Row Record will Removed permantley ?');
  await text(page, 'tag-cancel-status', 'Please Save This Voucher Then Effect....');
  await value(page, 'TagNo line 2', 'JTAG004');
  // A stone edit (CommPassTotal_Idtl): 8 pcs → labour 8 × 20 = 160, net 1000 + 160 = 1160; on the row, less =
  // ConWt 0.500, net 10.000, KrNwt = 10.5 − KrConWt 0.5 = 10, OthAmt = 1160. The row's fine is not recomputed.
  await page.getByTestId('tag-cancel-row-0').locator('td').first().click();
  await cell(page, 'tag-cancel-stone-pcs-0', '10');
  const stonePcs = page.getByTestId('tag-cancel-stone-pcs-0');
  await stonePcs.fill('8');
  await stonePcs.press('Tab');
  await cell(page, 'tag-cancel-stone-lbrAmount-0', '160.00');
  await cell(page, 'tag-cancel-stone-netAmount-0', '1160.00');
  await value(page, 'OthAmt line 1', '1160.00');
  await value(page, 'LsWt line 1', '0.500');
  await value(page, 'Fine line 1', '9.360');
  // The loose line: Touch 80 → fine 2 × 80 / 100 = 1.600.
  await typeCell(page, 'Touch line 3', '80');
  await value(page, 'Fine line 3', '1.600');
  await checkpoint('tag-cancel-edited', page);
  await page.getByTestId('tag-cancel-save').click();
  await text(page, 'tag-cancel-status', 'Updated voucher 00001');
  // The edit keeps the voucher's hidden number, clock and user (DISPLAY_DATA); a kept line keeps its OLD_SRNO.
  assert.deepEqual(
    (await header('TGC')).map(({ HD_VCH_NO, MAIN_USER, day, clockSet }) => ({
      HD_VCH_NO,
      MAIN_USER,
      day,
      clockSet,
    })),
    [{ HD_VCH_NO: '00001', MAIN_USER: 'browser', day: '2024-06-10', clockSet: true }],
  );
  assert.deepEqual(await details('TGC'), [
    { sr: 1, old: 1, ...line1, oth: 1160, kr_nwt: 10 },
    { sr: 2, old: 3, ...line3, ...noMoney, kr_nwt: 7, kr_fine: 6.412 },
    { sr: 3, old: 4, ...loose, fine: 1.6, ...noMoney, kr_nwt: 2, kr_fine: 1.6 },
  ]);
  assert.deepEqual(await stones('TGC'), [{ ...diamond, pcs: 8, lbr: 160, net: 1160 }]);
  assert.deepEqual(await diamonds('TGC'), [{ ...dm, pcs: 8, ...dmTail }]);
  assert.deepEqual(
    (await stock('TGC')).map(({ sr, tag, id, sign }) => [sr, tag, id, sign]),
    [
      [1, 'JTAG001', 910000001, '-'],
      [2, 'JTAG004', 910000005, '-'],
      [3, 'N', 0, '-'],
    ],
  );
  await none('DELETE_DATA', 'TGC');
  assert.equal(await live('JTAG002', 910000002), true, 'the removed line gives its tag back');
  assert.equal(await live('JTAG001', 910000001), false);
  await sourceUnchanged('by the edit');

  // ---- reopen by number, and the voucher list (BtnF1) --------------------------------------------
  await page.getByTestId('tag-cancel-new').click();
  await value(page, 'Vch No', '00002');
  await value(page, 'TagNo line 1', '');
  const vchNo = page.getByLabel('Vch No', { exact: true });
  await vchNo.fill('1');
  await vchNo.press('Enter');
  await text(page, 'tag-cancel-status', 'Loaded voucher 00001');
  await value(page, 'Vch Desc', 'DAMAGED');
  await page.getByText('Journey Karigar', { exact: true }).waitFor();
  await value(page, 'TagNo line 1', 'JTAG001');
  await value(page, 'TagNo line 2', 'JTAG004');
  await value(page, 'ItCode line 3', 'JOG');
  await value(page, 'Fine line 3', '1.600');
  await value(page, 'OthAmt line 1', '1160.00');
  await page.getByTestId('tag-cancel-list-toggle').click();
  await text(page, 'tag-cancel-voucher-list', /00001\s*2024-06-10\s*DAMAGED\s*browser\s*3/);
  await page.getByTestId('tag-cancel-list-toggle').click();

  // ---- delete: DELETE_DATA per line, then the whole write set, and every tag back -------------------
  const deletion = acceptNextDialog(page);
  await page.getByTestId('tag-cancel-delete').click();
  assert.equal(await deletion, 'Are You Sure To Delete This Voucher now?');
  await text(page, 'tag-cancel-status', 'Delete Success. Voucher 00001');
  const audit = {
    VCH_NO: '00001',
    VCH_TYPE: 'TGCAN',
    BOOK_NAME: 'Tag Cancel',
    FINE_TYPE: 'G',
    fine_dr: 0,
    HD_VCH_NO: '00001',
    MAIN_USER: 'browser',
    DELETE_USER: 'browser',
    day: '2024-06-10',
  };
  assert.deepEqual(await audits('TGC'), [
    { sr: 1, ...audit, fine_cr: 10, VCH_DESC: 'ItCode/JRNG TagNo/JTAG001' },
    { sr: 2, ...audit, fine_cr: 7, VCH_DESC: 'ItCode/JRNG TagNo/JTAG004' },
    { sr: 3, ...audit, fine_cr: 2, VCH_DESC: 'ItCode/JOG TagNo/N' },
  ]);
  for (const table of [
    'BAR_CAN_DATA',
    'BAR_CAN_DETL',
    'BAR_CAN_IDTL',
    'MAIN_STOCK',
    'DM_DATA',
    'LOT_DETL',
    'TEMP_BOOK_DATA',
  ])
    await none(table, 'TGC');
  assert.equal(await live('JTAG001', 910000001), true);
  assert.equal(await live('JTAG004', 910000005), true);
  await sourceUnchanged('by the delete');
  await value(page, 'Vch No', '00001');

  // ==== Tag Transfer (X18) ========================================================================
  await page.goto('/txn/tag-transfer');
  await page.getByRole('heading', { name: 'Tag Transfer', exact: true }).waitFor();
  assert.deepEqual(await bookValue(page, 'TTR'), ['TTR — Tag Transfer']);
  // MSG_CLEAR for TAG TRFR: no ghat, labour, other amount, MRP or karigar; the transfer item instead.
  assert.deepEqual(
    await page.getByTestId('tag-transfer-grid').locator('thead th').allTextContents(),
    [
      'Sr',
      'TagNo',
      'ItCode',
      'Counter',
      'Design',
      'Size',
      'BagWt',
      'Pcs',
      'GrWt',
      'LsWt',
      'NetWt',
      'Touch',
      'West%',
      'Fine',
      'TrfrItm',
      'TrfrItmName',
    ],
  );
  await value(page, 'Vch No', '00001');
  await page.getByLabel('Vch Date', { exact: true }).fill('2024-06-11');
  await pick(page, 'TagNo line 1', 'JTAG003');
  await value(page, 'Fine line 1', '7.328');
  await pick(page, 'TrfrItm line 1', 'JOG');
  await value(page, 'TrfrItmName line 1', 'Journey Old Gold');
  // GrWt 8 → 8.2: net 8.200, fine 8.2 × 91.6 / 100 = 7.511; the hidden LbrAmt becomes N 100 × 8.2 = 820.
  await typeCell(page, 'GrWt line 1', '8.2');
  await value(page, 'NetWt line 1', '8.200');
  await value(page, 'Fine line 1', '7.511');
  // CommPassAdd (:2830): the next row starts with the previous row's transfer item.
  await pick(page, 'TagNo line 2', 'JTAG001');
  await value(page, 'TrfrItm line 2', 'JOG');
  await value(page, 'TrfrItmName line 2', 'Journey Old Gold');
  await value(page, 'Fine line 2', '9.360');
  await text(page, 'tag-transfer-total-grossWt', '18.700');
  await text(page, 'tag-transfer-total-fine', '16.871');
  await checkpoint('tag-transfer-before-save', page);
  await page.getByTestId('tag-transfer-save').click();
  await text(page, 'tag-transfer-status', 'Saved voucher 00001');

  const transferRow = { trfr: 'JOG', it: 'JRNG' };
  const t1 = { tag: 'JTAG003', id: 910000003, gwt: 8.2, less: 0, nwt: 8.2, fine: 7.511 };
  const t2 = { tag: 'JTAG001', id: 910000001, gwt: 10.5, less: 0.5, nwt: 10, fine: 9.36 };
  assert.deepEqual(await details('TTR'), [
    { sr: 1, old: 1, ...t1, ...transferRow, lbr: 820, oth: 0, kr_nwt: 8, kr_fine: 7.328 },
    { sr: 2, old: 2, ...t2, ...transferRow, lbr: 1500, oth: 1200, kr_nwt: 9.91, kr_fine: 9.15 },
  ]);
  assert.deepEqual(await stamps('TTR'), [
    { ...cancelStamp, VCH_TYPE: 'TAGTR', BOOK_NAME: 'TAG TRFR' },
  ]);
  // Tag_Can_Stk inserts 1 and 2: the tag leaves ('-', O) and its metal enters the loose item ('+', I, TAG N,
  // serial 0, counter 001) with the same pieces, weights and fine and no money.
  const into = (sr, line) => ({
    sr,
    isr: 2,
    tag: 'N',
    id: 0,
    it: 'JOG',
    sign: '+',
    tr: 'I',
    tbl: '001',
    gwt: line.gwt,
    nwt: line.nwt,
    fine: line.fine,
    ...noMoney,
  });
  assert.deepEqual(await stock('TTR'), [
    out(1, { ...t1, it: 'JRNG' }, { lbr: 820, oth: 0 }),
    into(1, t1),
    out(2, { ...t2, it: 'JRNG' }, { lbr: 1500, oth: 1200 }),
    into(2, t2),
  ]);
  const [moved] = await rows(
    `SELECT sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_FINE" ELSE -"ITM_FINE" END)::float8 AS net,
            sum(CASE WHEN "IT_CODE"='JOG' THEN "ITM_FINE" ELSE 0 END)::float8 AS loose
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TTR'`,
  );
  assert.deepEqual(moved, { net: 0, loose: 16.871 }, 'the transfer conserves the fine');
  assert.deepEqual(await stones('TTR'), [{ ...diamond, sr: 2, pcs: 10, lbr: 200, net: 1200 }]);
  // A transfer writes no diamond register.
  await none('DM_DATA', 'TTR');
  assert.equal(await live('JTAG003', 910000003), false);
  assert.equal(await live('JTAG001', 910000001), false);
  await sourceUnchanged('by the transfer');
  await page.getByRole('button', { name: 'Update', exact: true }).waitFor();
  await value(page, 'Fine line 1', '7.511');
  await value(page, 'TrfrItm line 2', 'JOG');
  await checkpoint('tag-transfer-saved', page);

  const transferDeletion = acceptNextDialog(page);
  await page.getByTestId('tag-transfer-delete').click();
  assert.equal(await transferDeletion, 'Are You Sure To Delete This Voucher now?');
  await text(page, 'tag-transfer-status', 'Delete Success. Voucher 00001');
  const transferAudit = {
    ...audit,
    VCH_TYPE: 'TAGTR',
    BOOK_NAME: 'Tag Transfer',
    day: '2024-06-11',
  };
  assert.deepEqual(await audits('TTR'), [
    { sr: 1, ...transferAudit, fine_cr: 8.2, VCH_DESC: 'ItCode/JRNG TagNo/JTAG003' },
    { sr: 2, ...transferAudit, fine_cr: 10, VCH_DESC: 'ItCode/JRNG TagNo/JTAG001' },
  ]);
  for (const table of [
    'BAR_CAN_DATA',
    'BAR_CAN_DETL',
    'BAR_CAN_IDTL',
    'MAIN_STOCK',
    'TEMP_BOOK_DATA',
  ])
    await none(table, 'TTR');
  assert.equal(await live('JTAG003', 910000003), true);
  assert.equal(await live('JTAG001', 910000001), true);
  await sourceUnchanged('by the transfer delete');

  return {
    checks: [
      'each page offers only its own in-use book (TAG CANCEL / TAG TRFR) and the next voucher number',
      'a picked tag fills its row, stone and photograph; ItCode, Counter, Pcs and KrCode are read-only on it',
      'a typed tag resolves on leaving the cell; Duplicate Tag No, a sold tag and an ambiguous number are refused',
      'the live instance picked by its serial is the one saved; the other instance stays in stock',
      'a loose line recomputes net and fine on leaving each cell; the totals row equals the stored lines',
      'register header, lines, stones, TEMP_BOOK_DATA, MAIN_STOCK and DM_DATA read back with the desktop values',
      'an edit with Ctrl+D, a stone change and a touch change keeps the hidden number, clock, user and OLD_SRNO',
      'reopen by number and the voucher list restore the saved voucher',
      'delete writes DELETE_DATA per line, removes the write set and gives every tag back',
      'a transfer recomputes the hidden labour, copies the transfer item to the next row, moves the metal to the loose item and conserves the fine',
      'the source tags, their stones and their photograph never change',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture; not an independent desktop comparison or business acceptance',
  };
}
