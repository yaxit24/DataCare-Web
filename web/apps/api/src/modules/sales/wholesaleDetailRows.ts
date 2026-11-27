import {
  commPassTotalIdtl,
  detailRowIsWritten,
  rollupWholesaleDetails,
  round,
  type WholesaleDetailResult,
} from '@datacare/core';

/**
 * TR_WH_SALE's hand-typed item-detail rows for a loose issue line (`MSG_IDTL`), and the fine kasar boxes, as the
 * writer needs them (WP-30). The arithmetic is `commPassTotalIdtl` in `@datacare/core`, the same function the screen
 * previews with; this module validates what arrives, resolves the item's type, rolls the rows into the line and reads
 * the stored rows back for the reopen.
 *
 * The hosted service refuses a negative or non-numeric figure (the desktop has no check; a web request is not a
 * keyboard) and a row on a line that names a tag, whose stones come from the tag (`wholesaleTagStones.ts`).
 */
type Row = Record<string, unknown>;

export class WholesaleDetailValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'WholesaleSaleValidationError';
  }
}

/** A detail row after validation and the desktop arithmetic, in the shape SL_IDTL stores. */
export interface ComputedDetail extends WholesaleDetailResult {
  itCode: string;
  dmCode: string;
  dmName: string;
  dmColor: string;
  dmSize: string;
  dmOrigin: string;
  dmRemark: string;
  dmSfNo: string;
  krLessPrc: number;
}

const TEXT_LIMITS = {
  itCode: 5,
  dmCode: 8,
  dmName: 50,
  dmColor: 15,
  dmSize: 20,
  dmOrigin: 20,
  dmRemark: 20,
  dmSfNo: 20,
} as const;
const NUMERIC = [
  'pcs',
  'pcsWt',
  'krLessPrc',
  'grossWt',
  'tagWt',
  'conPct',
  'krConPct',
  'rate',
  'itAmt',
  'discPct',
  'discAmt',
  'lbrRate',
  'lbrAmt',
  'netAmt',
] as const;

const isTagged = (tagNo: unknown): boolean => {
  const t = String(tagNo ?? '').trim();
  return t !== '' && t.toUpperCase() !== 'N';
};

function validateDetail(raw: unknown, line: number, index: number): Row {
  const where = `line ${line} detail row ${index + 1}`;
  if (raw == null || typeof raw !== 'object' || Array.isArray(raw))
    throw new WholesaleDetailValidationError(`${where} must be an object`);
  const source = raw as Row;
  const out: Row = {};
  for (const field of NUMERIC) {
    const value = source[field];
    const parsed = value == null || value === '' ? 0 : Number(value);
    if (!Number.isFinite(parsed))
      throw new WholesaleDetailValidationError(`${where}: ${field} is not a number`);
    if (parsed < 0)
      throw new WholesaleDetailValidationError(`${where}: ${field} cannot be negative`);
    out[field] = parsed;
  }
  for (const [field, limit] of Object.entries(TEXT_LIMITS)) {
    const text = String(source[field] ?? '').trim();
    if (text.length > limit)
      throw new WholesaleDetailValidationError(
        `${where}: ${field} is longer than ${limit} characters`,
      );
    out[field] = text;
  }
  out.rateType = String(source.rateType ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  out.itType = String(source.itType ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  return out;
}

export interface WholesaleDetailPlan {
  /** The issue line with the rows rolled into it (cols 16, 17, 28, 37), or the line itself when it has none. */
  patch: (line: any, index: number) => any;
  /** Computed rows by the line's serial (index + 1). */
  rows: Map<number, ComputedDetail[]>;
}

/** Validate every line's `details`, run the desktop arithmetic and prepare the roll-up. */
export async function planWholesaleDetails(
  tx: any,
  tenantId: string,
  coCode: string,
  lines: any[],
): Promise<WholesaleDetailPlan> {
  const rows = new Map<number, ComputedDetail[]>();
  const types = new Map<string, string>();
  const typeOf = async (itCode: string): Promise<string> => {
    if (!itCode) return '';
    if (!types.has(itCode)) {
      const found: Array<{ t: string | null }> = await tx.$queryRawUnsafe(
        `SELECT "IT_TYPE" AS t FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 LIMIT 1`,
        tenantId,
        coCode,
        itCode,
      );
      types.set(
        itCode,
        String(found[0]?.t ?? '')
          .trim()
          .toUpperCase(),
      );
    }
    return types.get(itCode)!;
  };
  const rollups = new Map<number, ReturnType<typeof rollupWholesaleDetails>>();
  for (const [i, line] of lines.entries()) {
    if (line?.details === undefined) continue;
    if (!Array.isArray(line.details))
      throw new WholesaleDetailValidationError(`line ${i + 1}: details must be an array`);
    if (line.details.length && isTagged(line.tagNo))
      throw new WholesaleDetailValidationError(
        `line ${i + 1} names tag ${String(line.tagNo).trim()}: a tagged line takes its stones from the tag, not from typed detail rows`,
      );
    const computed: ComputedDetail[] = [];
    for (const [k, raw] of line.details.entries()) {
      const v = validateDetail(raw, i + 1, k);
      const result = commPassTotalIdtl({
        pcs: v.pcs as number,
        pcsWt: v.pcsWt as number,
        weight: v.grossWt as number,
        tagWt: v.tagWt as number,
        conPct: v.conPct as number,
        krConPct: v.krConPct as number,
        rateType: v.rateType as string,
        rate: v.rate as number,
        itAmt: v.itAmt as number,
        discPct: v.discPct as number,
        discAmt: v.discAmt as number,
        lbrRate: v.lbrRate as number,
        lbrAmt: v.lbrAmt as number,
        netAmt: v.netAmt as number,
        itType: (v.itType as string) || (await typeOf(v.itCode as string)),
      });
      computed.push({
        ...result,
        itCode: v.itCode as string,
        dmCode: v.dmCode as string,
        dmName: v.dmName as string,
        dmColor: v.dmColor as string,
        dmSize: v.dmSize as string,
        dmOrigin: v.dmOrigin as string,
        dmRemark: v.dmRemark as string,
        dmSfNo: v.dmSfNo as string,
        krLessPrc: v.krLessPrc as number,
      });
    }
    rows.set(i + 1, computed);
    rollups.set(i + 1, rollupWholesaleDetails(computed, Number(line.grossWt ?? 0) || 0));
  }
  return {
    rows,
    patch: (line, index) => {
      const up = rollups.get(index + 1);
      if (!up) return line;
      const out = { ...line };
      if (up.othWt != null) {
        out.othWt = up.othWt;
        out.netWt = up.netWt;
      }
      if (up.krNwt != null) out.krNetWt = up.krNwt;
      if (up.othAmt != null) out.othAmt = up.othAmt;
      if (up.silverFine != null) out.silverFine = up.silverFine;
      return out;
    },
  };
}

/** The SL_IDTL rows of one loose line, in the order the desktop writes them (ISR_NO from 1, empty rows skipped). */
export function writtenDetails(rows: ComputedDetail[]): ComputedDetail[] {
  return rows.filter((row) => detailRowIsWritten(row));
}

/**
 * An edit that sends no `details` for a line whose stored rows exist would drop them silently: the line is matched
 * by its serial, and the serial of a line can move when another is removed. Refuse it; `[]` removes the rows.
 */
export async function assertDetailsSent(
  tx: any,
  key: {
    tenantId: string;
    CO_CODE: string;
    LC_CODE: string;
    CO_YEAR: string;
    CO_BOOK: string;
    VCH_NO: string;
  },
  lines: any[],
  canDeleteRows?: boolean,
): Promise<void> {
  if (canDeleteRows === false) await assertNoDetailDeletion(tx, key, lines);
  const stored: Array<{ sr: number }> = await tx.$queryRawUnsafe(
    `SELECT DISTINCT "SR_NO"::int AS sr FROM "SL_IDTL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND coalesce("TAG_NO",'') IN ('','N')`,
    key.tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  for (const { sr } of stored) {
    const line = lines[sr - 1];
    if (line && line.details === undefined && !isTagged(line.tagNo))
      throw new WholesaleDetailValidationError(
        `line ${sr} carries item-detail rows: send its details (an empty list removes them)`,
      );
  }
}

/** Fine kasar from the request: absent means 0; a negative or non-numeric value is refused; stored to 3 places. */
export function kasarFine(raw: unknown, label: string): number {
  if (raw == null || raw === '') return 0;
  const value = Number(raw);
  if (!Number.isFinite(value)) throw new WholesaleDetailValidationError(`${label} is not a number`);
  if (value < 0) throw new WholesaleDetailValidationError(`${label} cannot be negative`);
  return round(value, 3);
}

/** The stored rows of a voucher by line serial, as the reopen returns them and as the print draws them. */
export async function readStoredDetails(
  tx: any,
  key: {
    tenantId: string;
    CO_CODE: string;
    LC_CODE: string;
    CO_YEAR: string;
    CO_BOOK: string;
    VCH_NO: string;
  },
): Promise<Map<number, Row[]>> {
  const found: Row[] = await tx.$queryRawUnsafe(
    `SELECT A.*, B."IT_NAME" AS item_name FROM "SL_IDTL" A
       LEFT JOIN "ITEM_MAST" B ON B.tenant_id=A.tenant_id AND B."CO_CODE"=A."CO_CODE" AND B."IT_CODE"=A."IT_CODE"
      WHERE A.tenant_id=$1 AND A."CO_CODE"=$2 AND A."LC_CODE"=$3 AND A."CO_YEAR"=$4 AND A."CO_BOOK"=$5 AND A."VCH_NO"=$6
      ORDER BY A."SR_NO", A."ISR_NO", A.row_id`,
    key.tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  const t = (v: unknown): string => String(v ?? '').trim();
  const n = (v: unknown): number => Number(v ?? 0) || 0;
  const bySerial = new Map<number, Row[]>();
  for (const r of found) {
    const serial = n(r.SR_NO);
    const list = bySerial.get(serial) ?? [];
    list.push({
      isrNo: n(r.ISR_NO),
      itCode: t(r.IT_CODE),
      itemName: t(r.item_name),
      dmCode: t(r.DM_CODE),
      dmName: t(r.DM_NAME),
      dmColor: t(r.DM_COLOR),
      dmSize: t(r.DM_SIZE),
      dmOrigin: t(r.DM_ORIGIN),
      dmRemark: t(r.DM_REMARK),
      dmSfNo: t(r.DM_SFNO),
      pcs: n(r.IT_PCS),
      pcsWt: n(r.IT_PCS_WT),
      krLessPrc: n(r.KR_LESS_PRC),
      grossWt: n(r.IT_GWT),
      tagWt: n(r.KR_WT),
      conPct: n(r.IT_CON_PRC),
      conWt: n(r.IT_CON_WT),
      krConPct: n(r.KR_CON_PRC),
      rateType: t(r.IT_RATE_TYPE),
      rate: n(r.IT_RATE),
      itAmt: n(r.IT_AMT),
      discPct: n(r.IT_DISC_PRC),
      discAmt: n(r.IT_DISC_AMT),
      lbrRate: n(r.IT_LBR_RATE),
      lbrAmt: n(r.IT_LBR_AMT),
      netAmt: n(r.IT_NET_AMT),
      itType: t(r.IT_TYPE),
      tagNo: t(r.TAG_NO),
    });
    bySerial.set(serial, list);
  }
  return bySerial;
}

/** TR_WH_SALE.cs:7326: checked inside the edit transaction, before reversal, independently of the client. */
export async function assertNoDetailDeletion(
  tx: any,
  key: {
    tenantId: string;
    CO_CODE: string;
    LC_CODE: string;
    CO_YEAR: string;
    CO_BOOK: string;
    VCH_NO: string;
  },
  lines: any[],
): Promise<void> {
  const stored: Array<{ sr: number; count: number }> = await tx.$queryRawUnsafe(
    `SELECT "SR_NO"::int AS sr, count(*)::int AS count FROM "SL_IDTL"
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
       AND coalesce("TAG_NO",'') IN ('','N') GROUP BY "SR_NO"`,
    key.tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  const plan = await planWholesaleDetails(tx, key.tenantId, key.CO_CODE, lines);
  if (stored.some((row) => writtenDetails(plan.rows.get(row.sr) ?? []).length < row.count))
    throw new WholesaleDetailValidationError('You Have No Rights.....');
}
