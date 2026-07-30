import { type StoneSubDetailInput, stoneSubDetailColumns } from '../shared/stoneSubDetail.js';
import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx, type LedgerLine } from '../posting/posting.js';

/**
 * Phase 4 tag operations — Tag Cancel (TR_TAG_CAN) and Tag Weight Change (TR_TAG_WT_DIFF).
 *
 * Both write inventory movements into MAIN_STOCK (the desktop single source of stock truth), each
 * voucher reversible by its key. They follow the tagOpening footprint in stock.ts: a per-tag
 * MAIN_STOCK row built inside one tenant transaction via postVoucherTx, deleted via reverseVoucherTx.
 *
 * Tag Cancel removes a tag from stock — pure inventory OUT, no money ledger (empty AC_DATA), mirroring
 * Ac_Stock.Tag_Can_Stk (BOOK_NAME 'TAG CANCEL', ITM_SIGN '-', TR_TYPE 'O').
 *
 * Tag Weight Change books only the NET weight difference (new − old) as a stock adjustment plus a
 * balanced value ledger. The desktop (Ac_Stock.Tag_Wt_Diff_Stk + Ac_Ledr.Tag_Wt_Diff_Ledr +
 * Ac_Rojmel.Tag_Wt_Diff_Rojmel) replaces the whole tag (full OUT + full IN); this web model is the
 * simplified, equivalent net-of-difference form requested for Phase 4: one signed MAIN_STOCK movement
 * of |diff| (sign '+'/'-' per direction) and a Dr/Cr AC_DATA pair valuing the fine difference at rate.
 */

export class TagOpsError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'TagOpsError';
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

/** Coerce to number (null/undefined ⇒ 0), matching stock.ts N(). */
const N = (v: unknown): number => (v == null ? 0 : Number(v));
/** Round to 3 dp (weights/fine), matching stock.ts r3(). */
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
/** Round to 2 dp (money). */
const r2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

const CANCEL_BOOK = 'TGC'; // CO_BOOK (varchar(3)) for Tag Cancel
const WTDIFF_BOOK = 'TWD'; // CO_BOOK (varchar(3)) for Tag Weight Change
const DEFAULT_STOCK_ADJ_AC = 'STKADJ'; // stock-adjustment (inventory valuation) account
const DEFAULT_DIFF_AC = 'WTDIFF'; // weight-difference counter (P&L) account

/** Build the 5-part voucher key (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO) from scope + number. */
function keyOf(s: VoucherScope, no: number, book: string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? book,
    VCH_NO: formatVoucherNo(no),
  };
}

/* ------------------------------------------------------------------ Tag Cancel ------------------ */

/** One tag being cancelled (removed from stock). */
export interface TagCancelLine {
  /** BAG_WT / LOT_NO / TRFR_IT_CODE — recorded on the cancelled tag row (TR_TAG_CAN.cs). */
  bagWt?: number;
  lotNo?: string;
  transferItCode?: string;
  tagNo: string;
  itCode: string;
  pcs?: number;
  netWt?: number;
  grossWt?: number;
  touch?: number;
  fineWt?: number;
  /**
   * Stone/diamond sub-detail rows for this cancelled tag → BAR_CAN_IDTL
   * (TR_TAG_CAN.cs:5194-5243, `DtIdtl` grid). Empty sub-grid writes no rows.
   */
  stones?: TagCancelStoneInput[];
}

/** One BAR_CAN_IDTL sub-detail row (TR_TAG_CAN.cs:5225-5242, `DtIdtl.Rows[i][n]` ordinals). */
export interface TagCancelStoneInput extends StoneSubDetailInput {
  // Extends the shared TblIdtl shape so the stone identity and karigar valuation come from one place.
  isrNo?: number; // [0]  ISR_NO
  itCode?: string; // [1]  IT_CODE
  pcs?: number; // [2]  IT_PCS
  grossWt?: number; // [3]  IT_GWT
  karigarWt?: number; // [4]  KR_WT
  conPct?: number; // [5]  IT_CON_PRC
  rateType?: string; // [7]  IT_RATE_TYPE
  rate?: number; // [8]  IT_RATE
  amount?: number; // [9]  IT_AMT
  lbrRate?: number; // [10] IT_LBR_RATE
  lbrAmount?: number; // [11] IT_LBR_AMT
  netAmount?: number; // [12] IT_NET_AMT
  conWt?: number; // [13] IT_CON_WT
  itType?: string; // [15] IT_TYPE
}

export interface TagCancelInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  book?: string;
  lines: TagCancelLine[];
}

/**
 * Tag Cancel (TR_TAG_CAN): cancel one or more tags, removing them from stock. Per cancelled tag we
 * write a MAIN_STOCK out-movement (VCH_TYPE 'TGCAN', TR_TYPE 'O', ITM_SIGN '-', BOOK_NAME 'TAG CANCEL')
 * carrying the full weight/fine columns. No money ledger — AC_DATA lines are empty (like tagOpening).
 * Reversible by voucher key via deleteTagCancel.
 */
export async function tagCancel(
  prisma: any,
  input: TagCancelInput,
): Promise<{ vchNo: number; tags: number }> {
  if (!input.lines?.length) throw new TagOpsError('tagCancel: at least one tag line required');
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const fineOf = (l: TagCancelLine): number =>
    l.fineWt != null ? Number(l.fineWt) : r3((N(l.netWt) * N(l.touch)) / 100);
  return withTenant(prisma, tenantId, async (tx: any) => {
    // In-stock guard: only an in-stock tag can be cancelled (exists in BAR_DETL AND not already
    // sold/removed via a MAIN_STOCK '-' out-movement). Prevents cancelling a phantom or sold tag.
    for (const l of input.lines) {
      const ex: Array<{ n: number }> = await tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "BAR_DETL" WHERE "CO_CODE"::text=$1 AND "TAG_NO"::text=$2`,
        input.scope.coCode,
        String(l.tagNo),
      );
      if (!ex[0] || ex[0].n === 0)
        throw new TagOpsError(`tagCancel: tag ${l.tagNo} not found in stock (BAR_DETL)`);
      const gone: Array<{ n: number }> = await tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "MAIN_STOCK" WHERE "CO_CODE"::text=$1 AND "TAG_NO"::text=$2 AND "ITM_SIGN"::text='-'`,
        input.scope.coCode,
        String(l.tagNo),
      );
      if (gone[0] && gone[0].n > 0)
        throw new TagOpsError(`tagCancel: tag ${l.tagNo} already sold/removed — cannot cancel`);
    }
    const no = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, no, input.book ?? CANCEL_BOOK);
    const mainStock = input.lines.map((l, i) => ({
      ...key,
      SR_NO: i + 1,
      ISR_NO: 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'TGCAN',
      BOOK_NAME: 'TAG CANCEL',
      IT_CODE: l.itCode,
      TAG_NO: l.tagNo,
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_QTY: N(l.netWt) || N(l.pcs) || 1,
      ITM_PCS: N(l.pcs) || 1,
      ITM_GWT: N(l.grossWt),
      ITM_NWT: N(l.netWt),
      ITM_TOUCH: N(l.touch),
      ITM_WEST: 0,
      ITM_FINE: fineOf(l),
      KR_TOUCH: N(l.touch),
      KR_FINE: fineOf(l),
      NET_AMT: 0,
    }));
    // Cancel register (desktop BAR_CAN_DATA / BAR_CAN_DETL) — audit of every cancelled tag.
    const canHeader = {
      ...key,
      VCH_DATE: vchDate,
      VCH_TIME: vchDate,
      VCH_DESC: 'Tag cancel',
      MAIN_USER: 'system',
    };
    const txt = (v: unknown, len: number): string | null =>
      String(v ?? '')
        .trim()
        .slice(0, len) || null;
    const canDetl = input.lines.map((l, i) => ({
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'TGCAN',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'C',
      BOOK_NAME: 'TAG CANCEL',
      IT_CODE: l.itCode,
      TAG_NO: l.tagNo,
      ITM_PCS: N(l.pcs),
      ITM_GWT: N(l.grossWt),
      ITM_NWT: N(l.netWt),
      ITM_TOUCH: N(l.touch),
      ITM_FINE: fineOf(l),
      ITM_SIGN: '-',
      // TR_TAG_CAN.cs also records the bag weight, the lot the tag came from and the item code the stock
      // is transferred to when a cancelled tag is re-issued under a different item.
      BAG_WT: N(l.bagWt),
      LOT_NO: txt(l.lotNo, 15),
      TRFR_IT_CODE: txt(l.transferItCode, 255),
    }));
    // BAR_CAN_IDTL stone/diamond sub-detail (TR_TAG_CAN.cs:5194-5243). Header-derived columns come
    // from the book and scope; the desktop writes nothing when the sub-grid is empty.
    const canIdtl = input.lines.flatMap((l, i) =>
      (l.stones ?? []).map((stone, sIdx) => ({
        ...key,
        VCH_DATE: vchDate,
        VCH_TYPE: 'TGCAN', // FormBookSname :5221
        INOUT_TYPE: 'O', // FormBookInOut :5222
        ENTRY_TYPE: 'T', // literal       :5223
        BOOK_NAME: 'TAG CANCEL', // FormMainBook  :5224
        SR_NO: i + 1, // parent line   :5225
        TAG_NO: l.tagNo, // MSG[num3,1]   :5226
        VCH_SRNO: i + 1, // MSG[num3,40]  :5227
        ISR_NO: stone.isrNo ?? sIdx + 1, // [0]  :5228
        IT_CODE: txt(stone.itCode, 10), // [1]  :5229
        IT_PCS: N(stone.pcs), // [2]  :5230
        IT_GWT: N(stone.grossWt), // [3]  :5231
        KR_WT: N(stone.karigarWt), // [4]  :5232
        IT_CON_PRC: N(stone.conPct), // [5]  :5233
        IT_RATE_TYPE: txt(stone.rateType, 1), // [7]  :5234
        IT_RATE: N(stone.rate), // [8]  :5235
        IT_AMT: N(stone.amount), // [9]  :5236
        IT_LBR_RATE: N(stone.lbrRate), // [10] :5237
        IT_LBR_AMT: N(stone.lbrAmount), // [11] :5238
        IT_NET_AMT: N(stone.netAmount), // [12] :5239
        IT_CON_WT: N(stone.conWt), // [13] :5240
        IT_TYPE: txt(stone.itType, 1), // [15] :5241
        // The rest of the desktop's TblIdtl block: the stone's identity plus the KARIGAR side of its
        // valuation. Without the KR_* columns a cancelled tag's stones lose the job-work basis the
        // karigar settlement is computed from.
        ...stoneSubDetailColumns({
          dmCode: stone.dmCode,
          dmName: stone.dmName,
          dmSize: stone.dmSize,
          dmSfNo: stone.dmSfNo,
          dmColor: stone.dmColor,
          dmOrigin: stone.dmOrigin,
          dmRemark: stone.dmRemark,
          dmLeb: stone.dmLeb,
          pcsWt: stone.pcsWt,
          conPct: stone.conPct,
          conWt: stone.conWt,
          rateType: stone.rateType,
          rate: stone.rate,
          labourRate: stone.lbrRate,
          labourAmount: stone.lbrAmount,
          karigarWt: stone.karigarWt,
          karigarLessPct: stone.karigarLessPct,
          karigarConPct: stone.karigarConPct,
          karigarConWt: stone.karigarConWt,
          karigarRate: stone.karigarRate,
          karigarAmount: stone.karigarAmount,
          karigarLabourRate: stone.karigarLabourRate,
          karigarLabourAmount: stone.karigarLabourAmount,
          karigarNetAmount: stone.karigarNetAmount,
        }),
        // AC_CODE and HD_VCH_NO: a cancellation has no party, and the desktop writes the voucher's own
        // number into HD_VCH_NO on this table (TR_TAG_CAN.cs) rather than a separate hidden sequence.
        AC_CODE: null,
        HD_VCH_NO: formatVoucherNo(no),
        MAIN_USER: 'system', // MainUser :5242
      })),
    );
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] }, // pure inventory removal — no amount entry
      writes: [
        { table: 'MAIN_STOCK', rows: mainStock },
        { table: 'BAR_CAN_DATA', rows: [canHeader] },
        { table: 'BAR_CAN_DETL', rows: canDetl },
        ...(canIdtl.length ? [{ table: 'BAR_CAN_IDTL', rows: canIdtl }] : []),
      ],
    });
    return { vchNo: no, tags: input.lines.length };
  });
}

/** Delete/reverse a tag-cancel voucher (removes its MAIN_STOCK rows by voucher key). */
export async function deleteTagCancel(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
  book = CANCEL_BOOK,
): Promise<{ reversed: true }> {
  const key = keyOf(scope, Number(vchNo), book);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: ['MAIN_STOCK', 'BAR_CAN_DATA', 'BAR_CAN_DETL', 'BAR_CAN_IDTL'],
      key,
    });
    return { reversed: true };
  });
}

/* -------------------------------------------------------------- Tag Weight Change --------------- */

/** One tag whose net weight is being corrected. */
export interface TagWeightDiffLine {
  tagNo: string;
  itCode: string;
  oldNetWt?: number;
  newNetWt?: number;
  touch?: number;
  rate?: number; // fine rate used to value the weight difference
}

export interface TagWeightDiffInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  book?: string;
  stockAdjAc?: string; // stock-adjustment account (default 'STKADJ')
  diffAc?: string; // difference counter account (default 'WTDIFF')
  // P1-8: route the weight difference to a karigar PARTY (its gold sub-ledger) + optional old-gold
  // absorption + optional cash payment for the labour on the change.
  partyAc?: string; // karigar/party — receives the fine difference as a gold leg (KR_TOUCH/KR_FINE)
  absorbItCode?: string; // bulk item (e.g. old-gold) that absorbs the metal difference in stock
  absorbSign?: '+' | '-'; // absorption direction (default: opposite the tag movement)
  payAc?: string; // cash/bank paid to the karigar for the work
  payAmt?: number; // amount paid now
  labourAc?: string; // labour expense (default 'LABOUR')
  lines: TagWeightDiffLine[];
}

/**
 * Tag Weight Change (TR_TAG_WT_DIFF): book the net weight difference (newNetWt − oldNetWt) per tag.
 * For each line with a non-zero difference we write:
 *   • a MAIN_STOCK movement (VCH_TYPE 'TGWD', BOOK_NAME 'TAG WT CHANGE') of |diff| with ITM_SIGN/
 *     TR_TYPE '+'/'I' when weight increased, '-'/'O' when it decreased; ITM_FINE = |diff|·touch/100;
 *   • a balanced AC_DATA pair valuing that fine at rate (value = diffFine·rate):
 *       gain (diff>0) ⇒ Dr stock-adjust / Cr diff-account (inventory value up),
 *       loss (diff<0) ⇒ Dr diff-account / Cr stock-adjust (inventory value down).
 * Each pair self-balances, so the whole voucher satisfies Σ DR = Σ CR. Reversible via deleteTagWeightDiff.
 */
export async function tagWeightDiff(
  prisma: any,
  input: TagWeightDiffInput,
): Promise<{ vchNo: number; tags: number; diffFine: number; value: number }> {
  if (!input.lines?.length) throw new TagOpsError('tagWeightDiff: at least one tag line required');
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const stockAdjAc = input.stockAdjAc ?? DEFAULT_STOCK_ADJ_AC;
  const diffAc = input.diffAc ?? DEFAULT_DIFF_AC;

  return withTenant(prisma, tenantId, async (tx: any) => {
    const no = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, no, input.book ?? WTDIFF_BOOK);
    const useParty = !!input.partyAc;

    const mainStock: Record<string, unknown>[] = [];
    const ledger: LedgerLine[] = [];
    let totDiffFine = 0;
    let totValue = 0;

    input.lines.forEach((l, i) => {
      const diff = r3(N(l.newNetWt) - N(l.oldNetWt));
      if (diff === 0) return; // no movement for an unchanged tag
      const absDiff = Math.abs(diff);
      const up = diff > 0;
      const diffFine = r3((absDiff * N(l.touch)) / 100);
      const value = r2(diffFine * N(l.rate));
      totDiffFine += up ? diffFine : -diffFine;
      totValue += up ? value : -value;

      mainStock.push({
        ...key,
        SR_NO: i + 1,
        ISR_NO: 1,
        VCH_DATE: vchDate,
        VCH_TYPE: 'TGWD',
        BOOK_NAME: 'TAG WT CHANGE',
        IT_CODE: l.itCode,
        TAG_NO: l.tagNo,
        TR_TYPE: up ? 'I' : 'O',
        ITM_SIGN: up ? '+' : '-',
        ITM_QTY: absDiff,
        ITM_PCS: 0,
        ITM_GWT: absDiff,
        ITM_NWT: absDiff,
        ITM_TOUCH: N(l.touch),
        ITM_WEST: 0,
        ITM_FINE: diffFine,
        ITM_RATE: N(l.rate),
        KR_TOUCH: N(l.touch),
        KR_FINE: diffFine,
        NET_AMT: value,
      });

      if (useParty) {
        // Karigar PARTY gold leg (metal-only, no money): tag gained ⇒ party is owed the added fine
        // (Cr-Gold, SIGN '+'); tag lost ⇒ party gold reduces (SIGN '-'). KR_TOUCH/KR_FINE carried.
        ledger.push({
          ...key,
          VCH_TYPE: 'TGWD',
          AC_CODE: input.partyAc as string,
          IT_TYPE: 'G',
          SIGN: up ? '+' : '-',
          FINE_WT: diffFine,
          FINE_RATE: N(l.rate),
          DR_AMT: 0,
          CR_AMT: 0,
        });
        // Old-gold absorption: the metal difference moves through a bulk item so stock is conserved.
        if (input.absorbItCode) {
          const aSign = input.absorbSign ?? (up ? '-' : '+');
          mainStock.push({
            ...key,
            SR_NO: 900 + i,
            ISR_NO: 1,
            VCH_DATE: vchDate,
            VCH_TYPE: 'TGWD',
            BOOK_NAME: 'TAG WT CHANGE',
            IT_CODE: input.absorbItCode,
            TAG_NO: 'N',
            TR_TYPE: aSign === '+' ? 'I' : 'O',
            ITM_SIGN: aSign,
            ITM_QTY: absDiff,
            ITM_NWT: absDiff,
            ITM_GWT: absDiff,
            ITM_TOUCH: N(l.touch),
            ITM_FINE: diffFine,
            ITM_RATE: N(l.rate),
            NET_AMT: value,
          });
        }
      } else if (value !== 0) {
        // Legacy self-balanced value pair (no party): Dr/Cr STKADJ ↔ WTDIFF.
        const drAc = up ? stockAdjAc : diffAc;
        const crAc = up ? diffAc : stockAdjAc;
        ledger.push(
          {
            ...key,
            VCH_TYPE: 'TGWD',
            AC_CODE: drAc,
            DR_AMT: value,
            CR_AMT: 0,
            SIGN: 'D',
            FINE_WT: diffFine,
            FINE_RATE: N(l.rate),
          },
          {
            ...key,
            VCH_TYPE: 'TGWD',
            AC_CODE: crAc,
            DR_AMT: 0,
            CR_AMT: value,
            SIGN: 'C',
            FINE_WT: diffFine,
            FINE_RATE: N(l.rate),
          },
        );
      }
    });

    if (!mainStock.length)
      throw new TagOpsError('tagWeightDiff: no non-zero weight differences to post');

    // Optional cash payment to the karigar for the work (Dr labour / Cr cash-bank).
    const payAmt = r2(N(input.payAmt));
    if (useParty && payAmt > 0) {
      const labourAc = input.labourAc ?? 'LABOUR';
      const payAc = input.payAc ?? 'CASH';
      ledger.push(
        { ...key, VCH_TYPE: 'TGWD', AC_CODE: labourAc, DR_AMT: payAmt, CR_AMT: 0, SIGN: 'D' },
        { ...key, VCH_TYPE: 'TGWD', AC_CODE: payAc, DR_AMT: 0, CR_AMT: payAmt, SIGN: 'C' },
      );
    }

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [{ table: 'MAIN_STOCK', rows: mainStock }],
      bookName: 'TAG WT CHANGE',
    });
    return { vchNo: no, tags: mainStock.length, diffFine: r3(totDiffFine), value: r2(totValue) };
  });
}

/** Delete/reverse a tag-weight-change voucher (removes MAIN_STOCK + AC_DATA rows by voucher key). */
export async function deleteTagWeightDiff(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
  book = WTDIFF_BOOK,
): Promise<{ reversed: true }> {
  const key = keyOf(scope, Number(vchNo), book);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, scope.tenantId, { tables: ['MAIN_STOCK', 'AC_DATA'], key });
    return { reversed: true };
  });
}
