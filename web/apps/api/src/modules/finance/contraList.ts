import { formatDesktopDate, round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import type { VoucherScope } from '../vouchers/numbering.js';
import { completeFinanceScope, configuredBookTx, requireBookFamily } from './lifecycle.js';

/** One line of the F1 list (TR_CONTRA.BtnF1_Click, TR_CONTRA.cs:3140-3146). */
export interface ContraListRow {
  vchNo: string;
  /** dd/mm/yyyy (SQL style 103). */
  vchDate: string;
  partyName: string;
  vchDesc: string;
  user: string;
  crAmt: number;
  drAmt: number;
}

/**
 * The desktop F1 list: the book's vouchers of the open year, one line per voucher, account name, description and user,
 * each with the sums of its CR_AMT and DR_AMT (TR_CONTRA.cs:3144
 * `GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME,A.IT_DESC,A.MAIN_USER ORDER BY A.VCH_NO`). The account name is looked up once
 * per row (company, location first) so a code that exists at two locations does not double its sums.
 */
export async function contraF1List(prisma: any, scope: VoucherScope): Promise<ContraListRow[]> {
  const s = completeFinanceScope(scope);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    requireBookFamily(await configuredBookTx(tx, s), 'CONTRA', 'contra');
    const rows: Array<Record<string, any>> = await tx.$queryRawUnsafe(
      `SELECT x."VCH_NO" vch, x."VCH_DATE"::text vd, coalesce(x.party,'') party, coalesce(x."IT_DESC",'') d,
              coalesce(x."MAIN_USER",'') u,
              sum(coalesce(NULLIF(x."CR_AMT"::text,'')::numeric,0))::float8 cr,
              sum(coalesce(NULLIF(x."DR_AMT"::text,'')::numeric,0))::float8 dr
         FROM (
           SELECT a.*, (SELECT m."AC_NAME" FROM "AC_MAST" m
                         WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE" AND m."AC_CODE"=a."AC_CODE"
                         ORDER BY CASE WHEN m."LC_CODE"=a."LC_CODE" THEN 0 ELSE 1 END, m.row_id LIMIT 1) party
             FROM "CONTRA_DATA" a
            WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5
         ) x
        GROUP BY x."VCH_NO", x."VCH_DATE", x.party, x."IT_DESC", x."MAIN_USER"
        ORDER BY x."VCH_NO", x.party, x."IT_DESC"`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      s.coBook,
    );
    return rows.map((r) => ({
      vchNo: String(r.vch ?? ''),
      vchDate: formatDesktopDate(r.vd),
      partyName: String(r.party ?? ''),
      vchDesc: String(r.d ?? ''),
      user: String(r.u ?? ''),
      crAmt: round(Number(r.cr ?? 0), 2),
      drAmt: round(Number(r.dr ?? 0), 2),
    }));
  });
}
