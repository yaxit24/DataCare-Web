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
const isoDate = (v: unknown): string | null => {
  if (!v) return null;
  const d = v instanceof Date ? v : new Date(String(v));
  return Number.isFinite(d.getTime()) ? d.toISOString().slice(0, 10) : null;
};
const todayIso = (): string => new Date().toISOString().slice(0, 10);
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
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

const isoToday = (): string => new Date().toISOString().slice(0, 10);
const firstOfThisMonth = (): string => {
  const now = new Date();
  return `${now.getUTCFullYear()}-${String(now.getUTCMonth() + 1).padStart(2, '0')}-01`;
};

function deleteDataRange(s: ReportScope): { fromDate: string; toDate: string } {
  const fromDate = s.fromDate ?? firstOfThisMonth();
  const toDate = s.toDate ?? isoToday();
  if (fromDate > toDate) {
    const err = new Error('fromDate must be before or equal to toDate');
    err.name = 'ReportValidationError';
    throw err;
  }
  return { fromDate, toDate };
}

function pointAsOf(s: ReportScope): string {
  return s.toDate ?? isoToday();
}

/** Delete Record Report — `RP_ORDER.cs` with `CurRpt = "Delete Data"`. */
export async function deleteDataReport(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { fromDate, toDate } = deleteDataRange(s);
    const params: unknown[] = [s.tenantId, s.coCode, s.lcCode ?? '', fromDate, toDate];
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY a."DELETE_DATE",a."BOOK_NAME",a."SR_NO")::int AS "srNo",
              a."BOOK_NAME" AS "book",a."VCH_NO" AS "vchNo",a."SR_NO"::float8 AS "lineSrNo",
              a."DELETE_DATE"::text AS "deleteDate",a."VCH_DATE"::text AS "vchDate",
              a."AC_NAME" AS "acName",a."AC_CODE" AS "acCode",
              coalesce(a."VCH_VAL_DR",0)::float8 AS "drAmt",coalesce(a."VCH_VAL_CR",0)::float8 AS "crAmt",
              a."FINE_TYPE" AS "fineType",coalesce(a."VCH_FINE_DR",0)::float8 AS "drFine",
              coalesce(a."VCH_FINE_CR",0)::float8 AS "crFine",a."MAIN_USER" AS "entryUser",
              a."DELETE_USER" AS "deleteUser",a."VCH_DESC" AS "itemRemark"
         FROM "DELETE_DATA" a
         LEFT JOIN "BOOK_DATA" d
           ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."LC_CODE"=a."LC_CODE" AND d."CO_BOOK"=a."CO_BOOK"
        WHERE a.tenant_id=$1
          AND a."CO_CODE"=$2
          AND ($3::text='' OR a."LC_CODE"=$3)
          AND a."DELETE_DATE" >= $4::date
          AND a."DELETE_DATE" <= $5::date
        ORDER BY a."DELETE_DATE",a."BOOK_NAME",a."SR_NO"`,
      ...params,
    );
    return {
      rows: rows.map((r) => ({
        srNo: num(r.srNo),
        book: String(r.book ?? ''),
        vchNo: String(r.vchNo ?? ''),
        lineSrNo: num(r.lineSrNo),
        deleteDate: String(r.deleteDate ?? '').slice(0, 10),
        vchDate: String(r.vchDate ?? '').slice(0, 10),
        acName: String(r.acName ?? ''),
        acCode: String(r.acCode ?? ''),
        drAmt: round2(num(r.drAmt)),
        crAmt: round2(num(r.crAmt)),
        fineType: String(r.fineType ?? ''),
        drFine: round3(num(r.drFine)),
        crFine: round3(num(r.crFine)),
        entryUser: String(r.entryUser ?? ''),
        deleteUser: String(r.deleteUser ?? ''),
        itemRemark: String(r.itemRemark ?? ''),
      })),
    };
  });
}

async function onePointValueTx(tx: any, s: ReportScope): Promise<number> {
  const rows = (await tx.$queryRawUnsafe(
    `SELECT coalesce("POINT_AMT",0)::float8 AS "pointAmt"
       FROM "POINT_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("CUR_IN_USE",'')='Y'
      ORDER BY "POINT_CODE","SR_NO"
      LIMIT 1`,
    s.tenantId,
    s.coCode,
  )) as Array<{ pointAmt?: number }>;
  return num(rows[0]?.pointAmt);
}

/** Member Point Report summary — `RP_ORDER.cs` with `CurRpt = "Point Report"`. */
export async function pointReport(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const toDate = pointAsOf(s);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY b."CARD_NO",b."MEMB_NAME")::int AS "srNo",
              a."MEMB_CODE" AS "memberCode",b."MEMB_NAME" AS "memberName",b."MOBILE_NO" AS "mobileNo",
              b."CARD_NO" AS "cardNo",c."AC_ADD1" AS "address",c."AC_CITY" AS "city",
              sum(CASE WHEN a."ITM_SIGN"='+' THEN coalesce(a."TOT_POINT",0) ELSE 0 END)::float8 AS "totalPoint",
              sum(CASE WHEN a."ITM_SIGN"='-' THEN coalesce(a."TOT_POINT",0) ELSE 0 END)::float8 AS "adjustedPoint",
              sum(CASE WHEN a."ITM_SIGN"='+' THEN coalesce(a."TOT_POINT",0) ELSE -coalesce(a."TOT_POINT",0) END)::float8 AS "balancePoint",
              NULL::date AS "delDate"
         FROM "POINT_DATA" a
         INNER JOIN "POINT_MEMB" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."POINT_CODE"=a."POINT_CODE" AND b."MEMB_CODE"=a."MEMB_CODE"
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE" AND c."AC_CODE"=a."MEMB_CODE"
        WHERE a.tenant_id=$1
          AND a."CO_CODE"=$2
          AND ($3::text='' OR a."LC_CODE"=$3)
          AND a."POINT_CODE"='01'
          AND a."VCH_DATE" <= $4::date
        GROUP BY a."MEMB_CODE",b."MEMB_NAME",b."MOBILE_NO",b."CARD_NO",c."AC_ADD1",c."AC_CITY"
        ORDER BY b."CARD_NO",b."MEMB_NAME"`,
      s.tenantId,
      s.coCode,
      s.lcCode ?? '',
      toDate,
    );
    return {
      rows: rows.map((r) => ({
        srNo: num(r.srNo),
        memberCode: String(r.memberCode ?? ''),
        memberName: String(r.memberName ?? ''),
        mobileNo: String(r.mobileNo ?? ''),
        cardNo: String(r.cardNo ?? ''),
        address: String(r.address ?? ''),
        city: String(r.city ?? ''),
        totalPoint: round2(num(r.totalPoint)),
        adjustedPoint: round2(num(r.adjustedPoint)),
        balancePoint: round2(num(r.balancePoint)),
        delDate: r.delDate ? String(r.delDate).slice(0, 10) : '',
      })),
    };
  });
}

/** Member Point Report detail drill-down — desktop double-click from `PointSumm()`. */
export async function pointReportDetail(
  prisma: any,
  s: ReportScope,
  memberCodeInput: string,
): Promise<ListReport> {
  const memberCode = String(memberCodeInput ?? '').trim();
  if (!memberCode) {
    const err = new Error('memberCode is required');
    err.name = 'ReportValidationError';
    throw err;
  }
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const toDate = pointAsOf(s);
    const onePointValue = await onePointValueTx(tx, s);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY a."VCH_DATE",a."VCH_NO")::int AS "srNo",
              d."BOOK_SNAME" AS "book",a."VCH_NO" AS "vchNo",a."VCH_DATE"::text AS "vchDate",
              b."MEMB_NAME" AS "memberName",a."CO_BOOK" AS "coBook",a."MEMB_CODE" AS "memberCode",
              d."MAIN_BOOK" AS "mainBook",a."POINT_TYPE" AS "pointType",$5::float8 AS "onePointValue",
              sum((CASE WHEN a."ITM_SIGN"='+' THEN coalesce(a."TOT_POINT",0) ELSE -coalesce(a."TOT_POINT",0) END) * $5::numeric)::float8 AS "pointValue",
              sum(CASE WHEN a."ITM_SIGN"='+' THEN coalesce(a."TOT_POINT",0) ELSE 0 END)::float8 AS "totalPoint",
              sum(CASE WHEN a."ITM_SIGN"='-' THEN coalesce(a."TOT_POINT",0) ELSE 0 END)::float8 AS "adjustedPoint",
              sum(CASE WHEN a."ITM_SIGN"='+' THEN coalesce(a."TOT_POINT",0) ELSE -coalesce(a."TOT_POINT",0) END)::float8 AS "balancePoint"
         FROM "POINT_DATA" a
         LEFT JOIN "POINT_MEMB" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."POINT_CODE"=a."POINT_CODE" AND b."MEMB_CODE"=a."MEMB_CODE"
         LEFT JOIN "BOOK_DATA" d
           ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."LC_CODE"=a."LC_CODE" AND d."CO_BOOK"=a."CO_BOOK"
        WHERE a.tenant_id=$1
          AND a."CO_CODE"=$2
          AND ($3::text='' OR a."LC_CODE"=$3)
          AND a."MEMB_CODE"=$4
          AND a."VCH_DATE" <= $6::date
        GROUP BY d."BOOK_SNAME",a."VCH_NO",a."VCH_DATE",b."MEMB_NAME",a."CO_BOOK",a."MEMB_CODE",d."MAIN_BOOK",a."POINT_TYPE"
        ORDER BY a."VCH_DATE",a."VCH_NO"`,
      s.tenantId,
      s.coCode,
      s.lcCode ?? '',
      memberCode,
      onePointValue,
      toDate,
    );
    return {
      rows: rows.map((r) => ({
        srNo: num(r.srNo),
        book: String(r.book ?? ''),
        vchNo: String(r.vchNo ?? ''),
        vchDate: String(r.vchDate ?? '').slice(0, 10),
        memberName: String(r.memberName ?? ''),
        coBook: String(r.coBook ?? ''),
        memberCode: String(r.memberCode ?? ''),
        mainBook: String(r.mainBook ?? ''),
        pointType: String(r.pointType ?? ''),
        onePointValue: round2(num(r.onePointValue)),
        pointValue: round2(num(r.pointValue)),
        totalPoint: round2(num(r.totalPoint)),
        adjustedPoint: round2(num(r.adjustedPoint)),
        balancePoint: round2(num(r.balancePoint)),
      })),
    };
  });
}

export type OrderTrackStatus = 'sales-pending' | 'issue-pending' | 'receive-pending' | 'all';

/**
 * Order Track — desktop `RP_ORD_TRACK.AcSumm`.
 *
 * Lists sales-order lines with customer, karigar issue/receive, generated tag, employee and advance data.
 * The status filter follows the desktop combo exactly:
 * - Sal Panding: `TAG_SALE = N` and `TAG_GEN = Y`
 * - Isu Panding: `DESIGN_ISU = N`
 * - Rec Panding: `TAG_GEN = N` and `DESIGN_ISU = Y`
 * - All: no status predicate
 */
export async function orderTrackReport(
  prisma: any,
  s: ReportScope,
  options: {
    orderNo?: unknown;
    employeeCode?: unknown;
    lcCode?: unknown;
    onlyOrderTagStock?: unknown;
    designNo?: unknown;
    karigarCode?: unknown;
    status?: unknown;
  } = {},
): Promise<ListReport> {
  const fromDate = s.fromDate ?? '2010-01-01';
  const toDate = s.toDate ?? todayIso();
  const status = String(options.status ?? 'sales-pending')
    .trim()
    .toLowerCase() as OrderTrackStatus;
  const lcCode = txt(options.lcCode) ?? s.lcCode ?? '';
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.coCode, fromDate, toDate];
    const where = [
      "a.tenant_id=current_setting('app.tenant_id', true)",
      'a."CO_CODE"=$1',
      'a."VCH_DATE">=$2::date',
      'a."VCH_DATE"<=$3::date',
    ];
    pushText(params, where, 'a."VCH_NO"', options.orderNo);
    pushText(params, where, 'b."EMP_CODE"', options.employeeCode);
    pushText(params, where, 'a."LC_CODE"', lcCode);
    pushText(params, where, 'a."DESIGN_NO"', options.designNo);
    pushText(params, where, 'e."AC_CODE"', options.karigarCode);
    if (flagFrom(options.onlyOrderTagStock, false)) {
      where.push('a."TAG_STK_LESS"=\'Y\'');
      where.push("coalesce(a.\"TAG_NO\",'') <> ''");
    }
    if (status === 'sales-pending') {
      where.push('a."TAG_SALE"=\'N\'');
      where.push('a."TAG_GEN"=\'Y\'');
    } else if (status === 'issue-pending') {
      where.push('a."DESIGN_ISU"=\'N\'');
    } else if (status === 'receive-pending') {
      where.push('a."TAG_GEN"=\'N\'');
      where.push('a."DESIGN_ISU"=\'Y\'');
    }

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ROW_NUMBER() OVER (ORDER BY a."VCH_DATE", a."VCH_NO", a."SR_NO") AS "srNo",
              a."AC_CODE" AS "acCode",
              c."AC_NAME" AS "acName",
              c."AC_MOBILE" AS "acMobile",
              a."VCH_NO" AS "ordNo",
              a."VCH_DATE" AS "ordDate",
              a."ORD_DEL_DATE" AS "delDate",
              d."IT_NAME" AS "itName",
              a."DESIGN_NO" AS "designNo",
              a."ITM_SIZE" AS "size",
              a."ITM_REMARK" AS "remark",
              a."ITM_GWT" AS "gwt",
              a."ITM_PCS" AS "pcs",
              a."DESIGN_ISU" AS "designIsu",
              f."AC_NAME" AS "karigarName",
              e."VCH_DATE" AS "karigarIssueDate",
              a."TAG_GEN" AS "tagGen",
              g."VCH_DATE" AS "karigarReceiveDate",
              g."TAG_NO" AS "tagNo",
              a."TAG_SALE" AS "tagSale",
              g."ITM_GWT" AS "tagGwt",
              g."ITM_NWT" AS "tagNwt",
              e."ORNA_REC_DATE" AS "ornaReceiveDate",
              i."EMP_NAME" AS "employeeName",
              a."NET_AMT" AS "netAmt",
              a."ORD_REC_AMT" AS "ordRecAmt",
              a."ITM_TOUCH" AS "touch",
              a."ITM_FINE" AS "fine",
              a."ITM_COLOR" AS "color",
              b."FUN_DATE" AS "functionDate",
              a."CO_BOOK" AS "coBook",
              a."CO_YEAR" AS "coYear",
              a."SR_NO" AS "lineNo",
              b."ADV_AMT" AS "advAmt",
              b."OLD_GL" AS "oldGold",
              b."OLD_SL" AS "oldSilver"
         FROM "SL_ORD_DETL" a
         LEFT JOIN "SL_ORD_DATA" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."CO_YEAR"=a."CO_YEAR"
          AND b."CO_BOOK"=a."CO_BOOK"
          AND b."VCH_NO"=a."VCH_NO"
         LEFT JOIN "ITEM_MAST" d
           ON d.tenant_id=a.tenant_id
          AND d."CO_CODE"=a."CO_CODE"
          AND d."IT_CODE"::text=a."IT_CODE"::text
         LEFT JOIN "APR_DETL" e
           ON e.tenant_id=a.tenant_id
          AND e."CO_CODE"=a."CO_CODE"
          AND e."ISU_YRCD"=a."CO_YEAR"
          AND e."ISU_DBCD"=a."CO_BOOK"
          AND e."ISU_NO"=a."VCH_NO"
          AND e."ISU_SRNO"=a."SR_NO"
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=a.tenant_id
          AND c."CO_CODE"=a."CO_CODE"
          AND c."AC_CODE"=a."AC_CODE"
         LEFT JOIN "AC_MAST" f
           ON f.tenant_id=e.tenant_id
          AND f."CO_CODE"=e."CO_CODE"
          AND f."AC_CODE"=e."AC_CODE"
         LEFT JOIN "BAR_DETL" g
           ON g.tenant_id=a.tenant_id
          AND g."CO_CODE"=a."CO_CODE"
          AND g."LC_CODE"=a."LC_CODE"
          AND g."ORD_YRCD"=a."CO_YEAR"
          AND g."ORD_DBCD"=a."CO_BOOK"
          AND g."ORD_NO"=a."VCH_NO"
          AND g."ORD_SRNO"=a."OLD_SRNO"
         LEFT JOIN "BOOK_DATA" h
           ON h.tenant_id=a.tenant_id
          AND h."CO_CODE"=a."CO_CODE"
          AND h."LC_CODE"=a."LC_CODE"
          AND h."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN "EMP_MAST" i
           ON i.tenant_id=a.tenant_id
          AND i."CO_CODE"=a."CO_CODE"
          AND i."EMP_CODE"=a."EMP_CODE"
        WHERE ${where.join(' AND ')}
        ORDER BY a."VCH_DATE", a."VCH_NO", a."SR_NO"`,
      ...params,
    );
    const mapped = rows.map((row, index) => ({
      srNo: index + 1,
      acCode: txt(row.acCode),
      acName: txt(row.acName),
      acMobile: txt(row.acMobile),
      ordNo: txt(row.ordNo),
      ordDate: isoDate(row.ordDate),
      delDate: txt(row.delDate),
      itName: txt(row.itName),
      designNo: txt(row.designNo),
      size: txt(row.size),
      remark: txt(row.remark),
      gwt: round3(num(row.gwt)),
      pcs: round3(num(row.pcs)),
      designIsu: txt(row.designIsu),
      karigarName: txt(row.karigarName),
      karigarIssueDate: isoDate(row.karigarIssueDate),
      tagGen: txt(row.tagGen),
      karigarReceiveDate: isoDate(row.karigarReceiveDate),
      tagNo: txt(row.tagNo),
      tagSale: txt(row.tagSale),
      tagGwt: round3(num(row.tagGwt)),
      tagNwt: round3(num(row.tagNwt)),
      ornaReceiveDate: txt(row.ornaReceiveDate),
      employeeName: txt(row.employeeName),
      netAmt: round2(num(row.netAmt)),
      ordRecAmt: round2(num(row.ordRecAmt)),
      touch: round3(num(row.touch)),
      fine: round3(num(row.fine)),
      color: txt(row.color),
      functionDate: txt(row.functionDate),
      coBook: txt(row.coBook),
      coYear: txt(row.coYear),
      lineNo: num(row.lineNo),
      advAmt: round2(num(row.advAmt)),
      oldGold: round3(num(row.oldGold)),
      oldSilver: round3(num(row.oldSilver)),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        gwt: round3(mapped.reduce((sum, row) => sum + row.gwt, 0)),
        netAmt: round2(mapped.reduce((sum, row) => sum + row.netAmt, 0)),
        ordRecAmt: round2(mapped.reduce((sum, row) => sum + row.ordRecAmt, 0)),
      },
    };
  });
}
