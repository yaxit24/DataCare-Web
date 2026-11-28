/**
 * Owner decision 1B (2026-11-27): ROF_AMT is only the round-off the operator types (TR_SALE.cs:15051,
 * TR_PURC.cs:12600). Before it the web COMPUTED ROF_AMT from the bill rounding and posted it as its own leg '99',
 * which no desktop build writes. A voucher still carrying that leg therefore holds a computed, not a typed,
 * round-off: its reopen shows 0, so a re-save treats nothing as typed and reposts without '99'. No data is migrated.
 *
 * `params` is the voucher's [tenant, CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO]. The old leg's key is exactly the
 * voucher key + '99' (posting.ts LEDR_KEY layout); a line key ending in 99 is longer.
 */
export async function hasWebRoundOffLegTx(
  tx: { $queryRawUnsafe: (...args: any[]) => Promise<any> },
  params: unknown[],
): Promise<boolean> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND rtrim("LEDR_KEY") = btrim("CO_CODE"::text) || btrim("LC_CODE"::text) || btrim("CO_YEAR"::text)
          || btrim("CO_BOOK"::text) || btrim("VCH_NO"::text) || '99'
      LIMIT 1`,
    ...params,
  );
  return rows.length > 0;
}
