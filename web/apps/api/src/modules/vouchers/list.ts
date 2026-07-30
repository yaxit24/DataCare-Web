import { withTenant } from '@datacare/db';

/**
 * Generic "recent vouchers" list for a header table + book — powers the reusable <VoucherList> that
 * gives every transaction screen navigate / load-to-edit / delete (desktop ◀▶/Delete). Read-only;
 * RLS-scoped; table is allow-listed. Amount/name columns are detected (tables differ). Delete is done
 * by each module's own reversible DELETE endpoint (createSale→/sales/:vchNo etc.).
 */
const ALLOWED = new Set([
  'SL_DATA',
  'PR_DATA',
  'PAY_DATA',
  'CASH_DATA',
  'CONTRA_DATA',
  'KR_DATA',
  'LBR_DATA',
  'APR_DATA',
  'SL_ORD_DATA',
]);
const qid = (c: string): string => '"' + c.replace(/[^A-Za-z0-9_]/g, '') + '"';

export interface VoucherRow {
  vchNo: string;
  vchDate: string | null;
  vchType: string | null;
  acCode: string;
  acName: string;
  total: number;
}

export async function recentVouchers(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  table: string,
  book: string,
  limit = 50,
): Promise<VoucherRow[]> {
  if (!ALLOWED.has(table)) return [];
  const n = Math.min(Number(limit) || 50, 200);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const colRows: { column_name: string }[] = await tx.$queryRawUnsafe(
      `SELECT column_name FROM information_schema.columns WHERE table_name=$1`,
      table,
    );
    const cols = new Set(colRows.map((c) => c.column_name));
    if (!cols.has('VCH_NO') || !cols.has('CO_BOOK')) return [];
    const amtCol = ['TOT_AMT', 'NET_AMT', 'TOT_DR_AMT', 'SL_NET_AMT', 'REC_AMT'].find((c) =>
      cols.has(c),
    );
    const nameSel = cols.has('AC_NAME') ? '"AC_NAME"' : `''`;
    const typeSel = cols.has('VCH_TYPE') ? `coalesce("VCH_TYPE",'')` : `''`;
    const acSel = cols.has('AC_CODE') ? `coalesce("AC_CODE",'')` : `''`;
    const amtSel = amtCol
      ? `coalesce(NULLIF(${qid(amtCol)}::text,'')::numeric,0)::float`
      : '0::float';
    const dateSel = cols.has('VCH_DATE') ? `"VCH_DATE"::text` : 'NULL';
    // The header table can hold several rows per voucher (party leg + tax + old-gold components share one
    // VCH_NO). The desktop voucher navigator lists ONE row per voucher, so collapse with DISTINCT ON and
    // pick the representative row: prefer a row that carries the party code, then the largest amount.
    const pickOrder = [
      '"VCH_NO"',
      cols.has('AC_CODE') ? `(CASE WHEN coalesce("AC_CODE",'')<>'' THEN 0 ELSE 1 END)` : '',
      amtCol ? `${amtSel} DESC` : '',
      cols.has('VCH_DATE') ? `"VCH_DATE" DESC NULLS LAST` : '',
    ]
      .filter(Boolean)
      .join(', ');
    const outerOrder = `${cols.has('VCH_DATE') ? 'vd DESC NULLS LAST,' : ''} length(vch) DESC, vch DESC`;
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM (
         SELECT DISTINCT ON ("VCH_NO") "VCH_NO" vch, ${dateSel} vd, ${typeSel} vt, ${acSel} ac, ${nameSel} acn, ${amtSel} tot
           FROM ${qid(table)} WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2
           ORDER BY ${pickOrder}
       ) x ORDER BY ${outerOrder} LIMIT ${n}`,
      scope.coCode,
      book,
    );
    return rows.map((r) => ({
      vchNo: String(r.vch ?? ''),
      vchDate: r.vd ? String(r.vd).slice(0, 10) : null,
      vchType: r.vt ?? null,
      acCode: String(r.ac ?? ''),
      acName: String(r.acn ?? ''),
      total: Number(r.tot),
    }));
  });
}
