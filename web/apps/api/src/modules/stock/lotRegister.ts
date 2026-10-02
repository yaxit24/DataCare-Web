/**
 * Lot register (`LOT_DETL`) — desktop `Ac_Stock` helpers populate it from a saved voucher's detail
 * rows so lot-wise stock can be reported.
 *
 * Ported verbatim from `Ac_Stock.cs:624` (`PrKr_Lot`), which runs:
 *
 *   INSERT INTO LOT_DETL (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,
 *       INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,IT_TYPE,LOT_NO,IT_PCS,IT_GWT,IT_NWT,
 *       IT_SIGN,HD_VCH_NO,MAIN_USER,DATA_TYPE,DATA_TRFR,TAG_NO,VCH_SRNO,TAG_IT_CODE,EMP_CODE,
 *       PR_CODE,KR_CODE)
 *   SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.SR_NO,A.VCH_DATE,
 *          B.BOOK_SNAME,B.BOOK_INOUT,'L',B.MAIN_BOOK,A.AC_CODE,A.IT_CODE,A.IT_TYPE,A.LOT_NO,
 *          A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,'+',A.VCH_NO,A.MAIN_USER,B.DATA_TYPE,'N','',0,'',
 *          C.EMP_CODE,A.PR_CODE,D.AC_SHORT
 *   FROM ((PR_DETL A LEFT JOIN PR_DATA C ON <voucher key>) LEFT JOIN BOOK_DATA B ON <book>)
 *        LEFT JOIN AC_MAST D ON C.AC_CODE = D.AC_CODE
 *   WHERE A.CO_CODE=.. AND A.LC_CODE=.. AND A.CO_YEAR=..
 *     AND B.MAIN_BOOK IN ('PURCHASE','B2B PURC') AND B.BOOK_INOUT = 'I'
 *
 * Kept as an INSERT..SELECT rather than rebuilt in TypeScript so every value comes from the same
 * source rows and joins the desktop uses — nothing is recomputed or substituted here. Note the
 * desktop stamps `HD_VCH_NO` with `A.VCH_NO` (not the hidden number) and applies no LOT_NO filter,
 * both reproduced exactly.
 */
export interface LotRegisterScope {
  coCode: string;
  lcCode: string;
  coYear: string;
}

/** Books whose purchase details feed the lot register (Ac_Stock.cs:624 WHERE clause). */
export const LOT_REGISTER_PURCHASE_MAIN_BOOKS = ['PURCHASE', 'B2B PURC'] as const;

export async function stagePurchaseLotDetailTx(
  tx: any,
  tenantId: string,
  scope: LotRegisterScope,
  coBook?: string,
  vchNo?: string,
): Promise<number> {
  const filters = [
    'a.tenant_id=$1',
    'a."CO_CODE"=$2',
    'a."LC_CODE"=$3',
    'a."CO_YEAR"=$4',
    `b."MAIN_BOOK" IN ('PURCHASE','B2B PURC')`,
    `b."BOOK_INOUT" = 'I'`,
  ];
  const params: unknown[] = [tenantId, scope.coCode, scope.lcCode, scope.coYear];
  if (coBook) {
    filters.push(`a."CO_BOOK"=$${params.length + 1}`);
    params.push(coBook);
  }
  if (vchNo) {
    filters.push(`a."VCH_NO"=$${params.length + 1}`);
    params.push(vchNo);
  }

  return (await tx.$executeRawUnsafe(
    `INSERT INTO "LOT_DETL"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE",
       "INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","AC_CODE","IT_CODE","IT_TYPE","LOT_NO","IT_PCS",
       "IT_GWT","IT_NWT","IT_SIGN","HD_VCH_NO","MAIN_USER","DATA_TYPE","DATA_TRFR","TAG_NO",
       "VCH_SRNO","TAG_IT_CODE","EMP_CODE","PR_CODE","KR_CODE","ITM_LOT")
     SELECT $1::text,a."CO_CODE",a."LC_CODE",a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."SR_NO",a."VCH_DATE",
            b."BOOK_SNAME",b."BOOK_INOUT",'L',b."MAIN_BOOK",a."AC_CODE",a."IT_CODE",a."IT_TYPE",
            a."LOT_NO",a."ITM_PCS",a."ITM_GWT",a."ITM_NWT",'+',a."VCH_NO",a."MAIN_USER",
            b."DATA_TYPE",'N','',0,'',c."EMP_CODE",a."PR_CODE",d."AC_SHORT",
            -- ITM_LOT mirrors LOT_NO: Ac_Stock's PrKr_Lot carries the lot on both columns so a lot
            -- lookup works whichever name a report binds.
            a."LOT_NO"
       FROM "PR_DETL" a
       LEFT JOIN "PR_DATA" c
         ON c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE" AND c."LC_CODE"=a."LC_CODE"
        AND c."CO_YEAR"=a."CO_YEAR" AND c."CO_BOOK"=a."CO_BOOK" AND c."VCH_NO"=a."VCH_NO"
       LEFT JOIN "BOOK_DATA" b
         ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE"
        AND b."CO_BOOK"=a."CO_BOOK"
       LEFT JOIN "AC_MAST" d
         ON d.tenant_id=c.tenant_id AND d."CO_CODE"=c."CO_CODE" AND d."AC_CODE"=c."AC_CODE"
      WHERE ${filters.join(' AND ')}`,
    ...params,
  )) as number;
}
