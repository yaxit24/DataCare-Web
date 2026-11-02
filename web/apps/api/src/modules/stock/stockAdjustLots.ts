import { withTxBudget } from '../shared/txBudget.js';
import type { VoucherScope } from '../vouchers/numbering.js';

/**
 * The Stock Adjust grid's lot helps (TR_TAG_CAN.cs:4089-4188), shown only with Purchase LOT (TagLot, col 2) and Item
 * With LOT Stock (ItmLot, col 3):
 * - TagLot lists `LOT_DETL` lots of the location by lot and item, with the signed pieces, gross and net weight
 *   (`SUM(CASE WHEN IT_SIGN = '+' …)`), leaving out a lot whose gross plus net weight is 0;
 * - ItmLot lists the same from `MAIN_STOCK` loose rows (`TAG_NO = 'N'`) by `ITM_LOT`.
 * Both order by lot, then item name. Choosing one fills the item, pieces, weights and the less weight (gross - net).
 */
export type StockAdjustLotKind = 'tag' | 'item';

export interface StockAdjustLotRow {
  /** The lot number (the help's first column, what the cell keeps). */
  code: string;
  /** The item name, as the help shows it beside the lot. */
  name: string;
  itCode: string;
  pcs: number;
  grossWt: number;
  netWt: number;
}

export class StockAdjustLotValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'StockAdjustLotValidationError';
  }
}

const SOURCES: Record<
  StockAdjustLotKind,
  { table: string; lot: string; sign: string; pcs: string; gwt: string; nwt: string; extra: string }
> = {
  tag: {
    table: 'LOT_DETL',
    lot: 'LOT_NO',
    sign: 'IT_SIGN',
    pcs: 'IT_PCS',
    gwt: 'IT_GWT',
    nwt: 'IT_NWT',
    extra: '',
  },
  item: {
    table: 'MAIN_STOCK',
    lot: 'ITM_LOT',
    sign: 'ITM_SIGN',
    pcs: 'ITM_PCS',
    gwt: 'ITM_GWT',
    nwt: 'ITM_NWT',
    extra: ` AND A."TAG_NO" = 'N'`,
  },
};

export async function stockAdjustLots(
  prisma: any,
  scope: Pick<VoucherScope, 'tenantId' | 'coCode' | 'lcCode'>,
  kindRaw: unknown,
  termRaw: unknown,
  limitRaw?: unknown,
): Promise<StockAdjustLotRow[]> {
  const kind = String(kindRaw ?? '').trim();
  if (kind !== 'tag' && kind !== 'item') {
    throw new StockAdjustLotValidationError('kind must be tag (TagLot) or item (ItmLot)');
  }
  const s = SOURCES[kind];
  const term = String(termRaw ?? '')
    .replace(/'/g, '')
    .trim()
    .toUpperCase();
  const limit = Math.min(Math.max(Number(limitRaw) || 50, 1), 100);
  const signed = (column: string) =>
    `SUM(CASE WHEN A."${s.sign}" = '+' THEN coalesce(A."${column}",0) ELSE -coalesce(A."${column}",0) END)`;
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT A."${s.lot}" AS lot, A."IT_CODE" AS it_code, B."IT_NAME" AS it_name,
              ${signed(s.pcs)}::text AS pcs, ${signed(s.gwt)}::text AS gwt, ${signed(s.nwt)}::text AS nwt
         FROM "${s.table}" AS A
         LEFT JOIN "ITEM_MAST" AS B ON B.tenant_id = A.tenant_id AND B."CO_CODE" = A."CO_CODE" AND B."IT_CODE" = A."IT_CODE"
        WHERE A.tenant_id = $1 AND A."CO_CODE" = $2 AND A."LC_CODE" = $3
          AND coalesce(A."${s.lot}", '') <> '' AND upper(A."${s.lot}") LIKE $4${s.extra}
        GROUP BY A."${s.lot}", A."IT_CODE", B."IT_NAME"
       HAVING ${signed(s.gwt)} + ${signed(s.nwt)} <> 0
        ORDER BY A."${s.lot}", B."IT_NAME", A."IT_CODE"
        LIMIT $5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      `${term.replace(/[\\%_]/g, (c) => `\\${c}`)}%`,
      limit,
    ),
  );
  return rows.map((r) => ({
    code: String(r.lot ?? '').trim(),
    name: String(r.it_name ?? '').trim(),
    itCode: String(r.it_code ?? '').trim(),
    pcs: Number(r.pcs ?? 0),
    grossWt: Number(r.gwt ?? 0),
    netWt: Number(r.nwt ?? 0),
  }));
}
