import { withTenant } from '@datacare/db';
import { PRECISION, round } from '@datacare/core';

/**
 * Physical stock verification (desktop `RP_PHY_STOCK`, menu caption "Physical Stock").
 *
 * WHAT IT COMPARES
 * The desktop's driving query carries the tag's details plus
 *   `SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE -1 END) AS OpPcs`
 * from `MAIN_STOCK` — the NET piece count the books say is held for that tag instance — and a second
 * query counts `BAR_CAN_DETL` per tag as `PhyPcs`. So this is a variance report: what the ledger holds
 * against what has been cancelled off it.
 *
 * WHY `APR_ISU` AND `EMP_ISU` ARE REPORTED
 * A tag that is not on the shelf is not necessarily missing: it may be out on approval or issued to an
 * employee. Both flags come straight from `BAR_DETL` and the desktop selects them, because a
 * stock-taking sheet that omits them manufactures phantom shortages.
 *
 * COUNTING IS PER TAG INSTANCE (`TAG_NO` + `VCH_SRNO`), not per tag number. A repeated tag number with
 * two instances is two physical pieces, and netting them together would hide a real discrepancy.
 *
 * Read-only and RLS-scoped.
 */
export interface PhysicalStockRow {
  tagNo: string;
  tagId: number;
  itCode: string | null;
  itName: string | null;
  designNo: string | null;
  itmSize: string | null;
  tblCode: string | null;
  book: string | null;
  bookName: string | null;
  vchNo: string | null;
  vchType: string | null;
  vchDate: string | null;
  acCode: string | null;
  karigarName: string | null;
  pcs: number;
  grossWt: number;
  netWt: number;
  fine: number;
  labourAmount: number;
  otherAmount: number;
  mrp: number;
  /** Out on approval / issued to an employee — a legitimate reason a tag is off the shelf. */
  approvalIssued: boolean;
  employeeIssued: boolean;
  /** Net pieces the ledger holds for this instance (the desktop's OpPcs). */
  bookPcs: number;
  /** Times this instance appears in the cancel register (the desktop's PhyPcs). */
  cancelledPcs: number;
  /** bookPcs - cancelledPcs. Non-zero is what a stock-take needs to explain. */
  variancePcs: number;
}

export interface PhysicalStockReport {
  rows: PhysicalStockRow[];
  totals: {
    count: number;
    bookPcs: number;
    cancelledPcs: number;
    netWt: number;
    fine: number;
    /** Rows whose variance is non-zero, and rows off the shelf for a known reason. */
    withVariance: number;
    onApproval: number;
    withEmployee: number;
  };
}

const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s === '' ? null : s;
};
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const flag = (v: unknown): boolean =>
  String(v ?? '')
    .trim()
    .toUpperCase() === 'Y';
const w3 = (n: number): number => round(n, PRECISION.weight);
const a2 = (n: number): number => round(n, PRECISION.amount);

export async function physicalStockReport(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  options: { itCode?: string; tblCode?: string; onlyVariance?: boolean } = {},
): Promise<PhysicalStockReport> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    const filters = ['a."CO_CODE"::text=$1', 'a."LC_CODE"::text=$2'];
    if (options.itCode) {
      params.push(options.itCode);
      filters.push(`a."IT_CODE"::text=$${params.length}`);
    }
    if (options.tblCode) {
      params.push(options.tblCode);
      filters.push(`c."TBL_CODE"::text=$${params.length}`);
    }
    // A tagged movement only: TAG_NO 'N' is the loose-stock sentinel and has no instance to verify.
    filters.push(`coalesce(a."TAG_NO"::text,'N') <> 'N'`);

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."TAG_NO",coalesce(a."VCH_SRNO",0) AS "VCH_SRNO",a."IT_CODE",b."IT_NAME",
              c."DESIGN_NO",c."ITM_SIZE",c."TBL_CODE",c."CO_BOOK",c."BOOK_NAME",c."VCH_NO",
              c."VCH_TYPE",c."VCH_DATE"::text AS "VCH_DATE",c."AC_CODE",c."KR_NAME",
              c."ITM_PCS",c."ITM_GWT",c."ITM_NWT",c."ITM_FINE",c."LBR_AMT",c."OTH_AMT",c."ITM_MRP",
              c."APR_ISU",c."EMP_ISU",
              SUM(CASE WHEN a."ITM_SIGN"::text='+' THEN 1 ELSE -1 END) AS "OpPcs",
              coalesce((
                SELECT count(*) FROM "BAR_CAN_DETL" k
                 WHERE k."CO_CODE"::text=a."CO_CODE"::text
                   AND k."LC_CODE"::text=a."LC_CODE"::text
                   AND k."TAG_NO"::text=a."TAG_NO"::text
                   AND coalesce(k."VCH_SRNO",0)=coalesce(a."VCH_SRNO",0)
              ),0) AS "PhyPcs"
         FROM "MAIN_STOCK" a
         LEFT JOIN "BAR_DETL" c
           ON c."CO_CODE"::text=a."CO_CODE"::text AND c."LC_CODE"::text=a."LC_CODE"::text
          AND c."TAG_NO"::text=a."TAG_NO"::text
          AND coalesce(c."VCH_SRNO",0)=coalesce(a."VCH_SRNO",0)
         LEFT JOIN "ITEM_MAST" b
           ON b."CO_CODE"::text=a."CO_CODE"::text AND b."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${filters.join(' AND ')}
        GROUP BY a."TAG_NO",a."VCH_SRNO",a."CO_CODE",a."LC_CODE",a."IT_CODE",b."IT_NAME",
                 c."DESIGN_NO",c."ITM_SIZE",c."TBL_CODE",c."CO_BOOK",c."BOOK_NAME",c."VCH_NO",
                 c."VCH_TYPE",c."VCH_DATE",c."AC_CODE",c."KR_NAME",c."ITM_PCS",c."ITM_GWT",
                 c."ITM_NWT",c."ITM_FINE",c."LBR_AMT",c."OTH_AMT",c."ITM_MRP",c."APR_ISU",c."EMP_ISU"
        ORDER BY a."TAG_NO", coalesce(a."VCH_SRNO",0)`,
      ...params,
    );

    let mapped: PhysicalStockRow[] = rows.map((r) => {
      const bookPcs = num(r.OpPcs);
      const cancelledPcs = num(r.PhyPcs);
      return {
        tagNo: String(r.TAG_NO ?? ''),
        tagId: num(r.VCH_SRNO),
        itCode: txt(r.IT_CODE),
        itName: txt(r.IT_NAME),
        designNo: txt(r.DESIGN_NO),
        itmSize: txt(r.ITM_SIZE),
        tblCode: txt(r.TBL_CODE),
        book: txt(r.CO_BOOK),
        bookName: txt(r.BOOK_NAME),
        vchNo: txt(r.VCH_NO),
        vchType: txt(r.VCH_TYPE),
        vchDate: txt(r.VCH_DATE)?.slice(0, 10) ?? null,
        acCode: txt(r.AC_CODE),
        karigarName: txt(r.KR_NAME),
        pcs: num(r.ITM_PCS),
        grossWt: w3(num(r.ITM_GWT)),
        netWt: w3(num(r.ITM_NWT)),
        fine: w3(num(r.ITM_FINE)),
        labourAmount: a2(num(r.LBR_AMT)),
        otherAmount: a2(num(r.OTH_AMT)),
        mrp: a2(num(r.ITM_MRP)),
        approvalIssued: flag(r.APR_ISU),
        employeeIssued: flag(r.EMP_ISU),
        bookPcs,
        cancelledPcs,
        variancePcs: bookPcs - cancelledPcs,
      };
    });
    if (options.onlyVariance) mapped = mapped.filter((r) => r.variancePcs !== 0);

    return {
      rows: mapped,
      totals: {
        count: mapped.length,
        bookPcs: mapped.reduce((s, r) => s + r.bookPcs, 0),
        cancelledPcs: mapped.reduce((s, r) => s + r.cancelledPcs, 0),
        netWt: w3(mapped.reduce((s, r) => s + r.netWt, 0)),
        fine: w3(mapped.reduce((s, r) => s + r.fine, 0)),
        withVariance: mapped.filter((r) => r.variancePcs !== 0).length,
        // Reported beside the variance so a shortage with a known cause is not read as a loss.
        onApproval: mapped.filter((r) => r.approvalIssued).length,
        withEmployee: mapped.filter((r) => r.employeeIssued).length,
      },
    };
  });
}
