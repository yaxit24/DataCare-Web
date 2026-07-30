import { withTenant } from '@datacare/db';

/**
 * Closing-stock valuation — the desktop's `Ac_Final.Trading_Stock` (`Ac_Final.cs:18-138`).
 *
 * WHY THIS EXISTS
 * ---------------
 * `reports.balanceSheet()` previously derived `closingStock = ΣCr − ΣDr`. That makes the sheet balance by
 * DEFINITION, so it can never reveal a stock discrepancy — which for a gold business is the main thing a
 * balance sheet is for. The desktop computes closing stock INDEPENDENTLY from inventory and posts it as a
 * balanced double-entry pair, so the sheet ties through bookkeeping and any difference is real and visible.
 *
 * DESKTOP CONTROL FLOW, established by reading `Ac_Final.cs:18-138`
 * ----------------------------------------------------------------
 *   DELETE AC_DATA WHERE CO_BOOK='999'                       ' :21  computed closing is rebuilt each run
 *   MsClgValueSave = (any AC_DATA with CO_BOOK='888') ? 'Y' : 'N'   ' :22-31
 *   if MsClgValueSave = 'N'                                   ' :34  no operator-entered values
 *      if MsBalanceSheetType = 'F'                            ' :36  'F' = Fine-wise
 *         if GoldRate + SilverRate <> 0                       ' :38
 *            metal pass  : MAIN_STOCK + BAL_GR                ' :40-95
 *      non-metal pass    : BAL_GR stored averages             ' :102-123  ALWAYS runs
 *
 * Two consequences that are easy to get backwards and are therefore stated explicitly:
 *  1. The METAL pass runs ONLY in 'F' mode with a non-zero rate. In any other mode metals are not valued
 *     from `MAIN_STOCK` at all.
 *  2. The NON-METAL pass always runs, and it does NOT aggregate `MAIN_STOCK`; it reads `BAL_GR.AVG_NWT`
 *     and `BAL_GR.TOT_PCS` (`Ac_Final.cs:102`).
 *
 * Book `888` is the operator's manually-entered closing stock. When it exists the computed pass is skipped
 * entirely — the operator's figure wins. Book `999` holds the computed figure.
 *
 * VALUATION
 * ---------
 *   metal    : ClFine × (rate / 10) + AVG_AMT                 ' :57,62,73,78 and the AVG_AMT add at :92
 *   non-metal: ClNwt × AVG_RATE + ClPcs × PCS_RATE            ' :110-111
 *
 * The ledger-fine adjustment (`AcLdrFineGold` / `AcLdrFineSilver`) applies ONLY to the group whose code is
 * literally 'GO' or 'SL' (`Ac_Final.cs:52,67`); every other gold/silver-type group uses raw `ClFine`.
 * Generalising that adjustment to all metal groups would silently misvalue stock.
 *
 * WHAT IS DELIBERATELY NOT PORTED
 * -------------------------------
 * The desktop WRITES `AC_DATA` book `999` while rendering. A web GET must not mutate the ledger, so the
 * balanced pair is returned as `legs` for presentation and never inserted. `MsClgValueSave` is runtime
 * state, not a setting: it is derived here exactly as the desktop derives it.
 */

/** `Conversion.Val` equivalent: leading numeric prefix, 0 for junk/blank. Needed because BAL_GR stores
 *  AVG_FINE / AVG_AMT / AVG_RATE / TRAD_AMT as VARCHAR, where a plain `::numeric` cast throws on junk. */
const VAL = (c: string): string =>
  `coalesce(substring(${c}::text from '^[[:space:]]*-?[0-9]+\\.?[0-9]*')::numeric, 0)`;

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => Number(v ?? 0);

export interface ClosingStockScope {
  tenantId: string;
  coCode: string;
  coYear?: string;
  /** `FinalLc` — blank means all locations (`Ac_Final.cs:40` omits the predicate when blank). */
  lcCode?: string;
}

export interface ClosingStockInput {
  /** `FinalClDt`. Rows with `VCH_DATE <= closingDate` are counted. */
  closingDate: Date | string;
  /** Operator-entered metal rates. Per-10-gram, matching the desktop's `rate / 10.0`. */
  goldRate?: number;
  silverRate?: number;
  /** `AcLdrFineGold` / `AcLdrFineSilver` — ledger fine applied to the 'GO' / 'SL' groups only. */
  ledgerFineGold?: number;
  ledgerFineSilver?: number;
}

export interface ClosingStockRow {
  code: string;
  name: string;
  itType: string;
  basis: 'fine' | 'amount';
  clFine: number;
  clNwt: number;
  clPcs: number;
  value: number;
  /** `CLG_AC` / `CLOSING_AC` — the two accounts the desktop posts the balanced pair against. */
  clgAc: string;
  closingAc: string;
}

export interface ClosingStockResult {
  /** `computed` = derived here; `managed` = operator values in book 888 took precedence. */
  mode: 'computed' | 'managed';
  /** `MsBalanceSheetType` from `CO_SET_NEW.PROFIT_RPT_TYPE` (`MS_OPNCOMP.cs:958`). */
  balanceSheetType: string;
  metalValued: boolean;
  rows: ClosingStockRow[];
  total: number;
  /** The balanced double-entry pair the desktop would post to book 999 — presentation only, never written. */
  legs: { acCode: string; ldCode: string; drAmt: number; crAmt: number }[];
}

const asDate = (d: Date | string): string =>
  (d instanceof Date ? d : new Date(d)).toISOString().slice(0, 10);

/**
 * Value closing stock the way the desktop does. Read-only: performs no INSERT/DELETE.
 */
export async function closingStockValuation(
  prisma: any,
  scope: ClosingStockScope,
  input: ClosingStockInput,
): Promise<ClosingStockResult> {
  return withTenant(prisma, scope.tenantId, async (tx: any) =>
    closingStockValuationTx(tx, scope, input),
  );
}

export async function closingStockValuationTx(
  tx: any,
  scope: ClosingStockScope,
  input: ClosingStockInput,
): Promise<ClosingStockResult> {
  const clDt = asDate(input.closingDate);
  const goldRate = num(input.goldRate);
  const silverRate = num(input.silverRate);

  // MsBalanceSheetType <- CO_SET_NEW.PROFIT_RPT_TYPE (MS_OPNCOMP.cs:958; UT_SETTING_MAIN.cs:8477 maps
  // 'Fine Wise'->F, 'Amount Wise'->A). Fails to 'A' (no metal pass) rather than inventing 'F'.
  const setRows: any[] = await tx.$queryRawUnsafe(
    `SELECT upper(btrim(coalesce("PROFIT_RPT_TYPE"::text,''))) AS t
       FROM "CO_SET_NEW" WHERE "CO_CODE"=$1 LIMIT 1`,
    scope.coCode,
  );
  const balanceSheetType = String(setRows[0]?.t ?? '') || 'A';

  // MsClgValueSave: operator-entered closing values live in book 888 (Ac_Final.cs:22-31).
  const managed: any[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(${VAL('"DR_AMT"')}),0) AS dr, count(*)::int AS n
       FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"='888'`,
    scope.coCode,
  );
  if (Number(managed[0]?.n ?? 0) > 0) {
    // Operator values take precedence and the computed pass is skipped entirely (Ac_Final.cs:34).
    const total = round2(num(managed[0].dr));
    return { mode: 'managed', balanceSheetType, metalValued: false, rows: [], total, legs: [] };
  }

  const rows: ClosingStockRow[] = [];
  const lcFilter = scope.lcCode ? ` AND a."LC_CODE"=$3` : '';
  const yrFilter = scope.coYear ? ` AND a."CO_YEAR"=$${scope.lcCode ? 4 : 3}` : '';
  const stockParams: unknown[] = [scope.coCode, clDt];
  if (scope.lcCode) stockParams.push(scope.lcCode);
  if (scope.coYear) stockParams.push(scope.coYear);

  const metalValued = balanceSheetType === 'F' && goldRate + silverRate !== 0;
  if (metalValued) {
    // Ac_Final.cs:40 — ClPcs counts ITM_MRP<>0 rows, ClNwt counts ITM_MRP=0 rows, both with ITM_SIGN
    // polarity, both bounded by VCH_DATE <= closing date.
    const metal: any[] = await tx.$queryRawUnsafe(
      `SELECT b."TRAD_TYPE" AS code, c."TRAD_NAME" AS name, c."IT_TYPE" AS ittype,
              ${VAL('c."AVG_FINE"')} AS clfine, ${VAL('c."AVG_AMT"')} AS avgamt,
              coalesce(c."CLG_AC",'') AS clgac, coalesce(c."CLOSING_AC",'') AS closingac,
              sum(CASE WHEN a."VCH_DATE" <= $2::date AND ${VAL('a."ITM_MRP"')} <> 0
                       THEN (CASE WHEN a."ITM_SIGN"='+' THEN ${VAL('a."ITM_PCS"')} ELSE -${VAL('a."ITM_PCS"')} END)
                       ELSE 0 END) AS clpcs,
              sum(CASE WHEN a."VCH_DATE" <= $2::date AND ${VAL('a."ITM_MRP"')} = 0
                       THEN (CASE WHEN a."ITM_SIGN"='+' THEN ${VAL('a."ITM_NWT"')} ELSE -${VAL('a."ITM_NWT"')} END)
                       ELSE 0 END) AS clnwt
         FROM "MAIN_STOCK" a
         LEFT JOIN "ITEM_MAST" b ON a."CO_CODE"=b."CO_CODE" AND a."IT_CODE"=b."IT_CODE"
         LEFT JOIN "BAL_GR"    c ON b."CO_CODE"=c."CO_CODE" AND b."TRAD_TYPE"=c."TRAD_TYPE"
        WHERE a."CO_CODE"=$1${lcFilter}${yrFilter} AND coalesce(b."TRAD_TYPE",'') <> ''
        GROUP BY b."TRAD_TYPE", c."TRAD_NAME", c."IT_TYPE", c."AVG_FINE", c."AVG_AMT",
                 c."CLG_AC", c."CLOSING_AC"
        ORDER BY c."TRAD_NAME"`,
      ...stockParams,
    );
    for (const r of metal) {
      const code = String(r.code ?? '');
      const itType = String(r.ittype ?? '')
        .trim()
        .toUpperCase();
      const rawFine = num(r.clfine);
      let value = 0;
      if (itType === 'G') {
        // Ledger-fine adjustment applies to the 'GO' group only (Ac_Final.cs:52-59).
        const fine = code === 'GO' ? adjustFine(rawFine, num(input.ledgerFineGold)) : rawFine;
        if (goldRate !== 0) value = fine * (goldRate / 10);
      } else if (itType === 'S') {
        const fine = code === 'SL' ? adjustFine(rawFine, num(input.ledgerFineSilver)) : rawFine;
        if (silverRate !== 0) value = fine * (silverRate / 10);
      } else {
        continue; // only G and S are valued by the metal pass (Ac_Final.cs:50,65)
      }
      const total = value + num(r.avgamt); // AVG_AMT added at Ac_Final.cs:92
      if (total === 0) continue; // desktop posts only when the pair is non-zero (Ac_Final.cs:86)
      rows.push({
        code,
        name: String(r.name ?? ''),
        itType,
        basis: 'fine',
        clFine: rawFine,
        clNwt: num(r.clnwt),
        clPcs: num(r.clpcs),
        value: round2(total),
        clgAc: String(r.clgac ?? ''),
        closingAc: String(r.closingac ?? ''),
      });
    }
  }

  // Non-metal pass ALWAYS runs and reads BAL_GR stored averages, not MAIN_STOCK (Ac_Final.cs:102).
  const other: any[] = await tx.$queryRawUnsafe(
    `SELECT a."TRAD_TYPE" AS code, b."IT_TYPE" AS ittype, b."TRAD_NAME" AS name,
            ${VAL('b."AVG_RATE"')} AS clrate, ${VAL('b."AVG_NWT"')} AS clnwt,
            coalesce(b."TOT_PCS",0) AS clpcs, coalesce(b."PCS_RATE",0) AS pcsrate,
            coalesce(b."CLG_AC",'') AS clgac, coalesce(b."CLOSING_AC",'') AS closingac
       FROM "ITEM_MAST" a
       LEFT JOIN "BAL_GR" b ON a."CO_CODE"=b."CO_CODE" AND a."TRAD_TYPE"=b."TRAD_TYPE"
      WHERE a."CO_CODE"=$1 AND coalesce(a."TRAD_TYPE",'') <> ''
      GROUP BY a."TRAD_TYPE", b."IT_TYPE", b."TRAD_NAME", b."AVG_RATE", b."AVG_NWT",
               b."TOT_PCS", b."PCS_RATE", b."CLG_AC", b."CLOSING_AC"
      ORDER BY b."TRAD_NAME"`,
    scope.coCode,
  );
  for (const r of other) {
    const code = String(r.code ?? '');
    // A group already valued by the metal pass must not be double counted.
    if (rows.some((x) => x.code === code)) continue;
    const value = num(r.clnwt) * num(r.clrate) + num(r.clpcs) * num(r.pcsrate); // :110-111
    if (value === 0) continue; // :114
    rows.push({
      code,
      name: String(r.name ?? ''),
      itType: String(r.ittype ?? '')
        .trim()
        .toUpperCase(),
      basis: 'amount',
      clFine: 0, // the desktop's non-metal query selects `0 As ClFine` (Ac_Final.cs:102)
      clNwt: num(r.clnwt),
      clPcs: num(r.clpcs),
      value: round2(value),
      clgAc: String(r.clgac ?? ''),
      closingAc: String(r.closingac ?? ''),
    });
  }

  const total = round2(rows.reduce((a, r) => a + r.value, 0));
  // The desktop posts TWO rows per group: Dr on CLG_AC and Cr on CLOSING_AC (Ac_Final.cs:88,90).
  const legs = rows.flatMap((r) => [
    { acCode: r.clgAc, ldCode: r.closingAc, drAmt: r.value, crAmt: 0 },
    { acCode: r.closingAc, ldCode: r.clgAc, drAmt: 0, crAmt: r.value },
  ]);
  return { mode: 'computed', balanceSheetType, metalValued, rows, total, legs };
}

/** `Ac_Final.cs:54-56` — a positive ledger fine is subtracted, a negative one is added by magnitude. */
function adjustFine(clFine: number, ledgerFine: number): number {
  if (ledgerFine > 0) return clFine - ledgerFine;
  if (ledgerFine < 0) return clFine + Math.abs(ledgerFine);
  return clFine;
}
