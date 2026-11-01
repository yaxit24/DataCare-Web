import type { TagKey } from '../stock/stock.js';

/** The voucher identity of a RATE_CUT_DATA voucher (rateCut.ts keyOf). */
export interface RateCutVoucherKey {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
}

const num = (v: unknown): number => (v == null || v === '' ? 0 : Number(v));

/**
 * Give back the tags this voucher moved, before its rows are deleted (edit and delete).
 *
 * Only this voucher's own SR_NO 1 '-' stock rows count: a voucher saved before stock was written has none, and
 * its tags were never reserved, so there is nothing to return. A `BAR_DETL` tag needs no action — deleting its
 * '-' row makes it available again. A `TAG_STOCK`-only tag was removed on sale and is re-inserted with its own
 * weights, as the retail sale's `releaseSaleReferencesTx` does; one already back in `TAG_STOCK` is left alone.
 */
export async function releaseRateCutTagsTx(
  tx: any,
  tenantId: string,
  key: RateCutVoucherKey,
): Promise<Array<Record<string, unknown> & TagKey>> {
  const moved: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT m."TAG_NO",coalesce(m."VCH_SRNO",0)::float8 AS vch_srno,m."IT_CODE",
            i."ITM_PCS"::float8 AS pcs,i."TAG_GWT"::float8 AS tag_gwt,i."TAG_NWT"::float8 AS tag_nwt,
            i."ITM_GWT"::float8 AS gwt,i."ITM_NWT"::float8 AS nwt,i."DESIGN_NO",i."ITM_SIZE",
            i."PR_CODE",i."IT_TYPE",i."LBR_TYPE"
       FROM "MAIN_STOCK" m
       LEFT JOIN "RATE_CUT_ISU" i
         ON i.tenant_id=m.tenant_id AND i."CO_CODE"=m."CO_CODE" AND i."LC_CODE"=m."LC_CODE"
        AND i."CO_YEAR"=m."CO_YEAR" AND i."CO_BOOK"=m."CO_BOOK" AND i."VCH_NO"=m."VCH_NO"
        AND i."SR_NO"=m."ISR_NO"
      WHERE m.tenant_id=$1 AND m."CO_CODE"=$2 AND m."LC_CODE"=$3 AND m."CO_YEAR"=$4
        AND m."CO_BOOK"=$5 AND m."VCH_NO"=$6 AND m."SR_NO"=1 AND m."ITM_SIGN"='-'
        AND upper(coalesce(nullif(btrim(m."TAG_NO"::text),''),'N'))<>'N'
      ORDER BY m."ISR_NO"
      FOR UPDATE OF m`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  const restores: Array<Record<string, unknown> & TagKey> = [];
  for (const row of moved) {
    const tagNo = String(row.TAG_NO ?? '').trim();
    const vchSrno = Number(row.vch_srno ?? 0);
    const itCode = String(row.IT_CODE ?? '').trim();
    const counts: Array<{ bar: number; stock: number }> = await tx.$queryRawUnsafe(
      `SELECT (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                AND "TAG_NO"::text=$4 AND coalesce("VCH_SRNO",0)=$5::numeric
                AND coalesce("IT_CODE"::text,'')=$6) AS bar,
              (SELECT count(*)::int FROM "TAG_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                AND "TAG_NO"::text=$4 AND coalesce("VCH_SRNO",0)=$5::numeric) AS stock`,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      tagNo,
      vchSrno,
      itCode,
    );
    if (Number(counts[0]?.bar ?? 0) > 0 || Number(counts[0]?.stock ?? 0) > 0) continue;
    const text = (value: unknown): string | undefined => String(value ?? '').trim() || undefined;
    const restore: Record<string, unknown> & TagKey = {
      CO_CODE: key.CO_CODE,
      LC_CODE: key.LC_CODE,
      TAG_NO: tagNo,
      VCH_SRNO: vchSrno,
      ITM_PCS: num(row.pcs),
      ITM_GWT: num(row.tag_gwt) || num(row.gwt),
      ITM_NWT: num(row.tag_nwt) || num(row.nwt),
      STK_TYPE: 'R',
    };
    for (const [column, value] of [
      ['DESIGN_NO', text(row.DESIGN_NO)],
      ['ITM_SIZE', text(row.ITM_SIZE)],
      ['PR_CODE', text(row.PR_CODE)],
      ['IT_TYPE', text(row.IT_TYPE)],
      ['LBR_TYPE', text(row.LBR_TYPE)],
    ] as const) {
      if (value) restore[column] = value;
    }
    restores.push(restore);
  }
  return restores;
}
