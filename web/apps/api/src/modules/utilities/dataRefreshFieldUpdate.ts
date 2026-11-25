import { createHash } from 'node:crypto';
import { diff, registerRepair, type RepairTableDiff } from './dataRepair.js';

/**
 * Field Update (`btnFildUpdate_Click`, `MS_UPDATE.cs:3958-8807`): the two statements of its 520 writes that
 * repair web data (class a in `orchestration/work/WP-24/field-update.md`). The 172 class b statements are
 * anomaly queries that must find nothing (`dataRefreshFieldAnomalies.db.test.ts`); the 219 class c are the
 * migration loader and are not built here.
 *
 *   A1 `MS_UPDATE.cs:7214` AC_MAST.AC_MAIN_GR follows AC_GROUP.AC_MAIN_GR when the two differ. Like the
 *      desktop `<>` it ignores NULL on either side and only repairs the selected location.
 *   A2 `MS_UPDATE.cs:8608` AC_MAST.DEFAULTER_AC NULL becomes 'N' across all locations. The desktop has
 *      no company filter; the web deliberately scopes to the session tenant and company for safety.
 *
 * Both run as ONE statement so a row that needs both is counted and written once.
 */

const GROUP = `LEFT JOIN LATERAL (
  SELECT g."AC_MAIN_GR" FROM "AC_GROUP" g
   WHERE g.tenant_id=m.tenant_id AND g."CO_CODE"=m."CO_CODE" AND g."AC_GR"=m."AC_GR"
   ORDER BY g.row_id LIMIT 1
) grp ON true`;
const MISMATCH = `(m."AC_MAIN_GR" <> grp."AC_MAIN_GR")`;
const SCOPED_MISMATCH = `(${MISMATCH} AND ($2::text='' OR m."LC_CODE"=$2))`;
const NULL_DEFAULTER = `(m."DEFAULTER_AC" IS NULL)`;
const WHERE = `m.tenant_id=current_setting('app.tenant_id',true)
  AND m."CO_CODE"=$1
  AND (${SCOPED_MISMATCH} OR ${NULL_DEFAULTER})`;

registerRepair({
  id: 'data-refresh-field-update',
  title: 'Field Update',
  description:
    'Re-aligns AC_MAST main group with its account group and fills a blank defaulter flag with N. Every other Field Update statement is a desktop schema, catalog or migration step the web does not run.',
  desktopSource: 'MS_UPDATE.cs:3958-8807',
  risk: 'medium',
  applyAvailable: true,
  completionText: 'Field Is Update ok....Please Re open Software',
  tables: ['AC_MAST'],
  async preview(tx, scope) {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT m."AC_CODE" AS code,
              CASE WHEN ${SCOPED_MISMATCH} THEN 'main group ' || coalesce(m."AC_MAIN_GR",'') || ' -> ' || grp."AC_MAIN_GR" ELSE '' END AS gr,
              CASE WHEN ${NULL_DEFAULTER} THEN 'defaulter blank -> N' ELSE '' END AS df
         FROM "AC_MAST" m ${GROUP}
        WHERE ${WHERE}
        ORDER BY m."AC_CODE",m.row_id`,
      scope.coCode,
      scope.lcCode ?? '',
    );
    const diffs: RepairTableDiff[] = rows.length ? [diff('AC_MAST', { update: rows.length })] : [];
    return {
      diffs,
      samples: rows
        .slice(0, 20)
        .map((r) => `AC_MAST ${r.code}: ${[r.gr, r.df].filter(Boolean).join('; ')}`),
      candidateFingerprint: createHash('sha256').update(JSON.stringify(rows)).digest('hex'),
    };
  },
  async apply(tx, scope) {
    const n: number = await tx.$executeRawUnsafe(
      `UPDATE "AC_MAST" t
          SET "AC_MAIN_GR"=CASE WHEN x.mismatch THEN x.gr ELSE t."AC_MAIN_GR" END,
              "DEFAULTER_AC"=coalesce(t."DEFAULTER_AC",'N')
         FROM (
           SELECT m.row_id, ${SCOPED_MISMATCH} AS mismatch, grp."AC_MAIN_GR" AS gr
             FROM "AC_MAST" m ${GROUP}
            WHERE ${WHERE}
         ) x
        WHERE t.row_id=x.row_id AND t.tenant_id=current_setting('app.tenant_id',true)`,
      scope.coCode,
      scope.lcCode ?? '',
    );
    return n ? [diff('AC_MAST', { update: n })] : [];
  },
});
