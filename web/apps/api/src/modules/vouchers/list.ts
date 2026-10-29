import { withTxBudget } from '../shared/txBudget.js';

/**
 * Generic "recent vouchers" list for a header table + book — powers the reusable <VoucherList> that
 * gives every transaction screen navigate / load-to-edit / delete (desktop ◀▶/Delete). Read-only;
 * RLS-scoped; table is allow-listed. Amount/name columns are detected (tables differ). Delete is done
 * by each module's own reversible DELETE endpoint (createSale→/sales/:vchNo etc.).
 *
 * N51 milestone 1 (G28): the list is scoped to the session's COMPLETE voucher identity: company, location,
 * year and book. It used to filter on company and book only. It then showed vouchers from other locations
 * and years, while Load and Delete act on the session's location and year by number. Clicking such a row could
 * therefore load or delete a DIFFERENT voucher that happened to share its number. Each row now also
 * returns its full identity, so callers act on exactly the row shown.
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
  'LDR_ADJ_DATA',
  'EMP_DATA',
  'DHRN_REC_DATA',
  'DHRN_ISU_DATA',
  'CARD_DATA',
  'CUT_DATA',
]);
const IDENTITY_COLUMNS = ['CO_CODE', 'LC_CODE', 'CO_YEAR', 'CO_BOOK', 'VCH_NO'];
const qid = (c: string): string => '"' + c.replace(/[^A-Za-z0-9_]/g, '') + '"';

export interface VoucherListScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

export interface VoucherRow {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  vchNo: string;
  vchDate: string | null;
  vchType: string | null;
  acCode: string;
  acName: string;
  total: number;
}

export async function recentVouchers(
  prisma: any,
  scope: VoucherListScope,
  table: string,
  book: string,
  limit = 50,
): Promise<VoucherRow[]> {
  if (!ALLOWED.has(table)) return [];
  // Fail closed: without a complete scope the list cannot tell this session's vouchers from another's.
  if (!scope.coCode || !scope.lcCode || !scope.coYear || !book) return [];
  const n = Math.min(Number(limit) || 50, 200);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const colRows: { column_name: string }[] = await tx.$queryRawUnsafe(
      `SELECT column_name FROM information_schema.columns
        WHERE table_schema=current_schema() AND table_name=$1`,
      table,
    );
    const cols = new Set(colRows.map((c) => c.column_name));
    if (!IDENTITY_COLUMNS.every((c) => cols.has(c))) return [];
    const amtCol = [
      'TOT_AMT',
      'NET_AMT',
      'TOT_DR_AMT',
      'SL_NET_AMT',
      'REC_AMT',
      'DIFF_AMT',
      'SALARY_AMT',
      'CARD_AMT',
      'DHRN_AMT',
    ].find((c) => cols.has(c));
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
           FROM ${qid(table)}
          WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"=$4
           ORDER BY ${pickOrder}
       ) x ORDER BY ${outerOrder} LIMIT ${n}`,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      book,
    );
    return rows.map((r) => ({
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear: scope.coYear,
      coBook: book,
      vchNo: String(r.vch ?? ''),
      vchDate: r.vd ? String(r.vd).slice(0, 10) : null,
      vchType: r.vt ?? null,
      acCode: String(r.ac ?? ''),
      acName: String(r.acn ?? ''),
      total: Number(r.tot),
    }));
  });
}
