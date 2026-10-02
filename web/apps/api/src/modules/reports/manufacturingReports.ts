import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import type { ListReport, ReportScope } from './reports.js';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
// Report display rounding (N57 exact until output); desktop presents half-up, kernel `round` (N48, G22).
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
const todayIso = (): string => new Date().toISOString().slice(0, 10);
const flagFrom = (v: unknown, defaultValue: boolean): boolean => {
  if (v == null || v === '') return defaultValue;
  const s = String(v).trim().toLowerCase();
  if (['1', 'true', 'y', 'yes', 'on'].includes(s)) return true;
  if (['0', 'false', 'n', 'no', 'off'].includes(s)) return false;
  return defaultValue;
};

function pushText(params: unknown[], where: string[], expr: string, value: unknown): void {
  const s = String(value ?? '').trim();
  if (!s) return;
  params.push(s);
  where.push(`${expr}=$${params.length}`);
}

function sumCols(
  rows: Array<Record<string, unknown>>,
  cols: readonly string[],
): Record<string, number> {
  return Object.fromEntries(
    cols.map((col) => [col, round3(rows.reduce((sum, row) => sum + num(row[col]), 0))]),
  );
}

const mfgMovementWeight =
  'coalesce(a."IR_WT",0)+coalesce(a."RTN_CHOL",0)+coalesce(a."RTN_GHIS",0)+coalesce(a."ITM_GHAT",0)+coalesce(a."ITM_LOSS",0)';
const mfgAmountBalance = 'SUM(coalesce(a."CR_AMT",0)-coalesce(a."DR_AMT",0))';
const mfgMetalBalance = (itemType: 'G' | 'S'): string =>
  `SUM(CASE WHEN a."IT_TYPE"='${itemType}' THEN CASE WHEN coalesce(a."ITM_SIGN",'')='+' THEN ${mfgMovementWeight} ELSE -coalesce(a."IR_WT",0) END ELSE 0 END)`;

const crDr = (balance: number): string => (balance > 0 ? 'Cr' : balance < 0 ? 'Dr' : '');

/**
 * Mfg InOut — desktop `RP_MFG_ZOOM.DGV_MFG_INOUT`.
 *
 * Groups manufacturing detail rows by process (`MFG_MAST.TRAN_NAME`) for the current company/location/year,
 * date range and optional karigar. The output columns mirror the WinForms grid: gross, other, net, mino,
 * diamond, ghat, ghis and chol totals.
 */
export async function mfgInoutReport(
  prisma: any,
  s: ReportScope,
  options: { karigarCode?: unknown } = {},
): Promise<ListReport> {
  const fromDate = s.fromDate ?? todayIso();
  const toDate = s.toDate ?? todayIso();
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? '', s.coYear ?? '', fromDate, toDate];
    const where = [
      'a."CO_CODE"=$1',
      'a."LC_CODE"=$2',
      'a."CO_YEAR"=$3',
      'a."VCH_DATE">=$4::date',
      'a."VCH_DATE"<=$5::date',
    ];
    pushText(params, where, 'a."KR_CODE"', options.karigarCode);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ROW_NUMBER() OVER (ORDER BY b."TRAN_NAME") AS "srNo",
              b."TRAN_NAME" AS "name",
              SUM(coalesce(a."ITM_GWT",0)) AS "grWt",
              SUM(coalesce(a."ITM_OTH_WT",0)) AS "othWt",
              SUM(coalesce(a."ITM_NWT",0)) AS "netWt",
              SUM(coalesce(a."KR_MINO_WT",0)) AS "minoWt",
              SUM(coalesce(a."DM_PCS",0)) AS "dmPcs",
              SUM(coalesce(a."DM_WT",0)) AS "dmWt",
              SUM(coalesce(a."ITM_GHT_WT",0)) AS "ghtWt",
              SUM(coalesce(a."RTN_GHIS",0)) AS "ghis",
              SUM(coalesce(a."RTN_CHOL",0)) AS "chol"
         FROM "MFG_DETL" a
         LEFT JOIN "MFG_MAST" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN "BOOK_DATA" c
           ON c.tenant_id=a.tenant_id
          AND c."CO_CODE"=a."CO_CODE"
          AND c."LC_CODE"=a."LC_CODE"
          AND c."CO_BOOK"=a."CO_BOOK"
        WHERE ${where.join(' AND ')}
        GROUP BY b."TRAN_NAME"
        ORDER BY b."TRAN_NAME"`,
      ...params,
    );
    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      name: txt(r.name),
      grWt: round3(num(r.grWt)),
      othWt: round3(num(r.othWt)),
      netWt: round3(num(r.netWt)),
      minoWt: round3(num(r.minoWt)),
      dmPcs: round3(num(r.dmPcs)),
      dmWt: round3(num(r.dmWt)),
      ghtWt: round3(num(r.ghtWt)),
      ghis: round3(num(r.ghis)),
      chol: round3(num(r.chol)),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        ...sumCols(mapped, [
          'grWt',
          'othWt',
          'netWt',
          'minoWt',
          'dmPcs',
          'dmWt',
          'ghtWt',
          'ghis',
          'chol',
        ]),
      },
    };
  });
}

/**
 * Lot IsuRec — desktop `RP_MFG_ZOOM.DGV_DESIGN_FILL` for the non-order manufacturing lot report.
 *
 * The desktop creates one dynamic column for every active manufacturing process book (`MFG_MAST.CUR_IN_USE = Y`)
 * and fills it from `MFG_ISU_REC` using `IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS`. It then adds
 * `DiffWt` from signed issue/receive movement and, when no karigar filter is active, the separate `IsPan`
 * loss/process balance (`IR_TYPE = 'L'`). This builder returns the same pivoted shape for screen, CSV and Excel.
 */
export async function mfgLotIsuRecReport(
  prisma: any,
  s: ReportScope,
  options: {
    partyCode?: unknown;
    karigarCode?: unknown;
    lotNo?: unknown;
    useItemLot?: unknown;
  } = {},
): Promise<ListReport> {
  const useItemLot = flagFrom(options.useItemLot, false);
  const lotExpr = useItemLot ? 'a."ITM_LOT"' : 'a."LOT_NO"';
  const lotColumn = useItemLot ? '"ITM_LOT"' : '"LOT_NO"';
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const processRows: Array<{ bookSname: unknown; smCode: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "BOOK_SNAME" AS "bookSname", "SM_CODE" AS "smCode"
         FROM "MFG_MAST"
        WHERE tenant_id=current_setting('app.tenant_id', true)
          AND "CO_CODE"=$1
          AND "CUR_IN_USE"='Y'
        ORDER BY "SM_CODE"`,
      s.coCode,
    );
    const processLabels = processRows.map((row) => txt(row.bookSname)).filter(Boolean) as string[];

    const params: unknown[] = [s.coCode, s.lcCode ?? ''];
    const where = ['a."CO_CODE"=$1', 'a."LC_CODE"=$2'];
    pushText(params, where, 'a."AC_CODE"', options.partyCode);
    pushText(params, where, 'a."KR_AC_CODE"', options.karigarCode);
    pushText(params, where, lotExpr, options.lotNo);

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${lotExpr} AS "lotNo",
              b."SM_CODE" AS "smCode",
              b."BOOK_SNAME" AS "bookSname",
              MIN(a."VCH_DATE") AS "firstDate",
              SUM(coalesce(a."IR_WT",0)+coalesce(a."RTN_CHOL",0)+coalesce(a."RTN_GHIS",0)+coalesce(a."ITM_GHAT",0)+coalesce(a."ITM_LOSS",0)) AS "gwt"
         FROM "MFG_ISU_REC" a
         LEFT JOIN "MFG_MAST" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."CO_BOOK"=a."CO_BOOK"
        WHERE ${where.join(' AND ')}
        GROUP BY ${lotExpr}, b."SM_CODE", b."BOOK_SNAME"
        ORDER BY ${lotExpr}, b."SM_CODE"`,
      ...params,
    );

    const diffRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${lotExpr} AS "lotNo",
              SUM(CASE WHEN coalesce(a."ITM_SIGN",'')='-'
                       THEN ${useItemLot ? 'coalesce(a."ITM_NWT",0)' : '(coalesce(a."IR_WT",0)+coalesce(a."RTN_CHOL",0)+coalesce(a."RTN_GHIS",0)+coalesce(a."ITM_GHAT",0)+coalesce(a."ITM_LOSS",0))'}
                       ELSE -${useItemLot ? 'coalesce(a."ITM_NWT",0)' : '(coalesce(a."IR_WT",0)+coalesce(a."RTN_CHOL",0)+coalesce(a."RTN_GHIS",0)+coalesce(a."ITM_GHAT",0)+coalesce(a."ITM_LOSS",0))'}
                  END) AS "diffWt"
         FROM "MFG_ISU_REC" a
        WHERE ${where.join(' AND ')} AND coalesce(a."IR_TYPE",'') <> 'L'
        GROUP BY ${lotExpr}
        ORDER BY ${lotExpr}`,
      ...params,
    );

    const lossRows: Array<Record<string, unknown>> = String(options.karigarCode ?? '').trim()
      ? []
      : await tx.$queryRawUnsafe(
          `SELECT ${lotExpr} AS "lotNo",
                  SUM(CASE WHEN coalesce(a."ITM_SIGN",'')='-'
                           THEN ${useItemLot ? 'coalesce(a."ITM_NWT",0)' : '(coalesce(a."IR_WT",0)+coalesce(a."RTN_CHOL",0)+coalesce(a."RTN_GHIS",0)+coalesce(a."ITM_GHAT",0)+coalesce(a."ITM_LOSS",0))'}
                           ELSE -${useItemLot ? 'coalesce(a."ITM_NWT",0)' : '(coalesce(a."IR_WT",0)+coalesce(a."RTN_CHOL",0)+coalesce(a."RTN_GHIS",0)+coalesce(a."ITM_GHAT",0)+coalesce(a."ITM_LOSS",0))'}
                      END) AS "lossDiffWt"
             FROM "MFG_ISU_REC" a
            WHERE ${where.join(' AND ')} AND coalesce(a."IR_TYPE",'') = 'L'
            GROUP BY ${lotExpr}
            ORDER BY ${lotExpr}`,
          ...params,
        );

    const firstDateRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${lotColumn} AS "lotNo", "VCH_DATE" AS "vchDate"
         FROM (
           SELECT a.${lotColumn}, a."VCH_DATE", a."VCH_TIME",
                  ROW_NUMBER() OVER (PARTITION BY a.${lotColumn} ORDER BY a."VCH_TIME" NULLS LAST, a."VCH_DATE" NULLS LAST) AS rn
             FROM "MFG_ISU_REC" a
            WHERE ${where.join(' AND ')}
         ) q
        WHERE rn=1`,
      ...params,
    );

    const byLot = new Map<string, Record<string, unknown>>();
    const ensure = (lot: string): Record<string, unknown> => {
      if (!byLot.has(lot)) {
        byLot.set(lot, {
          srNo: 0,
          lotNo: lot,
          date: null,
          ...Object.fromEntries(processLabels.map((label) => [label, 0])),
          diffWt: 0,
          isPan: 0,
        });
      }
      return byLot.get(lot)!;
    };

    for (const row of rows) {
      const lot = txt(row.lotNo);
      const label = txt(row.bookSname);
      if (!lot || !label) continue;
      if (!processLabels.includes(label)) processLabels.push(label);
      const out = ensure(lot);
      if (!(label in out)) out[label] = 0;
      out[label] = round3(num(out[label]) + num(row.gwt));
      if (!out.date) out.date = isoDate(row.firstDate);
    }
    for (const row of firstDateRows) {
      const lot = txt(row.lotNo);
      if (lot) ensure(lot).date = isoDate(row.vchDate);
    }
    for (const row of diffRows) {
      const lot = txt(row.lotNo);
      if (lot) ensure(lot).diffWt = round3(num(row.diffWt));
    }
    for (const row of lossRows) {
      const lot = txt(row.lotNo);
      if (lot) ensure(lot).isPan = round3(num(row.lossDiffWt));
    }

    const mapped = Array.from(byLot.values()).map((row, index) => ({ ...row, srNo: index + 1 }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        ...sumCols(mapped, [...processLabels, 'diffWt', 'isPan']),
      },
    };
  });
}

/**
 * Mfg Ledger account summary — desktop `RP_MFG_LEDR.AcSumm`.
 *
 * The desktop grid groups `MFG_ISU_REC` by karigar account and splits the signed balances into debit/credit
 * amount, gold and silver columns. The default excludes zero-balance accounts; the `includeZero` option
 * mirrors the desktop checkbox that removes the HAVING filter.
 */
export async function mfgLedgerReport(
  prisma: any,
  s: ReportScope,
  options: { lcCode?: unknown; acGroup?: unknown; khataNo?: unknown; includeZero?: unknown } = {},
): Promise<ListReport> {
  const toDate = s.toDate ?? todayIso();
  const includeZero = flagFrom(options.includeZero, false);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, toDate];
    const where = [
      "a.tenant_id=current_setting('app.tenant_id', true)",
      'a."CO_CODE"=$1',
      "coalesce(a.\"KR_AC_CODE\",'') <> ''",
      'a."VCH_DATE"<=$2::date',
    ];
    pushText(params, where, 'a."LC_CODE"', options.lcCode);
    pushText(params, where, 'b."AC_GR"', options.acGroup);
    pushText(params, where, 'b."AC_KHATA_NO"', options.khataNo);

    const zeroFilter = includeZero
      ? ''
      : 'WHERE coalesce("amountBal",0) <> 0 OR coalesce("goldBal",0) <> 0 OR coalesce("silverBal",0) <> 0';
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `WITH raw AS (
          SELECT a."KR_AC_CODE" AS "acCode",
                 b."AC_NAME" AS "acName",
                 b."AC_ADD1" AS "acAdd1",
                 b."AC_MOBILE" AS "acMobile",
                 b."AC_REF_NAME" AS "acRefBy",
                 b."AC_CITY" AS "acCity",
                 b."AC_KHATA_NO" AS "acKhataNo",
                 ${mfgAmountBalance} AS "amountBal",
                 ${mfgMetalBalance('G')} AS "goldBal",
                 ${mfgMetalBalance('S')} AS "silverBal"
            FROM "MFG_ISU_REC" a
            LEFT JOIN "AC_MAST" b
              ON b.tenant_id=a.tenant_id
             AND b."CO_CODE"=a."CO_CODE"
             AND b."AC_CODE"=a."KR_AC_CODE"
           WHERE ${where.join(' AND ')}
           GROUP BY a."KR_AC_CODE", b."AC_NAME", b."AC_ADD1", b."AC_MOBILE", b."AC_REF_NAME", b."AC_CITY", b."AC_KHATA_NO"
        )
        SELECT ROW_NUMBER() OVER (ORDER BY "acName") AS "srNo",
               "acCode",
               "acName",
               "acAdd1",
               "acMobile",
               CASE WHEN "amountBal" < 0 THEN abs("amountBal") ELSE 0 END AS "drAmt",
               CASE WHEN "amountBal" > 0 THEN abs("amountBal") ELSE 0 END AS "crAmt",
               CASE WHEN "goldBal" < 0 THEN abs("goldBal") ELSE 0 END AS "drGold",
               CASE WHEN "goldBal" > 0 THEN abs("goldBal") ELSE 0 END AS "crGold",
               CASE WHEN "silverBal" < 0 THEN abs("silverBal") ELSE 0 END AS "drSilver",
               CASE WHEN "silverBal" > 0 THEN abs("silverBal") ELSE 0 END AS "crSilver",
               "acRefBy",
               "acCity",
               "acKhataNo"
          FROM raw
          ${zeroFilter}
         ORDER BY "acName"`,
      ...params,
    );
    const mapped = rows.map((row, index) => ({
      srNo: index + 1,
      acCode: txt(row.acCode),
      acName: txt(row.acName),
      acAdd1: txt(row.acAdd1),
      acMobile: txt(row.acMobile),
      drAmt: round2(num(row.drAmt)),
      crAmt: round2(num(row.crAmt)),
      drGold: round3(num(row.drGold)),
      crGold: round3(num(row.crGold)),
      drSilver: round3(num(row.drSilver)),
      crSilver: round3(num(row.crSilver)),
      acRefBy: txt(row.acRefBy),
      acCity: txt(row.acCity),
      acKhataNo: txt(row.acKhataNo),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        drAmt: round2(mapped.reduce((sum, row) => sum + row.drAmt, 0)),
        crAmt: round2(mapped.reduce((sum, row) => sum + row.crAmt, 0)),
        ...sumCols(mapped, ['drGold', 'crGold', 'drSilver', 'crSilver']),
      },
    };
  });
}

/**
 * Mfg Ledger drill-down — desktop `RP_MFG_LEDR.DGV_DETL_FILL`.
 *
 * Builds the detail grid behind a selected karigar: opening balance before `fromDate`, then voucher-level
 * movement in the selected date window with running amount/gold/silver balances and Cr/Dr indicators.
 */
export async function mfgLedgerDetailReport(
  prisma: any,
  s: ReportScope,
  options: { acCode?: unknown; coBook?: unknown; lcCode?: unknown } = {},
): Promise<ListReport> {
  const acCode = txt(options.acCode);
  if (!acCode) return { rows: [], totals: { rows: 0 } };
  const lcCode = txt(options.lcCode) ?? s.lcCode ?? '';
  const fromDate = s.fromDate ?? '1900-01-01';
  const toDate = s.toDate ?? todayIso();
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, lcCode, acCode];
    const baseWhere = [
      "a.tenant_id=current_setting('app.tenant_id', true)",
      'a."CO_CODE"=$1',
      'a."LC_CODE"=$2',
      'a."KR_AC_CODE"=$3',
    ];
    pushText(params, baseWhere, 'a."CO_BOOK"', options.coBook);

    const openingParams = [...params, fromDate];
    const openingRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${mfgAmountBalance} AS "amountBal",
              ${mfgMetalBalance('G')} AS "goldBal",
              ${mfgMetalBalance('S')} AS "silverBal"
         FROM "MFG_ISU_REC" a
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=a.tenant_id
          AND c."CO_CODE"=a."CO_CODE"
          AND c."AC_CODE"=a."AC_CODE"
        WHERE ${baseWhere.join(' AND ')}
          AND a."VCH_DATE"<$${openingParams.length}::date`,
      ...openingParams,
    );

    const detailParams = [...params, fromDate, toDate];
    const detailRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT b."BOOK_NAME" AS "bookName",
              a."CO_BOOK" AS "coBook",
              a."VCH_NO" AS "vchNo",
              a."VCH_DATE" AS "vchDate",
              a."AC_CODE" AS "acCode",
              c."AC_NAME" AS "acName",
              c."AC_AREA" AS "acArea",
              b."MAIN_BOOK" AS "mainBook",
              ${mfgAmountBalance} AS "amountBal",
              ${mfgMetalBalance('G')} AS "goldBal",
              ${mfgMetalBalance('S')} AS "silverBal"
         FROM "MFG_ISU_REC" a
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=a.tenant_id
          AND c."CO_CODE"=a."CO_CODE"
          AND c."AC_CODE"=a."AC_CODE"
        WHERE ${baseWhere.join(' AND ')}
          AND a."VCH_DATE">=$${detailParams.length - 1}::date
          AND a."VCH_DATE"<=$${detailParams.length}::date
        GROUP BY b."BOOK_NAME", a."CO_BOOK", a."VCH_NO", a."VCH_DATE", a."AC_CODE", c."AC_NAME", c."AC_AREA", b."MAIN_BOOK"
        ORDER BY a."VCH_DATE", b."BOOK_NAME"`,
      ...detailParams,
    );

    let drAmtTotal = 0;
    let crAmtTotal = 0;
    let drGoldTotal = 0;
    let crGoldTotal = 0;
    let drSilverTotal = 0;
    let crSilverTotal = 0;
    const rows: Array<Record<string, unknown>> = [];
    const appendBalanceRow = (
      row: Record<string, unknown>,
      base: Record<string, unknown>,
    ): void => {
      const amountBal = num(row.amountBal);
      const goldBal = num(row.goldBal);
      const silverBal = num(row.silverBal);
      const drAmt = amountBal < 0 ? Math.abs(amountBal) : 0;
      const crAmt = amountBal > 0 ? Math.abs(amountBal) : 0;
      const drGold = goldBal < 0 ? Math.abs(goldBal) : 0;
      const crGold = goldBal > 0 ? Math.abs(goldBal) : 0;
      const drSilver = silverBal < 0 ? Math.abs(silverBal) : 0;
      const crSilver = silverBal > 0 ? Math.abs(silverBal) : 0;
      drAmtTotal += drAmt;
      crAmtTotal += crAmt;
      drGoldTotal += drGold;
      crGoldTotal += crGold;
      drSilverTotal += drSilver;
      crSilverTotal += crSilver;
      const runningAmt = crAmtTotal - drAmtTotal;
      const runningGold = crGoldTotal - drGoldTotal;
      const runningSilver = crSilverTotal - drSilverTotal;
      rows.push({
        srNo: rows.length + 1,
        ...base,
        drAmt: round2(drAmt),
        crAmt: round2(crAmt),
        balAmt: round2(runningAmt),
        amtCrDr: crDr(round2(runningAmt)),
        crGold: round3(crGold),
        drGold: round3(drGold),
        balGold: round3(runningGold),
        goldCrDr: crDr(round3(runningGold)),
        crSilver: round3(crSilver),
        drSilver: round3(drSilver),
        balSilver: round3(runningSilver),
        silverCrDr: crDr(round3(runningSilver)),
      });
    };

    const opening = openingRows[0] ?? {};
    if (
      num(opening.amountBal) !== 0 ||
      num(opening.goldBal) !== 0 ||
      num(opening.silverBal) !== 0
    ) {
      appendBalanceRow(opening, {
        bookName: 'Op Balance',
        vchNo: null,
        date: null,
        partyName: null,
        area: null,
        coBook: null,
        acCode: null,
        mainBook: null,
      });
    }

    for (const row of detailRows) {
      appendBalanceRow(row, {
        bookName: txt(row.bookName),
        vchNo: txt(row.vchNo),
        date: isoDate(row.vchDate),
        partyName: txt(row.acName),
        area: txt(row.acArea),
        coBook: txt(row.coBook),
        acCode: txt(row.acCode),
        mainBook: txt(row.mainBook),
      });
    }

    return {
      rows,
      totals: {
        rows: rows.length,
        drAmt: round2(drAmtTotal),
        crAmt: round2(crAmtTotal),
        balAmt: round2(Math.abs(crAmtTotal - drAmtTotal)),
        crGold: round3(crGoldTotal),
        drGold: round3(drGoldTotal),
        balGold: round3(Math.abs(crGoldTotal - drGoldTotal)),
        crSilver: round3(crSilverTotal),
        drSilver: round3(drSilverTotal),
        balSilver: round3(Math.abs(crSilverTotal - drSilverTotal)),
      },
    };
  });
}
