/**
 * A sale edit keeps its legs' bank clearing.
 *
 * The edit replaces the voucher's AC_DATA rows (TR_SALE.cs:15167-15172), so a cleared bank leg would come back with
 * CLR_DATE NULL, and a BANK_RECONCILE row (keyed by the WHOLE LEDR_KEY, contraClearing.ts) would point at a key that
 * may no longer exist: a voucher written by the older build carries its bank leg as …10 where the current code is
 * …16 (saleLedger.ts SALE_LEG). Before the rewrite the cleared legs are read; after it, each is matched to the new leg
 * with the same account and amounts, which takes the clearing date, and its BANK_RECONCILE row moves to the new key.
 * A leg whose amount changed has no match and keeps its BANK_RECONCILE row as it was.
 */

type Key = { CO_CODE: string; LC_CODE: string; CO_YEAR: string; CO_BOOK: string; VCH_NO: string };

export interface ClearedLeg {
  key: string;
  ac: string;
  dr: number;
  cr: number;
  clr: string | null;
  reconciled: boolean;
}

const WHERE = `a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5
  AND a."VCH_NO"=$6`;
const params = (tenantId: string, k: Key) => [
  tenantId,
  k.CO_CODE,
  k.LC_CODE,
  k.CO_YEAR,
  k.CO_BOOK,
  k.VCH_NO,
];

/** The voucher's legs that carry a clearing date or a BANK_RECONCILE row. */
export async function clearedSaleLegsTx(
  tx: any,
  tenantId: string,
  key: Key,
): Promise<ClearedLeg[]> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT a."LEDR_KEY" k, btrim(a."AC_CODE"::text) ac, coalesce(a."DR_AMT",0)::float dr,
            coalesce(a."CR_AMT",0)::float cr,
            coalesce(a."CLR_DATE", r."CLR_DATE")::date::text clr, (r.row_id IS NOT NULL) rec
       FROM "AC_DATA" a
       LEFT JOIN "BANK_RECONCILE" r ON r.tenant_id=a.tenant_id AND r."CO_CODE"=a."CO_CODE"
        AND r."LEDR_KEY"=a."LEDR_KEY"
      WHERE ${WHERE} AND (a."CLR_DATE" IS NOT NULL OR r.row_id IS NOT NULL)
      ORDER BY a."LEDR_KEY"`,
    ...params(tenantId, key),
  );
  return rows.map((r) => ({
    key: String(r.k),
    ac: String(r.ac),
    dr: Number(r.dr),
    cr: Number(r.cr),
    clr: r.clr == null ? null : String(r.clr),
    reconciled: Boolean(r.rec),
  }));
}

/** Give the rewritten voucher's matching legs their clearing back. Returns how many legs it carried over. */
export async function restoreSaleClearingTx(
  tx: any,
  tenantId: string,
  key: Key,
  cleared: readonly ClearedLeg[],
): Promise<number> {
  if (!cleared.length) return 0;
  const fresh: Array<{ k: string; ac: string; dr: number; cr: number }> = (
    await tx.$queryRawUnsafe(
      `SELECT a."LEDR_KEY" k, btrim(a."AC_CODE"::text) ac, coalesce(a."DR_AMT",0)::float dr,
              coalesce(a."CR_AMT",0)::float cr
         FROM "AC_DATA" a WHERE ${WHERE} ORDER BY a."LEDR_KEY"`,
      ...params(tenantId, key),
    )
  ).map((r: any) => ({ k: String(r.k), ac: String(r.ac), dr: Number(r.dr), cr: Number(r.cr) }));
  const used = new Set<string>();
  let carried = 0;
  for (const old of cleared) {
    const match =
      fresh.find((f) => !used.has(f.k) && f.k === old.key && f.ac === old.ac) ??
      fresh.find((f) => !used.has(f.k) && f.ac === old.ac && f.dr === old.dr && f.cr === old.cr);
    if (!match) continue;
    used.add(match.k);
    carried += 1;
    if (old.clr)
      await tx.$executeRawUnsafe(
        `UPDATE "AC_DATA" SET "CLR_DATE"=$3::date WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
        tenantId,
        match.k,
        old.clr,
      );
    if (old.reconciled && match.k !== old.key)
      await tx.$executeRawUnsafe(
        `UPDATE "BANK_RECONCILE" SET "LEDR_KEY"=$3 WHERE tenant_id=$1 AND "CO_CODE"=$4 AND "LEDR_KEY"=$2`,
        tenantId,
        old.key,
        match.k,
        key.CO_CODE,
      );
  }
  return carried;
}
