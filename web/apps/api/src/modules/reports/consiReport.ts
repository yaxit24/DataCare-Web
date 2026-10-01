import { round } from '@datacare/core';
import { withTenant } from '@datacare/db';
import type { ListReport, ReportScope } from './reports.js';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
// Report display rounding: aggregated weights/amounts are rounded only for presentation (N57 keeps the
// underlying numerics exact until output). The desktop presents these columns through Crystal / Strings.Format,
// which is half-up away from zero, so the kernel `round` is the correct primitive — not a float helper that
// rounds negative midpoints the wrong way (N48, G22).
const round3 = (n: number): number => round(n, 3);
const round2 = (n: number): number => round(n, 2);
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const isoDate = (v: unknown): string | null => {
  if (!v) return null;
  const d = v instanceof Date ? v : new Date(String(v));
  return Number.isFinite(d.getTime()) ? d.toISOString().slice(0, 10) : null;
};

/**
 * Consignment receipt balance summary — desktop `RP_CONSI_APR` initial grid.
 *
 * Source query: `APR_DETL` where `BOOK_NAME='CON REC'`, grouped by account and item type, with gold and
 * silver receipt/adjust/balance columns computed from `ITM_NWT` and `ADJ_NWT`. The desktop does not scope
 * this summary to the current location or financial year, so this builder deliberately does not add those
 * predicates; the tenant and company remain enforced.
 */
export async function consiReport(prisma: any, s: ReportScope): Promise<ListReport> {
  const toDate = s.toDate ?? new Date().toISOString().slice(0, 10);
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."AC_CODE" AS "acCode", b."AC_NAME" AS "party", b."AC_ADD1" AS "address",
              b."AC_MOBILE" AS "mobile", b."AC_CITY" AS "city", c."IT_TYPE" AS "itemType",
              SUM(CASE WHEN c."IT_TYPE"='G' THEN coalesce(a."ITM_NWT",0) ELSE 0 END) AS "recGold",
              SUM(CASE WHEN c."IT_TYPE"='G' THEN coalesce(a."ADJ_NWT",0) ELSE 0 END) AS "adjGold",
              SUM(CASE WHEN c."IT_TYPE"='G' THEN coalesce(a."ITM_NWT",0)-coalesce(a."ADJ_NWT",0) ELSE 0 END) AS "balGold",
              SUM(CASE WHEN c."IT_TYPE"='S' THEN coalesce(a."ITM_NWT",0) ELSE 0 END) AS "recSilver",
              SUM(CASE WHEN c."IT_TYPE"='S' THEN coalesce(a."ADJ_NWT",0) ELSE 0 END) AS "adjSilver",
              SUM(CASE WHEN c."IT_TYPE"='S' THEN coalesce(a."ITM_NWT",0)-coalesce(a."ADJ_NWT",0) ELSE 0 END) AS "balSilver"
         FROM "APR_DETL" a
         LEFT JOIN "AC_MAST" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."AC_CODE"::text=a."AC_CODE"::text
         LEFT JOIN "ITEM_MAST" c
           ON c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE" AND c."IT_CODE"::text=a."IT_CODE"::text
        WHERE a."CO_CODE"=$1 AND a."BOOK_NAME"='CON REC' AND a."VCH_DATE" <= $2::date
        GROUP BY a."AC_CODE", b."AC_NAME", b."AC_ADD1", b."AC_MOBILE", b."AC_CITY", c."IT_TYPE"
        ORDER BY b."AC_NAME", a."AC_CODE", c."IT_TYPE"`,
      s.coCode,
      toDate,
    );
    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      acCode: txt(r.acCode),
      party: txt(r.party),
      mobile: txt(r.mobile),
      itemType: txt(r.itemType),
      recGold: round3(num(r.recGold)),
      adjGold: round3(num(r.adjGold)),
      balGold: round3(num(r.balGold)),
      recSilver: round3(num(r.recSilver)),
      adjSilver: round3(num(r.adjSilver)),
      balSilver: round3(num(r.balSilver)),
      city: txt(r.city),
      address: txt(r.address),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        parties: new Set(mapped.map((r) => r.acCode).filter(Boolean)).size,
        recGold: round3(mapped.reduce((sum, r) => sum + r.recGold, 0)),
        adjGold: round3(mapped.reduce((sum, r) => sum + r.adjGold, 0)),
        balGold: round3(mapped.reduce((sum, r) => sum + r.balGold, 0)),
        recSilver: round3(mapped.reduce((sum, r) => sum + r.recSilver, 0)),
        adjSilver: round3(mapped.reduce((sum, r) => sum + r.adjSilver, 0)),
        balSilver: round3(mapped.reduce((sum, r) => sum + r.balSilver, 0)),
      },
    };
  });
}

function amountSides(balance: number): { dr: number; cr: number } {
  return balance < 0 ? { dr: Math.abs(balance), cr: 0 } : { dr: 0, cr: Math.abs(balance) };
}
function fineExpr(type: 'G' | 'S'): string {
  return `SUM(CASE WHEN a."IT_TYPE"='${type}' THEN CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END ELSE 0 END)`;
}

/** Desktop double-click account detail for the selected consignment account. */
export async function consiDetailReport(
  prisma: any,
  s: ReportScope,
  acCode: unknown,
): Promise<ListReport> {
  const partyCode = String(acCode ?? '').trim();
  if (!partyCode) return { rows: [], totals: { rows: 0 } };
  const fromDate = s.fromDate ?? '0001-01-01';
  const toDate = s.toDate ?? new Date().toISOString().slice(0, 10);

  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const openingRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT SUM(a."CR_AMT"-a."DR_AMT") AS "amountBal",
              ${fineExpr('G')} AS "goldBal",
              ${fineExpr('S')} AS "silverBal"
         FROM "AC_DATA" a
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."AC_CODE"=$3 AND a."VCH_DATE" < $4::date`,
      s.coCode,
      s.lcCode ?? '',
      partyCode,
      fromDate,
    );
    const entries: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT b."BOOK_NAME" AS "bookName", a."CO_BOOK" AS "coBook", a."VCH_NO" AS "vchNo",
              a."VCH_DATE" AS "vchDate", a."LEDR_KEY" AS "ledgerKey", a."LD_CODE" AS "acCode",
              c."AC_NAME" AS "party", c."AC_ADD1" AS "address", c."AC_MOBILE" AS "mobile",
              c."AC_AREA" AS "area", b."MAIN_BOOK" AS "mainBook",
              CASE WHEN SUM(a."CR_AMT"-a."DR_AMT") < 0 THEN abs(SUM(a."CR_AMT"-a."DR_AMT")) ELSE 0 END AS "drAmt",
              CASE WHEN SUM(a."CR_AMT"-a."DR_AMT") > 0 THEN abs(SUM(a."CR_AMT"-a."DR_AMT")) ELSE 0 END AS "crAmt",
              CASE WHEN ${fineExpr('G')} < 0 THEN abs(${fineExpr('G')}) ELSE 0 END AS "drGold",
              CASE WHEN ${fineExpr('G')} > 0 THEN abs(${fineExpr('G')}) ELSE 0 END AS "crGold",
              CASE WHEN ${fineExpr('S')} < 0 THEN abs(${fineExpr('S')}) ELSE 0 END AS "drSilver",
              CASE WHEN ${fineExpr('S')} > 0 THEN abs(${fineExpr('S')}) ELSE 0 END AS "crSilver"
         FROM "AC_DATA" a
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE" AND c."AC_CODE"::text=a."LD_CODE"::text
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."CO_YEAR"=$3 AND a."AC_CODE"=$4
          AND a."VCH_DATE" >= $5::date AND a."VCH_DATE" <= $6::date
        GROUP BY b."BOOK_NAME", a."CO_BOOK", a."VCH_NO", a."VCH_DATE", a."LEDR_KEY", a."LD_CODE",
                 c."AC_NAME", c."AC_ADD1", c."AC_MOBILE", c."AC_AREA", b."MAIN_BOOK"
        ORDER BY a."VCH_DATE", b."BOOK_NAME"`,
      s.coCode,
      s.lcCode ?? '',
      s.coYear ?? '',
      partyCode,
      fromDate,
      toDate,
    );

    const mapped: Record<string, unknown>[] = [];
    let drTotal = 0;
    let crTotal = 0;
    const opening = openingRows[0] ?? {};
    const opAmount = round2(num(opening.amountBal));
    const opSides = amountSides(opAmount);
    if (opSides.dr || opSides.cr) {
      drTotal += opSides.dr;
      crTotal += opSides.cr;
      const balance = round2(Math.abs(crTotal - drTotal));
      mapped.push({
        srNo: mapped.length + 1,
        bookName: 'Op Balance',
        vchNo: null,
        vchDate: null,
        party: null,
        area: null,
        drAmt: round2(opSides.dr),
        crAmt: round2(opSides.cr),
        balAmt: balance,
        crDr: crTotal - drTotal > 0 ? 'Cr' : crTotal - drTotal < 0 ? 'Dr' : '',
        coBook: null,
        acCode: partyCode,
        mainBook: null,
        drGold: amountSides(round3(num(opening.goldBal))).dr,
        crGold: amountSides(round3(num(opening.goldBal))).cr,
        drSilver: amountSides(round3(num(opening.silverBal))).dr,
        crSilver: amountSides(round3(num(opening.silverBal))).cr,
      });
    }

    for (const row of entries) {
      const drAmt = round2(num(row.drAmt));
      const crAmt = round2(num(row.crAmt));
      drTotal += drAmt;
      crTotal += crAmt;
      const diff = round2(crTotal - drTotal);
      mapped.push({
        srNo: mapped.length + 1,
        bookName: txt(row.bookName),
        vchNo: txt(row.vchNo),
        vchDate: isoDate(row.vchDate),
        party: txt(row.party),
        area: txt(row.area),
        drAmt,
        crAmt,
        balAmt: round2(Math.abs(diff)),
        crDr: diff > 0 ? 'Cr' : diff < 0 ? 'Dr' : '',
        coBook: txt(row.coBook),
        acCode: txt(row.acCode),
        mainBook: txt(row.mainBook),
        drGold: round3(num(row.drGold)),
        crGold: round3(num(row.crGold)),
        drSilver: round3(num(row.drSilver)),
        crSilver: round3(num(row.crSilver)),
      });
    }

    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        drAmt: round2(drTotal),
        crAmt: round2(crTotal),
        balAmt: round2(Math.abs(crTotal - drTotal)),
      },
    };
  });
}
