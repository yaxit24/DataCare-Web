/**
 * Tag housekeeping of a Sales Order (TR_SALE_ORD.cs), for a line that reserves a saved tag (TAG_STK_LESS 'Y').
 *
 * - Save (:9552-9556): BAR_DETL.ORD_NO/ORD_DBCD/ORD_YRCD/ORD_SRNO/ORD_AC take the order's identity (only lines with
 *   TAG_STK_LESS 'Y' and TAG_NO <> 'N'); BAR_DETL.TBL_CODE and MAIN_STOCK.TBL_CODE ('+' rows) take the line's TBL_CODE.
 * - Delete (:9680-9693 refusal, :9702-9706 release): refused when the tag is already in SL_DETL, matched by TAG_NO and
 *   VCH_SRNO; otherwise the ORD_* columns are cleared and both TBL_CODEs return to the line's OLD_TBL_CODE.
 * The web edit cannot add, remove or swap a tag (salesOrder.ts refuses tag identity transitions), so an edit only
 * repeats the save statements for the tags it keeps.
 */
import { SaleValidationError } from './sales.js';

type Tx = {
  $executeRawUnsafe: (sql: string, ...v: unknown[]) => Promise<number>;
  $queryRawUnsafe: (sql: string, ...v: unknown[]) => Promise<any[]>;
};
export interface OrderTagScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
}

const params = (s: OrderTagScope, voucherNo: string) => [
  s.tenantId,
  s.coCode,
  s.lcCode,
  s.coYear,
  s.coBook,
  voucherNo,
];
const ORDER_ROWS = `b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3 AND b."CO_YEAR"=$4 AND b."CO_BOOK"=$5 AND b."VCH_NO"=$6`;

/** The order's saved-tag lines (MSG col 70 'Y', a tag entered), as the desktop's delete loop selects them. */
export async function orderReservedTagsTx(tx: Tx, scope: OrderTagScope, voucherNo: string) {
  return tx.$queryRawUnsafe(
    `SELECT btrim("TAG_NO"::text) AS tag,"VCH_SRNO" AS srno FROM "SL_ORD_DETL" b
      WHERE ${ORDER_ROWS} AND coalesce(btrim("TAG_STK_LESS"::text),'')='Y' AND btrim(coalesce("TAG_NO"::text,''))<>''
      ORDER BY "SR_NO"`,
    ...params(scope, voucherNo),
  );
}

/** TR_SALE_ORD.cs:9684-9693: refuse the delete when a reserved tag already appears in SL_DETL. */
export async function assertOrderTagsNotSoldTx(tx: Tx, scope: OrderTagScope, voucherNo: string) {
  for (const row of await orderReservedTagsTx(tx, scope, voucherNo)) {
    const [sold] = await tx.$queryRawUnsafe(
      `SELECT "CO_BOOK","VCH_NO","SR_NO" FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND btrim("TAG_NO"::text)=$4 AND "VCH_SRNO"=$5 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      row.tag,
      row.srno,
    );
    if (sold)
      throw new SaleValidationError(
        `You Cant Delete This Order Because  This Tag ${row.tag} Sales With  Book =  ${String(sold.CO_BOOK).trim()} And Vch No = ${String(sold.VCH_NO).trim()} And Sr No = ${sold.SR_NO} ... `,
      );
  }
}

/** The tag a new order line's Tag cell takes, with the BAR_DETL figures the save copies. */
export interface PickedOrderTag {
  tagNo: string;
  vchSrno: number;
  /** BAR_DETL.TBL_CODE: the line's counter (mSG col 3) and its OLD_TBL_CODE (col 69), :7596-7597. */
  tblCode: string;
}

/** CO_SET_NEW.ORD_TAG_STK_LESS, 'Y' or 'N' (MsOrdTagLessInStk, MS_OPNCOMP.cs:996, :1200-1203). */
export async function orderTagStockLessSettingTx(
  tx: Tx,
  scope: { tenantId: string; coCode: string },
): Promise<'Y' | 'N'> {
  const [row] = await tx.$queryRawUnsafe(
    `SELECT btrim(coalesce("ORD_TAG_STK_LESS"::text,'')) v FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  return row?.v === 'Y' ? 'Y' : 'N';
}

/**
 * The Tag cell of a new order line (TR_SALE_ORD.cs:7490-7690): the tag must be in stock at the order's location
 * (MAIN_STOCK joined to BAR_DETL on the location, tag and instance, `HAVING SUM(+/- VCH_SRNO) > 0`) and not issued to
 * an employee (`B.EMP_ISU <> 'Y'`), :7496. The desktop then opens its help list instead of taking the tag; the web
 * refuses with the reason. With more than one instance in stock the desktop asks which (:7548-7578): the request
 * must name the instance. The same tag twice in one order is "Duplicate Tag No" (:7538-7545). The tag's BAR_DETL
 * row is locked for the order's transaction (FOR UPDATE), which only serialises two saves of the same tag.
 */
export async function pickOrderTagTx(
  tx: Tx,
  scope: { tenantId: string; coCode: string; lcCode: string },
  line: { tagNo?: string; vchSrno?: number },
  picked: ReadonlyMap<number, PickedOrderTag>,
): Promise<PickedOrderTag> {
  const tagNo = String(line.tagNo ?? '').trim();
  if ([...picked.values()].some((row) => row.tagNo === tagNo))
    throw new SaleValidationError('Duplicate Tag No');
  const srno = Number(line.vchSrno ?? 0) || 0;
  const stock: Array<{ srno: unknown }> = await tx.$queryRawUnsafe(
    `SELECT a."VCH_SRNO" srno FROM "MAIN_STOCK" a
       LEFT JOIN "BAR_DETL" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE"
            AND b."TAG_NO"=a."TAG_NO" AND b."VCH_SRNO"=a."VCH_SRNO"
      WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND btrim(a."TAG_NO"::text)=$4
        AND ($5::numeric=0 OR a."VCH_SRNO"=$5::numeric) AND b."EMP_ISU" <> 'Y'
      GROUP BY a."TAG_NO",a."VCH_SRNO",b."VCH_DATE"
     HAVING sum(CASE WHEN a."ITM_SIGN"='+' THEN a."VCH_SRNO" ELSE -a."VCH_SRNO" END) > 0
      ORDER BY b."VCH_DATE" DESC`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    tagNo,
    srno,
  );
  if (!stock.length)
    throw new SaleValidationError(`Tag ${tagNo} is not in stock at this location.`);
  if (stock.length > 1)
    throw new SaleValidationError(
      `Tag ${tagNo} is in stock more than once; choose the instance (VCH_SRNO).`,
    );
  const vchSrno = Number(stock[0]!.srno);
  const [bar] = await tx.$queryRawUnsafe(
    `SELECT btrim(coalesce("TBL_CODE"::text,'')) tbl FROM "BAR_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND btrim("TAG_NO"::text)=$4 AND "VCH_SRNO"=$5
      LIMIT 1 FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    tagNo,
    vchSrno,
  );
  return { tagNo: tagNo.slice(0, 15), vchSrno, tblCode: String(bar?.tbl ?? '') };
}

/**
 * SL_ORD_DETL.TAG_STK_LESS (mSG col 70). On a Sales Order a new row's cell is CO_SET_NEW.ORD_TAG_STK_LESS (:5557,
 * :7290) and the save keeps 'Y' only on a tagged line (:9268-9286); an edit keeps the saved cell unless the request
 * sends one. The Tour Order keeps the cell as it is (TR_TOUR_ORD.cs:7430-7442).
 */
export function orderLineTagStockLess(a: {
  salesOrderForm: boolean;
  previous?: Record<string, any>;
  requested?: string;
  picked: boolean;
  setting: 'Y' | 'N';
}): string | null {
  const cell = String(a.requested ?? a.previous?.TAG_STK_LESS ?? '')
    .trim()
    .slice(0, 1);
  if (!a.salesOrderForm) return cell || null;
  if (!a.previous) return a.picked && a.setting === 'Y' ? 'Y' : 'N';
  const tag = String(a.previous.TAG_NO ?? '').trim();
  return cell === 'Y' && tag !== '' && tag !== 'N' ? 'Y' : 'N';
}

const TAG_JOIN = `b.tenant_id=t.tenant_id AND b."CO_CODE"=t."CO_CODE" AND b."TAG_NO"=t."TAG_NO" AND b."VCH_SRNO"=t."VCH_SRNO"`;

/**
 * A line without a counter leaves the tag's counter as it is. The desktop line always has one, filled from the tag
 * (:7596); a web line imported or saved without it must not blank BAR_DETL / MAIN_STOCK.TBL_CODE.
 */
const HAS_COUNTER = `btrim(coalesce(t."TBL_CODE"::text,''))<>''`;

/** TR_SALE_ORD.cs:9552-9556. */
export async function reserveOrderTagsTx(tx: Tx, scope: OrderTagScope, voucherNo: string) {
  const p = params(scope, voucherNo);
  const lineOf = `t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6`;
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "ORD_NO"=t."VCH_NO","ORD_DBCD"=t."CO_BOOK","ORD_YRCD"=t."CO_YEAR","ORD_SRNO"=t."OLD_SRNO","ORD_AC"=t."AC_CODE"
       FROM "SL_ORD_DETL" t
      WHERE t."LC_CODE"=b."LC_CODE" AND ${TAG_JOIN} AND ${lineOf} AND t."TAG_STK_LESS"='Y' AND t."TAG_NO"<>'N'`,
    ...p,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "TBL_CODE"=t."TBL_CODE" FROM "SL_ORD_DETL" t WHERE ${TAG_JOIN} AND ${lineOf} AND ${HAS_COUNTER}`,
    ...p,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "MAIN_STOCK" b SET "TBL_CODE"=t."TBL_CODE" FROM "SL_ORD_DETL" t WHERE ${TAG_JOIN} AND ${lineOf} AND b."ITM_SIGN"='+' AND ${HAS_COUNTER}`,
    ...p,
  );
}

/** TR_SALE_ORD.cs:9702-9706; run before the order's own rows are deleted. */
export async function releaseOrderTagsTx(tx: Tx, scope: OrderTagScope, voucherNo: string) {
  const p = params(scope, voucherNo);
  const lineOf = `t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6`;
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "ORD_NO"='',"ORD_DBCD"='',"ORD_YRCD"='',"ORD_SRNO"=0,"ORD_AC"=''
       FROM "SL_ORD_DETL" t
      WHERE t."LC_CODE"=b."LC_CODE" AND ${TAG_JOIN} AND ${lineOf} AND t."TAG_STK_LESS"='Y' AND t."TAG_NO"<>'N'`,
    ...p,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "TBL_CODE"=t."OLD_TBL_CODE" FROM "SL_ORD_DETL" t WHERE ${TAG_JOIN} AND ${lineOf}`,
    ...p,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "MAIN_STOCK" b SET "TBL_CODE"=t."OLD_TBL_CODE" FROM "SL_ORD_DETL" t WHERE ${TAG_JOIN} AND ${lineOf} AND b."ITM_SIGN"='+'`,
    ...p,
  );
}
