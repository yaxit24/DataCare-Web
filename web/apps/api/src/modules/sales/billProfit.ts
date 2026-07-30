import { round } from '@datacare/core';

/**
 * Bill profit — the desktop's `nBillProfit` / `nItProfit`.
 *
 * Four desktop forms show the margin on the voucher being written (`TR_SALE`, `TR_SALE_LBR`,
 * `TR_TOUR_SALE`, `TR_WH_SALE`) and the web had none, so a jeweller could not see whether a bill was
 * profitable before completing it.
 *
 * PER-LINE COST HAS THREE BRANCHES (`TR_SALE.cs:17009-17045`), taken in this order. The grid columns were
 * resolved from the load/write path rather than assumed: 30 = `ITM_MRP`, 38 = `TAG_COST`, 48 = `KR_FINE`,
 * 14 = `ITM_NWT`, 22 = `ITM_RATE`, 35 = `TOT_AMT`, 37 = `NET_AMT`, 1 = `TAG_NO`.
 *
 *   1. MRP-priced line (`ITM_MRP <> 0`)          — `:17023`
 *        profit = NET_AMT − TAG_COST
 *        The tag carries its own recorded cost, so nothing has to be derived.
 *
 *   2. Tagged line with karigar fine             — `:17028-17030`
 *        cost   = round(KR_FINE × saleRate + TAG_COST, 2)
 *        profit = TOT_AMT − cost
 *        Requires BOTH a non-zero `KR_FINE` and a non-blank `TAG_NO`; the desktop tests both.
 *
 *   3. Otherwise, derive the fine from the item's average touch — `:17041-17044`
 *        fine   = round(ITM_NWT × AVG_TOUCH / 100, 3)
 *        cost   = round(fine × saleRate, 2)
 *        profit = TOT_AMT − cost
 *        Applies only when the item has a NON-ZERO `AVG_TOUCH` and the line has a net weight; with neither,
 *        the desktop shows no profit for the line at all rather than assuming zero cost.
 *
 * Note branch 1 uses `NET_AMT` while branches 2 and 3 use `TOT_AMT`. Both hold the same tax-exclusive
 * whole-rupee figure in this codebase, but the distinction is preserved because the desktop makes it.
 *
 * WAIVED, LICENCE-GATED
 * Two behaviours are gated on a specific registration serial and are NOT implemented:
 *   * `SSRegSrNo == 'KJ001NEKJ'` replaces the sale rate with `ITM_RATE × 100 / GROUP_MAST.GR_TOUCH`
 *     (`:17011-17018`);
 *   * the same serial adjusts the voucher total by a further term (`:19400-19409`).
 * Both would need the licence serial to reproduce, and inventing the condition would change every margin at
 * shops that do not hold it. Recorded in FEATURE-GAP-REGISTER.md with the revocation condition.
 *
 * VISIBILITY is a company setting, not a serial: the desktop shows the figure when the software edition is
 * 'E' or when `MsBillProfit` (`CO_SET_NEW.BILL_PROFIT`) is 'Y' (`:19392`). The web gates on the setting,
 * which is now reachable in the settings screen.
 */

export interface ProfitLineInput {
  /** `TAG_NO` (col 1) — blank for an untagged line. */
  tagNo?: string;
  /** `ITM_MRP` (col 30). */
  itmMrp?: number;
  /** `TAG_COST` (col 38) — the cost recorded against the tag. */
  tagCost?: number;
  /** `KR_FINE` (col 48) — karigar fine on the line. */
  krFine?: number;
  /** `ITM_NWT` (col 14). */
  netWt?: number;
  /** `TOT_AMT` (col 35). */
  totAmt?: number;
  /** `NET_AMT` (col 37). */
  netAmt?: number;
  /** `ITEM_MAST.AVG_TOUCH` for the line's item; 0/absent disables branch 3. */
  avgTouch?: number;
}

export type ProfitBasis = 'mrp' | 'karigar-fine' | 'average-touch' | 'none';

export interface ProfitLineResult {
  basis: ProfitBasis;
  cost: number;
  profit: number;
  /** Derived fine used by the average-touch branch; 0 otherwise. */
  fine: number;
}

const n = (v: unknown): number => {
  const x = Number(v ?? 0);
  return Number.isFinite(x) ? x : 0;
};

/** Per-line profit. `saleRate` is the desktop's `ToDaySlRate`, loaded server-side. */
export function lineProfit(line: ProfitLineInput, saleRate: number): ProfitLineResult {
  const rate = n(saleRate);
  const tagCost = n(line.tagCost);

  // 1. MRP-priced: the tag's own cost is authoritative.
  if (n(line.itmMrp) !== 0) {
    return {
      basis: 'mrp',
      cost: round(tagCost, 2),
      profit: round(n(line.netAmt) - tagCost, 2),
      fine: 0,
    };
  }

  // 2. Tagged line with karigar fine. BOTH conditions are required, as the desktop tests both.
  const krFine = n(line.krFine);
  if (krFine !== 0 && String(line.tagNo ?? '').trim() !== '') {
    const cost = round(krFine * rate + tagCost, 2);
    return { basis: 'karigar-fine', cost, profit: round(n(line.totAmt) - cost, 2), fine: krFine };
  }

  // 3. Derive the fine from the item's average touch. Without a touch or a weight the desktop shows
  //    nothing rather than treating the cost as zero, so an unknown cost is never read as pure profit.
  const avgTouch = n(line.avgTouch);
  const netWt = n(line.netWt);
  if (avgTouch !== 0 && netWt !== 0) {
    const fine = round((netWt * avgTouch) / 100, 3);
    const cost = round(fine * rate, 2);
    return { basis: 'average-touch', cost, profit: round(n(line.totAmt) - cost, 2), fine };
  }

  return { basis: 'none', cost: 0, profit: 0, fine: 0 };
}

export interface BillProfitResult {
  /** Sum of the per-line profits (`TR_SALE.cs:19396-19399`). */
  total: number;
  lines: ProfitLineResult[];
  /** False when the company setting hides the figure; callers must not return a total in that case. */
  visible: boolean;
}

/**
 * Voucher bill profit.
 *
 * `visible` reflects `CO_SET_NEW.BILL_PROFIT`. When it is off the total is reported as 0 and `visible` is
 * false, so a caller cannot accidentally surface a margin at a shop that has chosen not to show one.
 */
export function billProfit(
  lines: readonly ProfitLineInput[],
  saleRate: number,
  options: { billProfitEnabled?: boolean } = {},
): BillProfitResult {
  const results = lines.map((l) => lineProfit(l, saleRate));
  const visible = options.billProfitEnabled !== false;
  const total = round(
    results.reduce((sum, r) => sum + r.profit, 0),
    2,
  );
  return { total: visible ? total : 0, lines: results, visible };
}

/**
 * `ToDaySlRate` — the per-gram, tax-excluded fine sale rate the cost branches value fine metal at.
 *
 * `TR_SALE.cs` (the `RATE_MAST` lookup feeding `ToDaySlRate`):
 *
 *   SELECT TOP(1) FINE_GL_RATE, FINE_SL_RATE, VCH_DATE FROM RATE_MAST
 *    WHERE CO_CODE=? AND LC_CODE=? AND VCH_DATE <= <voucher date> AND SR_NO = 1
 *    ORDER BY VCH_DATE DESC
 *   ToDaySlRate = Format(FINE_SL_RATE / 103.0 * 100.0 / 1000.0, "0.00")
 *
 * Three details that would be wrong if guessed:
 *   * it uses `FINE_SL_RATE` — the fine SALE rate — even though the query also selects `FINE_GL_RATE`;
 *   * `/ 103 * 100` strips a 3% loading, so the cost basis is the EX-TAX rate. Costing at the loaded rate
 *     would understate every margin by roughly 3%;
 *   * `/ 1000` converts a per-kilogram quote to per gram, which is the unit the fine weights are in.
 *
 * `SR_NO = 1` selects the primary rate row, and the newest date NOT AFTER the voucher date — so a
 * back-dated voucher is costed at the rate that applied then, not today's.
 */
export async function todaySaleRateTx(
  tx: any,
  scope: { coCode: string; lcCode?: string },
  vchDate: Date | string,
): Promise<number> {
  const d = vchDate instanceof Date ? vchDate : new Date(vchDate);
  const iso = d.toISOString().slice(0, 10);
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "FINE_SL_RATE" FROM "RATE_MAST"
      WHERE tenant_id=current_setting('app.tenant_id', true)
        AND "CO_CODE"=$1 AND ($2::text = '' OR "LC_CODE"=$2)
        AND "VCH_DATE" <= $3::date AND coalesce("SR_NO",0)=1
      ORDER BY "VCH_DATE" DESC LIMIT 1`,
    scope.coCode,
    scope.lcCode ?? '',
    iso,
  );
  const raw = n(rows[0]?.FINE_SL_RATE);
  if (raw === 0) return 0; // no rate configured: the cost branches then yield no profit, not a wrong one
  return round(((raw / 103) * 100) / 1000, 2);
}

/** `ITEM_MAST.AVG_TOUCH` per item, for the derived-cost branch. Zero/absent rows are omitted. */
export async function averageTouchByItemTx(
  tx: any,
  scope: { coCode: string },
  itCodes: readonly string[],
): Promise<Record<string, number>> {
  const codes = [...new Set(itCodes.map((c) => String(c ?? '').trim()).filter(Boolean))];
  if (!codes.length) return {};
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE", "AVG_TOUCH" FROM "ITEM_MAST"
      WHERE tenant_id=current_setting('app.tenant_id', true)
        AND "CO_CODE"=$1 AND "IT_CODE" = ANY($2::text[])
        AND coalesce("AVG_TOUCH",0) <> 0`,
    scope.coCode,
    codes,
  );
  const out: Record<string, number> = {};
  for (const r of rows) out[String(r.IT_CODE)] = n(r.AVG_TOUCH);
  return out;
}

/**
 * Is the margin shown for this company?
 *
 * `CO_SET_NEW.BILL_PROFIT`, matching the desktop's `MsBillProfit` gate (`TR_SALE.cs:19392`). Read here
 * rather than through `resolveSettingsBehaviorTx`, which covers `CO_SET` and fails closed on a strict
 * one-row rule — a company without a `CO_SET_NEW` row should simply not show a margin, not break its sale.
 *
 * Defaults to OFF: a shop that has never configured this has not asked to see margins.
 */
export async function billProfitEnabledTx(tx: any, scope: { coCode: string }): Promise<boolean> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "BILL_PROFIT" FROM "CO_SET_NEW"
      WHERE tenant_id=current_setting('app.tenant_id', true) AND "CO_CODE"=$1 LIMIT 1`,
    scope.coCode,
  );
  return (
    String(rows[0]?.BILL_PROFIT ?? '')
      .trim()
      .toUpperCase() === 'Y'
  );
}
