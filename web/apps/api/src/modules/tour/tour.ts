import { type StoneSubDetailInput } from '../shared/stoneSubDetail.js';
import { assertWestPct } from '../shared/counterStockPolicy.js';
import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx } from '../posting/posting.js';

/**
 * Tour / Approval Sale (TR_TOUR.cs — "Tour Issue / Tour IsuRec"). A salesman takes goods OUT on
 * approval ("on tour"); they are later either sold or returned. The desktop persists this into the
 * APPROVAL voucher tables — APR_DATA (header) / APR_DETL (lines) / APR_IDTL (sub-items) — and writes
 * a MAIN_STOCK out-movement per line via Ac_Stock.Tour_Isu_Stk. There is NO money ledger on issue
 * (pure inventory movement), so AC_DATA is empty — identical to a tag issue. Book 'TUR'.
 *
 * Verified against the live DB: APR_DATA / APR_DETL / MAIN_STOCK exist and every column written here
 * exists; the only NOT-NULL-without-default column on each is tenant_id (supplied by insertRowTx).
 */

export class TourValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'TourValidationError';
  }
}

/** One line of goods sent out on approval (weight-based, like a sale line). */
export interface TourIssueLine {
  // ---- Approval detail columns (APR_DETL) --------------------------------------------------------
  // TR_APR_ISU.cs stamps these on every approval line.
  lotNo?: string; // LOT_NO
  itmColor?: string; // ITM_COLOR
  tagCost?: number; // TAG_COST
  hallmarkId2?: string; // HM_ID2
  hallmarkId3?: string; // HM_ID3
  hallmarkId4?: string; // HM_ID4
  hallmarkIdWt?: number; // HM_ID_WT
  hallmarkId2Wt?: number; // HM_ID2_WT
  hallmarkId3Wt?: number; // HM_ID3_WT
  hallmarkId4Wt?: number; // HM_ID4_WT
  /** ADJ_GWT / ADJ_NWT / ITM_LESS_TCH / ITM_LOSS_WT are varchar in the restored schema. */
  adjustGrossWt?: number | string;
  adjustNetWt?: number | string;
  lessTouch?: number | string;
  lossWt?: number | string;
  itCode: string;
  tagNo?: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fineWt?: number; // explicit fine; else derived from netWt × touch / 100
  remark?: string;
  // Desktop APR_DETL grid columns (TR_APR_ISU.cs `mSG[i, c]`).
  isuAcName?: string; // mSG[i,3]  :6180
  metalColor?: string; // mSG[i,12] :6182
  isuAcCode?: string; // mSG[i,40] :6183
  tblCode?: string; // mSG[i,7]  :6202
  designNo?: string; // mSG[i,8]  :6203
  itmSize?: string; // mSG[i,9]  :6204
  huid?: string; // mSG[i,10] :6205
  bagWt?: number; // mSG[i,13] :6206
  lessWt?: number; // mSG[i,16] :6209
  ghtWt?: number; // mSG[i,19] :6211
  westPct?: number; // mSG[i,21] :6213
  labourPct?: number; // mSG[i,25] :6215
  labourType?: string; // mSG[i,26] :6216
  labourRate?: number; // mSG[i,27] :6217
  labourAmount?: number; // mSG[i,28] :6218
  otherAmount?: number; // mSG[i,29] :6219
  rate?: number; // mSG[i,23] :6220
  amount?: number; // mSG[i,24] :6221
  mrp?: number; // mSG[i,30] :6222
  karigarNetWt?: number; // mSG[i,44] :6226
  karigarTouch?: number; // mSG[i,47] :6227
  karigarWestPct?: number; // mSG[i,48] :6228
  karigarFine?: number; // mSG[i,49] :6229
  karigarName?: string; // mSG[i,34] :6230
  rateType?: string; // mSG[i,58] :6231
  prCode?: string; // mSG[i,61] :6233
  isuYrcd?: string; // mSG[i,37] :6235
  isuDbcd?: string; // mSG[i,38] :6236
  isuLcCode?: string; // mSG[i,42] :6238
  designImageId?: string; // mSG[i,76] :6240
  /**
   * Stone/diamond sub-detail rows for this line → APR_IDTL (TR_APR_ISU.cs:6324-6377, `DtIdtl` grid).
   * An empty sub-grid writes no rows, so omitting this writes none.
   */
  stones?: TourStoneInput[];
}

/** One APR_IDTL sub-detail row (TR_APR_ISU.cs:6355-6376, `DtIdtl.Rows[i][n]` column ordinals). */
export interface TourStoneInput extends StoneSubDetailInput {
  /** Extends the shared TblIdtl shape: stone identity plus the karigar side of its valuation. */
  isrNo?: number; // [0]  ISR_NO
  itCode?: string; // [1]  IT_CODE
  dmCode?: string; // [3]  DM_CODE
  dmName?: string; // [4]  DM_NAME
  dmSize?: string; // [5]  DM_SIZE
  dmSfNo?: string; // [6]  DM_SFNO
  pcs?: number; // [7]  IT_PCS
  grossWt?: number; // [8]  IT_GWT
  karigarWt?: number; // [9]  KR_WT
  conPct?: number; // [10] IT_CON_PRC
  rateType?: string; // [11] IT_RATE_TYPE
  rate?: number; // [12] IT_RATE
  amount?: number; // [13] IT_AMT
  lbrRate?: number; // [14] IT_LBR_RATE
  lbrAmount?: number; // [15] IT_LBR_AMT
  netAmount?: number; // [16] IT_NET_AMT
  conWt?: number; // [17] IT_CON_WT
  itType?: string; // [19] IT_TYPE
}

export interface TourIssueInput {
  scope: VoucherScope; // tenantId, coCode, lcCode, coYear, coBook
  vchDate?: Date | string;
  salesmanAc?: string; // salesman account (AC_CODE) — LookupPicker entity='accounts'
  empCode?: string; // employee code (EMP_CODE) — LookupPicker entity='employees'
  salesmanName?: string;
  vchDesc?: string;
  mainUser?: string;
  lines: TourIssueLine[];
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

const num = (v: unknown): number => (v == null ? 0 : Number(v));
/** Module-scoped so both the detail and sub-detail builders can use it; a local const was shadowed. */
const txt = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;

/** Resolve a line's fine weight: explicit fineWt, else netWt × touch / 100. */
export function tourLineFine(line: TourIssueLine): number {
  if (line.fineWt != null) return Number(line.fineWt);
  if (line.netWt != null && line.touch != null)
    return r3((Number(line.netWt) * Number(line.touch)) / 100);
  return 0;
}

function keyOf(s: VoucherScope, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'TUR',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export interface TourIssueResult {
  vchNo: number;
  fine: number;
}

/**
 * Issue goods on tour/approval in ONE transaction: allocate the voucher no, write the APR_DATA
 * header + APR_DETL lines, and a MAIN_STOCK out-movement per line (TR_TYPE 'O', ITM_SIGN '-',
 * VCH_TYPE 'TOUR', full weight/fine). No money ledger is posted (empty AC_DATA, like a tag issue);
 * postVoucherTx still validates the 0=0 balance. Returns the voucher no and total fine issued.
 */
export async function tourIssue(prisma: any, input: TourIssueInput): Promise<TourIssueResult> {
  const acCode = input.salesmanAc ?? input.empCode;
  const empCode = (input.empCode ?? '').slice(0, 3) || null; // EMP_CODE is varchar(3); never the account code
  if (!acCode)
    throw new TourValidationError('salesman/employee (salesmanAc or empCode) is required');
  if (!input.lines || input.lines.length === 0)
    throw new TourValidationError('at least one line item is required');
  // TR_TOUR_SALE.cs refuses a negative wastage percentage in these exact words.
  for (const line of input.lines) assertWestPct(line.westPct);

  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();

  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo);

    const computed = input.lines.map((l) => ({ in: l, fine: tourLineFine(l) }));
    const totalFine = r3(computed.reduce((s, c) => s + c.fine, 0));

    const header = {
      ...key,
      VCH_DATE: vchDate,
      VCH_TIME: vchDate,
      HD_VCH_NO: formatVoucherNo(vchNo),
      AC_CODE: acCode,
      EMP_CODE: empCode,
      VCH_DESC: input.vchDesc ?? null,
      // TR_APR_ISU.cs carries the ISSUE key on the approval header so a returned approval ties back to
      // the issuing book, year and location.
      ISU_LC_CODE: input.scope.lcCode,
      ISU_YRCD: input.scope.coYear ?? null,
      ISU_DBCD: input.scope.coBook ?? null,
      MAIN_USER: input.mainUser ?? null,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    };

    // APR_DETL: one row per line. Goods OUT on approval (INOUT_TYPE 'O', ISU_REC 'N' = not yet sold/returned).
    /** Desktop grid text persists trimmed and bounded by the column width; blank ⇒ null. */
    const t = (v: unknown, len: number): string | null =>
      String(v ?? '')
        .trim()
        .slice(0, len) || null;
    const detl = computed.map((c, idx) => ({
      ...key,
      VCH_DATE: vchDate,
      VCH_TIME: vchDate,
      HD_VCH_NO: formatVoucherNo(vchNo),
      AC_CODE: acCode,
      EMP_CODE: empCode,
      VCH_TYPE: 'TOUR',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'A',
      BOOK_NAME: 'EMP ISU',
      SR_NO: idx + 1,
      OLD_SRNO: idx + 1,
      VCH_SRNO: idx + 1,
      IT_CODE: c.in.itCode,
      TAG_NO: c.in.tagNo ?? 'N',
      ISU_REC: 'N',
      EMP_SALE: 'N',
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
      NET_AMT: 0,
      ITM_REMARK: c.in.remark ?? null,
      ORNA_REC_DATE: vchDate,
      // TR_APR_ISU.cs carries the hallmark ids with their weights, the colour, the loss/less-touch
      // adjustment and the tag cost on the approval detail. ADJ_GWT/ADJ_NWT/ITM_LESS_TCH/ITM_LOSS_WT are
      // varchar in the restored schema, so they are written as text rather than coerced to numbers.
      LOT_NO: txt(c.in.lotNo, 15),
      ITM_COLOR: txt(c.in.itmColor, 15),
      TAG_COST: num(c.in.tagCost),
      HM_ID2: txt(c.in.hallmarkId2, 10),
      HM_ID3: txt(c.in.hallmarkId3, 10),
      HM_ID4: txt(c.in.hallmarkId4, 10),
      HM_ID_WT: num(c.in.hallmarkIdWt),
      HM_ID2_WT: num(c.in.hallmarkId2Wt),
      HM_ID3_WT: num(c.in.hallmarkId3Wt),
      HM_ID4_WT: num(c.in.hallmarkId4Wt),
      ADJ_GWT: c.in.adjustGrossWt == null ? null : Number(c.in.adjustGrossWt),
      ADJ_NWT: c.in.adjustNetWt == null ? null : Number(c.in.adjustNetWt),
      ITM_LESS_TCH: c.in.lessTouch == null ? null : Number(c.in.lessTouch),
      ITM_LOSS_WT: c.in.lossWt == null ? null : Number(c.in.lossWt),
      MAIN_USER: input.mainUser ?? null,
      // Desktop APR_DETL grid columns (TR_APR_ISU.cs:6180-6240, `mSG[i, c]`).
      ISU_AC_NAME: t(c.in.isuAcName, 50), // mSG[i,3]  :6180
      MTL_COLOR: t(c.in.metalColor, 15), // mSG[i,12] :6182
      ISU_AC_CODE: t(c.in.isuAcCode, 10), // mSG[i,40] :6183
      TBL_CODE: t(c.in.tblCode, 3), // mSG[i,7]  :6202
      DESIGN_NO: t(c.in.designNo, 20), // mSG[i,8]  :6203
      ITM_SIZE: t(c.in.itmSize, 20), // mSG[i,9]  :6204
      HM_ID: t(c.in.huid, 10), // mSG[i,10] :6205
      BAG_WT: num(c.in.bagWt), // mSG[i,13] :6206
      ITM_OTH_WT: num(c.in.lessWt), // mSG[i,16] :6209
      ITM_GHT_WT: num(c.in.ghtWt), // mSG[i,19] :6211
      ITM_WEST_PRC: num(c.in.westPct), // mSG[i,21] :6213
      LBR_PRC: num(c.in.labourPct), // mSG[i,25] :6215
      LBR_TYPE: t(c.in.labourType, 1), // mSG[i,26] :6216
      LBR_RATE: num(c.in.labourRate), // mSG[i,27] :6217
      LBR_AMT: num(c.in.labourAmount), // mSG[i,28] :6218
      OTH_AMT: num(c.in.otherAmount), // mSG[i,29] :6219
      ITM_RATE: num(c.in.rate), // mSG[i,23] :6220
      ITM_AMT: num(c.in.amount), // mSG[i,24] :6221
      ITM_MRP: num(c.in.mrp), // mSG[i,30] :6222
      KR_NET_WT: num(c.in.karigarNetWt), // mSG[i,44] :6226
      KR_TOUCH: num(c.in.karigarTouch), // mSG[i,47] :6227
      KR_WEST_PRC: num(c.in.karigarWestPct), // mSG[i,48] :6228
      KR_FINE: num(c.in.karigarFine), // mSG[i,49] :6229
      KR_NAME: t(c.in.karigarName, 5), // mSG[i,34] :6230
      RATE_TYPE: t(c.in.rateType, 1), // mSG[i,58] :6231
      PR_CODE: t(c.in.prCode, 2), // mSG[i,61] :6233
      ISU_YRCD: t(c.in.isuYrcd, 9), // mSG[i,37] :6235
      ISU_DBCD: t(c.in.isuDbcd, 3), // mSG[i,38] :6236
      ISU_LC_CODE: t(c.in.isuLcCode, 2), // mSG[i,42] :6238
      DESIGN_IMG_ID: t(c.in.designImageId, 50), // mSG[i,76] :6240
    }));

    // APR_IDTL stone/diamond sub-detail (TR_APR_ISU.cs:6324-6377). Header-derived columns come from
    // the book and scope; the desktop writes nothing when the sub-grid is empty.
    const idtl = computed.flatMap((c, idx) =>
      (c.in.stones ?? []).map((stone, sIdx) => ({
        ...key,
        VCH_DATE: vchDate,
        VCH_TYPE: 'TOUR', // FormBookSname :6351
        INOUT_TYPE: 'O', // FormBookInOut :6352
        ENTRY_TYPE: 'A', // literal       :6353
        BOOK_NAME: 'EMP ISU', // FormMainBook  :6354
        AC_CODE: acCode, // tAcCode.Text  :6350
        SR_NO: idx + 1, // parent line   :6355
        TAG_NO: c.in.tagNo ?? 'N', // MSG[num3,5]   :6356
        VCH_SRNO: idx + 1, // MSG[num3,41]  :6357
        ISR_NO: stone.isrNo ?? sIdx + 1, // [0]  :6358
        IT_CODE: txt(stone.itCode, 10), // [1]  :6359
        DM_CODE: txt(stone.dmCode, 10), // [3]  :6360
        DM_NAME: txt(stone.dmName, 50), // [4]  :6361
        DM_SIZE: txt(stone.dmSize, 15), // [5]  :6362
        DM_SFNO: txt(stone.dmSfNo, 15), // [6]  :6363
        IT_PCS: num(stone.pcs), // [7]  :6364
        IT_GWT: num(stone.grossWt), // [8]  :6365
        KR_WT: num(stone.karigarWt), // [9]  :6366
        IT_CON_PRC: num(stone.conPct), // [10] :6367
        IT_RATE_TYPE: txt(stone.rateType, 1), // [11] :6368
        IT_RATE: num(stone.rate), // [12] :6369
        IT_AMT: num(stone.amount), // [13] :6370
        IT_LBR_RATE: num(stone.lbrRate), // [14] :6371
        IT_LBR_AMT: num(stone.lbrAmount), // [15] :6372
        IT_NET_AMT: num(stone.netAmount), // [16] :6373
        IT_CON_WT: num(stone.conWt), // [17] :6374
        // Karigar side of the same stone (the desktop's shared TblIdtl block). A job-work settlement
        // prices the stone portion from these columns.
        DM_LEB: txt(stone.dmLeb, 15),
        DM_COLOR: txt(stone.dmColor, 15),
        DM_ORIGIN: txt(stone.dmOrigin, 20),
        DM_REMARK: txt(stone.dmRemark, 20),
        IT_PCS_WT: num(stone.pcsWt),
        KR_LESS_PRC: num(stone.karigarLessPct),
        KR_CON_PRC: num(stone.karigarConPct),
        KR_CON_WT: num(stone.karigarConWt),
        KR_RATE: num(stone.karigarRate),
        KR_AMT: num(stone.karigarAmount),
        KR_LBR_RATE: num(stone.karigarLabourRate),
        KR_LBR_AMT: num(stone.karigarLabourAmount),
        KR_NET_AMT: num(stone.karigarNetAmount),
        IT_TYPE: txt(stone.itType, 1), // [19] :6375
        MAIN_USER: input.mainUser ?? null, // MainUser :6376
      })),
    );

    // MAIN_STOCK out-movement per line (TR_TYPE 'O' = tour, sign '-', full weight/fine).
    const mainStock = computed.map((c, idx) => ({
      ...key,
      SR_NO: idx + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'TOUR',
      BOOK_NAME: 'EMP ISU',
      AC_CODE: acCode,
      EMP_CODE: empCode,
      IT_CODE: c.in.itCode,
      TAG_NO: c.in.tagNo ?? 'N',
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_QTY: num(c.in.netWt) || num(c.in.pcs) || 1,
      ITM_PCS: num(c.in.pcs) || 1,
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
    }));

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] }, // no money on issue — pure inventory movement
      bookName: 'EMP ISU',
      writes: [
        { table: 'APR_DATA', rows: [header] },
        { table: 'APR_DETL', rows: detl },
        ...(idtl.length ? [{ table: 'APR_IDTL', rows: idtl }] : []),
        { table: 'MAIN_STOCK', rows: mainStock },
      ],
    });

    return { vchNo, fine: totalFine };
  });
}

export interface DeleteTourInput {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
}

/**
 * Delete/reverse a tour issue in ONE transaction: remove APR_DATA / APR_DETL / APR_IDTL and the
 * MAIN_STOCK out-movement by voucher key, and write a DELETE_DATA audit row. Goods return to stock.
 */
export async function deleteTour(prisma: any, input: DeleteTourInput): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo));
  return withTenant(prisma, tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['APR_DATA', 'APR_DETL', 'APR_IDTL', 'MAIN_STOCK'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'TOUR', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}

/** One line of goods coming back from approval (matched to an original issue line by origSrNo or item/tag). */
export interface TourReturnLine {
  origSrNo?: number;
  itCode: string;
  tagNo?: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fineWt?: number;
  remark?: string;
}
export interface TourReturnInput {
  scope: VoucherScope;
  origVchNo: number | string;
  vchDate?: Date | string;
  salesmanAc?: string;
  empCode?: string;
  salesmanName?: string;
  vchDesc?: string;
  mainUser?: string;
  lines: TourReturnLine[];
}
export interface TourReturnResult {
  vchNo: number;
  fine: number;
  closedLines: number;
}

function returnKeyOf(s: VoucherScope, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: 'TRR',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

/**
 * Tour Return / IsuRec close-loop (TR_TOUR "Tour IsuRec"): goods taken on approval come BACK unsold.
 * In ONE transaction we (1) write an APR receive voucher (book 'TRR', VCH_TYPE 'TOURR', INOUT_TYPE 'R',
 * ISU_REC 'R') linked to the original issue (OLD_VCH_NO/OLD_SRNO), (2) post a MAIN_STOCK in-movement
 * (TR_TYPE 'R', ITM_SIGN '+') bringing the goods back into stock, and (3) flip the ORIGINAL issue's
 * APR_DETL lines ISU_REC 'N'→'R' so the salesman's on-approval balance closes. No money ledger.
 * (Goods SOLD on tour are billed via the normal sale; this handles the unsold return.)
 */
export async function tourReturn(prisma: any, input: TourReturnInput): Promise<TourReturnResult> {
  if (!input.origVchNo)
    throw new TourValidationError('the original tour issue voucher (origVchNo) is required');
  if (!input.lines || input.lines.length === 0)
    throw new TourValidationError('at least one return line is required');
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const empCode = (input.empCode ?? '').slice(0, 3) || null;
  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, { ...input.scope, coBook: 'TRR' });
    const key = returnKeyOf(input.scope, vchNo);
    const computed = input.lines.map((l) => ({ in: l, fine: tourLineFine(l) }));
    const totalFine = r3(computed.reduce((s, c) => s + c.fine, 0));

    const header = {
      ...key,
      VCH_DATE: vchDate,
      VCH_TIME: vchDate,
      HD_VCH_NO: formatVoucherNo(vchNo),
      ISU_NO: formatVoucherNo(input.origVchNo),
      AC_CODE: input.salesmanAc ?? null,
      EMP_CODE: empCode,
      VCH_DESC: input.vchDesc ?? null,
      MAIN_USER: input.mainUser ?? null,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    };
    const detl = computed.map((c, idx) => ({
      ...key,
      VCH_DATE: vchDate,
      VCH_TIME: vchDate,
      HD_VCH_NO: formatVoucherNo(vchNo),
      ISU_NO: formatVoucherNo(input.origVchNo),
      ISU_SRNO: c.in.origSrNo ?? null,
      OLD_SRNO: c.in.origSrNo ?? null,
      AC_CODE: input.salesmanAc ?? null,
      EMP_CODE: empCode,
      VCH_TYPE: 'TOURR',
      INOUT_TYPE: 'R',
      ENTRY_TYPE: 'A',
      BOOK_NAME: 'EMP REC',
      SR_NO: idx + 1,
      VCH_SRNO: idx + 1,
      IT_CODE: c.in.itCode,
      TAG_NO: c.in.tagNo ?? 'N',
      ISU_REC: 'R',
      EMP_SALE: 'N',
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
      NET_AMT: 0,
      ITM_REMARK: c.in.remark ?? null,
      ORNA_REC_DATE: vchDate,
      MAIN_USER: input.mainUser ?? null,
    }));
    const mainStock = computed.map((c, idx) => ({
      ...key,
      SR_NO: idx + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'TOURR',
      BOOK_NAME: 'EMP REC',
      AC_CODE: input.salesmanAc ?? null,
      EMP_CODE: empCode,
      IT_CODE: c.in.itCode,
      TAG_NO: c.in.tagNo ?? 'N',
      TR_TYPE: 'R',
      ITM_SIGN: '+',
      ITM_QTY: num(c.in.netWt) || num(c.in.pcs) || 1,
      ITM_PCS: num(c.in.pcs) || 1,
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
    }));

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      bookName: 'EMP REC',
      writes: [
        { table: 'APR_DATA', rows: [header] },
        { table: 'APR_DETL', rows: detl },
        { table: 'MAIN_STOCK', rows: mainStock },
      ],
    });

    // close the original issue's lines
    let closedLines = 0;
    for (const c of computed) {
      const where =
        c.in.origSrNo != null
          ? {
              sql: `"CO_CODE"=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2 AND "SR_NO"=$3`,
              params: [input.scope.coCode, formatVoucherNo(input.origVchNo), c.in.origSrNo],
            }
          : {
              sql: `"CO_CODE"=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2 AND "IT_CODE"=$3 AND coalesce("TAG_NO",'N')=$4 AND coalesce("ISU_REC",'N')='N'`,
              params: [
                input.scope.coCode,
                formatVoucherNo(input.origVchNo),
                c.in.itCode,
                c.in.tagNo ?? 'N',
              ],
            };
      const n: number = await tx.$executeRawUnsafe(
        `UPDATE "APR_DETL" SET "ISU_REC"='R' WHERE ${where.sql}`,
        ...where.params,
      );
      closedLines += Number(n) || 0;
    }
    return { vchNo, fine: totalFine, closedLines };
  });
}

/** Reverse a tour return (book 'TRR'): remove its APR/MAIN_STOCK rows AND re-open the original issue lines (ISU_REC 'R'→'N'). */
export async function deleteTourReturn(
  prisma: any,
  input: DeleteTourInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = returnKeyOf(input.scope, Number(input.vchNo));
  return withTenant(prisma, tenantId, async (tx: any) => {
    const links: any[] = await tx.$queryRawUnsafe(
      `SELECT "ISU_NO" ov, "ISU_SRNO" os, "IT_CODE" it, coalesce("TAG_NO",'N') tg FROM "APR_DETL" WHERE "CO_CODE"=$1 AND "CO_BOOK"='TRR' AND "VCH_NO"=$2`,
      key.CO_CODE,
      key.VCH_NO,
    );
    await reverseVoucherTx(tx, tenantId, {
      tables: ['APR_DATA', 'APR_DETL', 'APR_IDTL', 'MAIN_STOCK'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'TOURR', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    for (const l of links) {
      if (l.os != null)
        await tx.$executeRawUnsafe(
          `UPDATE "APR_DETL" SET "ISU_REC"='N' WHERE "CO_CODE"=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2 AND "SR_NO"=$3`,
          key.CO_CODE,
          String(l.ov),
          l.os,
        );
      else
        await tx.$executeRawUnsafe(
          `UPDATE "APR_DETL" SET "ISU_REC"='N' WHERE "CO_CODE"=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2 AND "IT_CODE"=$3 AND coalesce("TAG_NO",'N')=$4`,
          key.CO_CODE,
          String(l.ov),
          l.it,
          l.tg,
        );
    }
    return { reversed: true };
  });
}

/* -------------------------------------------------- P1-14: Isu-No lines + Approval → Sale bridge -- */

/** Read an approval issue's lines (APR_DETL) for the Isu-No picker. `open` = not yet sold/returned. */
export async function tourLines(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
): Promise<
  Array<{
    srNo: number;
    itCode: string;
    tagNo: string | null;
    pcs: number;
    grossWt: number;
    netWt: number;
    touch: number;
    rate: number;
    designNo: string | null;
    open: boolean;
  }>
> {
  const book = scope.coBook ?? 'TUR';
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO" sr,"IT_CODE" it,"TAG_NO" tag, coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0)::float pcs, coalesce(NULLIF("ITM_GWT"::text,'')::numeric,0)::float gwt, coalesce(NULLIF("ITM_NWT"::text,'')::numeric,0)::float nwt, coalesce(NULLIF("ITM_TOUCH"::text,'')::numeric,0)::float touch, coalesce(NULLIF("ITM_RATE"::text,'')::numeric,0)::float rate, "DESIGN_NO" dn, coalesce("ISU_REC",'N') ir
         FROM "APR_DETL" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      scope.coCode,
      book,
      formatVoucherNo(vchNo),
    );
    return rows.map((r) => ({
      srNo: Number(r.sr),
      itCode: String(r.it ?? ''),
      tagNo: r.tag ?? null,
      pcs: Number(r.pcs),
      grossWt: Number(r.gwt),
      netWt: Number(r.nwt),
      touch: Number(r.touch),
      rate: Number(r.rate),
      designNo: r.dn ?? null,
      open: String(r.ir) !== 'Y',
    }));
  });
}

/** Mark an approval issue's open lines as BILLED (EMP_SALE='Y', ISU_REC='Y') once billed via a sale
 *  (desktop Apr-No → Sales). Records the sale reference in ITM_REMARK (no NEW_VCH_NO col on APR_DETL). */
export async function markApprovalBilled(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
  saleRef?: string,
): Promise<{ marked: number }> {
  const book = scope.coBook ?? 'TUR';
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const n: number = await tx.$executeRawUnsafe(
      `UPDATE "APR_DETL" SET "EMP_SALE"='Y', "ISU_REC"='Y', "ITM_REMARK"=$4 WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND coalesce("ISU_REC",'N')<>'Y'`,
      scope.coCode,
      book,
      formatVoucherNo(vchNo),
      `Billed: ${saleRef ?? ''}`,
    );
    return { marked: Number(n) };
  });
}
