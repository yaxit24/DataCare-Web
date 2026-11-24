import type { ApprovalMode } from './approvalLayouts.js';
import { APPROVAL_BOOK_FAMILIES, APPROVAL_RESOLVED_STATUSES } from './approvalLayouts.js';
import type { SqlQuery } from './salesQuery.js';

/**
 * Read-only SQL for the Approval Rpt branch of RP_ALL (caption "Approval Rpt", RP_ALL.cs:6707-6711).
 *
 * The desktop interpolates every selector into a Crystal record-selection string
 * (RP_ALL.cs:8152, 8156-8192); that weakness is not ported. Here the fragments are constants chosen by the
 * mode table and every request value is bound as `$n`. The record set mirrors the three Apr*.rpt templates:
 * APR_DETL left-outer joined to ITEM_MAST by CO_CODE+IT_CODE, BOOK_DATA by CO_CODE+LC_CODE+CO_BOOK and
 * AC_MAST by CO_CODE+AC_CODE (AprPartyWise.xml:12, AprInOut.xml:12, AprPan.xml:12). Each master is looked
 * up once with LATERAL ... LIMIT 1, so a duplicate master cannot amplify a line count. The names printed in
 * the bands are the LIVE master names (AprPartyWise.xml:571 AC_MAST.AC_NAME and :608 BOOK_DATA.BOOK_NAME),
 * never the APR_DETL snapshot columns. Tenant isolation comes from forced RLS plus an explicit tenant_id.
 */

export interface ApprovalScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

export interface NormalizedApprovalFilters {
  coBook?: string;
  acCode?: string;
  prCode?: string;
  grCode?: string;
  city?: string;
  area?: string;
  itemType?: string;
}

export interface ApprovalQueryArgs {
  mode: ApprovalMode;
  scope: ApprovalScope;
  fromDate: string;
  toDate: string;
  filters: NormalizedApprovalFilters;
  /** Session DATA_TYPE setting A or B; any other value appends nothing (RP_ALL.cs:8186-8192). */
  dataType?: string;
}

const NUM = (expr: string): string => `COALESCE(${expr}, 0)::float8`;

export function buildApprovalQuery(args: ApprovalQueryArgs): SqlQuery {
  const values: unknown[] = [];
  const bind = (value: unknown): string => {
    values.push(value);
    return `$${values.length}`;
  };

  const tenant = bind(args.scope.tenantId);
  const coCode = bind(args.scope.coCode);
  const from = bind(args.fromDate);
  const to = bind(args.toDate);

  const where: string[] = [
    `a.tenant_id=${tenant}`,
    `a."CO_CODE"::text=${coCode}`,
    `a."VCH_DATE" >= ${from}::date`, // RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}}
    `a."VCH_DATE" <= ${to}::date`, // RP_ALL.cs:8227 {{AND {APR_DETL.VCH_DATE} <= #}}
  ];

  // tLcCode starts as the session location and is locked outside head office (RP_ALL.cs:6660-6671).
  if (args.scope.lcCode) where.push(`a."LC_CODE"::text=${bind(args.scope.lcCode)}`);
  // D4: the one-database web keeps the session-year scope that the desktop gets from its per-year database.
  if (args.scope.coYear) where.push(`a."CO_YEAR"::text=${bind(args.scope.coYear)}`);

  // Every approval button requires APR ISU (RP_ALL.cs:8153, 8228, 8303); the provisioned legacy family is
  // accepted as an explicit, recorded compatibility (D6), not as a desktop rule.
  const families = APPROVAL_BOOK_FAMILIES.map((f) => bind(f));
  where.push(`bk."MAIN_BOOK"::text IN (${families.join(', ')})`);

  // Pending selects exact N (RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}); a null is not N.
  if (args.mode === 'pending') where.push(`a."ISU_REC"=${bind('N')}`);

  // RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}} and :8192 (B).
  // The setting is bound, never interpolated from a client SQL fragment (D3). The column is selected only
  // when the predicate is appended, so a blank/other setting produces no DATA_TYPE reference at all.
  const hasDataType = args.dataType === 'A' || args.dataType === 'B';
  if (hasDataType) where.push(`bk."DATA_TYPE" = ${bind(args.dataType)}`);
  const bookColumns = hasDataType
    ? `b0."BOOK_NAME", b0."DATA_TYPE", b0."MAIN_BOOK"`
    : `b0."BOOK_NAME", b0."MAIN_BOOK"`;

  const f = args.filters;
  if (f.coBook) where.push(`a."CO_BOOK"::text=${bind(f.coBook)}`); // RP_ALL.cs:8160
  if (f.acCode) where.push(`a."AC_CODE"::text=${bind(f.acCode)}`); // RP_ALL.cs:8164
  // The desktop's Pr Code control filters ITEM_MAST.PR_CODE, not APR_DETL.IT_CODE (RP_ALL.cs:8168).
  if (f.prCode) where.push(`i."PR_CODE"::text=${bind(f.prCode)}`);
  if (f.grCode) where.push(`i."GR_CODE"::text=${bind(f.grCode)}`); // RP_ALL.cs:8184
  if (f.city) where.push(`m."AC_CITY"::text=${bind(f.city)}`); // RP_ALL.cs:8172
  if (f.area) where.push(`m."AC_AREA"::text=${bind(f.area)}`); // RP_ALL.cs:8176
  if (f.itemType) where.push(`i."IT_TYPE"::text=${bind(f.itemType)}`); // RP_ALL.cs:8180 (first character)

  // InOut: InPcs is ITM_PCS when ISU_REC='Y', PanPcs = OutPcs − InPcs (AprInOut.xml:293, 300, 304).
  // Legacy R is also resolved (D6). The two CASE expressions share one bound array.
  const resolved = bind([...APPROVAL_RESOLVED_STATUSES]);
  const inPcs = `CASE WHEN a."ISU_REC"::text=ANY(${resolved}::text[]) THEN ${NUM('a."ITM_PCS"')} ELSE 0 END`;

  const text = `SELECT concat(a."CO_YEAR", a."CO_BOOK", a."VCH_NO") AS "vchGroup",
       to_char(a."VCH_DATE", 'YYYY-MM-DD') AS "vchDate",
       a."CO_YEAR" AS "coYear", a."CO_BOOK" AS "coBook", a."VCH_NO" AS "vchNo",
       a."AC_CODE" AS "acCode", m."AC_NAME" AS "acName", bk."BOOK_NAME" AS "bookName",
       i."PR_CODE" AS "prCode", pm."PR_NAME" AS "productName",
       a."IT_CODE" AS "itemCode", i."IT_NAME" AS "itemName",
       a."DESIGN_NO" AS "designNo", a."TAG_NO" AS "tagNo", a."SR_NO"::float8 AS "srNo",
       ${NUM('a."ITM_PCS"')} AS "pcs", ${NUM('a."ITM_GWT"')} AS "grossWt",
       ${NUM('a."ITM_NWT"')} AS "netWt", ${NUM('a."OTH_AMT"')} AS "otherAmount",
       ${NUM('a."ITM_AMT"')} AS "itemAmount", ${NUM('a."LBR_AMT"')} AS "labourAmount",
       ${NUM('a."NET_AMT"')} AS "netAmount",
       ${NUM('a."ITM_PCS"')} AS "outPcs", ${inPcs} AS "inPcs",
       ${NUM('a."ITM_PCS"')} - ${inPcs} AS "pendingPcs", a."ISU_REC" AS "status"
  FROM "APR_DETL" a
  JOIN LATERAL (
    SELECT ${bookColumns} FROM "BOOK_DATA" b0
     WHERE b0.tenant_id=a.tenant_id AND b0."CO_CODE"::text=a."CO_CODE"::text
       AND b0."LC_CODE"::text=a."LC_CODE"::text AND b0."CO_BOOK"::text=a."CO_BOOK"::text
     ORDER BY b0.row_id LIMIT 1
  ) bk ON true
  LEFT JOIN LATERAL (
    SELECT m0."AC_NAME", m0."AC_CITY", m0."AC_AREA" FROM "AC_MAST" m0
     WHERE m0.tenant_id=a.tenant_id AND m0."CO_CODE"::text=a."CO_CODE"::text
       AND m0."AC_CODE"::text=a."AC_CODE"::text
     ORDER BY m0.row_id LIMIT 1
  ) m ON true
  LEFT JOIN LATERAL (
    SELECT i0."IT_NAME", i0."PR_CODE", i0."GR_CODE", i0."IT_TYPE" FROM "ITEM_MAST" i0
     WHERE i0.tenant_id=a.tenant_id AND i0."CO_CODE"::text=a."CO_CODE"::text
       AND i0."IT_CODE"::text=a."IT_CODE"::text
     ORDER BY i0."IT_CODE" LIMIT 1
  ) i ON true
  LEFT JOIN LATERAL (
    SELECT p0."PR_NAME" FROM "PRODUCT_MAST" p0
     WHERE p0.tenant_id=a.tenant_id AND p0."CO_CODE"::text=a."CO_CODE"::text
       AND p0."PR_CODE"::text=i."PR_CODE"::text
     ORDER BY p0.row_id LIMIT 1
  ) pm ON true
 WHERE ${where.join(' AND ')}
 ORDER BY a."AC_CODE", a."CO_YEAR", a."CO_BOOK", a."VCH_NO", i."PR_CODE", a."VCH_DATE", a."TAG_NO", a."SR_NO"`;

  return { text, values };
}
