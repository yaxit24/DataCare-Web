import { roundHalfEven, vbVal } from '@datacare/core';
import { insertRowTx } from '../posting/posting.js';
import { withTxBudget } from '../shared/txBudget.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { barTagAvailableSql } from '../shared/stockSql.js';
import { TAG_PRINT_STAGING_COLUMNS, renderTagLabels, type PrintableTag } from './tagPrint.js';

/**
 * Tag Print (desktop UT_TAG_PRINT, menu Other → Tag Print; MDI_FORM.cs:8596-8605 opens the form directly).
 *
 * - Load (UT_TAG_PRINT.cs:4735-5013): the user's rights row, the label files of PRINT_MAST (PRINT_TYPE 'QR' when
 *   QR_CODE_GEN is on, else 'TAG') with the one marked PRINT_SET_A 'Y' selected, and the item types (Gold first when
 *   CO_MAST.METAL_TYPE is G, else Silver).
 * - The grid is filled from a voucher (tBookCode, tVchNo: the voucher's BAR_DETL rows by SR_NO; a book of the
 *   Tag Cancel family reads BAR_CAN_DETL joined to BAR_DETL, :5284-5403) or from the stock (tGrCode, tPrCode and the
 *   item type: the in-stock tags of the location by item and tag, MSG_VCH_FILL :5575-5635), every row marked Y. A
 *   tag typed in the TagNo column is looked up in the location's stock, the latest instance first (:4102-4420).
 * - Print (BtnPrint_Click :5122-5226) needs the print right, clears TAG_PRINT_DATA, writes the label-skip rows
 *   (SR_NO 1..n, VCH_NO 00000, IT_CODE '00') and copies the BAR_DETL row of every Y row into it; the label file then
 *   reads TAG_PRINT_DATA.
 * - Hm Id Update (chkHmIdUpdate :5656-5666, BtnSave_Click :5073-5096) writes HM_ID..HM_ID4, their weights, LBR_PRC,
 *   ITM_MRP and LBR_RATE back to BAR_DETL for every row with a tag and an HM id or a Lbr% or Mrp, then prints.
 * - Set (BtnTagSet_Click :5636-5655) marks the chosen file PRINT_SET_A 'Y' and the others 'N'.
 *
 * Deliberate differences, recorded on the gap: a voucher of the Tag Cancel family is found by its book's table
 * (BAR_CAN_DATA) instead of the literal book code 140; the stock rule is the web's tag balance over MAIN_STOCK
 * (every year) rather than the year's rows; TAG_PRINT_DATA is cleared for the tenant only, and IMAGE_DATA is not
 * cleared (the desktop's unqualified DELETE FROM IMAGE_DATA also removes scheme member pictures); the labels print in
 * the web's label sheet because the Crystal label files are not in the repository; Hm Id Update and Set need the edit
 * right (the desktop checks none). The RFID writer and the Print Type combo (shown for named registrations only,
 * :4960-4980) and the QR picture are left out.
 */
export class TagPrintValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagPrintValidationError';
  }
}

export interface TagPrintScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

/** cboItemTyp's items (Load :4990-4997); the filter is the first letter of the item type. */
export const TAG_PRINT_ITEM_TYPES: ReadonlyArray<readonly [string, string]> = [
  ['Gold', 'G'],
  ['Silver', 'S'],
  ['Diamond', 'D'],
  ['Real Stone', 'R'],
  ['Emitation', 'E'],
  ['Other', 'O'],
  ['Platinum', 'P'],
];

export const TAG_PRINT_MESSAGES = {
  NO_PRINT_RIGHTS: 'You Have No Print Rights.....',
  HM_FIRST: 'Please First Update Hmid Data and Then print',
  DUPLICATE_TAG: 'Duplicate Tag No',
  REMOVE_ROW: 'This Row Record will Removed permantley ?',
} as const;

/** One grid row (MSG columns 1-44 of MSG_CLEAR :1816-2077). */
export interface TagPrintRow {
  tagNo: string;
  itCode: string;
  itName: string;
  counter: string;
  design: string;
  size: string;
  lCode: string;
  bagWt: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  ghatWt: string;
  touch: string;
  wastage: string;
  fine: string;
  lbrPrc: string;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  mrp: string;
  krCode: string;
  vchSrno: number;
  hmIds: [string, string, string, string];
  hmWts: [string, string, string, string];
}

const text = (v: unknown): string => String(v ?? '').trim();
/** Strings.Format(Val(x), "0.000") / "0.00". */
const fmt = (v: unknown, places: number): string => roundHalfEven(vbVal(v), places).toFixed(places);

function rowOf(r: any): TagPrintRow {
  return {
    tagNo: text(r.TAG_NO),
    itCode: text(r.IT_CODE),
    itName: text(r.IT_NAME),
    counter: text(r.TBL_CODE),
    design: text(r.DESIGN_NO),
    size: text(r.ITM_SIZE),
    lCode: text(r.LBR_CODE),
    bagWt: fmt(r.BAG_WT, 3),
    pcs: text(r.ITM_PCS),
    grossWt: fmt(r.ITM_GWT, 3),
    netWt: fmt(r.ITM_NWT, 3),
    ghatWt: fmt(r.ITM_GHT_WT, 3),
    touch: fmt(r.ITM_TOUCH, 2),
    wastage: fmt(r.ITM_WEST_PRC, 2),
    fine: fmt(r.ITM_FINE, 3),
    lbrPrc: fmt(r.LBR_PRC, 2),
    lbrType: text(r.LBR_TYPE),
    lbrRate: fmt(r.LBR_RATE, 2),
    lbrAmt: fmt(r.LBR_AMT, 2),
    othAmt: fmt(r.OTH_AMT, 2),
    mrp: fmt(r.ITM_MRP, 2),
    krCode: text(r.KR_NAME),
    vchSrno: Number(r.VCH_SRNO ?? 0),
    hmIds: [text(r.HM_ID), text(r.HM_ID2), text(r.HM_ID3), text(r.HM_ID4)],
    hmWts: [fmt(r.HM_ID_WT, 3), fmt(r.HM_ID2_WT, 3), fmt(r.HM_ID3_WT, 3), fmt(r.HM_ID4_WT, 3)],
  };
}

const ITEM_JOIN = `LEFT JOIN "ITEM_MAST" i ON i.tenant_id=b.tenant_id AND i."CO_CODE"=b."CO_CODE" AND i."IT_CODE"=b."IT_CODE"`;

export interface TagPrintSetup {
  files: string[];
  defaultFile: string;
  qr: boolean;
  itemTypes: string[];
  itemType: string;
}

/** Load: the label files, the default file and the default item type. */
export async function tagPrintSetup(prisma: any, scope: TagPrintScope): Promise<TagPrintSetup> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const behavior = await resolveSettingsBehaviorTx(tx, scope);
    const qr = behavior.qrCodeGeneration;
    const files: any[] = await tx.$queryRawUnsafe(
      `SELECT "PRINT_FILE","PRINT_SET_A" FROM "PRINT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PRINT_TYPE"=$3
        ORDER BY "PRINT_FILE", row_id`,
      scope.tenantId,
      scope.coCode,
      qr ? 'QR' : 'TAG',
    );
    const [co]: any[] = await tx.$queryRawUnsafe(
      `SELECT "METAL_TYPE" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
    );
    const names = files.map((f) => text(f.PRINT_FILE)).filter(Boolean);
    const marked = files.find((f) => text(f.PRINT_SET_A) === 'Y');
    // MS_OPNCOMP.cs:481-485: a blank METAL_TYPE is G.
    const metal = text(co?.METAL_TYPE) || 'G';
    return {
      files: names,
      defaultFile: marked ? text(marked.PRINT_FILE) : (names[0] ?? ''),
      qr,
      itemTypes: TAG_PRINT_ITEM_TYPES.map(([name]) => name),
      itemType: metal === 'G' ? 'Gold' : 'Silver',
    };
  });
}

/** BtnTagSet_Click: the chosen file becomes the default of its type. */
export async function tagPrintSetDefault(
  prisma: any,
  scope: TagPrintScope,
  fileRaw: string,
): Promise<{ defaultFile: string }> {
  const file = text(fileRaw);
  if (!file) throw new TagPrintValidationError('choose a print file first');
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const behavior = await resolveSettingsBehaviorTx(tx, scope);
    const type = behavior.qrCodeGeneration ? 'QR' : 'TAG';
    const [known]: any[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "PRINT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PRINT_TYPE"=$3 AND "PRINT_FILE"=$4 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      type,
      file,
    );
    if (!known) throw new TagPrintValidationError(`print file ${file} is not in PRINT_MAST`);
    await tx.$executeRawUnsafe(
      `UPDATE "PRINT_MAST" SET "PRINT_SET_A"=CASE WHEN "PRINT_FILE"=$4 THEN 'Y' ELSE 'N' END
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PRINT_TYPE"=$3`,
      scope.tenantId,
      scope.coCode,
      type,
      file,
    );
    return { defaultFile: file };
  });
}

/** tBookCode_KeyDown (:5439-5482): the book of the location, and whether it is a Tag Cancel family book. */
export async function tagPrintBook(
  prisma: any,
  scope: TagPrintScope,
  codeRaw: string,
): Promise<{ code: string; name: string; cancelFamily: boolean } | null> {
  const code = text(codeRaw).toUpperCase();
  if (!code) return null;
  const [book]: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "CO_BOOK","BOOK_NAME","BOOK_TBL_NAME" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      code,
    ),
  );
  if (!book) return null;
  return {
    code: text(book.CO_BOOK),
    name: text(book.BOOK_NAME),
    cancelFamily: text(book.BOOK_TBL_NAME).toUpperCase() === 'BAR_CAN_DATA',
  };
}

/** The book help: the location's books that have tags (BAR_DETL) or tag-cancel rows, with their names. */
export async function tagPrintBooks(
  prisma: any,
  scope: TagPrintScope,
): Promise<Array<{ name: string; code: string }>> {
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT t.book, coalesce(max(k."BOOK_NAME"),'') name FROM (
          SELECT "CO_BOOK" book FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          UNION SELECT "CO_BOOK" FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4) t
        LEFT JOIN "BOOK_DATA" k ON k.tenant_id=$1 AND k."CO_CODE"=$2 AND k."LC_CODE"=$3 AND k."CO_BOOK"=t.book
        WHERE coalesce(t.book,'')<>'' GROUP BY t.book ORDER BY t.book`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
    ),
  );
  return rows.map((r) => ({ name: text(r.name), code: text(r.book) }));
}

/** tVchNo's help (:5318-5326): the book's vouchers with their date and party. */
export async function tagPrintVouchers(
  prisma: any,
  scope: TagPrintScope,
  bookRaw: string,
): Promise<Array<{ vchNo: string; vchDate: string; party: string }>> {
  const book = await tagPrintBook(prisma, scope, bookRaw);
  if (!book) return [];
  const table = book.cancelFamily ? 'BAR_CAN_DETL' : 'BAR_DETL';
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT a."VCH_NO" v, to_char(min(a."VCH_DATE"),'DD/MM/YYYY') d, coalesce(max(p."AC_NAME"),'') party
         FROM "${table}" a LEFT JOIN "AC_MAST" p ON p.tenant_id=a.tenant_id AND p."CO_CODE"=a."CO_CODE" AND p."AC_CODE"=a."AC_CODE"
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5
        GROUP BY a."VCH_NO" ORDER BY a."VCH_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      book.code,
    ),
  );
  return rows.map((r) => ({ vchNo: text(r.v), vchDate: text(r.d), party: text(r.party) }));
}

/** tVchNo_KeyDown (:5284-5403): the voucher's tags by SR_NO, every row marked Y. */
export async function tagPrintVoucher(
  prisma: any,
  scope: TagPrintScope,
  bookRaw: string,
  vchNoRaw: string,
): Promise<TagPrintRow[]> {
  const book = await tagPrintBook(prisma, scope, bookRaw);
  const vchNo = text(vchNoRaw);
  if (!book || !vchNo) return [];
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = book.cancelFamily
      ? await tx.$queryRawUnsafe(
          `SELECT b.*, i."IT_NAME" FROM "BAR_CAN_DETL" c
             JOIN "BAR_DETL" b ON b.tenant_id=c.tenant_id AND b."CO_CODE"=c."CO_CODE" AND b."TAG_NO"=c."TAG_NO"
                              AND b."VCH_SRNO"=c."VCH_SRNO"
             ${ITEM_JOIN}
            WHERE c.tenant_id=$1 AND c."CO_CODE"=$2 AND c."LC_CODE"=$3 AND c."CO_YEAR"=$4 AND c."CO_BOOK"=$5 AND c."VCH_NO"=$6
            ORDER BY c."SR_NO", b.row_id`,
          scope.tenantId,
          scope.coCode,
          scope.lcCode,
          scope.coYear,
          book.code,
          vchNo,
        )
      : await tx.$queryRawUnsafe(
          `SELECT b.*, i."IT_NAME" FROM "BAR_DETL" b ${ITEM_JOIN}
            WHERE b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3 AND b."CO_YEAR"=$4 AND b."CO_BOOK"=$5 AND b."VCH_NO"=$6
            ORDER BY b."SR_NO", b.row_id`,
          scope.tenantId,
          scope.coCode,
          scope.lcCode,
          scope.coYear,
          book.code,
          vchNo,
        );
    return rows.filter((r) => text(r.TAG_NO)).map(rowOf);
  });
}

/** One instance per tag: the latest BAR_DETL row of each in-stock (TAG_NO, VCH_SRNO). */
const STOCK_SQL = (extra: string) => `
  SELECT * FROM (
    SELECT DISTINCT ON (b."TAG_NO", b."VCH_SRNO") b.*, i."IT_NAME", i."GR_CODE" item_group, i."PR_CODE" item_product,
           i."IT_TYPE" item_type
      FROM "BAR_DETL" b ${ITEM_JOIN}
     WHERE b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3 AND coalesce(b."TAG_NO",'')<>''
       AND ${barTagAvailableSql('b')} ${extra}
     ORDER BY b."TAG_NO", b."VCH_SRNO", b."VCH_TIME" DESC NULLS LAST, b.row_id DESC) s`;

/**
 * MSG_VCH_FILL (:5575-5635): the location's in-stock tags with a stock date up to today, by product, group and item
 * type, ordered by item and tag.
 */
export async function tagPrintStock(
  prisma: any,
  scope: TagPrintScope,
  filters: { group?: string; product?: string; itemType?: string },
): Promise<TagPrintRow[]> {
  const params: unknown[] = [scope.tenantId, scope.coCode, scope.lcCode];
  const where: string[] = [];
  const add = (sql: string, value: unknown) => {
    params.push(value);
    where.push(sql.replace('?', `$${params.length}`));
  };
  if (text(filters.product)) add('item_product=?', text(filters.product).toUpperCase());
  if (text(filters.group)) add('item_group=?', text(filters.group).toUpperCase());
  const type = TAG_PRINT_ITEM_TYPES.find(([name]) => name === text(filters.itemType));
  if (type) add('item_type=?', type[1]);
  // C.STK_DATE <= today (:5578); the web keeps STK_DATE as ISO text, a text it cannot read passes.
  add(
    `(s."STK_DATE" !~ '^\\d{4}-\\d{2}-\\d{2}' OR substr(s."STK_DATE",1,10) <= ?)`,
    new Date().toISOString().slice(0, 10),
  );
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `${STOCK_SQL('')} WHERE ${where.join(' AND ')} ORDER BY s."IT_CODE", s."TAG_NO", s."VCH_SRNO"`,
      ...params,
    );
    return rows.map(rowOf);
  });
}

/** A tag typed in the TagNo column (:4102-4420): its latest in-stock instance at the location. */
export async function tagPrintTag(
  prisma: any,
  scope: TagPrintScope,
  tagNoRaw: string,
): Promise<TagPrintRow | null> {
  const tagNo = text(tagNoRaw).toUpperCase();
  if (!tagNo) return null;
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const [row]: any[] = await tx.$queryRawUnsafe(
      `${STOCK_SQL('AND b."TAG_NO"=$4')} ORDER BY s."VCH_TIME" DESC NULLS LAST, s.row_id DESC LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      tagNo,
    );
    return row ? rowOf(row) : null;
  });
}

/** The TagNo help (:4132-4136): the location's in-stock tags by tag. */
export async function tagPrintTags(
  prisma: any,
  scope: TagPrintScope,
): Promise<Array<Record<string, string>>> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `${STOCK_SQL('')} ORDER BY s."TAG_NO", s."VCH_TIME" DESC NULLS LAST LIMIT 2000`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    return rows.map((r) => ({
      tagNo: text(r.TAG_NO),
      itName: text(r.IT_NAME),
      itCode: text(r.IT_CODE),
      design: text(r.DESIGN_NO),
      grossWt: fmt(r.ITM_GWT, 3),
      netWt: fmt(r.ITM_NWT, 3),
      mrp: fmt(r.ITM_MRP, 2),
      vchSrno: String(r.VCH_SRNO ?? ''),
    }));
  });
}

/** The group and product helps of tGrCode and tPrCode (:5499-5574). */
export async function tagPrintLookups(
  prisma: any,
  scope: TagPrintScope,
  kind: 'groups' | 'products',
): Promise<Array<Record<string, string>>> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] =
      kind === 'groups'
        ? await tx.$queryRawUnsafe(
            `SELECT "GR_NAME" name,"GR_CODE" code,"GR_TYPE" type,"TRAD_TYPE" trade FROM "GROUP_MAST"
              WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "GR_NAME", row_id`,
            scope.tenantId,
            scope.coCode,
          )
        : await tx.$queryRawUnsafe(
            `SELECT "PR_NAME" name,"PR_CODE" code FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
              ORDER BY "PR_NAME", row_id`,
            scope.tenantId,
            scope.coCode,
          );
    return rows.map((r) =>
      Object.fromEntries(Object.entries(r).map(([k, v]) => [k, text(v)])),
    ) as Array<Record<string, string>>;
  });
}

export interface TagPrintHmInput {
  tagNo: string;
  vchSrno: number;
  hmIds?: string[];
  hmWts?: Array<string | number>;
  lbrPrc?: string | number;
  mrp?: string | number;
  lbrRate?: string | number;
}

/** BtnSave_Click (:5073-5096): the HM ids and weights, Lbr%, Mrp and LRate of every changed row back to BAR_DETL. */
export async function tagPrintHmUpdate(
  prisma: any,
  scope: TagPrintScope,
  rows: TagPrintHmInput[],
): Promise<{ updated: number }> {
  // MSG[i,2] <> "" And (MSG[i,10] <> "" Or Val(MSG[i,32]) + Val(MSG[i,30]) <> 0) (:5085).
  const work = rows.filter(
    (r) => text(r.tagNo) && (text(r.hmIds?.[0]) !== '' || vbVal(r.lbrPrc) + vbVal(r.mrp) !== 0),
  );
  for (const r of work)
    for (const id of r.hmIds ?? [])
      if (text(id).length > 10)
        throw new TagPrintValidationError('an HM id is at most 10 characters');
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    let updated = 0;
    for (const r of work) {
      const ids = [0, 1, 2, 3].map((i) => text(r.hmIds?.[i]).toUpperCase());
      const wts = [0, 1, 2, 3].map((i) => vbVal(r.hmWts?.[i]));
      updated += Number(
        await tx.$executeRawUnsafe(
          `UPDATE "BAR_DETL" SET "HM_ID"=$5,"HM_ID_WT"=$6,"HM_ID2"=$7,"HM_ID2_WT"=$8,"HM_ID3"=$9,"HM_ID3_WT"=$10,
                  "HM_ID4"=$11,"HM_ID4_WT"=$12,"LBR_PRC"=$13,"ITM_MRP"=$14,"LBR_RATE"=$15
            WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAG_NO"=$3 AND coalesce("VCH_SRNO",0)=$4`,
          scope.tenantId,
          scope.coCode,
          text(r.tagNo).toUpperCase(),
          Number(r.vchSrno ?? 0),
          ids[0],
          wts[0],
          ids[1],
          wts[1],
          ids[2],
          wts[2],
          ids[3],
          wts[3],
          vbVal(r.lbrPrc),
          vbVal(r.mrp),
          vbVal(r.lbrRate),
        ),
      );
    }
    return { updated };
  });
}

export interface TagPrintStageInput {
  book: string;
  labelSkip?: string | number;
  tags: Array<{ tagNo: string; vchSrno: number }>;
}

/**
 * BtnPrint_Click (:5131-5175): TAG_PRINT_DATA cleared, the label-skip rows written (Math.Round of Val, banker's), then
 * the BAR_DETL row of every Y row copied, in grid order.
 */
export async function tagPrintStage(
  prisma: any,
  scope: TagPrintScope,
  input: TagPrintStageInput,
): Promise<{ skipped: number; staged: number }> {
  const skip = Math.max(0, roundHalfEven(vbVal(input.labelSkip), 0));
  if (skip > 500) throw new TagPrintValidationError('Lable Skip is at most 500');
  const tags = input.tags.filter((t) => text(t.tagNo));
  if (!tags.length && !skip) throw new TagPrintValidationError('mark at least one tag Y to print');
  const book = text(input.book).toUpperCase();
  const cols = TAG_PRINT_STAGING_COLUMNS.filter((c) => c !== 'CO_CODE').map((c) => `"${c}"`);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(`DELETE FROM "TAG_PRINT_DATA" WHERE tenant_id=$1`, scope.tenantId);
    for (let i = 1; i <= skip; i += 1)
      await insertRowTx(tx, 'TAG_PRINT_DATA', scope.tenantId, {
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
        CO_YEAR: scope.coYear,
        CO_BOOK: book,
        VCH_NO: '00000',
        SR_NO: i,
        IT_CODE: '00',
        VCH_SRNO: 0,
      });
    let staged = 0;
    for (const t of tags)
      staged += Number(
        await tx.$executeRawUnsafe(
          `INSERT INTO "TAG_PRINT_DATA"(tenant_id,"CO_CODE",${cols.join(',')})
             SELECT $1::text,$2::text,${cols.join(',')} FROM "BAR_DETL"
              WHERE row_id=(SELECT row_id FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                              AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)=$5 ORDER BY row_id DESC LIMIT 1)`,
          scope.tenantId,
          scope.coCode,
          scope.lcCode,
          text(t.tagNo).toUpperCase(),
          Number(t.vchSrno ?? 0),
        ),
      );
    return { skipped: skip, staged };
  });
}

/** The label sheet of the staged rows (the label file reads SELECT * FROM TAG_PRINT_DATA). */
export async function tagPrintLabels(prisma: any, scope: TagPrintScope): Promise<string> {
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT * FROM "TAG_PRINT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id`,
      scope.tenantId,
      scope.coCode,
    ),
  );
  const skip = rows.filter((r) => text(r.IT_CODE) === '00' && Number(r.VCH_SRNO ?? 0) === 0).length;
  const tags: PrintableTag[] = rows
    .filter((r) => text(r.TAG_NO))
    .map((r) => ({
      tagNo: text(r.TAG_NO),
      itCode: text(r.IT_CODE),
      designNo: text(r.DESIGN_NO) || null,
      tblCode: text(r.TBL_CODE) || null,
      netWt: vbVal(r.ITM_NWT),
      grossWt: vbVal(r.ITM_GWT),
      touch: vbVal(r.ITM_TOUCH),
      mrp: vbVal(r.ITM_MRP),
      rate: vbVal(r.ITM_RATE),
      hmId: text(r.HM_ID) || null,
      pcs: vbVal(r.ITM_PCS),
      lbrRate: vbVal(r.LBR_RATE),
      lbrAmt: vbVal(r.LBR_AMT),
    }));
  return renderTagLabels(tags, skip);
}
