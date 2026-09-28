import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { nextHiddenVoucherNoTx } from '../vouchers/lifecycle.js';
import { postVoucherTx, reverseVoucherTx } from '../posting/posting.js';

/**
 * Fine In/Out (TR_FN_INOUT — pure fine-metal in/out, e.g. to/from a refinery or inter-branch).
 *
 * This is the pure-metal flavour of the desktop Branch In/Out (TR_INOUT) form: each line is a
 * weight of metal moving IN (received) or OUT (sent). Per the recovered desktop footprint we write
 *   • the voucher header  → INOUT_DATA
 *   • one detail row/line → INOUT_DETL
 *   • one MAIN_STOCK movement/line — the row that actually changes on-hand fine:
 *        IN  ⇒ TR_TYPE 'I', ITM_SIGN '+', VCH_TYPE 'FNIN'
 *        OUT ⇒ TR_TYPE 'O', ITM_SIGN '-', VCH_TYPE 'FNOUT'
 *      both stamped BOOK_NAME 'FINE INOUT'.
 * It is a pure inventory movement: NO money ledger (AC_DATA is posted empty), since INOUT_DATA only
 * carries metal/weight totals. INOUT_IDTL (tag component sub-detail) is not used by a fine movement.
 * Reversible by voucher key via {@link deleteFineInout}.
 */

export class FineInoutError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'FineInoutError';
  }
}

const num = (v: unknown): number => (v == null ? 0 : Number(v));
/** Trimmed text for a persisted column; callers turn '' into null so a blank cell stays absent. */
const text = (v: unknown): string => String(v ?? '').trim();
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;

/** A fine-metal in/out line: an item + its weights. fineWt is optional (derived if omitted). */
/**
 * A Fine In/Out line.
 *
 * P7: extended from 6 fields to the desktop's `TR_FN_INOUT` MSG grid (42 named columns) plus the
 * transfer columns `TR_INOUT` adds (47 named). The writer previously populated 16 of `INOUT_DETL`'s
 * 96 columns, so an operator could move fine metal but none of the tag identity, labour, karigar or
 * transfer-target detail the desktop records was stored.
 *
 * Every field maps to a real `INOUT_DETL` column, verified against information_schema. Desktop
 * headers are quoted on each line so the grid labels and this contract can be read together.
 */
export interface FineInoutLine {
  itCode: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fineWt?: number;
  // --- identity / description ---
  tagNo?: string; // TAG_NO
  lotNo?: string; // LOT_NO      "ItmLot"
  itemLot?: string; // ITM_LOT
  designNo?: string; // DESIGN_NO   "Design"
  tblCode?: string; // TBL_CODE    "Counter"
  itmSize?: string; // ITM_SIZE    "Size"
  itmStyle?: string; // ITM_STYLE   "Style"
  itmColor?: string; // ITM_COLOR   "Color"
  /** HM_ID "HmId". Alphanumeric HUID, so a string — never coerce it to a number. */
  hallmarkId?: string;
  remark?: string; // ITM_REMARK
  // --- weights ---
  bagWt?: number; // BAG_WT      "BagWt"
  lessWt?: number; // ITM_OTH_WT  "LsWt"
  ghtWt?: number; // ITM_GHT_WT  "GhtWt"
  westPct?: number; // ITM_WEST_PRC "West%"
  // --- money ---
  rate?: number; // ITM_RATE    "ItRate"
  amount?: number; // ITM_AMT     "ItAmt"
  labourPct?: number; // LBR_PRC     "Lbr%"
  labourType?: string; // LBR_TYPE    "LType"
  labourRate?: number; // LBR_RATE    "LbrRate"
  labourAmount?: number; // LBR_AMT     "LbrAmt"
  otherAmount?: number; // OTH_AMT     "OthAmt"
  tagCost?: number; // TAG_COST    "TagCost"
  mrp?: number; // ITM_MRP     "Mrp"
  margin?: number; // ITM_MARGIN  "Margin"
  rateType?: string; // RATE_TYPE
  // --- karigar block ---
  karigarName?: string; // KR_NAME     "KrCode"
  karigarOtherWt?: number; // KR_OTH_WT   "KrOthWt"
  karigarNetWt?: number; // KR_NET_WT   "KrNwt"
  karigarGhtPct?: number; // KR_GHT_PRC  "KrGht%"
  karigarGhtWt?: number; // KR_GHT_WT   "KrGht"
  karigarTouch?: number; // KR_TOUCH    "KrTouch"
  karigarWestPct?: number; // KR_WEST_PRC "KrWst%"
  karigarFine?: number; // KR_FINE     "KrFine"
  karigarLbrRate?: number; // KR_LBR_RATE "KrLRate"
  karigarLbrAmt?: number; // KR_LBR_AMT  "KrLAmt"
  karigarOthAmt?: number; // KR_OTH_AMT  "KrOthAmt"
  // --- transfer target: the TR_INOUT "TrfrItm" / "LCode" columns ---
  transferItCode?: string; // TO_CO_BOOK is the book; the target item rides here
  toLcCode?: string; // TO_LC_CODE  "LCode"
  // --- provenance ---
  prCode?: string; // PR_CODE     "PrCost"
  lbrCode?: string; // LBR_CODE
  designImageId?: string; // DESIGN_IMG_ID "Image"
  empIsu?: string; // EMP_ISU
}

export interface FineInoutInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  book?: string; // CO_BOOK (default 'FIO')
  direction: 'IN' | 'OUT';
  partyAc?: string; // counter-party account (refinery / branch)
  lines: FineInoutLine[];
  /**
   * The operator saving the voucher.
   *
   * A Fine In/Out moves metal between the company and a refinery or another location, and previously
   * recorded NO acting user, NO VCH_TIME and NO HD_VCH_NO — although INOUT_DATA and INOUT_DETL carry all
   * three columns. HD_VCH_NO is the hidden identity TEMP_BOOK_DATA and the day book join on.
   */
  mainUser?: string;
}

const DEFAULT_BOOK = 'FIO';
const BOOK_NAME = 'FINE INOUT';

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

function keyOf(s: VoucherScope, book: string, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: book,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

/** Pure: fine weight for a line — an explicit fineWt wins, else net × touch / 100 (Tier-1 testable). */
export function lineFine(l: FineInoutLine): number {
  return l.fineWt != null ? round3(num(l.fineWt)) : round3((num(l.netWt) * num(l.touch)) / 100);
}

/**
 * Record a Fine In/Out voucher. Allocates the next voucher number, writes INOUT_DATA + INOUT_DETL
 * and a signed MAIN_STOCK movement per line, all inside ONE tenant transaction (rolls back on any
 * failure). Returns the new voucher number and the total fine moved.
 */
export async function fineInout(
  prisma: any,
  input: FineInoutInput,
): Promise<{ vchNo: number; fine: number }> {
  if (!input.lines?.length) throw new FineInoutError('at least one line is required');
  if (input.direction !== 'IN' && input.direction !== 'OUT')
    throw new FineInoutError("direction must be 'IN' or 'OUT'");

  const tenantId = input.scope.tenantId;
  const book = input.book ?? input.scope.coBook ?? DEFAULT_BOOK;
  const isIn = input.direction === 'IN';
  const trType: 'I' | 'O' = isIn ? 'I' : 'O';
  const sign: '+' | '-' = isIn ? '+' : '-';
  const vchType = isIn ? 'FNIN' : 'FNOUT';
  const inoutType = isIn ? 'I' : 'O';
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const partyAc = input.partyAc ?? null;

  const computed = input.lines.map((l) => ({ in: l, fine: lineFine(l) }));
  const totGwt = round3(computed.reduce((s, c) => s + num(c.in.grossWt), 0));
  const totNwt = round3(computed.reduce((s, c) => s + num(c.in.netWt), 0));
  const totFine = round3(computed.reduce((s, c) => s + c.fine, 0));

  const vchNo = await withTenant(prisma, tenantId, async (tx: any) => {
    const no = await nextVoucherNoTx(tx, { ...input.scope, coBook: book });
    // The hidden series is per book, so this is allocated once the book is known.
    const hdVchNo = await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: book } as never);
    const key = keyOf(input.scope, book, no);

    const header = {
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      INOUT_TYPE: inoutType,
      ENTRY_TYPE: 'O',
      BOOK_NAME,
      AC_CODE: partyAc,
      TOT_GWT: totGwt,
      TOT_NWT: totNwt,
      TOT_FINE: totFine,
      TOT_LBR: 0,
      TOT_OTH: 0,
      TOT_NET_AMT: 0,
      STK_TRFR: 'N',
      DATA_TRFR: 'N',
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
      MAIN_USER: input.mainUser ?? null,
      HD_VCH_NO: hdVchNo,
      VCH_TIME: vchDate,
    };

    const detl = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      OLD_SRNO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      INOUT_TYPE: inoutType,
      ENTRY_TYPE: 'O',
      BOOK_NAME,
      AC_CODE: partyAc,
      IT_CODE: c.in.itCode ?? null,
      // A tagged line carries its tag; a pure fine-metal line stays 'N', which is the desktop's
      // sentinel for "no tag" and what MAIN_STOCK filters on.
      TAG_NO: text(c.in.tagNo) || 'N',
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
      DATA_TRFR: 'N',
      DATA_TYPE: 'A',
      MAIN_USER: input.mainUser ?? null,
      HD_VCH_NO: hdVchNo,
      VCH_TIME: vchDate,
      // P7: the desktop TR_FN_INOUT / TR_INOUT MSG grid, persisted. Narrow columns are sliced to
      // their real widths (RATE_TYPE/LBR_TYPE/EMP_ISU are varchar(1), PR_CODE/TO_LC_CODE varchar(2),
      // LBR_CODE varchar(4)) so an over-long operator value truncates instead of aborting the whole
      // voucher with a 22001. Text columns default to null so an
      // untouched cell is absent rather than an empty string.
      LOT_NO: text(c.in.lotNo) || null,
      ITM_LOT: text(c.in.itemLot) || null,
      DESIGN_NO: text(c.in.designNo) || null,
      TBL_CODE: text(c.in.tblCode).slice(0, 3) || null,
      ITM_SIZE: text(c.in.itmSize).slice(0, 20) || null,
      ITM_STYLE: text(c.in.itmStyle) || null,
      ITM_COLOR: text(c.in.itmColor) || null,
      // HM_ID is the alphanumeric HUID. Coercing it to a number would destroy any id with a letter,
      // which is the defect P0-06 records on the tag-opening screen.
      HM_ID: text(c.in.hallmarkId).slice(0, 15) || null,
      ITM_REMARK: text(c.in.remark) || null,
      BAG_WT: num(c.in.bagWt),
      ITM_OTH_WT: num(c.in.lessWt),
      ITM_GHT_WT: num(c.in.ghtWt),
      ITM_WEST_PRC: num(c.in.westPct),
      ITM_RATE: num(c.in.rate),
      ITM_AMT: num(c.in.amount),
      LBR_PRC: num(c.in.labourPct),
      LBR_TYPE: text(c.in.labourType).slice(0, 1) || null,
      LBR_RATE: num(c.in.labourRate),
      LBR_AMT: num(c.in.labourAmount),
      OTH_AMT: num(c.in.otherAmount),
      TAG_COST: num(c.in.tagCost),
      ITM_MRP: num(c.in.mrp),
      ITM_MARGIN: num(c.in.margin),
      RATE_TYPE: text(c.in.rateType).slice(0, 1) || null,
      KR_NAME: text(c.in.karigarName) || null,
      KR_OTH_WT: num(c.in.karigarOtherWt),
      KR_NET_WT: num(c.in.karigarNetWt),
      KR_GHT_PRC: num(c.in.karigarGhtPct),
      KR_GHT_WT: num(c.in.karigarGhtWt),
      KR_TOUCH: num(c.in.karigarTouch),
      KR_WEST_PRC: num(c.in.karigarWestPct),
      KR_FINE: num(c.in.karigarFine),
      KR_LBR_RATE: num(c.in.karigarLbrRate),
      KR_LBR_AMT: num(c.in.karigarLbrAmt),
      KR_OTH_AMT: num(c.in.karigarOthAmt),
      TO_LC_CODE: text(c.in.toLcCode).slice(0, 2) || null,
      PR_CODE: text(c.in.prCode).slice(0, 2) || null,
      LBR_CODE: text(c.in.lbrCode).slice(0, 4) || null,
      DESIGN_IMG_ID: text(c.in.designImageId) || null,
      EMP_ISU: text(c.in.empIsu).slice(0, 1) || null,
    }));

    const mainStock = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      ISR_NO: 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      BOOK_NAME,
      AC_CODE: partyAc,
      IT_CODE: c.in.itCode ?? null,
      TAG_NO: 'N',
      TR_TYPE: trType,
      ITM_SIGN: sign,
      ITM_QTY: 1,
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
      DATA_TYPE: 'A',
    }));

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] }, // pure metal movement — no money ledger
      writes: [
        { table: 'INOUT_DATA', rows: [header] },
        { table: 'INOUT_DETL', rows: detl },
        { table: 'MAIN_STOCK', rows: mainStock },
      ],
    });
    return no;
  });

  return { vchNo, fine: totFine };
}

/** Delete/reverse a Fine In/Out voucher (removes INOUT_DATA + INOUT_DETL + MAIN_STOCK by key). */
export async function deleteFineInout(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
  book = DEFAULT_BOOK,
): Promise<{ reversed: true }> {
  const key = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear ?? '',
    CO_BOOK: scope.coBook ?? book,
    VCH_NO: formatVoucherNo(vchNo),
  };
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: ['INOUT_DATA', 'INOUT_DETL', 'MAIN_STOCK'],
      key,
    });
    return { reversed: true };
  });
}
