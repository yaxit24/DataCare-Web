import { withTenant } from '@datacare/db';
import { PRECISION, round } from '@datacare/core';

/**
 * HUID report — the hallmarking compliance register (desktop `RP_HUID`).
 *
 * WHY THIS EXISTS
 * A HUID is the six-character Hallmark Unique ID that BIS requires on hallmarked jewellery in India, so
 * a shop must be able to produce the list of which HUIDs it holds and which it has moved. The web had no
 * such report while the desktop has a dedicated form for it.
 *
 * COLUMNS ARE THE DESKTOP'S, NOT INVENTED. `RP_HUID.cs` selects, verbatim:
 *   CoCode, VchTyp, VchNo, VchDate, TagNo, ItCode, Counter, Qty (literal 1), Pcs, Grwt, NetWt,
 *   HuId, HuWt, HuId2, HuWt2, HuId3, HuWt3, HuId4, HuWt4, KrName, Book, BookName, ItRemark,
 *   TagId (= VCH_SRNO)
 * from `BAR_DETL` LEFT JOIN `ITEM_MAST`. `Qty` really is the constant 1 — one row is one tag.
 *
 * TABS mirror the desktop's variants, which differ only in how they reach stock:
 *   all   — every barcoded tag ever created (BAR_DETL alone)
 *   stock — tags still in stock, via the same net-sign availability rule the sale path uses, so this
 *           report cannot disagree with what is sellable
 *
 * Four HUID slots exist because one tag can carry up to four hallmarked components; the desktop pairs
 * each id with its own weight, and both are reported.
 *
 * Read-only and RLS-scoped.
 */
export type HuidTab = 'all' | 'stock';

export interface HuidRow {
  vchType: string | null;
  vchNo: string | null;
  vchDate: string | null;
  tagNo: string;
  itCode: string | null;
  itName: string | null;
  counter: string | null;
  qty: number;
  pcs: number;
  grossWt: number;
  netWt: number;
  /** HM_ID..HM_ID4 with their weights. Text, because a HUID is alphanumeric. */
  huid: string | null;
  huidWt: number;
  huid2: string | null;
  huid2Wt: number;
  huid3: string | null;
  huid3Wt: number;
  huid4: string | null;
  huid4Wt: number;
  karigarName: string | null;
  book: string | null;
  bookName: string | null;
  remark: string | null;
  /** VCH_SRNO — the desktop calls this TagId; it is the tag INSTANCE serial. */
  tagId: number;
}

export interface HuidReport {
  tab: HuidTab;
  rows: HuidRow[];
  /** `hallmarkedTags` counts rows carrying at least one HUID; `slots` counts ids across all four. */
  totals: { count: number; hallmarkedTags: number; slots: number; netWt: number; huidWt: number };
}

/**
 * Weight rounding goes through the money kernel, not a local Math.round.
 *
 * The kernel-conformance ratchet caught the first version of this file adding a 109th rounding bypass:
 * `Math.round((n + 1e-9) * 1000) / 1000` is neither of the desktop's two measured rounding mechanisms
 * and breaks negative ties toward +infinity. The ceiling may only shrink, so the fix is to use the
 * kernel rather than to raise the ceiling.
 */
const r3 = (n: number): number => round(n, PRECISION.weight);
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s === '' ? null : s;
};
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};

export async function huidReport(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  options: { tab?: HuidTab; itCode?: string; tblCode?: string; onlyHallmarked?: boolean } = {},
): Promise<HuidReport> {
  const tab: HuidTab = options.tab ?? 'all';
  return withTenant(prisma, tenantId, async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    const filters = ['c."CO_CODE"::text=$1', 'c."LC_CODE"::text=$2'];
    if (options.itCode) {
      params.push(options.itCode);
      filters.push(`c."IT_CODE"::text=$${params.length}`);
    }
    if (options.tblCode) {
      params.push(options.tblCode);
      filters.push(`c."TBL_CODE"::text=$${params.length}`);
    }
    if (options.onlyHallmarked !== false) {
      // The register is about hallmarked stock, so a tag with no id in any of the four slots is not a
      // compliance row. Passing onlyHallmarked:false returns every tag, which is what the desktop's
      // unfiltered variant shows.
      filters.push(
        `(NULLIF(btrim(coalesce(c."HM_ID"::text,'')),'') IS NOT NULL
          OR NULLIF(btrim(coalesce(c."HM_ID2"::text,'')),'') IS NOT NULL
          OR NULLIF(btrim(coalesce(c."HM_ID3"::text,'')),'') IS NOT NULL
          OR NULLIF(btrim(coalesce(c."HM_ID4"::text,'')),'') IS NOT NULL)`,
      );
    }
    if (tab === 'stock') {
      // Availability is the NET of MAIN_STOCK signs for this tag instance — the same rule
      // `availableBarTags` applies for a sale. A simple "no '-' movement exists" test would wrongly
      // exclude a tag that was sold and returned.
      filters.push(`coalesce((
        SELECT sum(CASE WHEN m."ITM_SIGN"::text='+' THEN 1 ELSE -1 END)
          FROM "MAIN_STOCK" m
         WHERE m."CO_CODE"::text=c."CO_CODE"::text
           AND m."LC_CODE"::text=c."LC_CODE"::text
           AND m."TAG_NO"::text=c."TAG_NO"::text
           AND coalesce(m."VCH_SRNO",0)=coalesce(c."VCH_SRNO",0)
      ),0) > 0`);
    }

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT c."VCH_TYPE",c."VCH_NO",c."VCH_DATE"::text AS "VCH_DATE",c."TAG_NO",c."IT_CODE",
              b."IT_NAME",c."TBL_CODE",c."ITM_PCS",c."ITM_GWT",c."ITM_NWT",
              c."HM_ID",c."HM_ID_WT",c."HM_ID2",c."HM_ID2_WT",c."HM_ID3",c."HM_ID3_WT",
              c."HM_ID4",c."HM_ID4_WT",c."KR_NAME",c."CO_BOOK",c."BOOK_NAME",c."ITM_REMARK",
              c."VCH_SRNO"
         FROM "BAR_DETL" c
         LEFT JOIN "ITEM_MAST" b
           ON b."CO_CODE"::text=c."CO_CODE"::text AND b."IT_CODE"::text=c."IT_CODE"::text
        WHERE ${filters.join(' AND ')}
        ORDER BY c."TAG_NO", coalesce(c."VCH_SRNO",0)`,
      ...params,
    );

    const mapped: HuidRow[] = rows.map((r) => ({
      vchType: txt(r.VCH_TYPE),
      vchNo: txt(r.VCH_NO),
      vchDate: txt(r.VCH_DATE)?.slice(0, 10) ?? null,
      tagNo: String(r.TAG_NO ?? ''),
      itCode: txt(r.IT_CODE),
      itName: txt(r.IT_NAME),
      counter: txt(r.TBL_CODE),
      // The desktop selects the literal 1: one row is one tag, regardless of piece count.
      qty: 1,
      pcs: num(r.ITM_PCS),
      grossWt: r3(num(r.ITM_GWT)),
      netWt: r3(num(r.ITM_NWT)),
      huid: txt(r.HM_ID),
      huidWt: r3(num(r.HM_ID_WT)),
      huid2: txt(r.HM_ID2),
      huid2Wt: r3(num(r.HM_ID2_WT)),
      huid3: txt(r.HM_ID3),
      huid3Wt: r3(num(r.HM_ID3_WT)),
      huid4: txt(r.HM_ID4),
      huid4Wt: r3(num(r.HM_ID4_WT)),
      karigarName: txt(r.KR_NAME),
      book: txt(r.CO_BOOK),
      bookName: txt(r.BOOK_NAME),
      remark: txt(r.ITM_REMARK),
      tagId: num(r.VCH_SRNO),
    }));

    const slots = mapped.reduce(
      (sum, r) => sum + [r.huid, r.huid2, r.huid3, r.huid4].filter((id) => id !== null).length,
      0,
    );
    return {
      tab,
      rows: mapped,
      totals: {
        count: mapped.length,
        hallmarkedTags: mapped.filter((r) => r.huid || r.huid2 || r.huid3 || r.huid4).length,
        slots,
        netWt: r3(mapped.reduce((s, r) => s + r.netWt, 0)),
        huidWt: r3(mapped.reduce((s, r) => s + r.huidWt + r.huid2Wt + r.huid3Wt + r.huid4Wt, 0)),
      },
    };
  });
}
