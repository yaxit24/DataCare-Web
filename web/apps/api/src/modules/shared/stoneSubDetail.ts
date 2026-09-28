/**
 * Shared stone / karigar sub-detail columns for the `*_IDTL` tables.
 *
 * The desktop builds `SL_ORD_IDTL`, `KR_IDTL`, `BAR_CAN_IDTL`, `PR_IDTL` and `APR_IDTL` from the same
 * `TblIdtl` DataTable shape — one row per stone under an item line, carrying both the stone's own
 * valuation and the karigar (job-worker) side of it. Rather than repeat twenty-odd column mappings per
 * module, this helper produces the common block from one input shape.
 *
 * The two sides exist because a stone is priced twice: once to the customer (`IT_*`) and once for the
 * karigar's job-work settlement (`KR_*`). Dropping the `KR_*` block, as the web previously did, leaves the
 * karigar settlement with no basis for the stone portion of a job.
 */
export interface StoneSubDetailInput {
  /** Stone / diamond identity. */
  dmCode?: string;
  dmName?: string;
  dmSize?: string;
  dmSfNo?: string;
  dmColor?: string;
  dmOrigin?: string;
  dmRemark?: string;
  /** `DM_LEB` — certificate / lab reference. */
  dmLeb?: string;

  /** Customer-side valuation. */
  pcsWt?: number;
  conPct?: number;
  conWt?: number;
  rateType?: string;
  rate?: number;
  labourRate?: number;
  labourAmount?: number;

  /** Karigar-side valuation of the same stone. */
  karigarWt?: number;
  karigarLessPct?: number;
  karigarConPct?: number;
  karigarConWt?: number;
  karigarRate?: number;
  karigarAmount?: number;
  karigarLabourRate?: number;
  karigarLabourAmount?: number;
  karigarNetAmount?: number;
}

/** Column widths verified against the live schema; guessed widths cause 22001 at runtime. */
const WIDTHS = {
  DM_CODE: 8,
  DM_NAME: 50,
  DM_SIZE: 20,
  DM_SFNO: 20,
  DM_COLOR: 15,
  DM_ORIGIN: 20,
  DM_REMARK: 20,
  DM_LEB: 15,
  RATE_TYPE: 1,
} as const;

const n = (v: unknown): number => (v == null ? 0 : Number(v) || 0);
const t = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;

/**
 * The stone/karigar block shared by the `*_IDTL` tables.
 *
 * `include` lets a caller omit columns a particular table does not have — `KR_IDTL` has no `DM_COLOR`,
 * for instance — so the same input shape serves tables with slightly different column sets without
 * writing a column that does not exist.
 */
export function stoneSubDetailColumns(
  input: StoneSubDetailInput,
  options: { omit?: readonly string[] } = {},
): Record<string, unknown> {
  const all: Record<string, unknown> = {
    DM_CODE: t(input.dmCode, WIDTHS.DM_CODE),
    DM_NAME: t(input.dmName, WIDTHS.DM_NAME),
    DM_SIZE: t(input.dmSize, WIDTHS.DM_SIZE),
    DM_SFNO: t(input.dmSfNo, WIDTHS.DM_SFNO),
    DM_COLOR: t(input.dmColor, WIDTHS.DM_COLOR),
    DM_ORIGIN: t(input.dmOrigin, WIDTHS.DM_ORIGIN),
    DM_REMARK: t(input.dmRemark, WIDTHS.DM_REMARK),
    DM_LEB: t(input.dmLeb, WIDTHS.DM_LEB),

    IT_PCS_WT: n(input.pcsWt),
    IT_CON_PRC: n(input.conPct),
    IT_CON_WT: n(input.conWt),
    IT_RATE_TYPE: t(input.rateType, WIDTHS.RATE_TYPE),
    IT_RATE: n(input.rate),
    IT_LBR_RATE: n(input.labourRate ?? (input as Record<string, unknown>).lbrRate),
    IT_LBR_AMT: n(input.labourAmount ?? (input as Record<string, unknown>).lbrAmount),

    KR_WT: n(input.karigarWt),
    KR_LESS_PRC: n(input.karigarLessPct),
    KR_CON_PRC: n(input.karigarConPct),
    KR_CON_WT: n(input.karigarConWt),
    KR_RATE: n(input.karigarRate),
    KR_AMT: n(input.karigarAmount),
    KR_LBR_RATE: n(input.karigarLabourRate),
    KR_LBR_AMT: n(input.karigarLabourAmount),
    KR_NET_AMT: n(input.karigarNetAmount),
  };
  if (!options.omit?.length) return all;
  const omit = new Set(options.omit);
  return Object.fromEntries(Object.entries(all).filter(([key]) => !omit.has(key)));
}

/** The column names this helper produces, for tests and the depth audit. */
export const STONE_SUB_DETAIL_COLUMNS = Object.keys(stoneSubDetailColumns({}));

/**
 * Inverse of `stoneSubDetailColumns`: turn a persisted `*_IDTL` row back into the input shape.
 *
 * Exists because writing these rows without reading them back is a data-loss trap, not a cosmetic
 * omission. Every `*_IDTL` table sits in its voucher's write set, so an edit deletes and rebuilds
 * it from the request — and a request built from a reader that omitted the rows deletes them. That
 * defect was live on `PR_IDTL` (purchase) and `KR_IDTL` (karigar issue/receive and job-work
 * issue/receive, four screens), and is prevented from recurring by keeping the read and the write
 * adjacent and sharing one column list.
 *
 * Columns outside the shared block (`ISR_NO`, `IT_CODE`, `IT_PCS`, `IT_GWT`, `IT_AMT`,
 * `IT_NET_AMT`, `IT_TYPE`) are included because every consumer needs them, even though the writer
 * emits them per module rather than from the shared helper.
 */
export function readStoneSubDetail(row: Record<string, unknown>): Record<string, unknown> {
  const n = (value: unknown): number => Number(value ?? 0) || 0;
  const t = (value: unknown): string => String(value ?? '').trim();
  return {
    isrNo: n(row.ISR_NO),
    itCode: t(row.IT_CODE),
    itType: t(row.IT_TYPE),
    dmCode: t(row.DM_CODE),
    dmName: t(row.DM_NAME),
    dmSize: t(row.DM_SIZE),
    dmSfNo: t(row.DM_SFNO),
    dmColor: t(row.DM_COLOR),
    dmOrigin: t(row.DM_ORIGIN),
    dmRemark: t(row.DM_REMARK),
    dmLeb: t(row.DM_LEB),
    pcs: n(row.IT_PCS),
    grossWt: n(row.IT_GWT),
    pcsWt: n(row.IT_PCS_WT),
    conPct: n(row.IT_CON_PRC),
    conWt: n(row.IT_CON_WT),
    rateType: t(row.IT_RATE_TYPE),
    rate: n(row.IT_RATE),
    amount: n(row.IT_AMT),
    /**
     * `lbrRate` / `lbrAmount`, NOT `labourRate` / `labourAmount`.
     *
     * One column has two names in this codebase: the shared `StoneSubDetailInput` calls them
     * `labourRate`/`labourAmount`, while every module that writes an `*_IDTL` row explicitly reads
     * `stone.lbrRate`/`stone.lbrAmount` — purchase (`purchase.ts:977`), karigar, tour
     * (`tour.ts:317`) and tagOps (`tagOps.ts:223`) all agree on the short form. A reader emitting
     * the long form produced a payload the writers ignored, so replaying a read-back voucher
     * silently zeroed both columns. Emitting the form the writers consume is what closes the round
     * trip; `stoneSubDetailColumns` below now accepts either so neither name is a trap.
     */
    lbrRate: n(row.IT_LBR_RATE),
    lbrAmount: n(row.IT_LBR_AMT),
    netAmount: n(row.IT_NET_AMT),
    karigarWt: n(row.KR_WT),
    karigarLessPct: n(row.KR_LESS_PRC),
    karigarConPct: n(row.KR_CON_PRC),
    karigarConWt: n(row.KR_CON_WT),
    karigarRate: n(row.KR_RATE),
    karigarAmount: n(row.KR_AMT),
    karigarLabourRate: n(row.KR_LBR_RATE),
    karigarLabourAmount: n(row.KR_LBR_AMT),
    karigarNetAmount: n(row.KR_NET_AMT),
  };
}
