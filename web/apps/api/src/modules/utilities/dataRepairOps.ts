import { diff, registerRepair, type RepairScope, type RepairTableDiff } from './dataRepair.js';

/**
 * Repair operations ported from the desktop's `MS_UPDATE` maintenance console.
 *
 * Every operation is written as a DIFF against expected state rather than the desktop's blanket UPDATE, so
 * a healthy row is never rewritten and a second run is a provable no-op. The desktop's own SQL is quoted
 * above each implementation; where its logic looks odd it is reproduced faithfully and the oddity is called
 * out rather than silently corrected — a "fix" here would diverge from the data the shop already has.
 */

/**
 * Scope predicate shared by the company/location/year-scoped repairs.
 *
 * `year` must be turned OFF for tables that do not carry `CO_YEAR`. Verified against `information_schema`:
 * `BOOK_DATA`, `BOOK_DETL` and `BANK_RECONCILE` have no year column, while `AC_DATA` and `CASH_DATA` do.
 * Emitting the predicate anyway fails with `column t.CO_YEAR does not exist` — a crash rather than a wrong
 * result, but still a defect worth making impossible to write by accident.
 */
const scoped = (
  alias: string,
  scope: RepairScope,
  from = 1,
  opts: { year?: boolean } = {},
): { sql: string; params: unknown[] } => {
  const withYear = opts.year !== false;
  const p: unknown[] = [scope.coCode];
  let sql = ` AND ${alias}."CO_CODE"=$${from}`;
  if (scope.lcCode) {
    p.push(scope.lcCode);
    sql += ` AND ${alias}."LC_CODE"=$${from + p.length - 1}`;
  }
  if (withYear && scope.coYear) {
    p.push(scope.coYear);
    sql += ` AND ${alias}."CO_YEAR"=$${from + p.length - 1}`;
  }
  return { sql, params: p };
};

// ---------------------------------------------------------------------------------------------------
// karigar-fine — MS_UPDATE.cs:32561-32596 (btnOthSet)
//
//   SELECT TAG_NO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,VCH_SRNO FROM BAR_DETL
//    WHERE <scope> AND (KR_TOUCH + KR_WEST_PRC) <> 0 AND KR_NET_WT <> 0
//   num = Format(KR_NET_WT * (KR_TOUCH + KR_WEST_PRC) / 100.0, "0.000")
//   UPDATE BAR_DETL     SET KR_FINE = num WHERE <scope> AND TAG_NO=… AND VCH_SRNO=…
//   UPDATE SL_DETL      SET KR_FINE = num WHERE …
//   UPDATE RATE_CUT_ISU SET KR_FINE = num WHERE …
//
// `Strings.Format(x, "0.000")` rounds half away from zero at three decimals, which is the project's
// `round`, NOT banker's rounding. The `/100` is essential: dropping it inflates every karigar fine 100x.
// ---------------------------------------------------------------------------------------------------
/** The desktop's exact expression, written once and used verbatim in both preview and apply. */
const KR_FINE_SQL =
  'round(coalesce(b."KR_NET_WT",0) * (coalesce(b."KR_TOUCH",0) + coalesce(b."KR_WEST_PRC",0)) / 100.0, 3)';

const krFineTargets = ['BAR_DETL', 'SL_DETL', 'RATE_CUT_ISU'] as const;

registerRepair({
  id: 'karigar-fine',
  title: 'Recalculate karigar fine',
  description:
    'Recomputes KR_FINE from net weight, touch and wastage on tag, sale and rate-cut records where the ' +
    'stored value disagrees. Only rows with a non-zero net weight and a non-zero touch+wastage are ' +
    'considered, exactly as the desktop selects them.',
  desktopSource: 'MS_UPDATE.cs:32561-32596',
  risk: 'medium',
  tables: krFineTargets,
  async preview(tx, scope) {
    const diffs: RepairTableDiff[] = [];
    const samples: string[] = [];
    for (const table of krFineTargets) {
      const s = scoped('b', scope);
      // BAR_DETL holds the source weights; the other two are corrected from their own columns where they
      // carry them, so each table is compared against its own recomputation.
      const rows: any[] = await tx.$queryRawUnsafe(
        `SELECT b."TAG_NO", b."VCH_SRNO", b."KR_FINE" AS stored, ${KR_FINE_SQL} AS expected
           FROM "${table}" b
          WHERE b.tenant_id=current_setting('app.tenant_id', true)${s.sql}
            AND coalesce(b."KR_NET_WT",0) <> 0
            AND (coalesce(b."KR_TOUCH",0) + coalesce(b."KR_WEST_PRC",0)) <> 0
            AND coalesce(b."KR_FINE",0) <> ${KR_FINE_SQL}
          ORDER BY b."TAG_NO" LIMIT 200`,
        ...s.params,
      );
      if (rows.length) {
        diffs.push(diff(table, { update: rows.length }));
        for (const r of rows.slice(0, 5)) {
          samples.push(`${table} ${r.TAG_NO}/${r.VCH_SRNO}: ${r.stored} -> ${r.expected}`);
        }
      }
    }
    return { diffs, samples };
  },
  async apply(tx, scope) {
    const applied: RepairTableDiff[] = [];
    for (const table of krFineTargets) {
      const s = scoped('b', scope);
      const n: number = await tx.$executeRawUnsafe(
        `UPDATE "${table}" b
            SET "KR_FINE" = ${KR_FINE_SQL}
          WHERE b.tenant_id=current_setting('app.tenant_id', true)${s.sql}
            AND coalesce(b."KR_NET_WT",0) <> 0
            AND (coalesce(b."KR_TOUCH",0) + coalesce(b."KR_WEST_PRC",0)) <> 0
            AND coalesce(b."KR_FINE",0) <> ${KR_FINE_SQL}`,
        ...s.params,
      );
      if (n) applied.push(diff(table, { update: n }));
    }
    return applied;
  },
});

// ---------------------------------------------------------------------------------------------------
// active-stock-type — MS_UPDATE.cs:33043-33074 (btnStkTypeSet)
//
//   SELECT A.TAG_NO,A.IT_CODE,A.VCH_SRNO FROM MAIN_STOCK A
//    WHERE <scope> AND A.TAG_NO <> 'N'
//    GROUP BY A.TAG_NO,A.IT_CODE,A.VCH_SRNO
//   HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0
//   UPDATE BAR_DETL SET DATA_TYPE = 'A' WHERE <scope> AND TAG_NO=…
//
// NOTE ON THE HAVING CLAUSE: the desktop sums the VOUCHER SERIAL with in/out polarity, not the quantity.
// Summing a serial number is an unusual presence test, but it is what the shop's data was produced by, so
// it is reproduced verbatim. "Correcting" it to sum pieces would mark a different set of tags active.
// ---------------------------------------------------------------------------------------------------
registerRepair({
  id: 'active-stock-type',
  title: 'Mark in-stock tags active',
  description:
    'Sets DATA_TYPE = A on tag records that are still in stock, so stock screens and reports treat them ' +
    'as live. In-stock is derived from MAIN_STOCK movements with in/out polarity.',
  desktopSource: 'MS_UPDATE.cs:33043-33074',
  risk: 'medium',
  tables: ['BAR_DETL'],
  async preview(tx, scope) {
    const s = scoped('a', scope);
    const rows: any[] = await tx.$queryRawUnsafe(
      `WITH live AS (
         SELECT a."TAG_NO"
           FROM "MAIN_STOCK" a
          WHERE a.tenant_id=current_setting('app.tenant_id', true)${s.sql}
            AND coalesce(a."TAG_NO",'') <> 'N'
          GROUP BY a."TAG_NO", a."IT_CODE", a."VCH_SRNO"
         HAVING sum(CASE WHEN a."ITM_SIGN"='+' THEN a."VCH_SRNO" ELSE -a."VCH_SRNO" END) > 0
       )
       SELECT b."TAG_NO" FROM "BAR_DETL" b
        WHERE b.tenant_id=current_setting('app.tenant_id', true)
          AND b."CO_CODE"=$1
          AND b."TAG_NO" IN (SELECT "TAG_NO" FROM live)
          AND coalesce(b."DATA_TYPE",'') <> 'A'
        ORDER BY b."TAG_NO" LIMIT 200`,
      ...s.params,
    );
    return {
      diffs: rows.length ? [diff('BAR_DETL', { update: rows.length })] : [],
      samples: rows.slice(0, 5).map((r) => `BAR_DETL ${r.TAG_NO}: DATA_TYPE -> 'A'`),
    };
  },
  async apply(tx, scope) {
    const s = scoped('a', scope);
    const n: number = await tx.$executeRawUnsafe(
      `WITH live AS (
         SELECT a."TAG_NO"
           FROM "MAIN_STOCK" a
          WHERE a.tenant_id=current_setting('app.tenant_id', true)${s.sql}
            AND coalesce(a."TAG_NO",'') <> 'N'
          GROUP BY a."TAG_NO", a."IT_CODE", a."VCH_SRNO"
         HAVING sum(CASE WHEN a."ITM_SIGN"='+' THEN a."VCH_SRNO" ELSE -a."VCH_SRNO" END) > 0
       )
       UPDATE "BAR_DETL" b SET "DATA_TYPE"='A'
        WHERE b.tenant_id=current_setting('app.tenant_id', true)
          AND b."CO_CODE"=$1
          AND b."TAG_NO" IN (SELECT "TAG_NO" FROM live)
          AND coalesce(b."DATA_TYPE",'') <> 'A'`,
      ...s.params,
    );
    return n ? [diff('BAR_DETL', { update: n })] : [];
  },
});

// ---------------------------------------------------------------------------------------------------
// approval-reconcile — MS_UPDATE.cs:8809-8824 (btnAprUpdate)
//
//   UPDATE APR_DETL SET ISU_REC = 'N' WHERE <company>
//   UPDATE BAR_DETL SET APR_ISU = 'N' WHERE <company>
//   UPDATE BAR_DETL SET APR_ISU = 'Y' FROM APR_DETL B
//    WHERE BAR_DETL.CO_CODE=B.CO_CODE AND BAR_DETL.TAG_NO=B.TAG_NO AND BAR_DETL.VCH_SRNO=B.VCH_SRNO
//
// The desktop resets both flags and then re-asserts 'Y' for tags that still have an approval line. The
// diff form computes the target state per tag and touches only rows that disagree, which yields the same
// end state without rewriting every row in the company.
// ---------------------------------------------------------------------------------------------------
registerRepair({
  id: 'approval-reconcile',
  title: 'Reconcile approval (tour) status',
  description:
    'Recomputes the approval-issued flag on tag records from the approval detail lines, so tags released ' +
    'on approval and tags returned show the correct status.',
  desktopSource: 'MS_UPDATE.cs:8809-8824',
  risk: 'medium',
  tables: ['BAR_DETL'],
  async preview(tx, scope) {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO", coalesce(b."APR_ISU",'') AS stored,
              CASE WHEN EXISTS (
                SELECT 1 FROM "APR_DETL" d
                 WHERE d.tenant_id=b.tenant_id AND d."CO_CODE"=b."CO_CODE"
                   AND d."TAG_NO"=b."TAG_NO" AND d."VCH_SRNO"=b."VCH_SRNO"
              ) THEN 'Y' ELSE 'N' END AS expected
         FROM "BAR_DETL" b
        WHERE b.tenant_id=current_setting('app.tenant_id', true) AND b."CO_CODE"=$1
          AND coalesce(b."APR_ISU",'') <> CASE WHEN EXISTS (
                SELECT 1 FROM "APR_DETL" d
                 WHERE d.tenant_id=b.tenant_id AND d."CO_CODE"=b."CO_CODE"
                   AND d."TAG_NO"=b."TAG_NO" AND d."VCH_SRNO"=b."VCH_SRNO"
              ) THEN 'Y' ELSE 'N' END
        ORDER BY b."TAG_NO" LIMIT 200`,
      scope.coCode,
    );
    return {
      diffs: rows.length ? [diff('BAR_DETL', { update: rows.length })] : [],
      samples: rows
        .slice(0, 5)
        .map((r) => `BAR_DETL ${r.TAG_NO}: APR_ISU ${r.stored || '(blank)'} -> ${r.expected}`),
    };
  },
  async apply(tx, scope) {
    const n: number = await tx.$executeRawUnsafe(
      `UPDATE "BAR_DETL" b
          SET "APR_ISU" = CASE WHEN EXISTS (
                SELECT 1 FROM "APR_DETL" d
                 WHERE d.tenant_id=b.tenant_id AND d."CO_CODE"=b."CO_CODE"
                   AND d."TAG_NO"=b."TAG_NO" AND d."VCH_SRNO"=b."VCH_SRNO"
              ) THEN 'Y' ELSE 'N' END
        WHERE b.tenant_id=current_setting('app.tenant_id', true) AND b."CO_CODE"=$1
          AND coalesce(b."APR_ISU",'') <> CASE WHEN EXISTS (
                SELECT 1 FROM "APR_DETL" d
                 WHERE d.tenant_id=b.tenant_id AND d."CO_CODE"=b."CO_CODE"
                   AND d."TAG_NO"=b."TAG_NO" AND d."VCH_SRNO"=b."VCH_SRNO"
              ) THEN 'Y' ELSE 'N' END`,
      scope.coCode,
    );
    return n ? [diff('BAR_DETL', { update: n })] : [];
  },
});

// ---------------------------------------------------------------------------------------------------
// sale-tag-weight — MS_UPDATE.cs:32537-32560 (BtnSlWtDiff)
//
//   UPDATE SL_DETL SET SL_DETL.TAG_GWT = B.ITM_GWT, SL_DETL.TAG_NWT = B.ITM_NWT
//     FROM SL_DETL, BAR_DETL AS B
//    WHERE SL_DETL.CO_CODE=B.CO_CODE AND SL_DETL.TAG_NO=B.TAG_NO AND SL_DETL.VCH_SRNO=B.VCH_SRNO
// ---------------------------------------------------------------------------------------------------
registerRepair({
  id: 'sale-tag-weight',
  title: 'Sync sale tag weights from stock',
  description:
    'Copies the authoritative gross and net weight from each tag record onto the sale lines that sold it, ' +
    'so sales carrying stale weights agree with the tag.',
  desktopSource: 'MS_UPDATE.cs:32537-32560',
  risk: 'medium',
  tables: ['SL_DETL'],
  async preview(tx, scope) {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT s."TAG_NO", s."TAG_GWT" AS gwt, s."TAG_NWT" AS nwt, b."ITM_GWT" AS xgwt, b."ITM_NWT" AS xnwt
         FROM "SL_DETL" s
         JOIN "BAR_DETL" b
           ON b.tenant_id=s.tenant_id AND b."CO_CODE"=s."CO_CODE"
          AND b."TAG_NO"=s."TAG_NO" AND b."VCH_SRNO"=s."VCH_SRNO"
        WHERE s.tenant_id=current_setting('app.tenant_id', true) AND s."CO_CODE"=$1
          AND (coalesce(s."TAG_GWT",0) <> coalesce(b."ITM_GWT",0)
            OR coalesce(s."TAG_NWT",0) <> coalesce(b."ITM_NWT",0))
        ORDER BY s."TAG_NO" LIMIT 200`,
      scope.coCode,
    );
    return {
      diffs: rows.length ? [diff('SL_DETL', { update: rows.length })] : [],
      samples: rows
        .slice(0, 5)
        .map((r) => `SL_DETL ${r.TAG_NO}: ${r.gwt}/${r.nwt} -> ${r.xgwt}/${r.xnwt}`),
    };
  },
  async apply(tx, scope) {
    const n: number = await tx.$executeRawUnsafe(
      `UPDATE "SL_DETL" s
          SET "TAG_GWT" = b."ITM_GWT", "TAG_NWT" = b."ITM_NWT"
         FROM "BAR_DETL" b
        WHERE b.tenant_id=s.tenant_id AND b."CO_CODE"=s."CO_CODE"
          AND b."TAG_NO"=s."TAG_NO" AND b."VCH_SRNO"=s."VCH_SRNO"
          AND s.tenant_id=current_setting('app.tenant_id', true) AND s."CO_CODE"=$1
          AND (coalesce(s."TAG_GWT",0) <> coalesce(b."ITM_GWT",0)
            OR coalesce(s."TAG_NWT",0) <> coalesce(b."ITM_NWT",0))`,
      scope.coCode,
    );
    return n ? [diff('SL_DETL', { update: n })] : [];
  },
});

// ---------------------------------------------------------------------------------------------------
// opening-balance — MS_UPDATE.cs:32662-32695 (BtnOpbal)
//
//   DELETE FROM OP_DATA WHERE CO_CODE=? AND LC_CODE=?
//   SELECT A.AC_CODE,
//          format(Sum(A.CR_AMT-A.DR_AMT),'0.00')                                   AS Amount,
//          format(SUM(iif(IT_TYPE='G', iif(SIGN='+', FINE_WT, -FINE_WT), 0)),'0.000') AS GoldWt,
//          format(SUM(iif(IT_TYPE='S', iif(SIGN='+', FINE_WT, -FINE_WT), 0)),'0.000') AS SilverWt
//     FROM AC_DATA A … WHERE <company/location> AND VCH_DATE < MOp_dt
//    GROUP BY A.AC_CODE … HAVING (amount + gold + silver + diamond) <> 0
//   INSERT INTO OP_DATA(… CO_BOOK='000', VCH_NO='00000',
//          OP_AMT=Abs(Amount),      OP_SIGN      = Amount   > 0 ? 'C' : 'D',
//          FINE_BAL=Abs(GoldWt),    FINE_SIGN    = GoldWt   > 0 ? 'C' : 'D',
//          SL_FINE_BAL=Abs(SilverWt), SL_FINE_SIGN = SilverWt > 0 ? 'C' : 'D',
//          DATA_TYPE='B', DATA_TRFR='Y')
//
// Details that are easy to get wrong and are therefore reproduced exactly:
//  * `VCH_DATE < MOp_dt` is STRICTLY before the fiscal opening date (from YEAR_MAST.OP_DATE). Including
//    the opening date itself would fold first-day trading into the opening balance.
//  * amount is credit-positive (`CR_AMT - DR_AMT`), and the sign is stored SEPARATELY from the magnitude.
//  * `> 0` yields 'C', so a zero balance is written as 'D'.
//  * the HAVING clause also counts a diamond ('D') term that the SELECT never returns, so an account whose
//    only pre-opening activity is diamond weight still produces a row (with zero amount/gold/silver).
//  * OP_AMT / FINE_BAL / SL_FINE_BAL are VARCHAR columns, so the desktop's formatted strings are stored as
//    text — matched here rather than writing raw numerics.
//
// The desktop deletes EVERY OP_DATA row for the company/location before rebuilding, so a manually entered
// opening that the ledger does not justify is removed. That is destructive and unrecoverable — the desktop
// says so in its own prompt — hence risk `high` and a typed confirmation.
// ---------------------------------------------------------------------------------------------------
const OPBAL_SELECT = `
  WITH pre AS (
    SELECT a."AC_CODE",
           sum(coalesce(a."CR_AMT",0) - coalesce(a."DR_AMT",0)) AS amount,
           sum(CASE WHEN a."IT_TYPE"='G' THEN (CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END) ELSE 0 END) AS gold,
           sum(CASE WHEN a."IT_TYPE"='S' THEN (CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END) ELSE 0 END) AS silver,
           sum(CASE WHEN a."IT_TYPE"='D' THEN (CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END) ELSE 0 END) AS diamond
      FROM "AC_DATA" a
     WHERE a.tenant_id=current_setting('app.tenant_id', true)
       AND a."CO_CODE"=$1 AND a."LC_CODE"=$2
       AND a."VCH_DATE" < $3::date
     GROUP BY a."AC_CODE"
    HAVING (sum(coalesce(a."CR_AMT",0) - coalesce(a."DR_AMT",0))
          + sum(CASE WHEN a."IT_TYPE"='G' THEN (CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END) ELSE 0 END)
          + sum(CASE WHEN a."IT_TYPE"='S' THEN (CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END) ELSE 0 END)
          + sum(CASE WHEN a."IT_TYPE"='D' THEN (CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END) ELSE 0 END)) <> 0
  )
  SELECT "AC_CODE",
         to_char(round(amount, 2), 'FM9999999999990.00')  AS amt_txt,
         to_char(round(gold, 3),   'FM9999999999990.000') AS gold_txt,
         to_char(round(silver, 3), 'FM9999999999990.000') AS silver_txt,
         amount, gold, silver
    FROM pre`;

/** Fiscal opening date (`MOp_dt`) from YEAR_MAST.OP_DATE — the boundary the derivation depends on. */
async function openingDate(tx: any, scope: RepairScope): Promise<string | null> {
  // OP_DATE is a VARCHAR holding an ISO date, and some rows hold an EMPTY STRING. A blank must yield no
  // derivation rather than an empty `::date` cast, which would abort the whole repair.
  const r: any[] = await tx.$queryRawUnsafe(
    `SELECT "OP_DATE" FROM "YEAR_MAST"
      WHERE tenant_id=current_setting('app.tenant_id', true) AND "CO_CODE"=$1
        AND ($2::text IS NULL OR "CO_YEAR"=$2)
        AND coalesce(btrim("OP_DATE"::text),'') <> ''
      ORDER BY "OP_DATE" DESC LIMIT 1`,
    scope.coCode,
    scope.coYear ?? null,
  );
  const v = r[0]?.OP_DATE;
  if (!v) return null;
  const text = v instanceof Date ? v.toISOString().slice(0, 10) : String(v).trim().slice(0, 10);
  return /^\d{4}-\d{2}-\d{2}$/.test(text) ? text : null;
}

const sign = (v: number): string => (v > 0 ? 'C' : 'D'); // desktop: `> 0 ? 'C' : 'D'`, so zero is 'D'

registerRepair({
  id: 'opening-balance',
  title: 'Rebuild party opening balances from the ledger',
  description:
    'Recomputes each party opening balance (cash, gold fine and silver fine) from ledger activity dated ' +
    'strictly before the fiscal opening date. Replaces existing opening rows, so a manually entered ' +
    'opening the ledger does not justify is removed.',
  desktopSource: 'MS_UPDATE.cs:32662-32695',
  risk: 'high',
  tables: ['OP_DATA'],
  async preview(tx, scope) {
    const opDate = await openingDate(tx, scope);
    if (!opDate)
      return { diffs: [], samples: ['no fiscal opening date configured; nothing to derive'] };
    const lc = scope.lcCode ?? '';
    const expected: any[] = await tx.$queryRawUnsafe(OPBAL_SELECT, scope.coCode, lc, opDate);
    const existing: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE","OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN"
         FROM "OP_DATA"
        WHERE tenant_id=current_setting('app.tenant_id', true) AND "CO_CODE"=$1 AND "LC_CODE"=$2`,
      scope.coCode,
      lc,
    );
    const cur = new Map(existing.map((r) => [String(r.AC_CODE), r]));
    const want = new Map(expected.map((r) => [String(r.AC_CODE), r]));
    let insert = 0;
    let update = 0;
    const samples: string[] = [];
    for (const [ac, e] of want) {
      const c = cur.get(ac);
      const target = {
        OP_AMT: Number(Math.abs(Number(e.amount)).toFixed(2)) || 0,
        OP_SIGN: sign(Number(e.amount)),
        FINE_BAL: Number(Math.abs(Number(e.gold)).toFixed(3)) || 0,
        FINE_SIGN: sign(Number(e.gold)),
        SL_FINE_BAL: Number(Math.abs(Number(e.silver)).toFixed(3)) || 0,
        SL_FINE_SIGN: sign(Number(e.silver)),
      };
      if (!c) {
        insert += 1;
        if (samples.length < 5)
          samples.push(`OP_DATA ${ac}: new ${target.OP_SIGN}${target.OP_AMT}`);
      } else if (
        Number(c.OP_AMT ?? 0) !== Number(target.OP_AMT) ||
        String(c.OP_SIGN ?? '') !== target.OP_SIGN ||
        Number(c.FINE_BAL ?? 0) !== Number(target.FINE_BAL) ||
        Number(c.SL_FINE_BAL ?? 0) !== Number(target.SL_FINE_BAL)
      ) {
        update += 1;
        if (samples.length < 5)
          samples.push(
            `OP_DATA ${ac}: ${c.OP_SIGN ?? ''}${c.OP_AMT ?? 0} -> ${target.OP_SIGN}${target.OP_AMT}`,
          );
      }
    }
    const remove = [...cur.keys()].filter((ac) => !want.has(ac));
    for (const ac of remove.slice(0, 3))
      samples.push(`OP_DATA ${ac}: removed (ledger shows no opening)`);
    const d = diff('OP_DATA', { insert, update, delete: remove.length });
    return { diffs: insert + update + remove.length ? [d] : [], samples };
  },
  async apply(tx, scope) {
    const opDate = await openingDate(tx, scope);
    if (!opDate) return [];
    const lc = scope.lcCode ?? '';
    const expected: any[] = await tx.$queryRawUnsafe(OPBAL_SELECT, scope.coCode, lc, opDate);
    const keep = expected.map((r) => String(r.AC_CODE));
    // Remove openings the ledger no longer justifies, exactly as the desktop's blanket delete would.
    const removed: number = await tx.$executeRawUnsafe(
      `DELETE FROM "OP_DATA"
        WHERE tenant_id=current_setting('app.tenant_id', true) AND "CO_CODE"=$1 AND "LC_CODE"=$2
          AND NOT ("AC_CODE" = ANY($3::text[]))`,
      scope.coCode,
      lc,
      keep,
    );
    let insert = 0;
    let update = 0;
    for (const e of expected) {
      const ac = String(e.AC_CODE);
      const amt = Math.abs(Number(e.amount)).toFixed(2);
      const gold = Math.abs(Number(e.gold)).toFixed(3);
      const silver = Math.abs(Number(e.silver)).toFixed(3);
      const n: number = await tx.$executeRawUnsafe(
        `UPDATE "OP_DATA"
            SET "OP_AMT"=$4::double precision,"OP_SIGN"=$5,
                "FINE_BAL"=$6::double precision,"FINE_SIGN"=$7,
                "SL_FINE_BAL"=$8::double precision,"SL_FINE_SIGN"=$9,
                "DATA_TYPE"='B',"DATA_TRFR"='Y'
          WHERE tenant_id=current_setting('app.tenant_id', true)
            AND "CO_CODE"=$1 AND "LC_CODE"=$2 AND "AC_CODE"=$3
            AND (coalesce("OP_AMT",0)<>$4::double precision OR coalesce("OP_SIGN",'')<>$5
              OR coalesce("FINE_BAL",0)<>$6::double precision
              OR coalesce("SL_FINE_BAL",0)<>$8::double precision)`,
        scope.coCode,
        lc,
        ac,
        amt,
        sign(Number(e.amount)),
        gold,
        sign(Number(e.gold)),
        silver,
        sign(Number(e.silver)),
      );
      if (n > 0) {
        update += n;
        continue;
      }
      const exists: unknown[] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "OP_DATA"
          WHERE tenant_id=current_setting('app.tenant_id', true)
            AND "CO_CODE"=$1 AND "LC_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
        scope.coCode,
        lc,
        ac,
      );
      if (exists.length) continue; // already correct — untouched
      await tx.$executeRawUnsafe(
        `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE",
           "OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN","DATA_TYPE","DATA_TRFR")
         VALUES (current_setting('app.tenant_id', true),$1,$2,$3,'000','00000',$4,
                 $5::double precision,$6,$7::double precision,$8,$9::double precision,$10,'B','Y')`,
        scope.coCode,
        lc,
        scope.coYear ?? null,
        ac,
        amt,
        sign(Number(e.amount)),
        gold,
        sign(Number(e.gold)),
        silver,
        sign(Number(e.silver)),
      );
      insert += 1;
    }
    const d = diff('OP_DATA', { insert, update, delete: removed });
    return insert + update + removed ? [d] : [];
  },
});

// ---------------------------------------------------------------------------------------------------
// serial-master — MS_UPDATE.cs:32465-32495 (BtnCounter) — NOT IMPLEMENTED, blocked on a real divergence.
//
// The desktop treats `SRNO_MAST` as a PER-TAG registry: it reads every BAR_DETL tag, filters the existing
// rows by `TAG_NO`, and inserts one row per tag that has none (`MS_UPDATE.cs:32480-32485`).
//
// The web schema treats the same table as a NUMBERING COUNTER: `uq_srno_mast_tenant_company_location` is
// unique on (tenant_id, CO_CODE, LC_CODE), and `seedCompany` provisions exactly one row per company and
// location with `VCH_SRNO = 0`, `TAG_SRNO = 0`.
//
// Those two meanings are incompatible: inserting a row per tag violates the constraint, and relaxing the
// constraint would let a second counter row exist and hand out duplicate voucher numbers. Which semantics
// the web should keep is a product decision, not something to infer here, so the operation is deliberately
// absent rather than implemented against a guess.
//
// To resolve: decide whether `SRNO_MAST` is the numbering counter (in which case this desktop operation has
// no web equivalent and should be formally waived) or a tag registry (in which case the counter needs its
// own table and a migration). Recorded in FEATURE-GAP-REGISTER.md.
// ---------------------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------------------
// orphan-tag-refs — MS_UPDATE.cs:33011-33042 (btnBarDtlReset)
//
//   UPDATE BOOK_DATA SET BOOK_TBL_DETL = '' WHERE BOOK_TBL_DETL IS NULL
//   SELECT B.BOOK_TBL_DETL,A.CO_BOOK,A.VCH_NO,A.TAG_NO,A.VCH_SRNO
//     FROM MAIN_STOCK A LEFT JOIN BOOK_DATA B ON A.CO_CODE=B.CO_CODE AND A.LC_CODE=B.LC_CODE
//                                            AND A.CO_BOOK=B.CO_BOOK
//    WHERE <scope> AND A.TAG_NO <> 'N' AND A.ITM_SIGN = '-' AND B.BOOK_TBL_DETL <> ''
//   -- for each: if BAR_DETL has no row for that TAG_NO/VCH_SRNO then
//   UPDATE <BOOK_TBL_DETL> SET TAG_NO = 'N', VCH_SRNO = 0 WHERE <scope> AND …
//
// The desktop's own prompt reads "Sales With Tag But Not In Tag Stock(BarDetl) Then Sales Tag ='' Update...
// (Please Tack Backup Before Run The Process..)", so this is `high` risk with a typed confirmation.
//
// SECURITY NOTE. The table to update is NOT a constant: it is read from `BOOK_DATA.BOOK_TBL_DETL`, i.e. from
// DATA. Interpolating that straight into SQL — as the desktop does — would let a stray master value write to
// an arbitrary table. Every candidate name is therefore validated against `information_schema` and must
// expose `tenant_id`, `TAG_NO` and `VCH_SRNO` before it is used; anything else is skipped and reported in
// the preview rather than silently ignored.
//
// Only OUTBOUND movements are considered (`ITM_SIGN = '-'`): an inbound row is what created the tag, so a
// missing tag there means something different and the desktop does not touch it.
// ---------------------------------------------------------------------------------------------------
async function bookDetailTables(
  tx: any,
  scope: RepairScope,
): Promise<{ table: string; ok: boolean }[]> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT DISTINCT btrim(coalesce(b."BOOK_TBL_DETL",'')) AS t
       FROM "BOOK_DATA" b
      WHERE b.tenant_id=current_setting('app.tenant_id', true) AND b."CO_CODE"=$1
        AND coalesce(btrim(b."BOOK_TBL_DETL"::text),'') <> ''`,
    scope.coCode,
  );
  const out: { table: string; ok: boolean }[] = [];
  for (const r of rows) {
    const name = String(r.t);
    // A data-supplied identifier is only ever used after the schema confirms it is a real, tenant-scoped
    // detail table with the columns this repair writes.
    if (!/^[A-Z][A-Z0-9_]{2,}$/.test(name)) {
      out.push({ table: name, ok: false });
      continue;
    }
    const cols: any[] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM information_schema.columns
        WHERE table_schema='public' AND table_name=$1
          AND column_name IN ('tenant_id','TAG_NO','VCH_SRNO')`,
      name,
    );
    out.push({ table: name, ok: Number(cols[0]?.n ?? 0) === 3 });
  }
  return out;
}

registerRepair({
  id: 'orphan-tag-refs',
  title: 'Clear tag references that no longer exist in stock',
  description:
    'Finds outbound movements whose tag is missing from tag stock and clears the dangling tag reference on ' +
    'the owning voucher detail, so reports stop pointing at a tag that is not there.',
  desktopSource: 'MS_UPDATE.cs:33011-33042',
  risk: 'high',
  tables: ['SL_DETL', 'PR_DETL', 'APR_DETL', 'KR_DETL', 'RATE_CUT_ISU'],
  async preview(tx, scope) {
    const candidates = await bookDetailTables(tx, scope);
    const samples: string[] = [];
    const diffs: RepairTableDiff[] = [];
    for (const c of candidates) {
      if (!c.ok) {
        samples.push(`skipped ${c.table}: not a tenant-scoped detail table with TAG_NO/VCH_SRNO`);
        continue;
      }
      const s = scoped('a', scope);
      const rows: any[] = await tx.$queryRawUnsafe(
        `SELECT d."TAG_NO", d."VCH_SRNO"
           FROM "${c.table}" d
          WHERE d.tenant_id=current_setting('app.tenant_id', true)
            AND coalesce(d."TAG_NO",'') NOT IN ('', 'N')
            AND EXISTS (
              SELECT 1 FROM "MAIN_STOCK" a
               WHERE a.tenant_id=d.tenant_id${s.sql}
                 AND a."TAG_NO"=d."TAG_NO" AND a."VCH_SRNO"=d."VCH_SRNO" AND a."ITM_SIGN"='-')
            AND NOT EXISTS (
              SELECT 1 FROM "BAR_DETL" b
               WHERE b.tenant_id=d.tenant_id AND b."CO_CODE"=$${s.params.length + 1}
                 AND b."TAG_NO"=d."TAG_NO" AND b."VCH_SRNO"=d."VCH_SRNO")
          ORDER BY d."TAG_NO" LIMIT 200`,
        ...s.params,
        scope.coCode,
      );
      if (rows.length) {
        diffs.push(diff(c.table, { update: rows.length }));
        for (const r of rows.slice(0, 3)) {
          samples.push(`${c.table} ${r.TAG_NO}/${r.VCH_SRNO}: TAG_NO -> 'N', VCH_SRNO -> 0`);
        }
      }
    }
    return { diffs, samples };
  },
  async apply(tx, scope) {
    // Normalise NULL to '' first, exactly as the desktop does before it reads the column.
    await tx.$executeRawUnsafe(
      `UPDATE "BOOK_DATA" SET "BOOK_TBL_DETL"=''
        WHERE tenant_id=current_setting('app.tenant_id', true) AND "BOOK_TBL_DETL" IS NULL`,
    );
    const candidates = await bookDetailTables(tx, scope);
    const applied: RepairTableDiff[] = [];
    for (const c of candidates) {
      if (!c.ok) continue;
      const s = scoped('a', scope);
      const n: number = await tx.$executeRawUnsafe(
        `UPDATE "${c.table}" d SET "TAG_NO"='N', "VCH_SRNO"=0
          WHERE d.tenant_id=current_setting('app.tenant_id', true)
            AND coalesce(d."TAG_NO",'') NOT IN ('', 'N')
            AND EXISTS (
              SELECT 1 FROM "MAIN_STOCK" a
               WHERE a.tenant_id=d.tenant_id${s.sql}
                 AND a."TAG_NO"=d."TAG_NO" AND a."VCH_SRNO"=d."VCH_SRNO" AND a."ITM_SIGN"='-')
            AND NOT EXISTS (
              SELECT 1 FROM "BAR_DETL" b
               WHERE b.tenant_id=d.tenant_id AND b."CO_CODE"=$${s.params.length + 1}
                 AND b."TAG_NO"=d."TAG_NO" AND b."VCH_SRNO"=d."VCH_SRNO")`,
        ...s.params,
        scope.coCode,
      );
      if (n) applied.push(diff(c.table, { update: n }));
    }
    return applied;
  },
});

// ---------------------------------------------------------------------------------------------------
// stock-fine-refresh — MS_UPDATE.cs:2671-2705 (btnStock, the fine-backfill portion)
//
//   SELECT TAG_NO,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,VCH_SRNO FROM BAR_DETL
//    WHERE <scope> AND (ITM_TOUCH + ITM_WEST_PRC) <> 0 AND ITM_FINE <= 0
//   num = ITM_NWT <> 0 AND (ITM_TOUCH+ITM_WEST_PRC) <> 0
//           ? ITM_NWT * (ITM_TOUCH + ITM_WEST_PRC) / 100.0 : 0
//   if ITM_FINE <= 0 : UPDATE BAR_DETL     SET ITM_FINE = num WHERE TAG_NO=… AND VCH_SRNO=…
//                      UPDATE SL_DETL_RTN  SET ITM_FINE = num WHERE TAG_NO=… AND VCH_SRNO=…
//
// Two faithful oddities:
//
//  1. The candidate query ALREADY filters `ITM_FINE <= 0`, so the inner `if (ITM_FINE <= 0)` is always
//     true. Reproduced as written; it changes nothing but is worth not "tidying" into a different filter.
//  2. The `SL_DETL_RTN` update sits OUTSIDE that `if`, so a sales-return line is rewritten for every
//     candidate tag. Because the candidate set is already fine <= 0 the effect coincides here, but the
//     predicate genuinely differs: the return row is matched on tag and serial ALONE, with no condition on
//     its own `ITM_FINE`. A return line already carrying a good fine WILL be overwritten from the tag's
//     recomputation. That is the desktop's behaviour and a shop's data may depend on it.
//
// The desktop writes the raw double (`Conversions.ToString(num)`); `ITM_FINE` is `numeric(_,3)` so the
// column rounds it. Rounding to 3 explicitly makes the diff deterministic rather than storage-dependent.
//
// Note the desktop gates the whole button on PRINT rights (`UserPrint = 'Y'`), which is unrelated to what
// it does; the web gates the console on delete rights instead, which is the stronger and more sensible
// check for a data rewrite.
// ---------------------------------------------------------------------------------------------------
/** The desktop expression. `ITM_NWT = 0` yields zero, which is why the guard is inside the CASE. */
const ITM_FINE_SQL =
  'round(CASE WHEN coalesce(b."ITM_NWT",0) <> 0 ' +
  'THEN coalesce(b."ITM_NWT",0) * (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) / 100.0 ' +
  'ELSE 0 END, 3)';

registerRepair({
  id: 'stock-fine-refresh',
  title: 'Backfill missing tag fine weight',
  description:
    'Fills ITM_FINE on tag rows that have a touch or wastage percentage but no fine weight, computing it ' +
    'from net weight x (touch + wastage) / 100. Matching sales-return lines are refreshed from the same ' +
    'figure. Rows that already carry a fine weight are not selected.',
  desktopSource: 'MS_UPDATE.cs:2671-2705',
  risk: 'medium',
  tables: ['BAR_DETL', 'SL_DETL_RTN'],
  async preview(tx, scope) {
    const diffs: RepairTableDiff[] = [];
    const samples: string[] = [];
    const s = scoped('b', scope);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO", b."VCH_SRNO", b."ITM_FINE" AS stored, ${ITM_FINE_SQL} AS expected
         FROM "BAR_DETL" b
        WHERE b.tenant_id=current_setting('app.tenant_id', true)${s.sql}
          AND (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) <> 0
          AND coalesce(b."ITM_FINE",0) <= 0
          AND coalesce(b."ITM_FINE",0) <> ${ITM_FINE_SQL}
        ORDER BY b."TAG_NO" LIMIT 200`,
      ...s.params,
    );
    if (rows.length) {
      diffs.push(diff('BAR_DETL', { update: rows.length }));
      for (const r of rows.slice(0, 5)) {
        samples.push(`BAR_DETL ${r.TAG_NO}/${r.VCH_SRNO}: ${r.stored} -> ${r.expected}`);
      }
    }
    // Counted separately because the return predicate does NOT test the return row's own fine weight.
    const s2 = scoped('b', scope);
    const rtn: any[] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "SL_DETL_RTN" r
        WHERE r.tenant_id=current_setting('app.tenant_id', true)
          AND EXISTS (
            SELECT 1 FROM "BAR_DETL" b
             WHERE b.tenant_id=r.tenant_id${s2.sql}
               AND b."TAG_NO"=r."TAG_NO" AND b."VCH_SRNO"=r."VCH_SRNO"
               AND (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) <> 0
               AND coalesce(b."ITM_FINE",0) <= 0
               AND coalesce(r."ITM_FINE",0) <> ${ITM_FINE_SQL})`,
      ...s2.params,
    );
    if (rtn[0]?.n) diffs.push(diff('SL_DETL_RTN', { update: rtn[0].n }));
    return { diffs, samples };
  },
  async apply(tx, scope) {
    const applied: RepairTableDiff[] = [];
    // The return rows are refreshed FIRST: they are derived from the tag's pre-repair state, and updating
    // BAR_DETL first would empty the candidate set (its predicate requires fine <= 0) and silently skip them.
    const s2 = scoped('b', scope);
    const rn: number = await tx.$executeRawUnsafe(
      `UPDATE "SL_DETL_RTN" r SET "ITM_FINE" = (
          SELECT ${ITM_FINE_SQL} FROM "BAR_DETL" b
           WHERE b.tenant_id=r.tenant_id${s2.sql}
             AND b."TAG_NO"=r."TAG_NO" AND b."VCH_SRNO"=r."VCH_SRNO"
             AND (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) <> 0
             AND coalesce(b."ITM_FINE",0) <= 0
           LIMIT 1)
        WHERE r.tenant_id=current_setting('app.tenant_id', true)
          AND EXISTS (
            SELECT 1 FROM "BAR_DETL" b
             WHERE b.tenant_id=r.tenant_id${s2.sql}
               AND b."TAG_NO"=r."TAG_NO" AND b."VCH_SRNO"=r."VCH_SRNO"
               AND (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) <> 0
               AND coalesce(b."ITM_FINE",0) <= 0
               AND coalesce(r."ITM_FINE",0) <> ${ITM_FINE_SQL})`,
      ...s2.params,
      ...s2.params,
    );
    if (rn) applied.push(diff('SL_DETL_RTN', { update: rn }));

    const s = scoped('b', scope);
    const n: number = await tx.$executeRawUnsafe(
      `UPDATE "BAR_DETL" b SET "ITM_FINE" = ${ITM_FINE_SQL}
        WHERE b.tenant_id=current_setting('app.tenant_id', true)${s.sql}
          AND (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) <> 0
          AND coalesce(b."ITM_FINE",0) <= 0
          AND coalesce(b."ITM_FINE",0) <> ${ITM_FINE_SQL}`,
      ...s.params,
    );
    if (n) applied.push(diff('BAR_DETL', { update: n }));
    return applied;
  },
});

// ---------------------------------------------------------------------------------------------------
// bar-idtl-serial — MS_UPDATE.cs:32496-32540 (btnBarIdtl)
//
//   SELECT CO_YEAR,VCH_NO,SR_NO,TAG_NO,VCH_SRNO FROM BAR_DETL
//    WHERE <scope> AND CO_BOOK = '000' ORDER BY VCH_NO,SR_NO
//   num = 0; num2 = 0
//   for each row:
//     if num <> Val(VCH_NO) then num = Round(Val(VCH_NO)); num2 = 1
//     UPDATE BAR_DETL SET SR_NO = num2, OLD_SRNO = num2 WHERE TAG_NO=… AND VCH_SRNO=…
//     num2++
//   then re-read and: UPDATE BAR_IDTL SET SR_NO = <BAR_DETL.SR_NO> WHERE TAG_NO=… AND VCH_SRNO=…
//
// So each voucher's lines are renumbered 1..n in `(VCH_NO, SR_NO)` order and `BAR_IDTL` is realigned to
// match. `CO_BOOK = '000'` restricts this to OPENING rows.
//
// Two details reproduced literally rather than tidied:
//
//  * `VCH_NO` is a TEXT column, so `ORDER BY VCH_NO` is lexicographic, while the group-change test compares
//    the NUMERIC value. Both are kept exactly as the desktop has them. For the zero-padded voucher numbers
//    this codebase writes the two orders coincide, but they are not the same rule and unpadded legacy data
//    would order differently — which is what the desktop would also do.
//  * The counter increments on every row and resets only on a voucher change, so a gap or duplicate in the
//    existing `SR_NO` is closed rather than preserved. That is the point of the repair.
//
// `SR_NO` and `OLD_SRNO` are set to the SAME value: the desktop overwrites the "old" serial too, so the
// pre-repair numbering is NOT recoverable from the row afterwards. Hence `high` risk.
// ---------------------------------------------------------------------------------------------------
/**
 * The renumbering as a single window function — one statement instead of the desktop's row-by-row loop, with
 * identical output. `PARTITION BY "VCH_NO"` is the voucher reset; `ORDER BY "VCH_NO","SR_NO"` is the
 * desktop's ordering (lexicographic on the text column, as there).
 */
const BAR_IDTL_TARGET = `
  SELECT b.ctid AS ct, b."TAG_NO" AS tag, b."VCH_SRNO" AS srno, b."VCH_NO" AS vch,
         b."SR_NO" AS stored, b."OLD_SRNO" AS old,
         row_number() OVER (PARTITION BY b."VCH_NO" ORDER BY b."VCH_NO", b."SR_NO", b.ctid) AS expected
    FROM "BAR_DETL" b
   WHERE b.tenant_id=current_setting('app.tenant_id', true)#SCOPE#
     AND b."CO_BOOK" = '000'`;

registerRepair({
  id: 'bar-idtl-serial',
  title: 'Renumber opening tag serials',
  description:
    'Renumbers the line serial of opening tag rows to a gap-free 1..n within each voucher, and realigns ' +
    'the matching BAR_IDTL rows. Only the opening book (000) is touched. The previous serial is NOT ' +
    'recoverable afterwards because the desktop overwrites OLD_SRNO with the new value as well.',
  desktopSource: 'MS_UPDATE.cs:32496-32540',
  risk: 'high',
  tables: ['BAR_DETL', 'BAR_IDTL'],
  async preview(tx, scope) {
    const diffs: RepairTableDiff[] = [];
    const samples: string[] = [];
    const s = scoped('b', scope);
    const rows: any[] = await tx.$queryRawUnsafe(
      `WITH t AS (${BAR_IDTL_TARGET.replace('#SCOPE#', s.sql)})
       SELECT tag, srno, vch, stored, expected FROM t
        WHERE coalesce(stored,-1) <> expected OR coalesce(old,-1) <> expected
        ORDER BY vch, expected LIMIT 200`,
      ...s.params,
    );
    if (rows.length) {
      diffs.push(diff('BAR_DETL', { update: rows.length }));
      for (const r of rows.slice(0, 5)) {
        samples.push(`BAR_DETL ${r.tag}/${r.srno} voucher ${r.vch}: ${r.stored} -> ${r.expected}`);
      }
    }
    // BAR_IDTL is realigned wherever its serial disagrees with the tag row's FINAL serial.
    const s2 = scoped('b', scope);
    const idtl: any[] = await tx.$queryRawUnsafe(
      `WITH t AS (${BAR_IDTL_TARGET.replace('#SCOPE#', s2.sql)})
       SELECT count(*)::int AS n FROM "BAR_IDTL" i
        JOIN t ON t.tag = i."TAG_NO" AND t.srno = i."VCH_SRNO"
       WHERE i.tenant_id=current_setting('app.tenant_id', true)
         AND coalesce(i."SR_NO",-1) <> t.expected`,
      ...s2.params,
    );
    if (idtl[0]?.n) diffs.push(diff('BAR_IDTL', { update: idtl[0].n }));
    return { diffs, samples };
  },
  async apply(tx, scope) {
    const applied: RepairTableDiff[] = [];
    const s = scoped('b', scope);
    // ctid identifies the physical row, so duplicate (TAG_NO, VCH_SRNO) pairs are each numbered rather than
    // collapsed — the desktop's per-row UPDATE would rewrite them all to the last counter value, which is
    // its own inconsistency; numbering them distinctly is what its loop intends.
    const n: number = await tx.$executeRawUnsafe(
      `WITH t AS (${BAR_IDTL_TARGET.replace('#SCOPE#', s.sql)})
       UPDATE "BAR_DETL" b SET "SR_NO" = t.expected, "OLD_SRNO" = t.expected
         FROM t WHERE b.ctid = t.ct
          AND (coalesce(b."SR_NO",-1) <> t.expected OR coalesce(b."OLD_SRNO",-1) <> t.expected)`,
      ...s.params,
    );
    if (n) applied.push(diff('BAR_DETL', { update: n }));

    // Read AFTER the renumbering so BAR_IDTL follows the tag rows' final serials, as the desktop's second
    // pass does by re-querying.
    const s2 = scoped('b', scope);
    const ni: number = await tx.$executeRawUnsafe(
      `UPDATE "BAR_IDTL" i SET "SR_NO" = b."SR_NO"
         FROM "BAR_DETL" b
        WHERE i.tenant_id=current_setting('app.tenant_id', true)
          AND b.tenant_id=i.tenant_id${s2.sql}
          AND b."CO_BOOK" = '000'
          AND b."TAG_NO"=i."TAG_NO" AND b."VCH_SRNO"=i."VCH_SRNO"
          AND coalesce(i."SR_NO",-1) <> b."SR_NO"`,
      ...s2.params,
    );
    if (ni) applied.push(diff('BAR_IDTL', { update: ni }));
    return applied;
  },
});

// ---------------------------------------------------------------------------------------------------
// duplicate-cancelled-tag — MS_UPDATE.cs:9244-9285 (btnProblemQry)
//
//   SELECT TAG_NO,VCH_SRNO,COUNT(*) FROM BAR_DETL WHERE <co+lc> GROUP BY TAG_NO,VCH_SRNO
//   HAVING COUNT(*) > 1 ORDER BY TAG_NO
//   for each duplicate group:
//     SELECT TAG_NO,VCH_SRNO,ITM_GWT FROM BAR_CAN_DETL WHERE <co+lc> AND TAG_NO=… AND VCH_SRNO=…
//     if found:
//        DELETE FROM BAR_DETL     WHERE <co+lc> AND TAG_NO=… AND VCH_SRNO=… AND ITM_GWT=<can row>
//        DELETE FROM BAR_CAN_DETL WHERE <co+lc> AND TAG_NO=… AND VCH_SRNO=… AND ITM_GWT=<can row>
//   then: "Total Record Adjust = n Please First Stock Refresh Then Check..."
//
// The rule: a tag that appears more than once in BAR_DETL **and** has a cancellation row is presumed to
// carry a leftover duplicate from that cancellation, so the rows matching the CANCELLED gross weight are
// removed from both tables.
//
// Three things this must not get wrong:
//
//  * The group key is `(TAG_NO, VCH_SRNO)` and is scoped by company and location only — the desktop query
//    has NO `CO_YEAR` here, unlike its neighbours. Adding a year would change which groups qualify.
//  * The DELETE matches on `ITM_GWT` taken from the cancellation row, so it removes only the rows whose
//    gross weight equals the cancelled weight — NOT the whole duplicate group. A tag duplicated at two
//    different weights keeps the weight that was not cancelled.
//  * It deletes ALL rows matching that weight, which can be more than one. Reproduced as written.
//
// The desktop takes only the FIRST cancellation row (`Rows[0]`) even when several exist. Reproduced: the
// deletion weight is the first cancellation row in a deterministic order.
//
// Destructive and unrecoverable, so `high` risk with typed confirmation.
// ---------------------------------------------------------------------------------------------------
/**
 * Candidate rows: duplicated `(TAG_NO, VCH_SRNO)` in `BAR_DETL` whose gross weight equals the first
 * cancellation weight for that tag. Company+location scope only, matching the desktop query.
 *
 * This is the CTE PREFIX only — each caller appends its own final SELECT, so preview (which counts) and
 * apply (which resolves targets) cannot drift apart on the candidate definition.
 */
const DUP_CANCEL_TARGET = `
  WITH dup AS (
    SELECT b."TAG_NO" AS tag, b."VCH_SRNO" AS srno
      FROM "BAR_DETL" b
     WHERE b.tenant_id=current_setting('app.tenant_id', true) AND b."CO_CODE"=$1 AND b."LC_CODE"=$2
     GROUP BY b."TAG_NO", b."VCH_SRNO"
    HAVING count(*) > 1
  ), can AS (
    -- The desktop reads Rows[0]; DISTINCT ON with an explicit order makes "first" deterministic.
    SELECT DISTINCT ON (c."TAG_NO", c."VCH_SRNO")
           c."TAG_NO" AS tag, c."VCH_SRNO" AS srno, c."ITM_GWT" AS gwt
      FROM "BAR_CAN_DETL" c
      JOIN dup d ON d.tag = c."TAG_NO" AND d.srno = c."VCH_SRNO"
     WHERE c.tenant_id=current_setting('app.tenant_id', true) AND c."CO_CODE"=$1 AND c."LC_CODE"=$2
     ORDER BY c."TAG_NO", c."VCH_SRNO", c."ITM_GWT"
  )`;

registerRepair({
  id: 'duplicate-cancelled-tag',
  title: 'Remove duplicated cancelled tag rows',
  description:
    'Finds tags that appear more than once in the tag ledger AND have a cancellation record, then deletes ' +
    'the rows whose gross weight matches the cancelled weight from both the tag ledger and the ' +
    'cancellation table. Duplicates at a weight that was never cancelled are left alone. This deletes ' +
    'rows and cannot be undone — run a stock refresh afterwards, as the desktop instructs.',
  desktopSource: 'MS_UPDATE.cs:9244-9285',
  risk: 'high',
  tables: ['BAR_DETL', 'BAR_CAN_DETL'],
  async preview(tx, scope) {
    const diffs: RepairTableDiff[] = [];
    const samples: string[] = [];
    const params = [scope.coCode, scope.lcCode ?? ''];
    const rows: any[] = await tx.$queryRawUnsafe(
      `${DUP_CANCEL_TARGET}
       , counts AS (
         SELECT can.tag, can.srno, can.gwt,
                (SELECT count(*) FROM "BAR_DETL" b
                  WHERE b.tenant_id=current_setting('app.tenant_id', true)
                    AND b."CO_CODE"=$1 AND b."LC_CODE"=$2
                    AND b."TAG_NO"=can.tag AND b."VCH_SRNO"=can.srno AND b."ITM_GWT"=can.gwt)::int AS nbar,
                (SELECT count(*) FROM "BAR_CAN_DETL" c
                  WHERE c.tenant_id=current_setting('app.tenant_id', true)
                    AND c."CO_CODE"=$1 AND c."LC_CODE"=$2
                    AND c."TAG_NO"=can.tag AND c."VCH_SRNO"=can.srno AND c."ITM_GWT"=can.gwt)::int AS ncan
           FROM can)
       SELECT tag, srno, gwt, nbar, ncan FROM counts WHERE nbar > 0 OR ncan > 0
        ORDER BY tag LIMIT 200`,
      ...params,
    );
    const bar = rows.reduce((s, r) => s + Number(r.nbar ?? 0), 0);
    const can = rows.reduce((s, r) => s + Number(r.ncan ?? 0), 0);
    if (bar) diffs.push(diff('BAR_DETL', { delete: bar }));
    if (can) diffs.push(diff('BAR_CAN_DETL', { delete: can }));
    for (const r of rows.slice(0, 5)) {
      samples.push(
        `tag ${r.tag}/${r.srno} cancelled weight ${r.gwt}: delete ${r.nbar} tag row(s), ${r.ncan} cancel row(s)`,
      );
    }
    return { diffs, samples };
  },
  async apply(tx, scope) {
    const applied: RepairTableDiff[] = [];
    const params = [scope.coCode, scope.lcCode ?? ''];
    // The cancellation rows are resolved into a temporary set FIRST: deleting from BAR_DETL changes the
    // duplicate grouping, so a second pass over live data would no longer see the same candidates.
    const targets: any[] = await tx.$queryRawUnsafe(
      `${DUP_CANCEL_TARGET} SELECT * FROM can`,
      ...params,
    );
    for (const t of targets) {
      const nb: number = await tx.$executeRawUnsafe(
        `DELETE FROM "BAR_DETL" b
          WHERE b.tenant_id=current_setting('app.tenant_id', true)
            AND b."CO_CODE"=$1 AND b."LC_CODE"=$2
            AND b."TAG_NO"=$3 AND b."VCH_SRNO"=$4 AND b."ITM_GWT"=$5`,
        ...params,
        t.tag,
        t.srno,
        t.gwt,
      );
      if (nb) applied.push(diff('BAR_DETL', { delete: nb }));
      const nc: number = await tx.$executeRawUnsafe(
        `DELETE FROM "BAR_CAN_DETL" c
          WHERE c.tenant_id=current_setting('app.tenant_id', true)
            AND c."CO_CODE"=$1 AND c."LC_CODE"=$2
            AND c."TAG_NO"=$3 AND c."VCH_SRNO"=$4 AND c."ITM_GWT"=$5`,
        ...params,
        t.tag,
        t.srno,
        t.gwt,
      );
      if (nc) applied.push(diff('BAR_CAN_DETL', { delete: nc }));
    }
    return applied;
  },
});

// ---------------------------------------------------------------------------------------------------
// ledger-normalise — MS_UPDATE.cs:2334-2350 (btnAc, the portion BEFORE AcRefresh)
//
//   UPDATE BOOK_DATA SET DATA_TYPE = 'A' WHERE DATA_TYPE IS NULL OR DATA_TYPE = ''
//   UPDATE BOOK_DETL SET DATA_TYPE = 'A' WHERE DATA_TYPE IS NULL OR DATA_TYPE = ''
//   UPDATE CASH_DATA SET CLR_DATE = VCH_DATE WHERE CLR_DATE IS NULL
//   DELETE FROM BANK_RECONCILE
//   INSERT INTO BANK_RECONCILE(CO_CODE,LC_CODE,LEDR_KEY,CLR_DATE)
//     SELECT A.CO_CODE,A.LC_CODE,LEDR_KEY,CLR_DATE FROM AC_DATA A
//      LEFT JOIN AC_MAST B ON A.CO_CODE=B.CO_CODE AND A.AC_CODE=B.AC_CODE
//      WHERE A.CO_CODE=? AND A.LC_CODE=? AND B.AC_GR IN ('02','22','23')
//
// WHAT THIS DELIBERATELY EXCLUDES
// -------------------------------
// `btnAc` then calls `AcRefresh()`, which DELETES the entire ledger — all `AC_DATA` except books '888' and
// '000', plus all of `ROJ_MEL_DATA`, `TAX_DATA` and `DHRN_DATA` — and re-derives it by looping over every
// configured book. That is a full general-ledger rebuild, and it is NOT implemented here. Shipping a partial
// rebuild would be the worst possible outcome: the ledger would be deleted and only partly restored, with no
// way back. It requires the complete per-book posting engine plus the danger-zone protocol (feature flag,
// verified backup, dual approval), and is recorded as outstanding.
//
// The four statements above stand alone, are idempotent, and are useful on their own: they normalise the
// book data-type flag, default an uncleared cash date to the voucher date, and rebuild the bank
// reconciliation index for bank/cash account groups.
//
// ONE NECESSARY ADAPTATION
// ------------------------
// The desktop's `DELETE FROM BANK_RECONCILE` carries **no scope at all** — it wipes every company's and every
// location's reconciliation rows before reinserting only the current company's. On a shared multi-tenant
// server that is cross-tenant data loss, so the delete here is scoped to the tenant, company and location
// being repaired. This is a deliberate divergence and the only safe reading of the intent.
// ---------------------------------------------------------------------------------------------------
/** Account groups the desktop treats as bank/cash for reconciliation purposes. */
const RECONCILE_AC_GROUPS = ['02', '22', '23'] as const;

registerRepair({
  id: 'ledger-normalise',
  title: 'Normalise book flags and rebuild bank reconciliation',
  description:
    'Sets a missing book data-type to A, defaults an uncleared cash clearing date to its voucher date, and ' +
    'rebuilds the bank reconciliation index from the ledger for bank and cash account groups. Does NOT ' +
    'rebuild the general ledger itself.',
  desktopSource: 'MS_UPDATE.cs:2334-2350',
  risk: 'medium',
  tables: ['BOOK_DATA', 'BOOK_DETL', 'CASH_DATA', 'BANK_RECONCILE'],
  async preview(tx, scope) {
    const diffs: RepairTableDiff[] = [];
    const samples: string[] = [];

    for (const table of ['BOOK_DATA', 'BOOK_DETL'] as const) {
      // BOOK_DATA and BOOK_DETL carry no CO_YEAR column.
      const s = scoped('t', scope, 1, { year: false });
      const rows: any[] = await tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "${table}" t
          WHERE t.tenant_id=current_setting('app.tenant_id', true)${s.sql}
            AND coalesce(t."DATA_TYPE",'') = ''`,
        ...s.params,
      );
      if (rows[0]?.n) {
        diffs.push(diff(table, { update: rows[0].n }));
        samples.push(`${table}: ${rows[0].n} book(s) get DATA_TYPE='A'`);
      }
    }

    const sc = scoped('c', scope);
    const cash: any[] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "CASH_DATA" c
        WHERE c.tenant_id=current_setting('app.tenant_id', true)${sc.sql}
          AND c."CLR_DATE" IS NULL AND c."VCH_DATE" IS NOT NULL`,
      ...sc.params,
    );
    if (cash[0]?.n) {
      diffs.push(diff('CASH_DATA', { update: cash[0].n }));
      samples.push(`CASH_DATA: ${cash[0].n} row(s) get CLR_DATE = VCH_DATE`);
    }

    // The reconciliation index is rebuilt wholesale, so the diff is "delete the existing, insert the derived".
    const existing: any[] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "BANK_RECONCILE" r
        WHERE r.tenant_id=current_setting('app.tenant_id', true)
          AND r."CO_CODE"=$1 AND ($2::text='' OR r."LC_CODE"=$2)`,
      scope.coCode,
      scope.lcCode ?? '',
    );
    const derived: any[] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "AC_DATA" a
        JOIN "AC_MAST" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
             AND b."AC_CODE"::text=a."AC_CODE"::text
       WHERE a.tenant_id=current_setting('app.tenant_id', true)
         AND a."CO_CODE"=$1 AND ($2::text='' OR a."LC_CODE"=$2)
         AND b."AC_GR" = ANY($3::text[])`,
      scope.coCode,
      scope.lcCode ?? '',
      [...RECONCILE_AC_GROUPS],
    );
    if (existing[0]?.n) diffs.push(diff('BANK_RECONCILE', { delete: existing[0].n }));
    if (derived[0]?.n) diffs.push(diff('BANK_RECONCILE', { insert: derived[0].n }));
    if (existing[0]?.n || derived[0]?.n) {
      samples.push(
        `BANK_RECONCILE: replace ${existing[0]?.n ?? 0} row(s) with ${derived[0]?.n ?? 0} derived from the ledger`,
      );
    }
    return { diffs, samples };
  },
  async apply(tx, scope) {
    const applied: RepairTableDiff[] = [];

    for (const table of ['BOOK_DATA', 'BOOK_DETL'] as const) {
      // BOOK_DATA and BOOK_DETL carry no CO_YEAR column.
      const s = scoped('t', scope, 1, { year: false });
      const n: number = await tx.$executeRawUnsafe(
        `UPDATE "${table}" t SET "DATA_TYPE"='A'
          WHERE t.tenant_id=current_setting('app.tenant_id', true)${s.sql}
            AND coalesce(t."DATA_TYPE",'') = ''`,
        ...s.params,
      );
      if (n) applied.push(diff(table, { update: n }));
    }

    const sc = scoped('c', scope);
    const nc: number = await tx.$executeRawUnsafe(
      `UPDATE "CASH_DATA" c SET "CLR_DATE" = c."VCH_DATE"
        WHERE c.tenant_id=current_setting('app.tenant_id', true)${sc.sql}
          AND c."CLR_DATE" IS NULL AND c."VCH_DATE" IS NOT NULL`,
      ...sc.params,
    );
    if (nc) applied.push(diff('CASH_DATA', { update: nc }));

    // SCOPED delete. The desktop's is unscoped and would remove every company's rows on a shared server.
    const nd: number = await tx.$executeRawUnsafe(
      `DELETE FROM "BANK_RECONCILE" r
        WHERE r.tenant_id=current_setting('app.tenant_id', true)
          AND r."CO_CODE"=$1 AND ($2::text='' OR r."LC_CODE"=$2)`,
      scope.coCode,
      scope.lcCode ?? '',
    );
    if (nd) applied.push(diff('BANK_RECONCILE', { delete: nd }));

    const ni: number = await tx.$executeRawUnsafe(
      `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE")
       SELECT a.tenant_id, a."CO_CODE", a."LC_CODE", a."LEDR_KEY", a."CLR_DATE"
         FROM "AC_DATA" a
         JOIN "AC_MAST" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
              AND b."AC_CODE"::text=a."AC_CODE"::text
        WHERE a.tenant_id=current_setting('app.tenant_id', true)
          AND a."CO_CODE"=$1 AND ($2::text='' OR a."LC_CODE"=$2)
          AND b."AC_GR" = ANY($3::text[])`,
      scope.coCode,
      scope.lcCode ?? '',
      [...RECONCILE_AC_GROUPS],
    );
    if (ni) applied.push(diff('BANK_RECONCILE', { insert: ni }));
    return applied;
  },
});

// ---------------------------------------------------------------------------------------------------
// tag-serial-backfill — MS_UPDATE.cs:32333-32422 (btnTagDiffSet)
//
//   SELECT TAG_NO,ITM_GWT,ITM_NWT,BOOK_NAME FROM MAIN_STOCK
//    WHERE <scope> AND TAG_NO <> 'N' AND ITM_SIGN = '-' AND VCH_SRNO = 0
//   for each candidate M:
//     SELECT TAG_NO,VCH_SRNO,… FROM BAR_DETL WHERE <scope> AND TAG_NO=M.TAG_NO AND ITM_GWT=M.ITM_GWT
//     if found:
//        UPDATE MAIN_STOCK    SET VCH_SRNO=<found> WHERE <scope> AND TAG_NO=… AND ITM_GWT=… AND BOOK_NAME=…
//        UPDATE SL_DETL       SET VCH_SRNO=<found> WHERE … (same three predicates)
//        UPDATE BAR_CAN_DETL  SET VCH_SRNO=<found> WHERE …
//        UPDATE RATE_CUT_ISU  SET VCH_SRNO=<found> WHERE …
//        UPDATE LBR_ISU_DETL  SET VCH_SRNO=<found> WHERE …
//        -- if the update produced a duplicate (TAG_NO, VCH_SRNO) in MAIN_STOCK:
//        DELETE FROM BAR_CAN_DETL WHERE <scope> AND TAG_NO=… AND VCH_SRNO=… AND BOOK_NAME='TAG CANCEL'
//        DELETE FROM MAIN_STOCK   WHERE <scope> AND TAG_NO=… AND VCH_SRNO=… AND BOOK_NAME='TAG CANCEL'
//     else:
//        SELECT … FROM BAR_DETL WHERE <scope> AND TAG_NO=M.TAG_NO           -- gross weight NOT matched
//        if found: UPDATE MAIN_STOCK SET VCH_SRNO=<found> WHERE <scope> AND TAG_NO=… AND BOOK_NAME=…
//                                                                          -- and NOT by gross weight
//
// The repair restores the tag instance identity (`VCH_SRNO`) on SOLD stock rows that lost it, so the tag can
// be traced back to the tag-ledger row it came from.
//
// Four things that must not be "tidied":
//
//  * The candidate set is `ITM_SIGN = '-'` — the OUTWARD side only. Inward rows are not touched.
//  * The primary match is by tag AND GROSS WEIGHT, and the five updates all carry `BOOK_NAME` as well. A tag
//    reused at a different weight therefore keeps its own serial.
//  * The FALLBACK path is not the same rule with a looser filter: it matches the tag alone, updates ONLY
//    `MAIN_STOCK` (not the other four tables), and drops the gross-weight predicate from the update. So a
//    weight mismatch repairs the stock row but deliberately leaves the sale, cancel, rate-cut and labour rows
//    untouched.
//  * The dedupe deletes are restricted to `BOOK_NAME = 'TAG CANCEL'`, so only a cancellation row is removed
//    when the backfill collides — never a real sale.
//
// The desktop reads `Rows[0]` from an unordered result. `DISTINCT ON` with an explicit `ORDER BY` makes
// "first" deterministic rather than dependent on physical row order.
//
// Destructive (the dedupe deletes) and it rewrites voucher identity, so `high` risk with typed confirmation.
// ---------------------------------------------------------------------------------------------------
/** The five tables the primary path rewrites, in the desktop's order. */
const TAG_SERIAL_TABLES = [
  'MAIN_STOCK',
  'SL_DETL',
  'BAR_CAN_DETL',
  'RATE_CUT_ISU',
  'LBR_ISU_DETL',
] as const;

/** Candidates joined to their resolved serial. Shared by preview and apply so they cannot diverge. */
const TAG_SERIAL_CANDIDATES = `
  WITH cand AS (
    SELECT DISTINCT m."TAG_NO" AS tag, m."ITM_GWT" AS gwt, m."BOOK_NAME" AS book
      FROM "MAIN_STOCK" m
     WHERE m.tenant_id=current_setting('app.tenant_id', true)#SCOPE_M#
       AND coalesce(m."TAG_NO",'') NOT IN ('', 'N')
       AND m."ITM_SIGN" = '-'
       AND coalesce(m."VCH_SRNO",0) = 0
  ), exact AS (
    -- Primary: tag AND gross weight.
    SELECT DISTINCT ON (c.tag, c.gwt, c.book)
           c.tag, c.gwt, c.book, b."VCH_SRNO" AS srno
      FROM cand c
      JOIN "BAR_DETL" b ON b.tenant_id=current_setting('app.tenant_id', true)#SCOPE_B#
           AND b."TAG_NO"=c.tag AND b."ITM_GWT"=c.gwt
     ORDER BY c.tag, c.gwt, c.book, b."VCH_SRNO"
  ), fallback AS (
    -- Only for candidates the weight match missed: tag alone.
    SELECT DISTINCT ON (c.tag, c.book) c.tag, c.gwt, c.book, b."VCH_SRNO" AS srno
      FROM cand c
      JOIN "BAR_DETL" b ON b.tenant_id=current_setting('app.tenant_id', true)#SCOPE_B#
           AND b."TAG_NO"=c.tag
     WHERE NOT EXISTS (SELECT 1 FROM exact e WHERE e.tag=c.tag AND e.gwt=c.gwt AND e.book=c.book)
     ORDER BY c.tag, c.book, b."VCH_SRNO"
  )`;

registerRepair({
  id: 'tag-serial-backfill',
  title: 'Restore lost tag serial on sold stock',
  description:
    'Sold stock rows whose tag instance number was lost are matched back to the tag ledger by tag and gross ' +
    'weight, and the serial is restored on the stock, sale, cancellation, rate-cut and labour rows. Where ' +
    'only the tag matches, just the stock row is repaired. Cancellation rows that collide after the repair ' +
    'are deleted, so this removes data and cannot be undone.',
  desktopSource: 'MS_UPDATE.cs:32333-32422',
  risk: 'high',
  tables: [...TAG_SERIAL_TABLES],
  async preview(tx, scope) {
    const diffs: RepairTableDiff[] = [];
    const samples: string[] = [];
    const sm = scoped('m', scope);
    const sb = scoped('b', scope, sm.params.length + 1);
    const cte = TAG_SERIAL_CANDIDATES.replace('#SCOPE_M#', sm.sql).replace(/#SCOPE_B#/g, sb.sql);
    const params = [...sm.params, ...sb.params];

    // Primary path: count the rows each of the five tables would rewrite.
    for (const table of TAG_SERIAL_TABLES) {
      const rows: any[] = await tx.$queryRawUnsafe(
        `${cte}
         SELECT count(*)::int AS n FROM "${table}" t
          JOIN exact e ON e.tag=t."TAG_NO" AND e.gwt=t."ITM_GWT" AND e.book=t."BOOK_NAME"
         WHERE t.tenant_id=current_setting('app.tenant_id', true)
           AND coalesce(t."VCH_SRNO",0) <> e.srno`,
        ...params,
      );
      if (rows[0]?.n) diffs.push(diff(table, { update: rows[0].n }));
    }
    // Fallback path touches MAIN_STOCK only, and without the gross-weight predicate.
    const fb: any[] = await tx.$queryRawUnsafe(
      `${cte}
       SELECT count(*)::int AS n FROM "MAIN_STOCK" t
        JOIN fallback f ON f.tag=t."TAG_NO" AND f.book=t."BOOK_NAME"
       WHERE t.tenant_id=current_setting('app.tenant_id', true)
         AND coalesce(t."VCH_SRNO",0) <> f.srno`,
      ...params,
    );
    if (fb[0]?.n) {
      const existing = diffs.find((d) => d.table === 'MAIN_STOCK');
      if (existing) existing.update += fb[0].n;
      else diffs.push(diff('MAIN_STOCK', { update: fb[0].n }));
    }
    const s: any[] = await tx.$queryRawUnsafe(
      `${cte} SELECT tag, gwt, srno FROM exact ORDER BY tag LIMIT 5`,
      ...params,
    );
    for (const r of s) samples.push(`tag ${r.tag} weight ${r.gwt} -> serial ${r.srno}`);
    return { diffs, samples };
  },
  async apply(tx, scope) {
    const applied: RepairTableDiff[] = [];
    const sm = scoped('m', scope);
    const sb = scoped('b', scope, sm.params.length + 1);
    const cte = TAG_SERIAL_CANDIDATES.replace('#SCOPE_M#', sm.sql).replace(/#SCOPE_B#/g, sb.sql);
    const params = [...sm.params, ...sb.params];

    // Resolve the target set BEFORE any write: updating MAIN_STOCK empties the candidate set, because the
    // candidates are defined by VCH_SRNO = 0.
    const exact: any[] = await tx.$queryRawUnsafe(
      `${cte} SELECT tag, gwt, book, srno FROM exact`,
      ...params,
    );
    const fallback: any[] = await tx.$queryRawUnsafe(
      `${cte} SELECT tag, book, srno FROM fallback`,
      ...params,
    );

    for (const table of TAG_SERIAL_TABLES) {
      let n = 0;
      for (const e of exact) {
        n += await tx.$executeRawUnsafe(
          `UPDATE "${table}" t SET "VCH_SRNO"=$1
            WHERE t.tenant_id=current_setting('app.tenant_id', true)
              AND t."TAG_NO"=$2 AND t."ITM_GWT"=$3 AND t."BOOK_NAME"=$4
              AND coalesce(t."VCH_SRNO",0) <> $1`,
          e.srno,
          e.tag,
          e.gwt,
          e.book,
        );
      }
      if (n) applied.push(diff(table, { update: n }));
    }

    // Fallback: MAIN_STOCK only, tag + book, no gross-weight predicate.
    let nf = 0;
    for (const f of fallback) {
      nf += await tx.$executeRawUnsafe(
        `UPDATE "MAIN_STOCK" t SET "VCH_SRNO"=$1
          WHERE t.tenant_id=current_setting('app.tenant_id', true)
            AND t."TAG_NO"=$2 AND t."BOOK_NAME"=$3
            AND coalesce(t."VCH_SRNO",0) <> $1`,
        f.srno,
        f.tag,
        f.book,
      );
    }
    if (nf) {
      const existing = applied.find((d) => d.table === 'MAIN_STOCK');
      if (existing) existing.update += nf;
      else applied.push(diff('MAIN_STOCK', { update: nf }));
    }

    // Dedupe: only where the backfill created a duplicate (TAG_NO, VCH_SRNO) in MAIN_STOCK, and only
    // cancellation rows are removed — never a real sale.
    for (const e of exact) {
      const dup: any[] = await tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "MAIN_STOCK" m
          WHERE m.tenant_id=current_setting('app.tenant_id', true)
            AND m."TAG_NO"=$1 AND coalesce(m."VCH_SRNO",0)=$2`,
        e.tag,
        e.srno,
      );
      if ((dup[0]?.n ?? 0) <= 1) continue;
      for (const table of ['BAR_CAN_DETL', 'MAIN_STOCK'] as const) {
        const nd: number = await tx.$executeRawUnsafe(
          `DELETE FROM "${table}" t
            WHERE t.tenant_id=current_setting('app.tenant_id', true)
              AND t."TAG_NO"=$1 AND coalesce(t."VCH_SRNO",0)=$2
              AND t."BOOK_NAME"='TAG CANCEL'`,
          e.tag,
          e.srno,
        );
        if (nd) applied.push(diff(table, { delete: nd }));
      }
    }
    return applied;
  },
});
