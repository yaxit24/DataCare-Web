import { withTenant } from '@datacare/db';
import { dateWhere, type ListReport, type ReportScope } from './reports.js';
import { applyFilters, type ReportFilters } from './reportFilters.js';

/**
 * Report families ported from `RP_TAG_ESTMATE` and `RP_ORDER`.
 *
 * These two were absent, and their absence was load-bearing: the desktop binds `Ctrl+F12` to the tag
 * estimate and `Ctrl+F2` to the order zoom, and both chords were deliberately left UNMAPPED in
 * `FormKeys.tsx` rather than pointed at a near-miss page. Building the reports is what unblocks them.
 */

/** `Conversion.Val`-equivalent numeric read; the desktop tolerates junk in these columns. */
const num = (v: unknown): number => {
  const n = typeof v === 'number' ? v : Number(v);
  return Number.isFinite(n) ? n : 0;
};
const round3 = (n: number): number => Math.round(n * 1000) / 1000;
const round2 = (n: number): number => Math.round(n * 100) / 100;

/** Extra filter dimensions the desktop exposes on the tag estimate. */
export interface TagEstimateFilters extends ReportFilters {
  /** A single tag — specific to this form, not part of the shared panel. */
  tagNo?: string;
  /**
   * `In` reads the tag ledger; `Out` reads issued stock joined back to it. Defaults to `In`, which is the
   * desktop's first case.
   */
  direction?: 'In' | 'Out';
}

/**
 * Tag estimate — `RP_TAG_ESTMATE.cs`.
 *
 * The desktop switches between two sources:
 *
 *   In  : FROM BAR_DETL A LEFT JOIN ITEM_MAST B
 *   Out : FROM (MAIN_STOCK A LEFT JOIN BAR_DETL C ON co+lc+TAG_NO+VCH_SRNO) LEFT JOIN ITEM_MAST B
 *
 * with `A.TAG_NO <> ''`, a `VCH_DATE` window, and optional `PR_CODE` / `GR_CODE` / `IT_TYPE` / `TAG_NO`
 * filters, ordered by `A.TAG_NO`.
 *
 * The `Out` variant is NOT the same columns from a different table: `DESIGN_NO`, `ITM_SIZE` and `KR_NAME`
 * come from the joined `BAR_DETL` (alias C) because `MAIN_STOCK` does not carry them, while the pieces and
 * weights come from `MAIN_STOCK` itself. Reading them all from one side would report the wrong figures.
 *
 * Both `ITEM_MAST` filters apply to alias B in both directions, so filtering by group narrows an `Out`
 * listing by the item's group even though the row comes from stock.
 */
export async function tagEstimate(
  prisma: any,
  s: ReportScope,
  f: TagEstimateFilters = {},
): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.coCode];
    let where = 'a."CO_CODE"=$1';
    if (s.lcCode) {
      params.push(s.lcCode);
      where += ` AND a."LC_CODE"=$${params.length}`;
    }
    if (s.coYear) {
      params.push(s.coYear);
      where += ` AND a."CO_YEAR"=$${params.length}`;
    }
    // The desktop's own predicate is `A.TAG_NO <> ''`; a NULL tag is excluded by that comparison in SQL
    // Server too, so `coalesce(...,'')` reproduces it rather than widening it.
    where += ` AND coalesce(a."TAG_NO",'') <> ''`;
    where += dateWhere({ ...s, tenantId: s.tenantId }, 'a."VCH_DATE"', params);

    // Shared RP_ALL filter matrix. `tagNo` stays here because it is specific to this form rather than one
    // of the eleven panel dimensions.
    where += applyFilters('tag-estimate', f, params);
    if (f.tagNo) {
      params.push(f.tagNo);
      where += ` AND a."TAG_NO"=$${params.length}`;
    }

    const out = f.direction === 'Out';
    const sql = out
      ? `SELECT a."VCH_TYPE" AS "vchType", a."VCH_NO" AS "vchNo", a."VCH_DATE" AS "vchDate",
                a."TAG_NO" AS "tagNo", c."DESIGN_NO" AS design, a."IT_CODE" AS "itCode",
                a."TBL_CODE" AS counter, c."ITM_SIZE" AS size, a."ITM_PCS" AS pcs,
                a."ITM_GWT" AS gwt, a."ITM_NWT" AS nwt, a."LBR_AMT" AS "lbrAmt",
                a."OTH_AMT" AS "othAmt", a."ITM_MRP" AS mrp, c."KR_NAME" AS "krName",
                a."CO_BOOK" AS book, a."BOOK_NAME" AS "bookName", a."AC_CODE" AS "acCode",
                a."VCH_SRNO" AS "tagId"
           FROM "MAIN_STOCK" a
           LEFT JOIN "BAR_DETL" c ON c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE"
             AND c."LC_CODE"=a."LC_CODE" AND c."TAG_NO"=a."TAG_NO" AND c."VCH_SRNO"=a."VCH_SRNO"
           LEFT JOIN "ITEM_MAST" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
             AND b."IT_CODE"::text=a."IT_CODE"::text
          WHERE ${where}
          ORDER BY a."TAG_NO"`
      : `SELECT a."VCH_TYPE" AS "vchType", a."VCH_NO" AS "vchNo", a."VCH_DATE" AS "vchDate",
                a."TAG_NO" AS "tagNo", a."IT_CODE" AS "itCode", a."TBL_CODE" AS counter,
                a."DESIGN_NO" AS design, a."ITM_SIZE" AS size, a."ITM_PCS" AS pcs,
                a."ITM_GWT" AS gwt, a."ITM_NWT" AS nwt, a."LBR_AMT" AS "lbrAmt",
                a."OTH_AMT" AS "othAmt", a."ITM_MRP" AS mrp, a."KR_NAME" AS "krName",
                a."CO_BOOK" AS book, a."BOOK_NAME" AS "bookName", a."AC_CODE" AS "acCode",
                a."VCH_SRNO" AS "tagId"
           FROM "BAR_DETL" a
           LEFT JOIN "ITEM_MAST" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
             AND b."IT_CODE"::text=a."IT_CODE"::text
          WHERE ${where}
          ORDER BY a."TAG_NO"`;

    const rows: any[] = await tx.$queryRawUnsafe(sql, ...params);
    const mapped = rows.map((r) => ({
      vchType: r.vchType ?? null,
      vchNo: r.vchNo ?? null,
      vchDate: r.vchDate ?? null,
      tagNo: r.tagNo ?? null,
      itCode: r.itCode ?? null,
      counter: r.counter ?? null,
      design: r.design ?? null,
      size: r.size ?? null,
      pcs: round3(num(r.pcs)),
      gwt: round3(num(r.gwt)),
      nwt: round3(num(r.nwt)),
      lbrAmt: round2(num(r.lbrAmt)),
      othAmt: round2(num(r.othAmt)),
      mrp: round2(num(r.mrp)),
      krName: r.krName ?? null,
      book: r.book ?? null,
      bookName: r.bookName ?? null,
      acCode: r.acCode ?? null,
      tagId: r.tagId == null ? null : num(r.tagId),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        pcs: round3(mapped.reduce((t, r) => t + r.pcs, 0)),
        gwt: round3(mapped.reduce((t, r) => t + r.gwt, 0)),
        nwt: round3(mapped.reduce((t, r) => t + r.nwt, 0)),
        lbrAmt: round2(mapped.reduce((t, r) => t + r.lbrAmt, 0)),
        othAmt: round2(mapped.reduce((t, r) => t + r.othAmt, 0)),
        mrp: round2(mapped.reduce((t, r) => t + r.mrp, 0)),
      },
    };
  });
}

/**
 * Order / lot movement zoom — `RP_ORDER.cs`.
 *
 * The desktop drills into ONE lot and unions its two sides:
 *
 *   SELECT A.VCH_DATE,…,A.IT_PCS,A.IT_GWT,A.IT_NWT, 0 AS TagPcs, 0 AS TagGwt, 0 AS TagNwt, …
 *     FROM LOT_DETL A LEFT JOIN BOOK_DATA B ON co+lc+book
 *    WHERE co AND lc AND A.IT_SIGN = '+' AND A.LOT_NO = <selected>
 *   UNION ALL
 *   SELECT C.VCH_DATE,…,C.TAG_IT_CODE, C.TAG_NO, 0,0,0, C.IT_PCS,C.IT_GWT,C.IT_NWT, …
 *     FROM LOT_DETL C LEFT JOIN BOOK_DATA D ON co+book
 *    WHERE co AND lc AND C.IT_SIGN = '-' AND C.LOT_NO = <selected>
 *   ORDER BY A.VCH_DATE, A.SR_NO
 *
 * Three asymmetries between the two legs are real and preserved:
 *
 *  1. The `+` leg reports its weights in the issue columns and ZEROES the tag columns; the `-` leg does the
 *     reverse. A single row therefore only ever carries one side, and the column pair is what tells the
 *     reader whether metal went out or came back as tags.
 *  2. The `-` leg's item code is `TAG_IT_CODE`, not `IT_CODE` — the code of the item the tag was made into,
 *     which can differ from the item issued.
 *  3. The `-` leg's `BOOK_DATA` join omits `LC_CODE` (it joins on company and book only). Kept as written;
 *     it matters only where a book is defined per location, and "correcting" it would change which book
 *     name a returning row is labelled with.
 *
 * `LOT_NO` is required: this is a drill-down, and running it unfiltered would union an entire year of lot
 * movement into one grid, which is not a view the desktop offers.
 */
export async function orderLotZoom(
  prisma: any,
  s: ReportScope,
  lotNo: string,
): Promise<ListReport> {
  const lot = String(lotNo ?? '').trim();
  if (!lot) return { rows: [], totals: { rows: 0 } };
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? '', lot];
    // `$2 = ''` disables the location predicate rather than dropping it, so both legs keep identical
    // parameter positions and cannot drift apart.
    const cols = `x."VCH_DATE" AS "vchDate", x."CO_BOOK" AS book, x."VCH_NO" AS "vchNo",
                  x."SR_NO" AS "srNo", x."LOT_NO" AS "lotNo", x.item AS "itCode", x."TAG_NO" AS "tagNo",
                  x."IT_PCS" AS pcs, x."IT_GWT" AS gwt, x."IT_NWT" AS nwt,
                  x."TagPcs" AS "tagPcs", x."TagGwt" AS "tagGwt", x."TagNwt" AS "tagNwt",
                  x."EMP_CODE" AS "empCode", x."BOOK_SNAME" AS "bookShort", x."MAIN_BOOK" AS "mainBook"`;
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT ${cols} FROM (
         SELECT a."VCH_DATE", a."CO_BOOK", a."VCH_NO", a."SR_NO", a."LOT_NO",
                a."IT_CODE" AS item, a."TAG_NO",
                a."IT_PCS", a."IT_GWT", a."IT_NWT",
                0 AS "TagPcs", 0 AS "TagGwt", 0 AS "TagNwt",
                a."EMP_CODE", b."BOOK_SNAME", b."MAIN_BOOK"
           FROM "LOT_DETL" a
           LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
             AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
          WHERE a.tenant_id=current_setting('app.tenant_id', true)
            AND a."CO_CODE"=$1 AND ($2::text='' OR a."LC_CODE"=$2)
            AND a."IT_SIGN"='+' AND a."LOT_NO"=$3
         UNION ALL
         SELECT c."VCH_DATE", c."CO_BOOK", c."VCH_NO", c."SR_NO", c."LOT_NO",
                c."TAG_IT_CODE" AS item, c."TAG_NO",
                0, 0, 0,
                c."IT_PCS", c."IT_GWT", c."IT_NWT",
                c."EMP_CODE", d."BOOK_SNAME", d."MAIN_BOOK"
           FROM "LOT_DETL" c
           LEFT JOIN "BOOK_DATA" d ON d.tenant_id=c.tenant_id AND d."CO_CODE"=c."CO_CODE"
             AND d."CO_BOOK"=c."CO_BOOK"
          WHERE c.tenant_id=current_setting('app.tenant_id', true)
            AND c."CO_CODE"=$1 AND ($2::text='' OR c."LC_CODE"=$2)
            AND c."IT_SIGN"='-' AND c."LOT_NO"=$3
       ) x
       ORDER BY x."VCH_DATE", x."SR_NO"`,
      ...params,
    );
    const mapped = rows.map((r) => ({
      vchDate: r.vchDate ?? null,
      book: r.book ?? null,
      vchNo: r.vchNo ?? null,
      srNo: r.srNo == null ? null : num(r.srNo),
      lotNo: r.lotNo ?? null,
      itCode: r.itCode ?? null,
      tagNo: r.tagNo ?? null,
      pcs: round3(num(r.pcs)),
      gwt: round3(num(r.gwt)),
      nwt: round3(num(r.nwt)),
      tagPcs: round3(num(r.tagPcs)),
      tagGwt: round3(num(r.tagGwt)),
      tagNwt: round3(num(r.tagNwt)),
      empCode: r.empCode ?? null,
      bookShort: r.bookShort ?? null,
      mainBook: r.mainBook ?? null,
    }));
    const sum = (k: keyof (typeof mapped)[number]) =>
      round3(mapped.reduce((t, r) => t + num(r[k]), 0));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        pcs: sum('pcs'),
        gwt: sum('gwt'),
        nwt: sum('nwt'),
        tagPcs: sum('tagPcs'),
        tagGwt: sum('tagGwt'),
        tagNwt: sum('tagNwt'),
        // The lot's balance: what went out less what came back as tags. This is the figure the drill-down
        // exists to answer, and neither leg alone shows it.
        balanceNwt: round3(sum('nwt') - sum('tagNwt')),
      },
    };
  });
}
