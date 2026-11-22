import { round } from '@datacare/core';
import { insertRowTx } from '../posting/posting.js';

/**
 * The tag part of an Order Cancel voucher (desktop TR_SL_ORD_ADJ). An order line can hold a tag back from stock
 * (SL_ORD_DETL.TAG_STK_LESS = 'Y', the order's MAIN_STOCK '-' row, Ac_Stock.cs:94). Cancelling the order releases it:
 *
 * - picking an order fills the tag grid with its lines `TAG_SALE = 'N' AND TAG_STK_LESS = 'Y'` (TR_SL_ORD_ADJ.cs:2598);
 * - Save writes, for every tag row with an item, a tag and an MRP, or with pieces or gross weight (:3610):
 *   an APR_DETL line (ENTRY_TYPE 'I', ISU_REC 'Y', the order line's key in ISU_NO/ISU_YRCD/ISU_DBCD/ISU_SRNO,
 *   :3611-3649), a copy of the tag's latest BAR_DETL instance (ENTRY_TYPE 'D', a new VCH_SRNO, the order link
 *   cleared, :3650) and of its stone rows in BAR_IDTL (:3652);
 * - marks the order lines sold, SL_ORD_DETL.TAG_SALE = 'Y' (:3659);
 * - Ac_Stock.Ord_Adj_Stk (Ac_Stock.cs:610-622) puts each copied tag back into MAIN_STOCK: SR_NO 2, TR_TYPE 'I', '+'.
 * Delete sets TAG_SALE back to 'N' first (:3743) and then removes the voucher's rows.
 *
 * Deliberate differences, each a desktop weakness: the desktop restarts the tag grid at row 1 for every order picked,
 * so a second order's tags overwrite the first's; here the rows of all orders are numbered one after another. The
 * desktop copies every BAR_IDTL row ever written for the tag number and instance; here only the stone rows of the
 * BAR_DETL instance that is copied.
 */

/** BAR_DETL columns the desktop copies (TR_SL_ORD_ADJ.cs:3650), in its order. */
const BAR_DETL_COLUMNS =
  `CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,
ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,
ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,
ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,
KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,
ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,
HM_ID4_WT,HM_ID,DATA_TYPE,APP_TRFR,ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,
JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID`
    .split(',')
    .map((c) => c.trim());

/** BAR_IDTL columns the desktop copies (TR_SL_ORD_ADJ.cs:3652). */
const BAR_IDTL_COLUMNS =
  `CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,
AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,
IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,
KR_LBR_AMT,KR_NET_AMT,MAIN_USER,DM_NAME,OLD_VCH_NO,NEW_VCH_NO,DM_ORIGIN,DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC`
    .split(',')
    .map((c) => c.trim());

const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => Number(value ?? 0) || 0;

export interface OrderTagScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
}

export interface OrderTagRow {
  srNo: number;
  ordNo: string;
  ordYear: string;
  ordBook: string;
  ordSrNo: number;
  acCode: string;
  tagNo: string;
  tagSrNo: number;
  itCode: string;
  itName: string;
  tblCode: string;
  designNo: string;
  pcs: number;
  gwt: number;
  othWt: number;
  nwt: number;
  mrp: number;
}

/** VB `Conversion.Val`: the leading number of a text, 0 when there is none. */
const val = (value: unknown): string => {
  const m = /^\s*(\d+(?:\.\d+)?)/.exec(String(value ?? ''));
  return String(m ? Number(m[1]) : 0);
};

/**
 * The tag instance number a copied tag gets (TR_SL_ORD_ADJ.cs:3650): Val(CO_CODE) & Val(LC_CODE) & first character of
 * the year & Val(CO_BOOK) & Val(VCH_NO) & Val(SR_NO), joined as text.
 */
export function orderCancelTagSrNo(scope: OrderTagScope, voucherNo: string, srNo: number): number {
  return Number(
    val(scope.coCode) +
      val(scope.lcCode) +
      String(scope.coYear).slice(0, 1) +
      val(scope.coBook) +
      val(voucherNo) +
      val(srNo),
  );
}

/** The reserved tag lines of the orders, in grid order (TR_SL_ORD_ADJ.cs:2598-2631). */
export async function reservedOrderTagsTx(
  tx: any,
  scope: OrderTagScope,
  orders: Array<{ ordNo: string; ordYear: string; ordBook: string }>,
): Promise<OrderTagRow[]> {
  const out: OrderTagRow[] = [];
  for (const order of orders) {
    const lines: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."AC_CODE",a."TAG_NO",a."VCH_NO",a."IT_CODE",b."IT_NAME",a."TBL_CODE",a."DESIGN_NO",
              coalesce(a."ITM_PCS",0)::float pcs,coalesce(a."ITM_GWT",0)::float gwt,coalesce(a."ITM_OTH_WT",0)::float oth,
              coalesce(a."ITM_NWT",0)::float nwt,coalesce(a."ITM_MRP",0)::float mrp,coalesce(a."VCH_SRNO",0)::float vsr,
              a."CO_YEAR",a."CO_BOOK",coalesce(a."OLD_SRNO",0)::float old
         FROM "SL_ORD_DETL" a
         LEFT JOIN LATERAL (SELECT m."IT_NAME" FROM "ITEM_MAST" m
                             WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE" AND m."IT_CODE"=a."IT_CODE"
                             LIMIT 1) b ON true
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
          AND a."TAG_SALE"='N' AND a."TAG_STK_LESS"='Y'
        ORDER BY a."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      order.ordYear,
      order.ordBook,
      order.ordNo,
    );
    for (const l of lines) {
      const tag = text(l.TAG_NO);
      out.push({
        srNo: out.length + 1,
        ordNo: text(l.VCH_NO),
        ordYear: text(l.CO_YEAR),
        ordBook: text(l.CO_BOOK),
        ordSrNo: num(l.old),
        acCode: text(l.AC_CODE),
        tagNo: tag === 'N' ? '' : tag,
        tagSrNo: num(l.vsr),
        itCode: text(l.IT_CODE),
        itName: text(l.IT_NAME),
        tblCode: text(l.TBL_CODE),
        designNo: text(l.DESIGN_NO),
        pcs: num(l.pcs),
        gwt: round(num(l.gwt), 3),
        othWt: round(num(l.oth), 3),
        nwt: round(num(l.nwt), 3),
        mrp: round(num(l.mrp), 2),
      });
    }
  }
  // :3610 — a row is saved when it names an item, a tag and an MRP, or carries pieces or gross weight.
  return out.filter((t) => (t.itCode && t.tagNo && t.mrp !== 0) || t.pcs + t.gwt !== 0);
}

async function columnsOfTx(tx: any, table: string): Promise<Set<string>> {
  const rows: Array<{ column_name: string }> = await tx.$queryRawUnsafe(
    `SELECT column_name FROM information_schema.columns WHERE table_schema=current_schema() AND table_name=$1`,
    table,
  );
  return new Set(rows.map((r) => r.column_name));
}

const pick = (row: Record<string, unknown>, columns: string[], present: Set<string>) =>
  Object.fromEntries(columns.filter((c) => present.has(c) && c in row).map((c) => [c, row[c]]));

export interface OrderCancelTagContext {
  scope: OrderTagScope;
  voucherNo: string;
  hiddenVoucherNo: string;
  vchDate: Date;
  voucherTime: Date;
  book: { shortName: string; inout: string; mainBook: string; dataType: string };
  mainUser: string;
  empCode: string;
}

/** Writes the tag rows of a cancel voucher and returns the MAIN_STOCK rows Ord_Adj_Stk derives from them. */
export async function writeOrderCancelTagsTx(
  tx: any,
  ctx: OrderCancelTagContext,
  tags: OrderTagRow[],
): Promise<void> {
  if (!tags.length) return;
  const { scope, voucherNo } = ctx;
  const key = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
  const barDetl = await columnsOfTx(tx, 'BAR_DETL');
  const barIdtl = await columnsOfTx(tx, 'BAR_IDTL');
  for (const t of tags) {
    await insertRowTx(tx, 'APR_DETL', scope.tenantId, {
      ...key,
      VCH_DATE: ctx.vchDate,
      HD_VCH_NO: ctx.hiddenVoucherNo,
      AC_CODE: t.acCode,
      VCH_TYPE: ctx.book.shortName,
      INOUT_TYPE: ctx.book.inout,
      ENTRY_TYPE: 'I',
      BOOK_NAME: ctx.book.mainBook,
      SR_NO: t.srNo,
      OLD_SRNO: t.srNo,
      ISU_NO: t.ordNo,
      ISU_AC_NAME: '',
      ITM_REMARK: t.itName,
      MTL_COLOR: '',
      ISU_AC_CODE: t.acCode,
      IT_CODE: t.itCode,
      TAG_NO: t.tagNo || 'N',
      VCH_SRNO: t.tagNo ? t.tagSrNo : 0,
      TBL_CODE: t.tblCode,
      DESIGN_NO: t.designNo,
      ITM_PCS: t.pcs,
      ITM_GWT: t.gwt,
      ITM_OTH_WT: t.othWt,
      ITM_NWT: t.nwt,
      ITM_MRP: t.mrp,
      ISU_REC: 'Y',
      ISU_YRCD: t.ordYear,
      ISU_DBCD: t.ordBook,
      ISU_SRNO: t.ordSrNo,
      EMP_SALE: 'N',
      DESIGN_IMG_ID: 'N',
      ORNA_REC_DATE: ctx.vchDate,
      VCH_TIME: ctx.voucherTime,
      MAIN_USER: ctx.mainUser,
      EMP_CODE: ctx.empCode,
    });
    if (!t.tagNo) continue;
    // TOP 1 ... ORDER BY VCH_TIME DESC: the tag's latest instance with this tag instance number.
    const [source]: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4
          AND coalesce("VCH_SRNO",0)=$5
        ORDER BY "VCH_TIME" DESC NULLS LAST, row_id DESC LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      t.tagNo,
      t.tagSrNo,
    );
    if (!source) continue;
    const newSrNo = orderCancelTagSrNo(scope, voucherNo, t.srNo);
    const copy: Record<string, any> = {
      ...pick(source, BAR_DETL_COLUMNS, barDetl),
      ...key,
      SR_NO: t.srNo,
      OLD_SRNO: t.srNo,
      VCH_DATE: ctx.vchDate,
      VCH_TIME: ctx.voucherTime,
      VCH_TYPE: ctx.book.shortName,
      INOUT_TYPE: ctx.book.inout,
      ENTRY_TYPE: 'D',
      BOOK_NAME: ctx.book.mainBook,
      TBL_CODE: t.tblCode,
      VCH_SRNO: newSrNo,
      ORD_NO: '',
      ORD_SRNO: 0,
      ORD_YRCD: '',
      ORD_DBCD: '',
      ORD_AC: '',
    };
    await insertRowTx(tx, 'BAR_DETL', scope.tenantId, copy);
    const stones: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4
          AND coalesce("VCH_SRNO",0)=$5 AND "CO_YEAR"=$6 AND "CO_BOOK"=$7 AND "VCH_NO"=$8
        ORDER BY "ISR_NO", row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      t.tagNo,
      t.tagSrNo,
      source.CO_YEAR,
      source.CO_BOOK,
      source.VCH_NO,
    );
    for (const stone of stones)
      await insertRowTx(tx, 'BAR_IDTL', scope.tenantId, {
        ...pick(stone, BAR_IDTL_COLUMNS, barIdtl),
        ...key,
        SR_NO: t.srNo,
        VCH_DATE: ctx.vchDate,
        VCH_TYPE: ctx.book.shortName,
        INOUT_TYPE: ctx.book.inout,
        ENTRY_TYPE: 'D',
        BOOK_NAME: ctx.book.mainBook,
        VCH_SRNO: newSrNo,
      });
    // Ac_Stock.Ord_Adj_Stk, second insert (Ac_Stock.cs:619): the tag is back in stock.
    await insertRowTx(tx, 'MAIN_STOCK', scope.tenantId, {
      ...key,
      SR_NO: 2,
      ISR_NO: t.srNo,
      VCH_DATE: ctx.vchDate,
      STK_DATE: copy.STK_DATE ?? ctx.vchDate,
      VCH_TYPE: ctx.book.shortName,
      BOOK_NAME: ctx.book.mainBook,
      AC_CODE: copy.AC_CODE ?? null,
      IT_CODE: copy.IT_CODE ?? t.itCode,
      TAG_NO: t.tagNo,
      VCH_SRNO: newSrNo,
      TBL_CODE: t.tblCode,
      TR_TYPE: 'I',
      ITM_SIGN: '+',
      ITM_QTY: 1,
      ITM_PCS: copy.ITM_PCS ?? 0,
      ITM_GWT: copy.ITM_GWT ?? 0,
      ITM_NWT: copy.ITM_NWT ?? 0,
      ITM_TOUCH: copy.ITM_TOUCH ?? 0,
      ITM_WEST: copy.ITM_WEST_PRC ?? 0,
      ITM_FINE: copy.ITM_FINE ?? 0,
      ITM_RATE: copy.ITM_RATE ?? 0,
      ITM_AMT: copy.ITM_AMT ?? 0,
      LBR_RATE: copy.LBR_RATE ?? 0,
      LBR_AMT: copy.LBR_AMT ?? 0,
      OTH_AMT: copy.OTH_AMT ?? 0,
      ITM_MRP: copy.ITM_MRP ?? 0,
      NET_AMT: 0,
      KR_NWT: copy.KR_NET_WT ?? 0,
      KR_TOUCH: copy.KR_TOUCH ?? 0,
      KR_WEST: copy.KR_WEST_PRC ?? 0,
      KR_FINE: copy.KR_FINE ?? 0,
      KR_LBR_AMT: copy.KR_LBR_AMT ?? 0,
      KR_OTH_AMT: copy.KR_OTH_AMT ?? 0,
      KR_COST: copy.KR_COST ?? 0,
      EMP_CODE: '',
      ENTRY_TIME: ctx.voucherTime,
      MAIN_USER: copy.MAIN_USER ?? ctx.mainUser,
      DATA_TYPE: copy.DATA_TYPE ?? ctx.book.dataType,
      DESIGN_NO: copy.DESIGN_NO ?? t.designNo,
      ITM_SIZE: copy.ITM_SIZE ?? null,
      ITM_DESC: '',
      GHT_PRC: copy.ITM_GHT_PRC ?? 0,
      ITM_LOT: '',
      ITM_DISC: 0,
    });
  }
  await markOrderTagsTx(tx, scope, voucherNo, 'Y');
}

/** SL_ORD_DETL.TAG_SALE for the order lines this voucher's APR_DETL names (:3659 'Y', :3743 'N'). */
export async function markOrderTagsTx(
  tx: any,
  scope: OrderTagScope,
  voucherNo: string,
  flag: 'Y' | 'N',
): Promise<void> {
  await tx.$executeRawUnsafe(
    `UPDATE "SL_ORD_DETL" o SET "TAG_SALE"=$7
       FROM "APR_DETL" a
      WHERE o.tenant_id=a.tenant_id AND o."CO_CODE"=a."CO_CODE" AND o."LC_CODE"=a."LC_CODE"
        AND o."VCH_NO"=a."ISU_NO" AND o."CO_YEAR"=a."ISU_YRCD" AND o."CO_BOOK"=a."ISU_DBCD"
        AND coalesce(o."OLD_SRNO",0)=coalesce(a."ISU_SRNO",0)
        AND a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5
        AND a."VCH_NO"=$6`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
    flag,
  );
}

/** The saved tag grid of a voucher (OrderTagFeel, TR_SL_ORD_ADJ.cs:3328-3378). */
export async function savedOrderCancelTagsTx(
  tx: any,
  scope: OrderTagScope,
  voucherNo: string,
): Promise<OrderTagRow[]> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT a."SR_NO",a."ISU_NO",a."ISU_YRCD",a."ISU_DBCD",coalesce(a."ISU_SRNO",0)::float isr,a."AC_CODE",a."TAG_NO",
            coalesce(a."VCH_SRNO",0)::float vsr,a."IT_CODE",coalesce(b."IT_NAME",'') it_name,a."TBL_CODE",a."DESIGN_NO",
            coalesce(a."ITM_PCS",0)::float pcs,coalesce(a."ITM_GWT",0)::float gwt,coalesce(a."ITM_OTH_WT",0)::float oth,
            coalesce(a."ITM_NWT",0)::float nwt,coalesce(a."ITM_MRP",0)::float mrp
       FROM "APR_DETL" a
       LEFT JOIN LATERAL (SELECT m."IT_NAME" FROM "ITEM_MAST" m
                           WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE" AND m."IT_CODE"=a."IT_CODE"
                           LIMIT 1) b ON true
      WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
      ORDER BY a."SR_NO"`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  return rows.map((r) => {
    const tag = text(r.TAG_NO);
    return {
      srNo: num(r.SR_NO),
      ordNo: text(r.ISU_NO),
      ordYear: text(r.ISU_YRCD),
      ordBook: text(r.ISU_DBCD),
      ordSrNo: num(r.isr),
      acCode: text(r.AC_CODE),
      tagNo: tag === 'N' ? '' : tag,
      tagSrNo: num(r.vsr),
      itCode: text(r.IT_CODE),
      itName: text(r.it_name),
      tblCode: text(r.TBL_CODE),
      designNo: text(r.DESIGN_NO),
      pcs: num(r.pcs),
      gwt: num(r.gwt),
      othWt: num(r.oth),
      nwt: num(r.nwt),
      mrp: num(r.mrp),
    };
  });
}
