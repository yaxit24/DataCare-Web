import { withTxBudget } from '../shared/txBudget.js';

/**
 * Size-wise stock movement (desktop `RP_STK_MOVE`, menu caption "Movement").
 *
 * WHAT IT ANSWERS
 * Every other stock report in the web aggregates by item, group, party or location. This one groups by
 * SIZE, which is the merchandising question: a ring range can look healthy in total while every
 * saleable size is gone and only the extremes remain. The desktop has two variants and both are kept
 * as modes:
 *   'item'   — SUM(CASE WHEN ITM_SIGN='+' THEN 1 ELSE -1 END) by IT_CODE + ITM_SIZE
 *   'design' — the same net, by DESIGN_NO + ITM_SIZE
 *
 * THE COUNT IS PIECES, NOT WEIGHT, and it is a NET of movement signs rather than a snapshot — the
 * desktop counts each '+' as one and each '-' as minus one, so a tag that came in and went out
 * contributes zero. Size lives on `BAR_DETL`, so the join is MAIN_STOCK -> BAR_DETL on the tag
 * instance (TAG_NO + VCH_SRNO); joining on the tag number alone would double-count a repeated number.
 *
 * Read-only and RLS-scoped.
 */
export type MovementMode = 'item' | 'design';

export interface MovementRow {
  /** IT_CODE in 'item' mode, DESIGN_NO in 'design' mode. */
  key: string;
  name: string | null;
  size: string;
  /** Net pieces: '+' movements minus '-' movements for this key and size. */
  pcs: number;
}

export interface MovementReport {
  mode: MovementMode;
  rows: MovementRow[];
  totals: {
    count: number;
    pcs: number;
    /** Distinct sizes seen, and how many rows are net-zero (fully sold through). */
    sizes: number;
    soldThrough: number;
  };
}

const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s === '' ? null : s;
};
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};

export async function movementReport(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  options: { mode?: MovementMode; itCode?: string; inStockOnly?: boolean } = {},
): Promise<MovementReport> {
  const mode: MovementMode = options.mode ?? 'item';
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    const filters = ['a."CO_CODE"::text=$1', 'a."LC_CODE"::text=$2'];
    if (options.itCode) {
      params.push(options.itCode);
      filters.push(`a."IT_CODE"::text=$${params.length}`);
    }
    // Size only exists on a tagged piece; loose stock has no size to group by.
    filters.push(`coalesce(a."TAG_NO"::text,'N') <> 'N'`);

    // In 'design' mode the desktop reports DESIGN_NO in both the key and the name column, because a
    // design has no separate description — reproduced rather than substituting the item name.
    const keyCol = mode === 'design' ? 'b."DESIGN_NO"' : 'a."IT_CODE"';
    const nameCol = mode === 'design' ? 'b."DESIGN_NO"' : 'c."IT_NAME"';

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${keyCol} AS "KEY", ${nameCol} AS "NAME",
              coalesce(b."ITM_SIZE"::text,'') AS "ITM_SIZE",
              SUM(CASE WHEN a."ITM_SIGN"::text='+' THEN 1 ELSE -1 END) AS "PCS"
         FROM "MAIN_STOCK" a
         LEFT JOIN "BAR_DETL" b
           ON b."CO_CODE"::text=a."CO_CODE"::text AND b."LC_CODE"::text=a."LC_CODE"::text
          AND b."TAG_NO"::text=a."TAG_NO"::text
          AND coalesce(b."VCH_SRNO",0)=coalesce(a."VCH_SRNO",0)
         LEFT JOIN "ITEM_MAST" c
           ON c."CO_CODE"::text=a."CO_CODE"::text AND c."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${filters.join(' AND ')}
        GROUP BY ${keyCol}, ${nameCol}, coalesce(b."ITM_SIZE"::text,'')
        ORDER BY ${keyCol}, coalesce(b."ITM_SIZE"::text,'')`,
      ...params,
    );

    let mapped: MovementRow[] = rows
      .filter((r) => txt(r.KEY) !== null)
      .map((r) => ({
        key: String(r.KEY),
        name: txt(r.NAME),
        size: String(r.ITM_SIZE ?? ''),
        pcs: num(r.PCS),
      }));
    // Optional: hide the rows that have netted to nothing, which is what a buyer re-ordering wants.
    if (options.inStockOnly) mapped = mapped.filter((r) => r.pcs > 0);

    return {
      mode,
      rows: mapped,
      totals: {
        count: mapped.length,
        pcs: mapped.reduce((s, r) => s + r.pcs, 0),
        sizes: new Set(mapped.map((r) => r.size)).size,
        // A net of zero means everything of that key and size has moved out — the signal a size needs
        // re-ordering, which is the whole point of grouping this way.
        soldThrough: mapped.filter((r) => r.pcs === 0).length,
      },
    };
  });
}
