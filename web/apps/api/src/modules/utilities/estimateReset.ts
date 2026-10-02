import { withTxBudget } from '../shared/txBudget.js';

export const ESTIMATE_RESET_KIND = 'datacare.ut-import-estimate-reset/1.0' as const;
export const ESTIMATE_RESET_CONFIRMATION = 'RESET ESTIMATE' as const;
export const STOCK_ADJUST_BOOK = '163' as const;

export interface EstimateResetScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

export interface EstimateResetDiff {
  table: string;
  insert: number;
  update: number;
  delete: number;
}

export interface EstimateResetPreview {
  kind: typeof ESTIMATE_RESET_KIND;
  generatedAt: string;
  asOfDate: string;
  scope: Required<EstimateResetScope>;
  companyType: string;
  desktopSource: string[];
  diffs: EstimateResetDiff[];
  samples: string[];
  totals: {
    insert: number;
    update: number;
    delete: number;
    selectedVouchers: number;
    stockAdjustmentDetails: number;
  };
  requiresConfirmation: typeof ESTIMATE_RESET_CONFIRMATION;
  postApplyMessage: string;
  registrationSpecificBranches: string[];
}

export interface EstimateResetApplied extends EstimateResetPreview {
  applied: true;
}

export class EstimateResetValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'EstimateResetValidationError';
  }
}

const DESKTOP_SOURCE = [
  'UT_IMPORT.cs:6415-6432 btnReSet_Click',
  'UT_IMPORT.cs:6709-6816 Sale_Reset',
  'UT_IMPORT.cs:6633-6707 TagCancel_Reset',
  'UT_IMPORT.cs:6531-6631 WhSales_Reset',
  'UT_IMPORT.cs:6434-6469 AprTag_Delete_NotIn_Stock',
];

const REGISTRATION_BRANCHES = [
  'SSRegSrNo=HM208NEPK permits DATA_TRFR=Y estimates even when BILL_OS is not zero; web keeps the shared BILL_OS=0 rule until registration identity is modelled.',
  'SSRegSrNo=VS026NSVS optionally deletes zero-balance ledger accounts after a second desktop confirmation; web does not run that installation-specific cleanup from the generic reset.',
];

const POST_APPLY_MESSAGE = 'Process complete. Run Data Refresh after this process.';

const requiredScope = (scope: EstimateResetScope): Required<EstimateResetScope> => {
  const tenantId = String(scope.tenantId ?? '').trim();
  const coCode = String(scope.coCode ?? '').trim();
  const lcCode = String(scope.lcCode ?? '').trim();
  const coYear = String(scope.coYear ?? '').trim();
  if (!tenantId) throw new EstimateResetValidationError('tenant is required');
  if (!coCode) throw new EstimateResetValidationError('company is required');
  if (!lcCode) throw new EstimateResetValidationError('location is required');
  if (!coYear) throw new EstimateResetValidationError('financial year is required');
  return { tenantId, coCode, lcCode, coYear };
};

const dateOnly = (input?: unknown): string => {
  if (input === undefined || input === null || input === '')
    return new Date().toISOString().slice(0, 10);
  const text = String(input).trim();
  if (!/^\d{4}-\d{2}-\d{2}$/.test(text)) {
    throw new EstimateResetValidationError('asOfDate must be an ISO date (YYYY-MM-DD)');
  }
  const date = new Date(`${text}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== text) {
    throw new EstimateResetValidationError('asOfDate is not a valid date');
  }
  return text;
};

const params = (
  scope: Required<EstimateResetScope>,
  asOfDate: string,
): [string, string, string, string, string] => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  asOfDate,
];

async function ensureCompanyAllowsResetTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<string> {
  const rows = (await tx.$queryRawUnsafe(
    `SELECT coalesce("CO_TYPE", '') AS co_type
       FROM "CO_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
    scope.tenantId,
    scope.coCode,
  )) as Array<{ co_type: string | null }>;
  if (!rows.length) throw new EstimateResetValidationError(`company ${scope.coCode} was not found`);
  const companyType = String(rows[0]?.co_type ?? '').trim();
  if (companyType !== '') {
    throw new EstimateResetValidationError(
      'Estimate Reset is available only when company type is blank, matching desktop MCo_Type="" behavior',
    );
  }
  return companyType;
}

async function prepareCandidateTablesTx(
  tx: any,
  scope: Required<EstimateResetScope>,
  asOfDate: string,
): Promise<void> {
  await tx.$executeRawUnsafe('DROP TABLE IF EXISTS pg_temp.estimate_reset_sale_keys');
  await tx.$executeRawUnsafe('DROP TABLE IF EXISTS pg_temp.estimate_reset_tag_keys');
  await tx.$executeRawUnsafe('DROP TABLE IF EXISTS pg_temp.estimate_reset_wh_keys');
  await tx.$executeRawUnsafe('DROP TABLE IF EXISTS pg_temp.estimate_reset_source_tags');
  await tx.$executeRawUnsafe('DROP TABLE IF EXISTS pg_temp.estimate_reset_adjust_rows');
  await tx.$executeRawUnsafe('DROP TABLE IF EXISTS pg_temp.estimate_reset_apr_headers');

  await tx.$executeRawUnsafe(
    `CREATE TEMP TABLE estimate_reset_sale_keys(
       co_year text NOT NULL,
       co_book text NOT NULL,
       vch_no text NOT NULL,
       PRIMARY KEY (co_year, co_book, vch_no)
     ) ON COMMIT DROP`,
  );
  await tx.$executeRawUnsafe(
    `INSERT INTO estimate_reset_sale_keys(co_year, co_book, vch_no)
     SELECT DISTINCT A."CO_YEAR"::text, A."CO_BOOK"::text, A."VCH_NO"::text
       FROM "SL_DATA" AS A
      WHERE A.tenant_id=$1
        AND A."CO_CODE"::text=$2::text
        AND A."LC_CODE"::text=$3::text
        AND A."CO_YEAR"::text=$4::text
        AND coalesce(A."BILL_OS", 0)=0
        AND A."VCH_DATE" <= $5::date
        AND EXISTS (
          SELECT 1
            FROM "BOOK_DATA" AS B
           WHERE B.tenant_id=A.tenant_id
             AND B."CO_CODE"::text=A."CO_CODE"::text
             AND coalesce(B."CO_BOOK"::text, '')=coalesce(A."CO_BOOK"::text, '')
             AND coalesce(B."RESET_BOOK"::text, '')='Y'
             AND coalesce(B."BOOK_TYPE"::text, '') IN ('M','F')
             AND (B."LC_CODE" IS NULL OR B."LC_CODE"::text='' OR B."LC_CODE"::text=A."LC_CODE"::text)
        )`,
    ...params(scope, asOfDate),
  );

  await tx.$executeRawUnsafe(
    `CREATE TEMP TABLE estimate_reset_tag_keys(
       co_year text NOT NULL,
       co_book text NOT NULL,
       vch_no text NOT NULL,
       PRIMARY KEY (co_year, co_book, vch_no)
     ) ON COMMIT DROP`,
  );
  await tx.$executeRawUnsafe(
    `INSERT INTO estimate_reset_tag_keys(co_year, co_book, vch_no)
     SELECT DISTINCT A."CO_YEAR"::text, A."CO_BOOK"::text, A."VCH_NO"::text
       FROM "BAR_CAN_DATA" AS A
      WHERE A.tenant_id=$1
        AND A."CO_CODE"::text=$2::text
        AND A."LC_CODE"::text=$3::text
        AND A."CO_YEAR"::text=$4::text
        AND A."VCH_DATE" <= $5::date
        AND EXISTS (
          SELECT 1
            FROM "BOOK_DATA" AS B
           WHERE B.tenant_id=A.tenant_id
             AND B."CO_CODE"::text=A."CO_CODE"::text
             AND coalesce(B."CO_BOOK"::text, '')=coalesce(A."CO_BOOK"::text, '')
             AND coalesce(B."RESET_BOOK"::text, '')='Y'
             AND (B."LC_CODE" IS NULL OR B."LC_CODE"::text='' OR B."LC_CODE"::text=A."LC_CODE"::text)
        )`,
    ...params(scope, asOfDate),
  );

  await tx.$executeRawUnsafe(
    `CREATE TEMP TABLE estimate_reset_wh_keys(
       co_year text NOT NULL,
       co_book text NOT NULL,
       vch_no text NOT NULL,
       PRIMARY KEY (co_year, co_book, vch_no)
     ) ON COMMIT DROP`,
  );
  await tx.$executeRawUnsafe(
    `INSERT INTO estimate_reset_wh_keys(co_year, co_book, vch_no)
     SELECT DISTINCT A."CO_YEAR"::text, A."CO_BOOK"::text, A."VCH_NO"::text
       FROM "RATE_CUT_DATA" AS A
      WHERE A.tenant_id=$1
        AND A."CO_CODE"::text=$2::text
        AND A."LC_CODE"::text=$3::text
        AND A."CO_YEAR"::text=$4::text
        AND coalesce(A."SL_BILL_OS", 0)=0
        AND coalesce(A."PR_BILL_OS", 0)=0
        AND A."VCH_DATE" <= $5::date
        AND EXISTS (
          SELECT 1
            FROM "BOOK_DATA" AS B
           WHERE B.tenant_id=A.tenant_id
             AND B."CO_CODE"::text=A."CO_CODE"::text
             AND coalesce(B."CO_BOOK"::text, '')=coalesce(A."CO_BOOK"::text, '')
             AND coalesce(B."MAIN_BOOK"::text, '')='WH SALES'
             AND coalesce(B."RESET_BOOK"::text, '')='Y'
             AND (B."LC_CODE" IS NULL OR B."LC_CODE"::text='' OR B."LC_CODE"::text=A."LC_CODE"::text)
        )`,
    ...params(scope, asOfDate),
  );

  await tx.$executeRawUnsafe(
    `CREATE TEMP TABLE estimate_reset_source_tags ON COMMIT DROP AS
     WITH source_lines AS (
       SELECT "TAG_NO"::text AS tag_no, "VCH_SRNO"::double precision AS vch_srno
         FROM "SL_DETL" AS D
         JOIN estimate_reset_sale_keys AS K
           ON K.co_year=D."CO_YEAR"::text AND K.co_book=D."CO_BOOK"::text AND K.vch_no=D."VCH_NO"::text
        WHERE D.tenant_id=$1 AND D."CO_CODE"::text=$2::text AND D."LC_CODE"::text=$3::text
       UNION ALL
       SELECT "TAG_NO"::text, "VCH_SRNO"::double precision
         FROM "BAR_CAN_DETL" AS D
         JOIN estimate_reset_tag_keys AS K
           ON K.co_year=D."CO_YEAR"::text AND K.co_book=D."CO_BOOK"::text AND K.vch_no=D."VCH_NO"::text
        WHERE D.tenant_id=$1 AND D."CO_CODE"::text=$2::text AND D."LC_CODE"::text=$3::text
       UNION ALL
       SELECT "TAG_NO"::text, "VCH_SRNO"::double precision
         FROM "RATE_CUT_ISU" AS D
         JOIN estimate_reset_wh_keys AS K
           ON K.co_year=D."CO_YEAR"::text AND K.co_book=D."CO_BOOK"::text AND K.vch_no=D."VCH_NO"::text
        WHERE D.tenant_id=$1 AND D."CO_CODE"::text=$2::text AND D."LC_CODE"::text=$3::text
     )
     SELECT DISTINCT B."CO_YEAR"::text AS co_year,
            B."CO_BOOK"::text AS co_book,
            B."VCH_NO"::text AS vch_no,
            B."TAG_NO"::text AS tag_no,
            B."VCH_SRNO"::double precision AS vch_srno
       FROM "BAR_DETL" AS B
      WHERE B.tenant_id=$1
        AND B."CO_CODE"::text=$2::text
        AND B."LC_CODE"::text=$3::text
        AND EXISTS (
          SELECT 1 FROM source_lines AS L
           WHERE coalesce(L.tag_no, '')<>''
             AND coalesce(L.tag_no, '')<>'N'
             AND B."TAG_NO"::text=L.tag_no
             AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM L.vch_srno
        )`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
  await tx.$executeRawUnsafe(
    'CREATE INDEX ON estimate_reset_source_tags(co_year, co_book, vch_no, tag_no, vch_srno)',
  );

  await tx.$executeRawUnsafe(
    `CREATE TEMP TABLE estimate_reset_adjust_rows ON COMMIT DROP AS
     WITH sale_lines AS (
       SELECT D.*
         FROM "SL_DETL" AS D
         JOIN estimate_reset_sale_keys AS K
           ON K.co_year=D."CO_YEAR"::text AND K.co_book=D."CO_BOOK"::text AND K.vch_no=D."VCH_NO"::text
        WHERE D.tenant_id=$1 AND D."CO_CODE"::text=$2::text AND D."LC_CODE"::text=$3::text
     ),
     wh_lines AS (
       SELECT D.*
         FROM "RATE_CUT_ISU" AS D
         JOIN estimate_reset_wh_keys AS K
           ON K.co_year=D."CO_YEAR"::text AND K.co_book=D."CO_BOOK"::text AND K.vch_no=D."VCH_NO"::text
        WHERE D.tenant_id=$1 AND D."CO_CODE"::text=$2::text AND D."LC_CODE"::text=$3::text
     ),
     tag_lines AS (
       SELECT D.*
         FROM "BAR_CAN_DETL" AS D
         JOIN estimate_reset_tag_keys AS K
           ON K.co_year=D."CO_YEAR"::text AND K.co_book=D."CO_BOOK"::text AND K.vch_no=D."VCH_NO"::text
        WHERE D.tenant_id=$1 AND D."CO_CODE"::text=$2::text AND D."LC_CODE"::text=$3::text
     ),
     sale_or_wh_source AS (
       SELECT 'sale'::text AS source, L.row_id AS line_row_id, L."VCH_DATE" AS vch_date,
              COALESCE(NULLIF(SRC.stk_it_code, ''), L."IT_CODE"::text) AS it_code,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_REMARK"::text ELSE 'ORNAMENTS' END AS itm_remark,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_PCS" ELSE SRC."ITM_PCS" END AS itm_pcs,
              CASE WHEN SRC.row_id IS NULL THEN L."BAG_WT" ELSE SRC."BAG_WT" END AS bag_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_GWT" ELSE SRC."ITM_GWT" END AS itm_gwt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_OTH_WT" ELSE SRC."ITM_OTH_WT" END AS itm_oth_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_NWT" ELSE SRC."ITM_NWT" END AS itm_nwt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_GHT_WT" ELSE SRC."ITM_GHT_WT" END AS itm_ght_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_TOUCH" ELSE SRC."ITM_TOUCH" END AS itm_touch,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_WEST_PRC" ELSE SRC."ITM_WEST_PRC" END AS itm_west_prc,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_FINE" ELSE SRC."ITM_FINE" END AS itm_fine,
              CASE WHEN SRC.row_id IS NULL THEN L."LBR_PRC" ELSE SRC."LBR_PRC" END AS lbr_prc,
              CASE WHEN SRC.row_id IS NULL THEN L."LBR_RATE" ELSE SRC."LBR_RATE" END AS lbr_rate,
              CASE WHEN SRC.row_id IS NULL THEN L."LBR_AMT" ELSE SRC."LBR_AMT" END AS lbr_amt,
              CASE WHEN SRC.row_id IS NULL THEN L."OTH_AMT" ELSE SRC."OTH_AMT" END AS oth_amt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_RATE" ELSE SRC."ITM_RATE" END AS itm_rate,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_AMT" ELSE SRC."ITM_AMT" END AS itm_amt,
              CASE WHEN SRC.row_id IS NULL THEN L."TAG_COST" ELSE SRC."TAG_COST" END AS tag_cost,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_MRP" ELSE SRC."ITM_MRP" END AS itm_mrp,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_NET_WT" ELSE SRC."KR_NET_WT" END AS kr_net_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_TOUCH" ELSE SRC."KR_TOUCH" END AS kr_touch,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_WEST_PRC" ELSE SRC."KR_WEST_PRC" END AS kr_west_prc,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_FINE" ELSE SRC."KR_FINE" END AS kr_fine
         FROM sale_lines AS L
         LEFT JOIN LATERAL (
           SELECT B.*, COALESCE(D."STK_IT_CODE"::text, '') AS stk_it_code
             FROM "BAR_DETL" AS B
             LEFT JOIN "BAR_DATA" AS D
               ON D.tenant_id=B.tenant_id
              AND D."CO_CODE"::text=B."CO_CODE"::text
              AND D."LC_CODE"::text=B."LC_CODE"::text
              AND D."CO_YEAR"::text=B."CO_YEAR"::text
              AND D."CO_BOOK"::text=B."CO_BOOK"::text
              AND D."VCH_NO"::text=B."VCH_NO"::text
            WHERE B.tenant_id=L.tenant_id
              AND B."CO_CODE"::text=L."CO_CODE"::text
              AND B."LC_CODE"::text=L."LC_CODE"::text
              AND B."TAG_NO"::text=L."TAG_NO"::text
              AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM L."VCH_SRNO"::double precision
            ORDER BY B.row_id
            LIMIT 1
         ) AS SRC ON true
        WHERE SRC.row_id IS NULL OR COALESCE(SRC.stk_it_code, '')<>''
       UNION ALL
       SELECT 'wh-sale'::text AS source, L.row_id AS line_row_id, L."VCH_DATE" AS vch_date,
              COALESCE(NULLIF(SRC.stk_it_code, ''), L."IT_CODE"::text) AS it_code,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_REMARK"::text ELSE 'ORNAMENTS' END AS itm_remark,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_PCS" ELSE SRC."ITM_PCS" END AS itm_pcs,
              CASE WHEN SRC.row_id IS NULL THEN L."BAG_WT" ELSE SRC."BAG_WT" END AS bag_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_GWT" ELSE SRC."ITM_GWT" END AS itm_gwt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_OTH_WT" ELSE SRC."ITM_OTH_WT" END AS itm_oth_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_NWT" ELSE SRC."ITM_NWT" END AS itm_nwt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_GHT_WT" ELSE SRC."ITM_GHT_WT" END AS itm_ght_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_TOUCH" ELSE SRC."ITM_TOUCH" END AS itm_touch,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_WEST_PRC" ELSE SRC."ITM_WEST_PRC" END AS itm_west_prc,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_FINE" ELSE SRC."ITM_FINE" END AS itm_fine,
              CASE WHEN SRC.row_id IS NULL THEN L."LBR_PRC" ELSE SRC."LBR_PRC" END AS lbr_prc,
              CASE WHEN SRC.row_id IS NULL THEN L."LBR_RATE" ELSE SRC."LBR_RATE" END AS lbr_rate,
              CASE WHEN SRC.row_id IS NULL THEN L."LBR_AMT" ELSE SRC."LBR_AMT" END AS lbr_amt,
              CASE WHEN SRC.row_id IS NULL THEN L."OTH_AMT" ELSE SRC."OTH_AMT" END AS oth_amt,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_RATE" ELSE SRC."ITM_RATE" END AS itm_rate,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_AMT" ELSE SRC."ITM_AMT" END AS itm_amt,
              CASE WHEN SRC.row_id IS NULL THEN L."TAG_COST" ELSE SRC."TAG_COST" END AS tag_cost,
              CASE WHEN SRC.row_id IS NULL THEN L."ITM_MRP" ELSE SRC."ITM_MRP" END AS itm_mrp,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_NET_WT" ELSE SRC."KR_NET_WT" END AS kr_net_wt,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_TOUCH" ELSE SRC."KR_TOUCH" END AS kr_touch,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_WEST_PRC" ELSE SRC."KR_WEST_PRC" END AS kr_west_prc,
              CASE WHEN SRC.row_id IS NULL THEN L."KR_FINE" ELSE SRC."KR_FINE" END AS kr_fine
         FROM wh_lines AS L
         LEFT JOIN LATERAL (
           SELECT B.*, COALESCE(D."STK_IT_CODE"::text, '') AS stk_it_code
             FROM "BAR_DETL" AS B
             LEFT JOIN "BAR_DATA" AS D
               ON D.tenant_id=B.tenant_id
              AND D."CO_CODE"::text=B."CO_CODE"::text
              AND D."LC_CODE"::text=B."LC_CODE"::text
              AND D."CO_YEAR"::text=B."CO_YEAR"::text
              AND D."CO_BOOK"::text=B."CO_BOOK"::text
              AND D."VCH_NO"::text=B."VCH_NO"::text
            WHERE B.tenant_id=L.tenant_id
              AND B."CO_CODE"::text=L."CO_CODE"::text
              AND B."LC_CODE"::text=L."LC_CODE"::text
              AND B."TAG_NO"::text=L."TAG_NO"::text
              AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM L."VCH_SRNO"::double precision
            ORDER BY B.row_id
            LIMIT 1
         ) AS SRC ON true
        WHERE SRC.row_id IS NULL OR COALESCE(SRC.stk_it_code, '')<>''
       UNION ALL
       SELECT 'tag-cancel'::text AS source, L.row_id AS line_row_id, L."VCH_DATE" AS vch_date,
              SRC.stk_it_code AS it_code,
              'ORNAMENTS'::text AS itm_remark,
              SRC."ITM_PCS" AS itm_pcs,
              SRC."BAG_WT" AS bag_wt,
              SRC."ITM_GWT" AS itm_gwt,
              SRC."ITM_OTH_WT" AS itm_oth_wt,
              SRC."ITM_NWT" AS itm_nwt,
              SRC."ITM_GHT_WT" AS itm_ght_wt,
              SRC."ITM_TOUCH" AS itm_touch,
              SRC."ITM_WEST_PRC" AS itm_west_prc,
              SRC."ITM_FINE" AS itm_fine,
              SRC."LBR_PRC" AS lbr_prc,
              SRC."LBR_RATE" AS lbr_rate,
              SRC."LBR_AMT" AS lbr_amt,
              SRC."OTH_AMT" AS oth_amt,
              SRC."ITM_RATE" AS itm_rate,
              SRC."ITM_AMT" AS itm_amt,
              SRC."TAG_COST" AS tag_cost,
              SRC."ITM_MRP" AS itm_mrp,
              SRC."KR_NET_WT" AS kr_net_wt,
              SRC."KR_TOUCH" AS kr_touch,
              SRC."KR_WEST_PRC" AS kr_west_prc,
              SRC."KR_FINE" AS kr_fine
         FROM tag_lines AS L
         JOIN LATERAL (
           SELECT B.*, COALESCE(D."STK_IT_CODE"::text, '') AS stk_it_code
             FROM "BAR_DETL" AS B
             LEFT JOIN "BAR_DATA" AS D
               ON D.tenant_id=B.tenant_id
              AND D."CO_CODE"::text=B."CO_CODE"::text
              AND D."LC_CODE"::text=B."LC_CODE"::text
              AND D."CO_YEAR"::text=B."CO_YEAR"::text
              AND D."CO_BOOK"::text=B."CO_BOOK"::text
              AND D."VCH_NO"::text=B."VCH_NO"::text
            WHERE B.tenant_id=L.tenant_id
              AND B."CO_CODE"::text=L."CO_CODE"::text
              AND B."LC_CODE"::text=L."LC_CODE"::text
              AND B."TAG_NO"::text=L."TAG_NO"::text
              AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM L."VCH_SRNO"::double precision
              AND COALESCE(D."STK_IT_CODE"::text, '')<>''
            ORDER BY B.row_id
            LIMIT 1
         ) AS SRC ON true
     )
     SELECT * FROM sale_or_wh_source
      WHERE vch_date IS NOT NULL`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
  await tx.$executeRawUnsafe(
    'CREATE INDEX ON estimate_reset_adjust_rows(vch_date, source, line_row_id)',
  );

  await tx.$executeRawUnsafe(
    `CREATE TEMP TABLE estimate_reset_apr_headers ON COMMIT DROP AS
     SELECT DISTINCT A."CO_YEAR"::text AS co_year, A."CO_BOOK"::text AS co_book, A."VCH_NO"::text AS vch_no
       FROM "APR_DETL" AS A
       LEFT JOIN "BAR_DETL" AS B
         ON B.tenant_id=A.tenant_id
        AND B."CO_CODE"::text=A."CO_CODE"::text
        AND B."LC_CODE"::text=A."LC_CODE"::text
        AND B."TAG_NO"::text=A."TAG_NO"::text
        AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM A."VCH_SRNO"::double precision
        AND NOT EXISTS (
          SELECT 1 FROM pg_temp.estimate_reset_source_tags AS K
           WHERE K.co_year=B."CO_YEAR"::text
             AND K.co_book=B."CO_BOOK"::text
             AND K.vch_no=B."VCH_NO"::text
             AND K.tag_no=B."TAG_NO"::text
             AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM K.vch_srno
        )
      WHERE A.tenant_id=$1
        AND A."CO_CODE"::text=$2::text
        AND A."LC_CODE"::text=$3::text
        AND coalesce(A."TAG_NO"::text, '')<>'N'
        AND coalesce(A."BOOK_NAME"::text, '') IN ('APR ISU','APR RTN')
        AND B.row_id IS NULL`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
  await tx.$executeRawUnsafe(
    'CREATE INDEX ON estimate_reset_apr_headers(co_year, co_book, vch_no)',
  );
}

async function scalarInt(tx: any, sql: string, ...p: unknown[]): Promise<number> {
  const rows = (await tx.$queryRawUnsafe(sql, ...p)) as Array<Record<string, unknown>>;
  const first = rows[0] ?? {};
  const value = Object.values(first)[0] ?? 0;
  return Number(value);
}

function compactDiffs(diffs: EstimateResetDiff[]): EstimateResetDiff[] {
  const merged = new Map<string, EstimateResetDiff>();
  for (const diff of diffs) {
    const current = merged.get(diff.table) ?? {
      table: diff.table,
      insert: 0,
      update: 0,
      delete: 0,
    };
    current.insert += Number(diff.insert || 0);
    current.update += Number(diff.update || 0);
    current.delete += Number(diff.delete || 0);
    merged.set(diff.table, current);
  }
  return [...merged.values()]
    .filter((d) => d.insert !== 0 || d.update !== 0 || d.delete !== 0)
    .sort((a, b) => a.table.localeCompare(b.table));
}

async function countTemp(tx: any, table: string): Promise<number> {
  return scalarInt(tx, `SELECT count(*)::int AS n FROM pg_temp.${table}`);
}

async function countVoucherDeleteTx(
  tx: any,
  table: string,
  keyTable: string,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return scalarInt(
    tx,
    `SELECT count(*)::int AS n
       FROM "${table}" AS T
      WHERE T.tenant_id=$1
        AND T."CO_CODE"::text=$2::text
        AND T."LC_CODE"::text=$3::text
        AND EXISTS (
          SELECT 1 FROM pg_temp.${keyTable} AS K
           WHERE K.co_year=T."CO_YEAR"::text
             AND K.co_book=T."CO_BOOK"::text
             AND K.vch_no=T."VCH_NO"::text
        )`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
}

async function countSourceTagDeleteTx(
  tx: any,
  table: string,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return scalarInt(
    tx,
    `SELECT count(*)::int AS n
       FROM "${table}" AS T
      WHERE T.tenant_id=$1
        AND T."CO_CODE"::text=$2::text
        AND T."LC_CODE"::text=$3::text
        AND EXISTS (
          SELECT 1 FROM pg_temp.estimate_reset_source_tags AS K
           WHERE K.co_year=T."CO_YEAR"::text
             AND K.co_book=T."CO_BOOK"::text
             AND K.vch_no=T."VCH_NO"::text
             AND K.tag_no=T."TAG_NO"::text
             AND T."VCH_SRNO"::double precision IS NOT DISTINCT FROM K.vch_srno
        )`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
}

async function countMainStockDeleteTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return scalarInt(
    tx,
    `SELECT count(*)::int AS n
       FROM "MAIN_STOCK" AS T
      WHERE T.tenant_id=$1
        AND T."CO_CODE"::text=$2::text
        AND T."LC_CODE"::text=$3::text
        AND (
          EXISTS (
            SELECT 1 FROM pg_temp.estimate_reset_source_tags AS K
             WHERE K.co_year=T."CO_YEAR"::text
               AND K.co_book=T."CO_BOOK"::text
               AND K.vch_no=T."VCH_NO"::text
               AND K.tag_no=T."TAG_NO"::text
               AND T."VCH_SRNO"::double precision IS NOT DISTINCT FROM K.vch_srno
          )
          OR EXISTS (
            SELECT 1 FROM pg_temp.estimate_reset_sale_keys AS K
             WHERE K.co_year=T."CO_YEAR"::text AND K.co_book=T."CO_BOOK"::text AND K.vch_no=T."VCH_NO"::text
          )
          OR EXISTS (
            SELECT 1 FROM pg_temp.estimate_reset_tag_keys AS K
             WHERE K.co_year=T."CO_YEAR"::text AND K.co_book=T."CO_BOOK"::text AND K.vch_no=T."VCH_NO"::text
          )
          OR EXISTS (
            SELECT 1 FROM pg_temp.estimate_reset_wh_keys AS K
             WHERE K.co_year=T."CO_YEAR"::text AND K.co_book=T."CO_BOOK"::text AND K.vch_no=T."VCH_NO"::text
          )
        )`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
}

async function countAprDetlOrphansTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return scalarInt(
    tx,
    `SELECT count(*)::int AS n
       FROM "APR_DETL" AS A
       LEFT JOIN "BAR_DETL" AS B
         ON B.tenant_id=A.tenant_id
        AND B."CO_CODE"::text=A."CO_CODE"::text
        AND B."LC_CODE"::text=A."LC_CODE"::text
        AND B."TAG_NO"::text=A."TAG_NO"::text
        AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM A."VCH_SRNO"::double precision
        AND NOT EXISTS (
          SELECT 1 FROM pg_temp.estimate_reset_source_tags AS K
           WHERE K.co_year=B."CO_YEAR"::text
             AND K.co_book=B."CO_BOOK"::text
             AND K.vch_no=B."VCH_NO"::text
             AND K.tag_no=B."TAG_NO"::text
             AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM K.vch_srno
        )
      WHERE A.tenant_id=$1
        AND A."CO_CODE"::text=$2::text
        AND A."LC_CODE"::text=$3::text
        AND coalesce(A."TAG_NO"::text, '')<>'N'
        AND coalesce(A."BOOK_NAME"::text, '') IN ('APR ISU','APR RTN')
        AND B.row_id IS NULL`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
}

async function countAprHeadersAfterOrphansTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return scalarInt(
    tx,
    `SELECT count(*)::int AS n
       FROM "APR_DATA" AS H
      WHERE H.tenant_id=$1
        AND H."CO_CODE"::text=$2::text
        AND H."LC_CODE"::text=$3::text
        AND EXISTS (
          SELECT 1 FROM pg_temp.estimate_reset_apr_headers AS A
           WHERE A.co_year=H."CO_YEAR"::text
             AND A.co_book=H."CO_BOOK"::text
             AND A.vch_no=H."VCH_NO"::text
        )
        AND NOT EXISTS (
          SELECT 1
            FROM "APR_DETL" AS D
           WHERE D.tenant_id=H.tenant_id
             AND D."CO_CODE"::text=H."CO_CODE"::text
             AND D."LC_CODE"::text=H."LC_CODE"::text
             AND D."CO_YEAR"::text=H."CO_YEAR"::text
             AND D."CO_BOOK"::text=H."CO_BOOK"::text
             AND D."VCH_NO"::text=H."VCH_NO"::text
             AND NOT (
               coalesce(D."TAG_NO"::text, '')<>'N'
               AND coalesce(D."BOOK_NAME"::text, '') IN ('APR ISU','APR RTN')
               AND NOT EXISTS (
                 SELECT 1 FROM "BAR_DETL" AS B
                  WHERE B.tenant_id=D.tenant_id
                    AND B."CO_CODE"::text=D."CO_CODE"::text
                    AND B."LC_CODE"::text=D."LC_CODE"::text
                    AND B."TAG_NO"::text=D."TAG_NO"::text
                    AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM D."VCH_SRNO"::double precision
                    AND NOT EXISTS (
                      SELECT 1 FROM pg_temp.estimate_reset_source_tags AS K
                       WHERE K.co_year=B."CO_YEAR"::text
                         AND K.co_book=B."CO_BOOK"::text
                         AND K.vch_no=B."VCH_NO"::text
                         AND K.tag_no=B."TAG_NO"::text
                         AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM K.vch_srno
                    )
               )
             )
        )`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
}

async function estimateDiffsTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<EstimateResetDiff[]> {
  const selectedSale = await countTemp(tx, 'estimate_reset_sale_keys');
  const selectedTag = await countTemp(tx, 'estimate_reset_tag_keys');
  const selectedWh = await countTemp(tx, 'estimate_reset_wh_keys');
  const adjustDetails = await countTemp(tx, 'estimate_reset_adjust_rows');
  const newAdjustHeaders = await scalarInt(
    tx,
    `SELECT count(*)::int AS n
       FROM (SELECT DISTINCT vch_date FROM pg_temp.estimate_reset_adjust_rows) AS D
      WHERE NOT EXISTS (
        SELECT 1 FROM "BAR_CAN_DATA" AS H
         WHERE H.tenant_id=$1
           AND H."CO_CODE"::text=$2::text
           AND H."LC_CODE"::text=$3::text
           AND H."CO_YEAR"::text=$4::text
           AND H."CO_BOOK"::text=$5::text
           AND H."VCH_DATE"=D.vch_date
      )`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    STOCK_ADJUST_BOOK,
  );
  const diffs: EstimateResetDiff[] = [
    {
      table: 'BAR_DATA',
      insert: 0,
      update: await scalarInt(
        tx,
        `SELECT count(*)::int AS n FROM "BAR_DATA"
          WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "LC_CODE"::text=$3::text AND "CO_YEAR"::text=$4::text AND "STK_IT_CODE" IS NULL`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
      ),
      delete: 0,
    },
    { table: 'BAR_CAN_DATA', insert: newAdjustHeaders, update: 0, delete: selectedTag },
    {
      table: 'BAR_CAN_DETL',
      insert: adjustDetails,
      update: 0,
      delete: await countVoucherDeleteTx(tx, 'BAR_CAN_DETL', 'estimate_reset_tag_keys', scope),
    },
    {
      table: 'BAR_CAN_IDTL',
      insert: 0,
      update: 0,
      delete: await countVoucherDeleteTx(tx, 'BAR_CAN_IDTL', 'estimate_reset_tag_keys', scope),
    },
    { table: 'TEMP_BOOK_DATA', insert: newAdjustHeaders, update: 0, delete: 0 },
    {
      table: 'BAR_DETL',
      insert: 0,
      update: 0,
      delete: await countSourceTagDeleteTx(tx, 'BAR_DETL', scope),
    },
    {
      table: 'BAR_IDTL',
      insert: 0,
      update: 0,
      delete: await countSourceTagDeleteTx(tx, 'BAR_IDTL', scope),
    },
    { table: 'MAIN_STOCK', insert: 0, update: 0, delete: await countMainStockDeleteTx(tx, scope) },
    { table: 'SL_DATA', insert: 0, update: 0, delete: selectedSale },
    {
      table: 'SL_DETL',
      insert: 0,
      update: 0,
      delete: await countVoucherDeleteTx(tx, 'SL_DETL', 'estimate_reset_sale_keys', scope),
    },
    {
      table: 'SL_IDTL',
      insert: 0,
      update: 0,
      delete:
        (await countVoucherDeleteTx(tx, 'SL_IDTL', 'estimate_reset_sale_keys', scope)) +
        (await countVoucherDeleteTx(tx, 'SL_IDTL', 'estimate_reset_wh_keys', scope)),
    },
    {
      table: 'SL_PR_DETL',
      insert: 0,
      update: 0,
      delete: await countVoucherDeleteTx(tx, 'SL_PR_DETL', 'estimate_reset_sale_keys', scope),
    },
    {
      table: 'AC_DATA',
      insert: 0,
      update: 0,
      delete:
        (await countVoucherDeleteTx(tx, 'AC_DATA', 'estimate_reset_sale_keys', scope)) +
        (await countVoucherDeleteTx(tx, 'AC_DATA', 'estimate_reset_wh_keys', scope)),
    },
    {
      table: 'ROJ_MEL_DATA',
      insert: 0,
      update: 0,
      delete:
        (await countVoucherDeleteTx(tx, 'ROJ_MEL_DATA', 'estimate_reset_sale_keys', scope)) +
        (await countVoucherDeleteTx(tx, 'ROJ_MEL_DATA', 'estimate_reset_wh_keys', scope)),
    },
    {
      table: 'FINE_DATA',
      insert: 0,
      update: 0,
      delete:
        (await countVoucherDeleteTx(tx, 'FINE_DATA', 'estimate_reset_sale_keys', scope)) +
        (await countVoucherDeleteTx(tx, 'FINE_DATA', 'estimate_reset_wh_keys', scope)),
    },
    { table: 'RATE_CUT_DATA', insert: 0, update: 0, delete: selectedWh },
    {
      table: 'RATE_CUT_ISU',
      insert: 0,
      update: 0,
      delete: await countVoucherDeleteTx(tx, 'RATE_CUT_ISU', 'estimate_reset_wh_keys', scope),
    },
    {
      table: 'RATE_CUT_REC',
      insert: 0,
      update: 0,
      delete: await countVoucherDeleteTx(tx, 'RATE_CUT_REC', 'estimate_reset_wh_keys', scope),
    },
    { table: 'APR_DETL', insert: 0, update: 0, delete: await countAprDetlOrphansTx(tx, scope) },
    {
      table: 'APR_DATA',
      insert: 0,
      update: 0,
      delete: await countAprHeadersAfterOrphansTx(tx, scope),
    },
  ];
  return compactDiffs(diffs);
}

async function samplesTx(tx: any): Promise<string[]> {
  const rows = (await tx.$queryRawUnsafe(
    `SELECT workflow, co_book, vch_no, co_year
       FROM (
         SELECT 'Estimate Sales' AS workflow, co_book, vch_no, co_year FROM pg_temp.estimate_reset_sale_keys
         UNION ALL
         SELECT 'Tag Cancel' AS workflow, co_book, vch_no, co_year FROM pg_temp.estimate_reset_tag_keys
         UNION ALL
         SELECT 'Wholesale Sales' AS workflow, co_book, vch_no, co_year FROM pg_temp.estimate_reset_wh_keys
       ) AS X
      ORDER BY workflow, co_book, vch_no
      LIMIT 12`,
  )) as Array<{ workflow: string; co_book: string; vch_no: string; co_year: string }>;
  return rows.map((r) => `${r.workflow}: ${r.co_year}/${r.co_book}/${r.vch_no}`);
}

function buildPreview(
  scope: Required<EstimateResetScope>,
  asOfDate: string,
  companyType: string,
  diffs: EstimateResetDiff[],
  samples: string[],
  selectedVouchers: number,
  stockAdjustmentDetails: number,
): EstimateResetPreview {
  return {
    kind: ESTIMATE_RESET_KIND,
    generatedAt: new Date().toISOString(),
    asOfDate,
    scope,
    companyType,
    desktopSource: DESKTOP_SOURCE,
    diffs,
    samples,
    totals: {
      insert: diffs.reduce((sum, d) => sum + d.insert, 0),
      update: diffs.reduce((sum, d) => sum + d.update, 0),
      delete: diffs.reduce((sum, d) => sum + d.delete, 0),
      selectedVouchers,
      stockAdjustmentDetails,
    },
    requiresConfirmation: ESTIMATE_RESET_CONFIRMATION,
    postApplyMessage: POST_APPLY_MESSAGE,
    registrationSpecificBranches: REGISTRATION_BRANCHES,
  };
}

async function selectedVoucherTotalTx(tx: any): Promise<number> {
  return (
    (await countTemp(tx, 'estimate_reset_sale_keys')) +
    (await countTemp(tx, 'estimate_reset_tag_keys')) +
    (await countTemp(tx, 'estimate_reset_wh_keys'))
  );
}

export async function estimateResetPreview(
  prisma: any,
  inputScope: EstimateResetScope,
  inputAsOfDate?: unknown,
): Promise<EstimateResetPreview> {
  const scope = requiredScope(inputScope);
  const asOfDate = dateOnly(inputAsOfDate);
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    const companyType = await ensureCompanyAllowsResetTx(tx, scope);
    await prepareCandidateTablesTx(tx, scope, asOfDate);
    const diffs = await estimateDiffsTx(tx, scope);
    const samples = await samplesTx(tx);
    return buildPreview(
      scope,
      asOfDate,
      companyType,
      diffs,
      samples,
      await selectedVoucherTotalTx(tx),
      await countTemp(tx, 'estimate_reset_adjust_rows'),
    );
  });
}

function assertConfirmation(input: Record<string, unknown>): void {
  if (input.confirmed === true) return;
  if (
    String(input.confirmation ?? '')
      .trim()
      .toUpperCase() === ESTIMATE_RESET_CONFIRMATION
  )
    return;
  throw new EstimateResetValidationError(
    `type ${ESTIMATE_RESET_CONFIRMATION} to apply Estimate Reset`,
  );
}

function toDb(value: unknown): unknown {
  return value === undefined ? null : value;
}

function isoDate(value: unknown): string {
  if (value instanceof Date) return value.toISOString().slice(0, 10);
  return String(value ?? '').slice(0, 10);
}

async function ensureAdjustmentVoucherTx(
  tx: any,
  scope: Required<EstimateResetScope>,
  vchDate: string,
  createdDates: Set<string>,
): Promise<string> {
  const existing = (await tx.$queryRawUnsafe(
    `SELECT "VCH_NO"::text AS vch_no
       FROM "BAR_CAN_DATA"
      WHERE tenant_id=$1
        AND "CO_CODE"::text=$2::text
        AND "LC_CODE"::text=$3::text
        AND "CO_YEAR"::text=$4::text
        AND "CO_BOOK"::text=$5::text
        AND "VCH_DATE"=$6::date
      ORDER BY "VCH_NO"
      LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    STOCK_ADJUST_BOOK,
    vchDate,
  )) as Array<{ vch_no: string }>;
  if (existing[0]?.vch_no) return existing[0].vch_no;

  const maxRows = (await tx.$queryRawUnsafe(
    `SELECT coalesce(max(CASE WHEN "VCH_NO"::text ~ '^[0-9]+$' THEN "VCH_NO"::int ELSE NULL END), 0)::int AS n
       FROM "BAR_CAN_DATA"
      WHERE tenant_id=$1
        AND "CO_CODE"::text=$2::text
        AND "LC_CODE"::text=$3::text
        AND "CO_YEAR"::text=$4::text
        AND "CO_BOOK"::text=$5::text`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    STOCK_ADJUST_BOOK,
  )) as Array<{ n: number }>;
  const vchNo = String(Number(maxRows[0]?.n ?? 0) + 1).padStart(5, '0');
  await tx.$executeRawUnsafe(
    `INSERT INTO "BAR_CAN_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","HD_VCH_NO","MAIN_USER","DATA_TRFR")
     VALUES ($1,$2,$3,$4,$5,$6,$7::date,$7::timestamp,$6,'web','N')`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    STOCK_ADJUST_BOOK,
    vchNo,
    vchDate,
  );
  await tx.$executeRawUnsafe(
    `DELETE FROM "TEMP_BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "LC_CODE"::text=$3::text AND "CO_BOOK"::text=$4::text AND "VCH_NO"::text=$5::text`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    STOCK_ADJUST_BOOK,
    vchNo,
  );
  await tx.$executeRawUnsafe(
    `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
     VALUES ($1,$2,$3,$4,$5,'Stock Adjust1')`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    STOCK_ADJUST_BOOK,
    vchNo,
  );
  createdDates.add(vchDate);
  return vchNo;
}

async function insertAdjustmentRowsTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<{ headers: number; details: number }> {
  const rows = (await tx.$queryRawUnsafe(
    `SELECT source, line_row_id::text AS line_row_id, vch_date, it_code, itm_remark,
            itm_pcs, bag_wt, itm_gwt, itm_oth_wt, itm_nwt, itm_ght_wt, itm_touch, itm_west_prc,
            itm_fine, lbr_prc, lbr_rate, lbr_amt, oth_amt, itm_rate, itm_amt, tag_cost, itm_mrp,
            kr_net_wt, kr_touch, kr_west_prc, kr_fine
       FROM pg_temp.estimate_reset_adjust_rows
      ORDER BY vch_date, source, line_row_id`,
  )) as Array<Record<string, unknown>>;
  const createdDates = new Set<string>();
  let details = 0;
  for (const row of rows) {
    const vchDate = isoDate(row.vch_date);
    const vchNo = await ensureAdjustmentVoucherTx(tx, scope, vchDate, createdDates);
    const srRows = (await tx.$queryRawUnsafe(
      `SELECT coalesce(max("SR_NO"), 0) + 1 AS sr_no
         FROM "BAR_CAN_DETL"
        WHERE tenant_id=$1
          AND "CO_CODE"::text=$2::text
          AND "LC_CODE"::text=$3::text
          AND "CO_YEAR"::text=$4::text
          AND "CO_BOOK"::text=$5::text
          AND "VCH_NO"::text=$6::text`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      STOCK_ADJUST_BOOK,
      vchNo,
    )) as Array<{ sr_no: number }>;
    const srNo = Number(srRows[0]?.sr_no ?? 1);
    await tx.$executeRawUnsafe(
      `INSERT INTO "BAR_CAN_DETL"(
        tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TIME",
        "IT_CODE","ITM_REMARK","ITM_PCS","BAG_WT","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_GHT_WT",
        "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","LBR_PRC","LBR_RATE","LBR_AMT","OTH_AMT",
        "ITM_RATE","ITM_AMT","TAG_COST","ITM_MRP","ITM_SIGN","TAG_NO","VCH_SRNO",
        "KR_NET_WT","KR_TOUCH","KR_WEST_PRC","KR_FINE","MAIN_USER","DATA_TRFR"
      ) VALUES (
        $1,$2,$3,$4,$5,$6,$7,$8::date,$8::timestamp,
        $9,$10,$11,$12,$13,$14,$15,$16,
        $17,$18,$19,$20,$21,$22,$23,
        $24,$25,$26,$27,'-','N',0,
        $28,$29,$30,$31,'web','N'
      )`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      STOCK_ADJUST_BOOK,
      vchNo,
      srNo,
      vchDate,
      toDb(row.it_code),
      toDb(row.itm_remark),
      toDb(row.itm_pcs),
      toDb(row.bag_wt),
      toDb(row.itm_gwt),
      toDb(row.itm_oth_wt),
      toDb(row.itm_nwt),
      toDb(row.itm_ght_wt),
      toDb(row.itm_touch),
      toDb(row.itm_west_prc),
      toDb(row.itm_fine),
      toDb(row.lbr_prc),
      toDb(row.lbr_rate),
      toDb(row.lbr_amt),
      toDb(row.oth_amt),
      toDb(row.itm_rate),
      toDb(row.itm_amt),
      toDb(row.tag_cost),
      toDb(row.itm_mrp),
      toDb(row.kr_net_wt),
      toDb(row.kr_touch),
      toDb(row.kr_west_prc),
      toDb(row.kr_fine),
    );
    details += 1;
  }
  return { headers: createdDates.size, details };
}

async function deleteVoucherRowsTx(
  tx: any,
  table: string,
  keyTable: string,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return Number(
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}" AS T
        USING pg_temp.${keyTable} AS K
        WHERE T.tenant_id=$1
          AND T."CO_CODE"::text=$2::text
          AND T."LC_CODE"::text=$3::text
          AND K.co_year=T."CO_YEAR"::text
          AND K.co_book=T."CO_BOOK"::text
          AND K.vch_no=T."VCH_NO"::text`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    ),
  );
}

async function deleteSourceTagRowsTx(
  tx: any,
  table: string,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return Number(
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}" AS T
        USING pg_temp.estimate_reset_source_tags AS K
        WHERE T.tenant_id=$1
          AND T."CO_CODE"::text=$2::text
          AND T."LC_CODE"::text=$3::text
          AND K.co_year=T."CO_YEAR"::text
          AND K.co_book=T."CO_BOOK"::text
          AND K.vch_no=T."VCH_NO"::text
          AND K.tag_no=T."TAG_NO"::text
          AND T."VCH_SRNO"::double precision IS NOT DISTINCT FROM K.vch_srno`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    ),
  );
}

async function deleteMainStockRowsTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<number> {
  return Number(
    await tx.$executeRawUnsafe(
      `DELETE FROM "MAIN_STOCK" AS T
       WHERE T.tenant_id=$1
         AND T."CO_CODE"::text=$2::text
         AND T."LC_CODE"::text=$3::text
         AND (
           EXISTS (
             SELECT 1 FROM pg_temp.estimate_reset_source_tags AS K
              WHERE K.co_year=T."CO_YEAR"::text
                AND K.co_book=T."CO_BOOK"::text
                AND K.vch_no=T."VCH_NO"::text
                AND K.tag_no=T."TAG_NO"::text
                AND T."VCH_SRNO"::double precision IS NOT DISTINCT FROM K.vch_srno
           )
           OR EXISTS (
             SELECT 1 FROM pg_temp.estimate_reset_sale_keys AS K
              WHERE K.co_year=T."CO_YEAR"::text AND K.co_book=T."CO_BOOK"::text AND K.vch_no=T."VCH_NO"::text
           )
           OR EXISTS (
             SELECT 1 FROM pg_temp.estimate_reset_tag_keys AS K
              WHERE K.co_year=T."CO_YEAR"::text AND K.co_book=T."CO_BOOK"::text AND K.vch_no=T."VCH_NO"::text
           )
           OR EXISTS (
             SELECT 1 FROM pg_temp.estimate_reset_wh_keys AS K
              WHERE K.co_year=T."CO_YEAR"::text AND K.co_book=T."CO_BOOK"::text AND K.vch_no=T."VCH_NO"::text
           )
         )`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    ),
  );
}

async function applyDeletesTx(
  tx: any,
  scope: Required<EstimateResetScope>,
): Promise<EstimateResetDiff[]> {
  const diffs: EstimateResetDiff[] = [];
  const updateBarData = Number(
    await tx.$executeRawUnsafe(
      `UPDATE "BAR_DATA" SET "STK_IT_CODE"=''
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "LC_CODE"::text=$3::text AND "CO_YEAR"::text=$4::text AND "STK_IT_CODE" IS NULL`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
    ),
  );
  diffs.push({ table: 'BAR_DATA', insert: 0, update: updateBarData, delete: 0 });

  const inserted = await insertAdjustmentRowsTx(tx, scope);
  diffs.push({ table: 'BAR_CAN_DATA', insert: inserted.headers, update: 0, delete: 0 });
  diffs.push({ table: 'TEMP_BOOK_DATA', insert: inserted.headers, update: 0, delete: 0 });
  diffs.push({ table: 'BAR_CAN_DETL', insert: inserted.details, update: 0, delete: 0 });

  diffs.push({
    table: 'MAIN_STOCK',
    insert: 0,
    update: 0,
    delete: await deleteMainStockRowsTx(tx, scope),
  });
  diffs.push({
    table: 'BAR_IDTL',
    insert: 0,
    update: 0,
    delete: await deleteSourceTagRowsTx(tx, 'BAR_IDTL', scope),
  });
  diffs.push({
    table: 'BAR_DETL',
    insert: 0,
    update: 0,
    delete: await deleteSourceTagRowsTx(tx, 'BAR_DETL', scope),
  });

  for (const table of ['AC_DATA', 'ROJ_MEL_DATA', 'FINE_DATA', 'SL_IDTL'] as const) {
    const saleDelete = await deleteVoucherRowsTx(tx, table, 'estimate_reset_sale_keys', scope);
    const whDelete = await deleteVoucherRowsTx(tx, table, 'estimate_reset_wh_keys', scope);
    diffs.push({ table, insert: 0, update: 0, delete: saleDelete + whDelete });
  }
  for (const table of ['SL_PR_DETL', 'SL_DETL', 'SL_DATA'] as const) {
    diffs.push({
      table,
      insert: 0,
      update: 0,
      delete: await deleteVoucherRowsTx(tx, table, 'estimate_reset_sale_keys', scope),
    });
  }
  for (const table of ['BAR_CAN_IDTL', 'BAR_CAN_DETL', 'BAR_CAN_DATA'] as const) {
    diffs.push({
      table,
      insert: 0,
      update: 0,
      delete: await deleteVoucherRowsTx(tx, table, 'estimate_reset_tag_keys', scope),
    });
  }
  for (const table of ['RATE_CUT_ISU', 'RATE_CUT_REC', 'RATE_CUT_DATA'] as const) {
    diffs.push({
      table,
      insert: 0,
      update: 0,
      delete: await deleteVoucherRowsTx(tx, table, 'estimate_reset_wh_keys', scope),
    });
  }

  const aprDetlDelete = Number(
    await tx.$executeRawUnsafe(
      `DELETE FROM "APR_DETL" AS A
       WHERE A.tenant_id=$1
         AND A."CO_CODE"::text=$2::text
         AND A."LC_CODE"::text=$3::text
         AND coalesce(A."TAG_NO"::text, '')<>'N'
         AND coalesce(A."BOOK_NAME"::text, '') IN ('APR ISU','APR RTN')
         AND NOT EXISTS (
           SELECT 1 FROM "BAR_DETL" AS B
            WHERE B.tenant_id=A.tenant_id
              AND B."CO_CODE"::text=A."CO_CODE"::text
              AND B."LC_CODE"::text=A."LC_CODE"::text
              AND B."TAG_NO"::text=A."TAG_NO"::text
              AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM A."VCH_SRNO"::double precision
         )`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    ),
  );
  diffs.push({ table: 'APR_DETL', insert: 0, update: 0, delete: aprDetlDelete });

  const aprDataDelete = Number(
    await tx.$executeRawUnsafe(
      `DELETE FROM "APR_DATA" AS H
        USING pg_temp.estimate_reset_apr_headers AS A
        WHERE H.tenant_id=$1
          AND H."CO_CODE"::text=$2::text
          AND H."LC_CODE"::text=$3::text
          AND A.co_year=H."CO_YEAR"::text
          AND A.co_book=H."CO_BOOK"::text
          AND A.vch_no=H."VCH_NO"::text
          AND NOT EXISTS (
            SELECT 1 FROM "APR_DETL" AS D
             WHERE D.tenant_id=H.tenant_id
               AND D."CO_CODE"::text=H."CO_CODE"::text
               AND D."LC_CODE"::text=H."LC_CODE"::text
               AND D."CO_YEAR"::text=H."CO_YEAR"::text
               AND D."CO_BOOK"::text=H."CO_BOOK"::text
               AND D."VCH_NO"::text=H."VCH_NO"::text
          )`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    ),
  );
  diffs.push({ table: 'APR_DATA', insert: 0, update: 0, delete: aprDataDelete });

  return compactDiffs(diffs);
}

export async function applyEstimateReset(
  prisma: any,
  inputScope: EstimateResetScope,
  options: { asOfDate?: unknown; confirmed?: boolean; confirmation?: unknown } = {},
): Promise<EstimateResetApplied> {
  assertConfirmation(options as Record<string, unknown>);
  const scope = requiredScope(inputScope);
  const asOfDate = dateOnly(options.asOfDate);
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    const companyType = await ensureCompanyAllowsResetTx(tx, scope);
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `estimate-reset:${scope.tenantId}:${scope.coCode}:${scope.lcCode}:${scope.coYear}`,
    );
    await prepareCandidateTablesTx(tx, scope, asOfDate);
    const samples = await samplesTx(tx);
    const selectedVouchers = await selectedVoucherTotalTx(tx);
    const stockAdjustmentDetails = await countTemp(tx, 'estimate_reset_adjust_rows');
    const diffs = await applyDeletesTx(tx, scope);
    return {
      ...buildPreview(
        scope,
        asOfDate,
        companyType,
        diffs,
        samples,
        selectedVouchers,
        stockAdjustmentDetails,
      ),
      applied: true as const,
    };
  });
}
