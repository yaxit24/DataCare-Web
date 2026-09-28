import { type StoneSubDetailInput, stoneSubDetailColumns } from '../shared/stoneSubDetail.js';
import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx, type LedgerLine } from '../posting/posting.js';
import { issueTagTx, restoreTagTx, resolveLiveTagIdentityTx } from './stock.js';
import { fineFor } from '@datacare/core';

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
  /**
   * The live tag INSTANCE to cancel, when a tag number has more than one.
   *
   * A tag number is not unique on its own: `BAR_DETL` keys an instance by `TAG_NO + VCH_SRNO`, and the
   * resolver treats an ambiguous number as an error rather than picking one. Supplying this selects the
   * intended instance; omitting it is fine when only one is live.
   */
  vchSrno?: number;
  pcs?: number;
  netWt?: number;
  grossWt?: number;
  /** ITM_GHT_WT — part of the fine base under the shared tag policy. */
  ghtWt?: number;
  touch?: number;
  /** ITM_WEST_PRC — added to touch in the fine base, as every other voucher family does. */
  westPct?: number;
  fineWt?: number;
  /**
   * P6: the rest of the desktop `TR_TAG_CAN` MSG grid (45 named columns). The writer populated 17 of
   * `BAR_CAN_DETL`'s 76 columns, so the cancel register recorded far less than the tag it cancels —
   * the "omits required source and sub-detail lineage" half of the containment rule.
   *
   * Every field maps to a real BAR_CAN_DETL column, verified against information_schema.
   */
  tagLot?: string; // ITM_LOT      "TagLot"
  designNo?: string; // DESIGN_NO    "Design"
  tblCode?: string; // TBL_CODE     "Counter"
  itmSize?: string; // ITM_SIZE     "Size"
  itmStyle?: string; // ITM_STYLE
  itmColor?: string; // ITM_COLOR
  itmPolish?: string; // ITM_POLISH
  itDesc?: string; // IT_DESC
  remark?: string; // ITM_REMARK
  /** HM_ID — alphanumeric HUID, so a string. Never coerce it to a number. */
  hallmarkId?: string;
  lessWt?: number; // ITM_OTH_WT   "LsWt"
  itemType?: string; // IT_TYPE      "Type"
  labourPct?: number; // LBR_PRC      "Lbr%"
  labourType?: string; // LBR_TYPE     "LType"
  labourRate?: number; // LBR_RATE     "LbrRate"
  labourAmount?: number; // LBR_AMT      "LbrAmt"
  otherAmount?: number; // OTH_AMT      "OthAmt"
  mrp?: number; // ITM_MRP      "Mrp"
  rate?: number; // ITM_RATE     "ItRate"
  amount?: number; // ITM_AMT      "ItAmt"
  tagCost?: number; // TAG_COST     "TagCost"
  tagNetWt?: number; // TAG_NWT
  rateType?: string; // RATE_TYPE
  prCode?: string; // PR_CODE      "PrCost"
  karigarName?: string; // KR_NAME      "KrCode"
  karigarNetWt?: number; // KR_NET_WT    "KrNwt"
  karigarTouch?: number; // KR_TOUCH     "KrTouch"
  karigarWestPct?: number; // KR_WEST_PRC  "KrWst%"
  karigarFine?: number; // KR_FINE      "KrFine"
  designImageId?: string; // DESIGN_IMG_ID "Image"
  toTblCode?: string; // TO_TBL_CODE
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
    l.fineWt != null
      ? Number(l.fineWt)
      : fineFor('tagOpening', {
          netWt: N(l.netWt),
          ghtWt: N(l.ghtWt),
          touch: N(l.touch),
          westPct: N(l.westPct),
        });
  return withTenant(prisma, tenantId, async (tx: any) => {
    /**
     * P6/WP-09 — resolve ONE LIVE SERIAL IDENTITY per line, under the shared resolver.
     *
     * What this replaces was the first defect named in the containment rule. It ran two count queries:
     *   SELECT count(*) FROM BAR_DETL  WHERE CO_CODE=$1 AND TAG_NO=$2
     *   SELECT count(*) FROM MAIN_STOCK WHERE CO_CODE=$1 AND TAG_NO=$2 AND ITM_SIGN='-'
     * Both were wrong in ways that matter:
     *   • no LC_CODE, so a tag belonging to ANOTHER LOCATION satisfied the guard;
     *   • no VCH_SRNO, so it counted any historical row for that tag number rather than the one live
     *     instance — "historical availability instead of one live serial identity", verbatim;
     *   • the sign test asked whether a '-' movement EVER existed, so a tag sold and later returned
     *     (the return posts '+') could not be cancelled even though it is in stock, while a tag with
     *     several instances could be cancelled on the strength of a different instance's movement.
     *
     * `issueTagTx` is the same path a sale uses. It nets the MAIN_STOCK signs per instance and requires
     * a positive balance, excludes employee-issued tags, holds an advisory lock on the identity, and
     * throws TagNotAvailableError / TagIdentityAmbiguousValidationError rather than guessing. Reusing it
     * means a cancel cannot disagree with a sale about what "in stock" means.
     */
    const identities = [] as Array<{ TAG_NO: string; VCH_SRNO: number; IT_CODE: string }>;
    for (const l of input.lines) {
      const identity = await issueTagTx(tx, {
        CO_CODE: input.scope.coCode,
        LC_CODE: input.scope.lcCode,
        TAG_NO: String(l.tagNo),
        IT_CODE: l.itCode ? String(l.itCode) : undefined,
        VCH_SRNO: l.vchSrno != null ? Number(l.vchSrno) : undefined,
      } as never);
      identities.push({
        TAG_NO: identity.TAG_NO,
        VCH_SRNO: Number(identity.VCH_SRNO ?? 0),
        IT_CODE: String(identity.IT_CODE ?? l.itCode ?? ''),
      });
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
      IT_CODE: identities[i]!.IT_CODE || l.itCode,
      TAG_NO: identities[i]!.TAG_NO,
      // The resolved instance, so the out-movement nets against the SAME row the resolver matched.
      // Without it a multi-instance tag could be cancelled while its stock stayed positive.
      VCH_SRNO: identities[i]!.VCH_SRNO,
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_QTY: 1,
      ITM_PCS: N(l.pcs) || 1,
      ITM_GWT: N(l.grossWt),
      ITM_NWT: N(l.netWt),
      ITM_TOUCH: N(l.touch),
      // Wastage now travels rather than being hard-coded to 0: it is part of the fine base for every
      // other voucher family, so zeroing it here made a cancel disagree with the tag it reverses.
      ITM_WEST: N(l.westPct),
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
      // P6: the rest of the desktop MSG grid. This register is the audit trail for a cancelled tag, so
      // recording 17 of 76 columns meant the evidence of WHAT was cancelled was thinner than the tag
      // itself — the "omits required source and sub-detail lineage" clause of the containment rule.
      //
      // The resolved serial identity is stamped here too: without VCH_SRNO the register cannot say which
      // instance of a repeated tag number was cancelled.
      VCH_SRNO: identities[i]!.VCH_SRNO,
      ITM_LOT: txt(l.tagLot, 15),
      DESIGN_NO: txt(l.designNo, 255),
      TBL_CODE: txt(l.tblCode, 3),
      ITM_SIZE: txt(l.itmSize, 20),
      ITM_STYLE: txt(l.itmStyle, 255),
      ITM_COLOR: txt(l.itmColor, 255),
      ITM_POLISH: txt(l.itmPolish, 255),
      IT_DESC: txt(l.itDesc, 50),
      ITM_REMARK: txt(l.remark, 255),
      // HM_ID is the alphanumeric HUID; a Number() coercion here would destroy any id with a letter.
      HM_ID: txt(l.hallmarkId, 15),
      ITM_OTH_WT: N(l.lessWt),
      ITM_GHT_WT: N(l.ghtWt),
      ITM_WEST_PRC: N(l.westPct),
      IT_TYPE: txt(l.itemType, 1),
      LBR_PRC: N(l.labourPct),
      LBR_TYPE: txt(l.labourType, 1),
      LBR_RATE: N(l.labourRate),
      LBR_AMT: N(l.labourAmount),
      OTH_AMT: N(l.otherAmount),
      ITM_MRP: N(l.mrp),
      ITM_RATE: N(l.rate),
      ITM_AMT: N(l.amount),
      TAG_COST: N(l.tagCost),
      TAG_NWT: N(l.tagNetWt),
      RATE_TYPE: txt(l.rateType, 1),
      PR_CODE: txt(l.prCode, 2),
      KR_NAME: txt(l.karigarName, 255),
      KR_NET_WT: N(l.karigarNetWt),
      KR_TOUCH: N(l.karigarTouch),
      KR_WEST_PRC: N(l.karigarWestPct),
      KR_FINE: N(l.karigarFine),
      DESIGN_IMG_ID: txt(l.designImageId, 255),
      TO_TBL_CODE: txt(l.toTblCode, 3),
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
    /**
     * P6/WP-09 — restore the tags this cancel consumed, or deleting a cancel LOSES them.
     *
     * `tagCancel` resolves each line through `issueTagTx`, which DELETES the `TAG_STOCK` row when the
     * tag lives there. Reversing only `MAIN_STOCK` and the register therefore restored availability for
     * a tag backed by `BAR_DETL` (because `availableBarTags` nets the signs, and removing the '-' makes
     * the net positive again) but left a TAG_STOCK-only tag permanently gone: not in TAG_STOCK, not in
     * BAR_DETL, so invisible to every availability query.
     *
     * This mirrors the sale reversal (`sales.ts:2017-2042`): read what was consumed, and restore only
     * the tags that BAR_DETL cannot vouch for. Restoring a BAR_DETL-backed tag as well would duplicate
     * it into TAG_STOCK and make the same tag issuable twice.
     *
     * The read must happen BEFORE `reverseVoucherTx`, which deletes the register rows it reads from.
     */
    const consumed: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT"
         FROM "BAR_CAN_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6
          AND NULLIF(btrim(coalesce("TAG_NO"::text,'')),'') IS NOT NULL
          AND "TAG_NO"::text <> 'N'`,
      scope.tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_YEAR,
      key.CO_BOOK,
      key.VCH_NO,
    );

    const restores: Array<Record<string, unknown>> = [];
    for (const tag of consumed) {
      const inBar: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "BAR_DETL"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"::text=$4
            AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)`,
        scope.tenantId,
        key.CO_CODE,
        key.LC_CODE,
        String(tag.TAG_NO ?? ''),
        Number(tag.VCH_SRNO ?? 0),
      );
      if (Number(inBar[0]?.n ?? 0) === 0) {
        restores.push({
          CO_CODE: key.CO_CODE,
          LC_CODE: key.LC_CODE,
          TAG_NO: String(tag.TAG_NO ?? ''),
          VCH_SRNO: Number(tag.VCH_SRNO ?? 0),
          // TAG_STOCK has IT_TYPE, not IT_CODE — insertTagTx rejects unknown columns by design, so a
          // stray key aborts the whole reversal rather than being ignored.
          ITM_PCS: tag.ITM_PCS,
          ITM_GWT: tag.ITM_GWT,
          ITM_NWT: tag.ITM_NWT,
          STK_TYPE: 'R',
        });
      }
    }

    await reverseVoucherTx(tx, scope.tenantId, {
      tables: ['MAIN_STOCK', 'BAR_CAN_DATA', 'BAR_CAN_DETL', 'BAR_CAN_IDTL'],
      key,
    });
    for (const tag of restores) await restoreTagTx(tx, scope.tenantId, tag as never);
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
  /**
   * The live tag INSTANCE whose weight is changing, when a tag number has more than one.
   *
   * `BAR_DETL` keys an instance by TAG_NO + VCH_SRNO and the resolver treats an ambiguous number as an
   * error rather than picking one, so this selects the intended instance.
   */
  vchSrno?: number;
  /** ITM_WEST_PRC — part of the fine base, as in every other voucher family. */
  westPct?: number;
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

    /**
     * P6/WP-09 — resolve the LIVE tag instance before adjusting its weight.
     *
     * This path previously never looked the tag up at all: it wrote a MAIN_STOCK movement keyed on
     * TAG_NO alone, so it would happily adjust a tag that does not exist, one belonging to another
     * location, or one already sold. It also stamped no VCH_SRNO, so the movement did not net against
     * any particular instance of a repeated tag number.
     *
     * `resolveLiveTagIdentityTx` is the resolver a sale uses — LC_CODE-scoped, per-instance, netting the
     * MAIN_STOCK signs. Note it RESOLVES without consuming: a weight change does not remove the tag from
     * stock, so `issueTagTx` (which deletes the TAG_STOCK row) would be wrong here. That distinction is
     * why this calls the resolver directly rather than reusing the cancel path.
     */
    const identities = new Map<number, { VCH_SRNO: number; IT_CODE: string }>();
    for (let i = 0; i < input.lines.length; i += 1) {
      const l = input.lines[i]!;
      if (r3(N(l.newNetWt) - N(l.oldNetWt)) === 0) continue; // unchanged tag: nothing to resolve
      const identity = await resolveLiveTagIdentityTx(tx, {
        CO_CODE: input.scope.coCode,
        LC_CODE: input.scope.lcCode,
        TAG_NO: String(l.tagNo),
        IT_CODE: l.itCode ? String(l.itCode) : undefined,
        VCH_SRNO: l.vchSrno != null ? Number(l.vchSrno) : undefined,
      } as never);
      identities.set(i, {
        VCH_SRNO: Number(identity.VCH_SRNO ?? 0),
        IT_CODE: String(identity.IT_CODE ?? l.itCode ?? ''),
      });
    }

    const mainStock: Record<string, unknown>[] = [];
    const ledger: LedgerLine[] = [];
    let totDiffFine = 0;
    let totValue = 0;

    input.lines.forEach((l, i) => {
      const diff = r3(N(l.newNetWt) - N(l.oldNetWt));
      if (diff === 0) return; // no movement for an unchanged tag
      const absDiff = Math.abs(diff);
      const up = diff > 0;
      // Fine goes through the shared desktop policy so a weight change agrees with the tag it adjusts,
      // rather than using a local netWt x touch / 100 that ignores wastage.
      const diffFine = fineFor('tagOpening', {
        netWt: absDiff,
        touch: N(l.touch),
        westPct: N(l.westPct),
      });
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
        IT_CODE: identities.get(i)?.IT_CODE || l.itCode,
        TAG_NO: l.tagNo,
        // The resolved instance: without it the movement nets against no particular tag row.
        VCH_SRNO: identities.get(i)?.VCH_SRNO ?? 0,
        TR_TYPE: up ? 'I' : 'O',
        ITM_SIGN: up ? '+' : '-',
        ITM_QTY: absDiff,
        ITM_PCS: 0,
        ITM_GWT: absDiff,
        ITM_NWT: absDiff,
        ITM_TOUCH: N(l.touch),
        // Wastage travels rather than being hard-coded to 0, matching every other voucher family.
        ITM_WEST: N(l.westPct),
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
