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

const TAG_JOIN = `b.tenant_id=t.tenant_id AND b."CO_CODE"=t."CO_CODE" AND b."TAG_NO"=t."TAG_NO" AND b."VCH_SRNO"=t."VCH_SRNO"`;

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
    `UPDATE "BAR_DETL" b SET "TBL_CODE"=t."TBL_CODE" FROM "SL_ORD_DETL" t WHERE ${TAG_JOIN} AND ${lineOf}`,
    ...p,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "MAIN_STOCK" b SET "TBL_CODE"=t."TBL_CODE" FROM "SL_ORD_DETL" t WHERE ${TAG_JOIN} AND ${lineOf} AND b."ITM_SIGN"='+'`,
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
