import { createHash } from 'node:crypto';
import {
  diff,
  getRepair,
  registerRepair,
  RepairError,
  type RepairScope,
  type RepairTableDiff,
} from './dataRepair.js';

/**
 * The six operator-visible MS_UPDATE actions. Account, Stock, Field Update, Image Data and Old Field are
 * intentionally classifications in this milestone. Their desktop graphs are not proved safe to execute on
 * shared PostgreSQL data. Approval Adj is the only complete writer here.
 */

const fingerprint = (value: unknown): string =>
  createHash('sha256').update(JSON.stringify(value)).digest('hex');

const refuseApply = (reason: string) => async (): Promise<RepairTableDiff[]> => {
  throw new RepairError('preview-only', reason);
};

const blocked = {
  account:
    'Full Account apply is unavailable: the complete Ac_Ledr, Ac_Rojmel and Ac_Tax builder graph after AcRefresh is not yet proved.',
  stock:
    'Full Stock apply is unavailable: the remaining Ac_Stock builder graph after StockRefresh is not yet proved.',
  field:
    'Field Update is classification-pending; its legacy statements must be classified as web repair, historical anomaly, or migration-loader work before apply is safe.',
  image:
    'Image Data apply is unavailable: TAG_IMAGE_DATA is committed schema, while legacy MOB_IMAGE, IMG_IMPORT and CONV_IMAGE semantics are unproved and runtime schema mutation is forbidden.',
  oldField:
    'Old Field is classification-pending; its legacy statements must be classified as web repair, historical anomaly, or migration-loader work before apply is safe.',
} as const;

registerRepair({
  id: 'data-refresh-account',
  title: 'Account',
  description:
    'Classifies the proven book flag, cash clearing-date and bank-reconciliation anomalies. It does not run the unproved full AcRefresh ledger rebuild.',
  desktopSource: 'MS_UPDATE.cs:2334-2669',
  risk: 'danger',
  applyAvailable: false,
  blockedReason: blocked.account,
  completionText: 'Account Refersh Process Complete.',
  tables: ['BOOK_DATA', 'BOOK_DETL', 'CASH_DATA', 'BANK_RECONCILE'],
  async preview(tx, scope) {
    const partial = await getRepair('ledger-normalise').preview(tx, scope);
    return {
      ...partial,
      samples: [...partial.samples, blocked.account],
      candidateFingerprint: fingerprint([partial.diffs, partial.samples]),
    };
  },
  apply: refuseApply(blocked.account),
});

registerRepair({
  id: 'data-refresh-stock',
  title: 'Stock',
  description:
    'Classifies missing tag fine-weight candidates from the opening Stock refresh step. It does not run the unproved full StockRefresh builder graph.',
  desktopSource: 'MS_UPDATE.cs:2671-3047',
  risk: 'danger',
  applyAvailable: false,
  blockedReason: blocked.stock,
  completionText: 'Stock Refresh Process Complete.',
  tables: ['BAR_DETL', 'SL_DETL_RTN', 'MAIN_STOCK'],
  async preview(tx, scope) {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT b.row_id::text AS id,b."TAG_NO" AS tag,b."VCH_SRNO" AS serial,
              coalesce(b."ITM_FINE",0)::text AS stored,
              round(CASE WHEN coalesce(b."ITM_NWT",0) <> 0
                THEN coalesce(b."ITM_NWT",0) *
                     (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) / 100.0
                ELSE 0 END,3)::text AS expected
         FROM "BAR_DETL" b
        WHERE b.tenant_id=current_setting('app.tenant_id',true)
          AND b."CO_CODE"=$1 AND ($2::text='' OR b."LC_CODE"=$2)
          AND ($3::text='' OR b."CO_YEAR"=$3)
          AND (coalesce(b."ITM_TOUCH",0)+coalesce(b."ITM_WEST_PRC",0))<>0
          AND coalesce(b."ITM_FINE",0)<=0
          AND coalesce(b."ITM_FINE",0)<>round(CASE WHEN coalesce(b."ITM_NWT",0) <> 0
                THEN coalesce(b."ITM_NWT",0) *
                     (coalesce(b."ITM_TOUCH",0) + coalesce(b."ITM_WEST_PRC",0)) / 100.0
                ELSE 0 END,3)
        ORDER BY b."TAG_NO",b."VCH_SRNO",b.row_id`,
      scope.coCode,
      scope.lcCode ?? '',
      scope.coYear ?? '',
    );
    return {
      diffs: rows.length ? [diff('BAR_DETL', { update: rows.length })] : [],
      samples: [
        ...rows
          .slice(0, 20)
          .map((r) => `BAR_DETL ${r.tag}/${r.serial}: ITM_FINE ${r.stored} -> ${r.expected}`),
        blocked.stock,
      ],
      candidateFingerprint: fingerprint(rows),
    };
  },
  apply: refuseApply(blocked.stock),
});

registerRepair({
  id: 'data-refresh-field-update',
  title: 'Field Update',
  description: 'Visible desktop action retained as a classification-pending milestone item.',
  desktopSource: 'MS_UPDATE.cs:3958-8807',
  risk: 'danger',
  applyAvailable: false,
  blockedReason: blocked.field,
  completionText: 'Field Is Update ok....Please Re open Software',
  tables: ['BOOK_DATA'],
  async preview() {
    return { diffs: [], samples: [blocked.field], candidateFingerprint: fingerprint([]) };
  },
  apply: refuseApply(blocked.field),
});

const CONSUMED = `
  EXISTS (
    SELECT 1 FROM "APR_DETL" r
     WHERE r.tenant_id=i.tenant_id AND r."CO_CODE"=i."CO_CODE" AND r."LC_CODE"=i."LC_CODE"
       AND r."BOOK_NAME"='APR RTN' AND coalesce(btrim(r."ISU_NO"),'')<>''
       AND r."ISU_YRCD"=i."CO_YEAR" AND r."ISU_DBCD"=i."CO_BOOK"
       AND r."ISU_NO"=i."VCH_NO" AND r."ISU_SRNO"=i."OLD_SRNO"
  ) OR EXISTS (
    SELECT 1 FROM "SL_DETL" s
     WHERE s.tenant_id=i.tenant_id AND s."CO_CODE"=i."CO_CODE" AND s."LC_CODE"=i."LC_CODE"
       AND s."BOOK_NAME"='SALES' AND coalesce(btrim(s."ISU_NO"),'')<>''
       AND s."ISU_YRCD"=i."CO_YEAR" AND s."ISU_DBCD"=i."CO_BOOK"
       AND s."ISU_NO"=i."VCH_NO" AND s."ISU_SRNO"=i."OLD_SRNO"
  ) OR EXISTS (
    SELECT 1 FROM "RATE_CUT_ISU" w
     WHERE w.tenant_id=i.tenant_id AND w."CO_CODE"=i."CO_CODE" AND w."LC_CODE"=i."LC_CODE"
       AND w."BOOK_NAME"='WH SALES' AND coalesce(btrim(w."ISU_NO"),'')<>''
       AND w."ISU_YRCD"=i."CO_YEAR" AND w."ISU_DBCD"=i."CO_BOOK"
       AND w."ISU_NO"=i."VCH_NO" AND w."ISU_SRNO"=i."OLD_SRNO"
  ) OR EXISTS (
    SELECT 1 FROM "RATE_CUT_ISU" c
     WHERE c.tenant_id=i.tenant_id AND c."CO_CODE"=i."CO_CODE" AND c."LC_CODE"=i."LC_CODE"
       AND c."BOOK_NAME"='RATE CUT' AND coalesce(btrim(c."ISU_NO"),'')<>''
       AND c."ISU_YRCD"=i."CO_YEAR" AND c."ISU_DBCD"=i."CO_BOOK"
       AND c."ISU_NO"=i."VCH_NO" AND c."ISU_SRNO"=i."OLD_SRNO"
  )`;

const ISSUE_EXPECTED = `CASE WHEN (${CONSUMED}) THEN 'Y' ELSE 'N' END`;
const BAR_EXPECTED = `CASE WHEN EXISTS (
  SELECT 1 FROM "APR_DETL" i
   WHERE i.tenant_id=b.tenant_id AND i."CO_CODE"=b."CO_CODE" AND i."LC_CODE"=b."LC_CODE"
     AND i."CO_YEAR"=b."CO_YEAR" AND i."BOOK_NAME"='APR ISU'
     AND i."TAG_NO"=b."TAG_NO" AND i."VCH_SRNO"=b."VCH_SRNO"
     AND NOT (${CONSUMED})
) THEN 'Y' ELSE 'N' END`;

registerRepair({
  id: 'approval-reconcile',
  title: 'Approval Adj',
  description:
    'Recomputes APR ISU consumed status from APR RTN, SALES, WH SALES and RATE CUT references, then marks only unconsumed issue tags as on approval.',
  desktopSource: 'MS_UPDATE.cs:8809-8823',
  risk: 'medium',
  applyAvailable: true,
  completionText: 'Approval Refersh Process Complete.',
  tables: ['APR_DETL', 'BAR_DETL'],
  async preview(tx, scope) {
    const params = [scope.coCode, scope.lcCode ?? '', scope.coYear ?? ''];
    const issues: any[] = await tx.$queryRawUnsafe(
      `SELECT i.row_id::text AS id,i."TAG_NO" AS tag,coalesce(i."ISU_REC",'') AS stored,
              ${ISSUE_EXPECTED} AS expected
         FROM "APR_DETL" i
        WHERE i.tenant_id=current_setting('app.tenant_id',true)
          AND i."CO_CODE"=$1 AND ($2::text='' OR i."LC_CODE"=$2)
          AND ($3::text='' OR i."CO_YEAR"=$3) AND i."BOOK_NAME"='APR ISU'
          AND coalesce(i."ISU_REC",'')<>${ISSUE_EXPECTED}
        ORDER BY i."CO_YEAR",i."CO_BOOK",i."VCH_NO",i."OLD_SRNO",i.row_id`,
      ...params,
    );
    const bars: any[] = await tx.$queryRawUnsafe(
      `SELECT b.row_id::text AS id,b."TAG_NO" AS tag,coalesce(b."APR_ISU",'') AS stored,
              ${BAR_EXPECTED} AS expected
         FROM "BAR_DETL" b
        WHERE b.tenant_id=current_setting('app.tenant_id',true)
          AND b."CO_CODE"=$1 AND ($2::text='' OR b."LC_CODE"=$2)
          AND ($3::text='' OR b."CO_YEAR"=$3)
          AND coalesce(b."APR_ISU",'')<>${BAR_EXPECTED}
        ORDER BY b."TAG_NO",b."VCH_SRNO",b.row_id`,
      ...params,
    );
    const diffs: RepairTableDiff[] = [];
    if (issues.length) diffs.push(diff('APR_DETL', { update: issues.length }));
    if (bars.length) diffs.push(diff('BAR_DETL', { update: bars.length }));
    const samples = [
      ...issues
        .slice(0, 10)
        .map((r) => `APR_DETL ${r.tag}: ISU_REC ${r.stored || '(blank)'} -> ${r.expected}`),
      ...bars
        .slice(0, 10)
        .map((r) => `BAR_DETL ${r.tag}: APR_ISU ${r.stored || '(blank)'} -> ${r.expected}`),
    ];
    return {
      diffs,
      samples,
      candidateFingerprint: fingerprint({ issues, bars }),
    };
  },
  async apply(tx, scope) {
    const params = [scope.coCode, scope.lcCode ?? '', scope.coYear ?? ''];
    const apr: number = await tx.$executeRawUnsafe(
      `UPDATE "APR_DETL" i SET "ISU_REC"=${ISSUE_EXPECTED}
        WHERE i.tenant_id=current_setting('app.tenant_id',true)
          AND i."CO_CODE"=$1 AND ($2::text='' OR i."LC_CODE"=$2)
          AND ($3::text='' OR i."CO_YEAR"=$3) AND i."BOOK_NAME"='APR ISU'
          AND coalesce(i."ISU_REC",'')<>${ISSUE_EXPECTED}`,
      ...params,
    );
    const bar: number = await tx.$executeRawUnsafe(
      `UPDATE "BAR_DETL" b SET "APR_ISU"=${BAR_EXPECTED}
        WHERE b.tenant_id=current_setting('app.tenant_id',true)
          AND b."CO_CODE"=$1 AND ($2::text='' OR b."LC_CODE"=$2)
          AND ($3::text='' OR b."CO_YEAR"=$3)
          AND coalesce(b."APR_ISU",'')<>${BAR_EXPECTED}`,
      ...params,
    );
    const applied: RepairTableDiff[] = [];
    if (apr) applied.push(diff('APR_DETL', { update: apr }));
    if (bar) applied.push(diff('BAR_DETL', { update: bar }));
    return applied;
  },
});

registerRepair({
  id: 'data-refresh-image-data',
  title: 'Image Data',
  description:
    'Classifies the committed web image architecture. It performs no runtime DDL and copies no bytes.',
  desktopSource: 'MS_UPDATE.cs:8825-9038',
  risk: 'danger',
  applyAvailable: false,
  blockedReason: blocked.image,
  completionText: 'Image Data Carete Process Complete.',
  tables: ['TAG_IMAGE_DATA'],
  async preview() {
    const samples = [
      'TAG_IMAGE_DATA is committed with tenant/company/location/tag/serial identity.',
      'Legacy MOB_IMAGE, IMG_IMPORT and CONV_IMAGE flags have no proven web semantics.',
      blocked.image,
    ];
    return { diffs: [], samples, candidateFingerprint: fingerprint(samples) };
  },
  apply: refuseApply(blocked.image),
});

registerRepair({
  id: 'data-refresh-old-field',
  title: 'Old Field',
  description: 'Visible desktop action retained as a classification-pending milestone item.',
  desktopSource: 'MS_UPDATE.cs:9412-33074',
  risk: 'danger',
  applyAvailable: false,
  blockedReason: blocked.oldField,
  completionText: 'Old Field Is Update ok....Please Re open Software',
  tables: ['BOOK_DATA'],
  async preview() {
    return { diffs: [], samples: [blocked.oldField], candidateFingerprint: fingerprint([]) };
  },
  apply: refuseApply(blocked.oldField),
});
